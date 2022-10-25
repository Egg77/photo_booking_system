using System;
using photo_booking_system.Models;
using photo_booking_system.Dto;

namespace photo_booking_system.Services
{
    public interface IBookingService
    {
        public Task<Booking> GetBookingAsync<T>(int BookingID);
        public Task<List<Booking>> GetBookingListAsync<T>();
        public Task<bool?> CreateBookingAsync(BookingCreationDto bookingCreationDto);
        public Task<bool?> UpdateBookingAsync(int BookingId, BookingUpdateDto bookingUpdateDto);
        public Task<bool?> DeleteBookingAsync(int BookingId);
    }
}