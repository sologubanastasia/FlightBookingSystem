using AutoMapper;
using FlightApp.Application.Dto;
using FlightApp.Application.Interfaces;
using FlightApp.Domain.Entities;
using FlightApp.Domain.Interfaces;

namespace FlightApp.Application.Services;

public class BookingsService : IBookingService
{
    private readonly IBookingRepository _bookingRepository;
    private readonly IFlightRepository _flightRepository;
    private readonly ISeatRepository _seatRepository;
    private readonly IMapper _mapper;

    public BookingsService(
        IBookingRepository bookingRepository,
        IFlightRepository flightRepository,
        ISeatRepository seatRepository,
        IMapper mapper)
    {
        _bookingRepository = bookingRepository;
        _flightRepository = flightRepository;
        _seatRepository = seatRepository;
        _mapper = mapper;
    }

    public async Task<BookingDto> CreateBookingAsync(CreateBookingDto dto, Guid userId)
    {
        var flight = await _flightRepository.GetByIdAsync(dto.FlightId);
        if (flight == null) throw new ArgumentException("Flight not found");

        var seat = await _seatRepository.GetByIdAsync(dto.SeatId);
        if (seat == null || seat.FlightId != dto.FlightId || !seat.IsAvailable)
            throw new ArgumentException("Seat is not available");

        var booking = new Booking
        {
            Id = Guid.NewGuid(),
            FlightId = dto.FlightId,
            SeatId = dto.SeatId,
            UserId = userId,
            BookingDate = DateTime.UtcNow,
            Status = "Confirmed"
        };

        seat.IsAvailable = false;
        await _seatRepository.UpdateAsync(seat);
        
        var createdBooking = await _bookingRepository.AddAsync(booking);
        return _mapper.Map<BookingDto>(createdBooking);
    }

    public async Task<IEnumerable<BookingDto>> GetUserBookingsAsync(Guid userId)
    {
        var bookings = await _bookingRepository.GetByUserIdAsync(userId);
        return _mapper.Map<IEnumerable<BookingDto>>(bookings);
    }

    public async Task<bool> CancelBookingAsync(Guid bookingId)
    {
        var booking = await _bookingRepository.GetByIdAsync(bookingId);
        if (booking == null) return false;

        var seat = await _seatRepository.GetByIdAsync(booking.SeatId);
        if (seat != null)
        {
            seat.IsAvailable = true;
            await _seatRepository.UpdateAsync(seat);
        }

        return await _bookingRepository.DeleteAsync(bookingId);
    }
}