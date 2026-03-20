using AutoMapper;
using FlightApp.Application.Dto;
using FlightApp.Application.Interfaces;
using FlightApp.Domain.Entities;
using FlightApp.Domain.Interfaces;

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
        var seats = (await _seatRepo.GetByIdsAsync(dto.SeatIds)).ToList();

        foreach (var seat in seats)
        {
            if (seat.IsAvailable == false)
            {
                throw new Exception("Seat already ");
            }
        }

        // 3. Створюємо об'єкт бронювання
        var booking = new Booking
        {
            Id = Guid.NewGuid(),
            UserId = userId,
            FlightId = dto.FlightId,
            BookingDate = DateTime.UtcNow,
            Status = "Confirmed",
            BookingSeats = new List<BookingSeat>() // створюємо порожній список для зв'язків
        };

        // 4. Оновлюємо кожне місце і додаємо його до бронювання
        foreach (var seat in seats)
        {
            seat.IsAvailable = false; // місце тепер зайняте
            
            var connection = new BookingSeat 
            { 
                BookingId = booking.Id, 
                SeatId = seat.Id 
            };
            
            booking.BookingSeats.Add(connection);
        }

        // 5. Зберігаємо зміни
        await _bookingRepo.AddAsync(booking);
        _seatRepo.UpdateRange(seats); 
        await _bookingRepo.SaveChangesAsync();

        // 6. Повертаємо результат через Маппер
        return _mapper.Map<BookingDto>(booking);
    }

    public async Task<IEnumerable<BookingDto>> GetUserBookingsAsync(Guid userId)
    {
        var bookings = await _bookingRepo.GetUserBookingsAsync(userId);
        return _mapper.Map<IEnumerable<BookingDto>>(bookings);
    }

    public async Task CancelBookingAsync(Guid bookingId, Guid userId)
    {
        // 1. Знаходимо бронювання
        var booking = await _bookingRepo.GetByIdAsync(bookingId);

        // 2. Перевіряємо, чи воно існує і чи воно наше
        if (booking == null)
        {
            throw new Exception("Бронювання не знайдено.");
        }

        if (booking.UserId != userId)
        {
            throw new Exception("Ви не можете видалити чуже бронювання!");
        }

        // 3. Робимо всі місця знову вільними
        foreach (var item in booking.BookingSeats)
        {
            if (item.Seat != null)
            {
                item.Seat.IsAvailable = true;
            }
        }

        // 4. Видаляємо і зберігаємо
        _bookingRepo.Delete(booking);
        await _bookingRepo.SaveChangesAsync();
    }
}