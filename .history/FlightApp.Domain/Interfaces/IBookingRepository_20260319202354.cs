namespace FlightApp.Domain.Interfaces
{
    public interface IBookingRepository
    {
        Task<IEnumerable<Booking>> GetBookingsByUserId(Guid userId)
    }
}