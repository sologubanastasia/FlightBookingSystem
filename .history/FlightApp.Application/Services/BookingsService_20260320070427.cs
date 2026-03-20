using FlightApp.Application.Interfaces;
using FlightApp.Application.Dto.Booking;
using FlightApp.Domain.Entities;
using AutoMapper;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace FlightApp.Application.Services
{
    public class BookingsService : IBookingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BookingsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookingDto>> GetUsersBookingsAsync(string userId)
        {
            var bookings = await _unitOfWork.Bookings.GetByUserIdAsync(userId);
            return _mapper.Map<IEnumerable<BookingDto>>(bookings);
        }

        public async Task<BookingDto> CreateBookingAsync(string userId, CreateBookingDto dto)
        {
            var booking = _mapper.Map<Booking>(dto);
            booking.UserId = userId;
            
            await _unitOfWork.Bookings.AddAsync(booking);
            await _unitOfWork.CompleteAsync();
            
            return _mapper.Map<BookingDto>(booking);
        }

        public async Task CancelBookingAsync(string userId, Guid bookingId)
        {
            var booking = await _unitOfWork.Bookings.GetByIdAsync(bookingId);
            if (booking != null && booking.UserId == userId)
            {
                _unitOfWork.Bookings.Remove(booking);
                await _unitOfWork.CompleteAsync();
            }
        }
    }
}