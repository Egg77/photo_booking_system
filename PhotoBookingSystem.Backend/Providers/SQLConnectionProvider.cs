using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace photo_booking_system.Providers
{
    public class SQLConnectionProvider : ISQLConnectionProvider
    {

        private readonly static string connectionString = "Data Source=localhost;TrustServerCertificate=True;Initial Catalog=PhotoBookingDB;User Id=sa; Password=someThingComplicated1234";

        public SQLConnectionProvider()
        {
        }

        public async Task<IDbConnection> GetConnectionAsync()
        {

            int connectionAttempts = 0;

            while (connectionAttempts < 2)
            {
                connectionAttempts++;
                var connection = new SqlConnection(connectionString);

                try
                {
                    await connection.OpenAsync().ConfigureAwait(false);
                    Console.WriteLine("Connected to database...");
                    return connection;
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + ex.StackTrace);
                }
            }
           
            return null;

        }
    }
}

