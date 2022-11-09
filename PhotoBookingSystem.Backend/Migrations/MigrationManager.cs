using System;
using FluentMigrator.Runner;
using Microsoft.Extensions.Hosting;

namespace photo_booking_system.Migrations
{
	public static class MigrationManager
	{
		public static IHost MigrateDatabase(this IHost host)
		{
            using (var scope = host.Services.CreateScope())
            {
                var databaseService = scope.ServiceProvider.GetRequiredService<IDatabase>();
                //var migrationService = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();

                try
                {
                    databaseService.CreateDatabase("PhotoBookingDB");

                    //migrationService.ListMigrations();
                    //migrationService.MigrateDown(202106280001);
                }
                catch
                {
                    throw;
                }
            }

            return host;
        }
	}
}

