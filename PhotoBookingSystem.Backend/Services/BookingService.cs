using System;
using System.Data;
using photo_booking_system.Models;
using photo_booking_system.Providers;
using Dapper;
using photo_booking_system.Dto;

namespace photo_booking_system.Services
{
    public class BookingService : IBookingService
    {
        private readonly ISQLConnectionProvider _SQLConnectionProvider;

        public BookingService(ISQLConnectionProvider sQLConnectionProvider)
        {
            _SQLConnectionProvider = sQLConnectionProvider;
             
        }

        public async Task<Booking> GetBookingAsync<T>(int BookingId)
        {
            var query = "select * from Bookings where BookingId = @BookingID";

            var connection = await _SQLConnectionProvider.GetConnectionAsync();
            var result = await connection.QuerySingleOrDefaultAsync<Booking>(query, new {BookingId}).ConfigureAwait(false);
            return (Booking)result;
        }

        public async Task<List<T>> GetBookingListAsync<T>()
        {
            var query = "select * from Bookings";

            var connection = await _SQLConnectionProvider.GetConnectionAsync();
            var result = await connection.QueryAsync<T>(query).ConfigureAwait(false);
            return result.ToList();
        }

        public async Task CreateBooking(BookingCreationDto Booking)
        {
            var query = "insert into Bookings (ClientName, ClientEmail, ClientPhone, StartDateTime, EndDateTime, Photo, Video, Comments, Price, Paid) values (@ClientName, @ClientEmail, @ClientPhone, @StartDateTime, @EndDateTime, @Photo, @Video, @Comments, @Price, @Paid)";
            var parameters = new DynamicParameters();

            parameters.Add("ClientName", Booking.ClientName, DbType.String);
            parameters.Add("ClientEmail", Booking.ClientEmail, DbType.String);
            parameters.Add("ClientPhone", Booking.ClientPhone, DbType.String);
            parameters.Add("StartDateTime", Booking.StartDateTime, DbType.DateTime);
            parameters.Add("EndDateTime", Booking.EndDateTime, DbType.DateTime);
            parameters.Add("Photo", Booking.Photo, DbType.Int16);
            parameters.Add("Video", Booking.Video, DbType.Int16);
            parameters.Add("Comments", Booking.Comments, DbType.String);
            parameters.Add("Price", Booking.Price, DbType.Currency);
            parameters.Add("Paid", Booking.Paid, DbType.Boolean);

            var connection = await _SQLConnectionProvider.GetConnectionAsync();
            await connection.ExecuteAsync(query, parameters).ConfigureAwait(false);
        }

        public async Task UpdateBooking(int BookingId, BookingUpdateDto Booking)
        {
            var query = "update Bookings set ClientName = @ClientName, ClientEmail = @ClientEmail, ClientPhone = @ClientPhone, StartDateTime = @StartDateTime, EndDateTime = @EndDateTime, Photo = @Photo, Video = @Video, Comments = @Comments, Price = @Price, Paid = @Paid where BookingId = @BookingId";
            var parameters = new DynamicParameters();

            parameters.Add("BookingId", BookingId, DbType.Int32);
            parameters.Add("ClientName", Booking.ClientName, DbType.String);
            parameters.Add("ClientEmail", Booking.ClientEmail, DbType.String);
            parameters.Add("ClientPhone", Booking.ClientPhone, DbType.String);
            parameters.Add("StartDateTime", Booking.StartDateTime, DbType.DateTime);
            parameters.Add("EndDateTime", Booking.EndDateTime, DbType.DateTime);
            parameters.Add("Photo", Booking.Photo, DbType.Int16);
            parameters.Add("Video", Booking.Video, DbType.Int16);
            parameters.Add("Comments", Booking.Comments, DbType.String);
            parameters.Add("Price", Booking.Price, DbType.Currency);
            parameters.Add("Paid", Booking.Paid, DbType.Boolean);

            var connection = await _SQLConnectionProvider.GetConnectionAsync();
            await connection.ExecuteAsync(query, parameters).ConfigureAwait(false);
        }

        public async Task DeleteBooking(int BookingId)
        {
            var query = "delete from Bookings where BookingId = @BookingId";

            var connection = await _SQLConnectionProvider.GetConnectionAsync();
            await connection.ExecuteAsync(query, new { BookingId }).ConfigureAwait(false);
        }
    }
}