using System;
namespace photo_booking_system.Migrations
{
	public interface IDatabase
	{
        public void CreateDatabase(string dbName);

    }
}