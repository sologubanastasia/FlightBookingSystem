using FlightApp.Domain.Entities;
using FlightApp.Application.Dto;
using AutoMapper;
using System.Runtime.CompilerServices;

namespace FlightApp.Application.Mapper
{
    public class MappingProfile : ProfileOptimization
    {
        CreateMap<Flight, FlightDto>();
    }
}