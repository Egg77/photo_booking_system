using System;
using photo_booking_system.Models;
using photo_booking_system.Dto;

namespace photo_booking_system.Services
{
    public interface IBookingService
    {
        public Task<Booking> GetBookingAsync<T>(int BookingID);
        public Task<List<Booking>> GetBookingListAsync<T>();
        public Task CreateBookingAsync(BookingCreationDto bookingCreationDto);
        public Task UpdateBookingAsync(int BookingId, BookingUpdateDto bookingUpdateDto);
        public Task DeleteBookingAsync(int BookingId);
    }
}