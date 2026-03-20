using FlightApp.Application.Dto.Booking;
using FlightApp.Application.Interfaces;
using FlightApp.Domain.Entities;
using FlightApp.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace FlightApp.Application.Services;

public class BookingService : IBookingService
{
    private readonly IBookingRepository _bookingRepo;
    private readonly ISeatRepository _seatRepo;
    private readonly IMapper _mapper;

    public BookingService(IBookingRepository bookingRepo, ISeatRepository seatRepo, IMapper mapper)
    {
        _bookingRepo = bookingRepo;
        _seatRepo = seatRepo;
        _mapper = mapper;
    }

    public async Task<BookingDto> CreateBookingAsync(Guid userId, CreateBookingDto dto)
    {
        var seats = (await _seatRepo.GetByIdsAsync(dto.Seats)).ToList();

        foreach (var seat in seats)
        {
            if (!seat.IsAvailable)
            {
                throw new Exception("Seat has already been booked");
            }
        }

        var booking = new Booking
        {
            Id = Guid.NewGuid(),
            UserId = userId,
            FlightId = dto.FlightId,
            BookingDate = DateTime.UtcNow,
            Status = Status.Confirmed,
            BookingSeats = new List<BookingSeat>() 
        };

        foreach (var seat in seats)
        {
            seat.IsAvailable = false; 
            
            var connection = new BookingSeat 
            { 
                BookingId = booking.Id, 
                SeatId = seat.Id,
                Seat = seat 
            };
            
            booking.BookingSeats.Add(connection);
        }

        await _bookingRepo.AddAsync(booking);


        await _bookingRepo.SaveChangesAsync();

        return _mapper.Map<BookingDto>(booking);
    }

    public async Task<IEnumerable<BookingDto>> GetUserBookingsAsync(Guid userId)
    {
        var bookings = await _bookingRepo.GetUserBookingsAsync(userId);
        return _mapper.Map<IEnumerable<BookingDto>>(bookings);
    }

    public async Task<bool> CancelBookingAsync(Guid bookingId, Guid userId)
    {
        var booking = await _bookingRepo.GetByIdAsync(bookingId);

        if (booking == null)
        {
            throw new Exception("Booking not found");
        }

        if (booking.UserId != userId)
        {
            throw new Exception("Access denied: You cannot delete this booking.");
        }

        foreach (var item in booking.BookingSeats)
        {
            if (item.Seat != null)
            {
                item.Seat.IsAvailable = true;
                await _seatRepo.UpdateAsync(item.Seat);
            }
        }

        _bookingRepo.Delete(booking);
        await _bookingRepo.SaveChangesAsync();
        
        return true;
    }
}