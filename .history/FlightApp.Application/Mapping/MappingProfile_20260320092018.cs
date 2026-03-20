using AutoMapper;
using FlightApp.Domain.Entities;
using FlightApp.Application.Dto.Flight;
using FlightApp.Application.Dto.Booking;
using FlightApp.Application.Dto.Seat;
namespace FlightApp.Application.Mapper;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Flight, FlightDto>();
        CreateMap<CreateFlightDto, Flight>();
        CreateMap<UpdateFlightDto, Flight>();

        CreateMap<Seat, SeatDto>();

        // 3. Мапінг для Booking (найскладніший)
        CreateMap<Booking, BookingDto>()
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
            // Цей рядок каже: візьми всі BookingSeats, витягни з них Seat і змап їх у SeatDto
            .ForMember(dest => dest.Seats, opt => opt.MapFrom(src => src.BookingSeats.Select(bs => bs.Seat)));

        // 4. Мапінг для створення бронювання
        CreateMap<CreateBookingDto, Booking>()
            .ForMember(dest => dest.BookingSeats, opt => opt.Ignore()); // Місця додаються вручну в сервісі
    }
}