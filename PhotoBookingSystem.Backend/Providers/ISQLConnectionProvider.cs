using System;
using System.Data;

namespace photo_booking_system.Providers
{
    public interface ISQLConnectionProvider
    {
        Task<IDbConnection> GetConnectionAsync();
    }
}

