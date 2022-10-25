using System;
using System.Data;
using Microsoft.Data.SqlClient;
using Dapper;

using photo_booking_system.Models;
using photo_booking_system.Dto;

namespace photo_booking_system.Providers
{
    public class SQLConnectionProvider : ISQLConnectionProvider
    {
        private readonly static string connectionString = "Data Source=localhost;TrustServerCertificate=True;Initial Catalog=PhotoBookingDB;User Id=sa; Password=someThingComplicated1234";


        public async Task<IDbConnection> GetConnectionAsync()
        {

            int connectionAttempts = 0;
            while (connectionAttempts < 2)
            {
                try
                {
                    connectionAttempts++;
                    var connection = new SqlConnection(connectionString);
                    await connection.OpenAsync().ConfigureAwait(false);
                    return connection;
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + ex.StackTrace);
                    throw;
                }
            }
            return null;
        }

        public async Task<Booking> GetBooking<T>(int BookingId)
        {
            try
            {
                var query = "select * from Bookings where BookingId = @BookingID";

                var connection = await GetConnectionAsync();
                return await connection.QueryFirstOrDefaultAsync<Booking>(query, new { BookingId }).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex + ex.StackTrace);
                throw;
            }
        }

        public async Task<List<T>> GetBookingList<T>()
        {
            try
            {
                var query = "select * from Bookings";

                var connection = await GetConnectionAsync();
                var result = await connection.QueryAsync<T>(query).ConfigureAwait(false);
                return result.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex + ex.StackTrace);
                return null;
            }

            
        }

        public async Task<bool?> CreateBooking(BookingCreationDto Booking)
        {
            try
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

                var connection = await GetConnectionAsync();
                var created = await connection.ExecuteAsync(query, parameters).ConfigureAwait(false);

                if (created < 1)
                    return false;
                else
                    return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex + ex.StackTrace);
                return null;
            }


        }

        public async Task<bool?> UpdateBooking(int BookingId, BookingUpdateDto Booking)
        {
            try
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

                var connection = await GetConnectionAsync();
                var updated = await connection.ExecuteAsync(query, parameters).ConfigureAwait(false);

                if (updated < 1)
                    return false;
                else
                    return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex + ex.StackTrace);
                return null;
            }

        }

        public async Task<bool?> DeleteBooking(int BookingId)
        {
            try
            {
                var query = "delete from Bookings where BookingId = @BookingId";

                var connection = await GetConnectionAsync();
                var deleted = await connection.ExecuteAsync(query, new { BookingId }).ConfigureAwait(false);

                if (deleted < 1)
                    return false;
                else
                    return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex + ex.StackTrace);
                return null;
            }

        }
    }
}