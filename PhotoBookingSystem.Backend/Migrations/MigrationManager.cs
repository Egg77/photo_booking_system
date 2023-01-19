using System;
using FluentMigrator.Runner;
using Microsoft.Extensions.Hosting;
using PhotoBookingSystem.Backend.Migrations;

namespace photo_booking_system.Migrations
{
	public static class MigrationManager
	{
		public static IHost MigrateDatabase(this IHost host)
		{
            using (var scope = host.Services.CreateScope())
            {
                var databaseService = scope.ServiceProvider.GetRequiredService<IDatabase>();
                var migrationService = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();

                try
                {
                    //databaseService.CreateDatabase("PhotoBookingDB");

                    migrationService.ListMigrations();
                    migrationService.MigrateUp(2022110901); //Create Table
                    migrationService.MigrateUp(2022110902); //Populate table with initial seed data
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

