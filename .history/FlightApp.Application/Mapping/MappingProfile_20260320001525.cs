using FlightApp.Domain.Entities;
using FlightApp.Application.Dto.Flight;
using FlightApp.Application.Dto.;
using AutoMapper;

namespace FlightApp.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public void MapppingProfile()
        {
            CreateMap<Flight, FlightDto>();
            CreateMap<Seat, SeatDto>();
            CreateMap<Booking, BookingDto>();

            CreateMap<CreateFlightDto, Flight>();
            CreateMap<CreateBookingDto, Bookings>();
        }
    }
}