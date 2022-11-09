using System;
using photo_booking_system.Providers;
using Dapper;

namespace photo_booking_system.Migrations
{
    public class Database : IDatabase
	{
        private readonly ISQLConnectionProvider _SQLConnectionProvider;

        public Database(ISQLConnectionProvider sQLConnectionProvider)
		{
			_SQLConnectionProvider = sQLConnectionProvider;
		}

		public void  CreateDatabase (string dbName)
		{
			var query = "select * from sys.databases where name = @name";
			var parameters = new DynamicParameters();
			parameters.Add("name", dbName);

			var connection = _SQLConnectionProvider.CreateMasterConnection();
			
            var records = connection.Query(query, parameters);

            if (!records.Any())
				connection.Execute($"create database {dbName}");
        }
	}
}