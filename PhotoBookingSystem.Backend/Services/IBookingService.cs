using System;
using photo_booking_system.Models;
using photo_booking_system.Dto;

namespace photo_booking_system.Services
{
    public interface IBookingService
    {
        public Task<List<T>> GetBookingListAsync<T>();
        public Task<Booking> GetBookingAsync<T>(int BookingID);
        public Task CreateBooking(BookingCreationDto bookingCreationDto);
        public Task UpdateBooking(int BookingId, BookingUpdateDto bookingUpdateDto);
        public Task DeleteBooking(int BookingId);
    }
}