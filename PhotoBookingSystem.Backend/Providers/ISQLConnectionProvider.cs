using System;
using System.Data;
using photo_booking_system.Dto;
using photo_booking_system.Models;

namespace photo_booking_system.Providers
{
    public interface ISQLConnectionProvider
    {
        public Task<IDbConnection> GetConnectionAsync();

        public Task<Booking> GetBooking<T>(int BookingId);

        public Task<List<T>> GetBookingList<T>();

        public Task<bool?> CreateBooking(BookingCreationDto Booking);

        public Task<bool?> UpdateBooking(int BookingId, BookingUpdateDto Booking);

        public Task<bool?> DeleteBooking(int BookingId);

        public IDbConnection CreateMasterConnection();
    }
}