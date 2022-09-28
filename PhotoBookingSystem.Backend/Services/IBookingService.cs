using System;
using photo_booking_system.Models;

namespace photo_booking_system.Services
{
    public interface IBookingService
    {
        public Task<List<T>> GetBookingListAsync<T>();
        public Task<Booking> GetBookingAsync<T>(int BookingID);
    }
}

