using FlightApp.Application.Mapper;
using FlightApp.Application.Interfaces;
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
        // 1. Отримуємо вибрані місця
        var seats = (await _seatRepo.GetByIdsAsync(dto.SeatIds)).ToList();

        // 2. Перевірка: чи всі місця вільні?
        if (seats.Any(s => !s.IsAvailable))
            throw new Exception("One or more seats are already booked.");

        // 3. Створюємо бронювання
        var booking = new Booking
        {
            Id = Guid.NewGuid(),
            UserId = userId,
            FlightId = dto.FlightId,
            BookingDate = DateTime.UtcNow,
            Status = "Confirmed"
        };

        // 4. Додаємо зв'язки та міняємо статус місць
        foreach (var seat in seats)
        {
            seat.IsAvailable = false;
            booking.BookingSeats.Add(new BookingSeat { 
                BookingId = booking.Id, 
                SeatId = seat.Id 
            });
        }

        await _bookingRepo.AddAsync(booking);
        _seatRepo.UpdateRange(seats); 
        await _bookingRepo.SaveChangesAsync();

        return _mapper.Map<BookingDto>(booking);
    }

    public async Task<IEnumerable<BookingDto>> GetUserBookingsAsync(Guid userId)
    {
        var bookings = await _bookingRepo.GetUserBookingsAsync(userId);
        return _mapper.Map<IEnumerable<BookingDto>>(bookings);
    }

    public async Task CancelBookingAsync(Guid bookingId, Guid userId)
    {
        var booking = await _bookingRepo.GetByIdAsync(bookingId);

        if (booking == null || booking.UserId != userId)
            throw new Exception("Booking not found or access denied.");

        var seatIds = booking.BookingSeats.Select(bs => bs.SeatId);
        var seats = await _seatRepo.GetByIdsAsync(seatIds);
        
        foreach (var seat in seats)
        {
            seat.IsAvailable = true;
        }

        _seatRepo.UpdateRange(seats);
        _bookingRepo.Delete(booking);
        await _bookingRepo.SaveChangesAsync();
    }
}