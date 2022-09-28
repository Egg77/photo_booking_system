using System;
using photo_booking_system.Models;
using photo_booking_system.Providers;
using Dapper;

namespace photo_booking_system.Services
{
    public class BookingService : IBookingService
    {
        private readonly ISQLConnectionProvider _SQLConnectionProvider;

        public BookingService(ISQLConnectionProvider sQLConnectionProvider)
        {
            _SQLConnectionProvider = sQLConnectionProvider;
             
        }

        public async Task<Booking> GetBookingAsync<T>(int BookingID)
        {
            var query = "select * from Bookings where BookingId = @BookingID";

            var connection = await _SQLConnectionProvider.GetConnectionAsync();
            var result = await connection.QuerySingleOrDefaultAsync<Booking>(query, new {BookingID}).ConfigureAwait(false);
            return (Booking)result;
        }

        public async Task<List<T>> GetBookingListAsync<T>()
        {
            var query = "select * from Bookings";

            var connection = await _SQLConnectionProvider.GetConnectionAsync();
            var result = await connection.QueryAsync<T>(query).ConfigureAwait(false);
            return result.ToList();
        }
    }
}

