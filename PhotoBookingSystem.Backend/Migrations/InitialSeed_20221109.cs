using System;
using FluentMigrator;
using FluentMigrator.SqlServer;
using photo_booking_system.Dto;

namespace PhotoBookingSystem.Backend.Migrations
{
    [Migration(2022110902)]
    public class InitialSeed_20221109 : Migration
	{
		public override void Down()
		{
            throw new NotImplementedException();
		}

		public override void Up()
		{
			Insert.IntoTable("Bookings")
				.Row(new BookingCreationDto
				{
					ClientName = "Vincent",
					ClientEmail = "vincent@company.com",
					ClientPhone = "123-456-7890",
					StartDateTime = System.DateTime.Now,
					EndDateTime = System.DateTime.Now.AddHours(1),
					Photo = 30,
					Video = 0,
					Comments = "Nah",
					Price = 110,
					Paid = 0
				});

            Insert.IntoTable("Bookings")
                .Row(new BookingCreationDto
                {
                    ClientName = "Don",
                    ClientEmail = "don@company.com",
                    ClientPhone = "123-456-7890",
                    StartDateTime = System.DateTime.Now,
                    EndDateTime = System.DateTime.Now.AddHours(1),
                    Photo = 45,
                    Video = 0,
                    Comments = "...",
                    Price = 150,
                    Paid = 0
                });

            Insert.IntoTable("Bookings")
                .Row(new BookingCreationDto
                {
                    ClientName = "Sarah",
                    ClientEmail = "sarah@company.com",
                    ClientPhone = "123-456-7890",
                    StartDateTime = System.DateTime.Now,
                    EndDateTime = System.DateTime.Now.AddHours(1),
                    Photo = 30,
                    Video = 0,
                    Comments = "",
                    Price = 110,
                    Paid = 0
                });

            Insert.IntoTable("Bookings")
                .Row(new BookingCreationDto
                {
                    ClientName = "Karen",
                    ClientEmail = "karen@company.com",
                    ClientPhone = "123-456-7890",
                    StartDateTime = System.DateTime.Now,
                    EndDateTime = System.DateTime.Now.AddHours(1),
                    Photo = 30,
                    Video = 0,
                    Comments = ":)",
                    Price = 110,
                    Paid = 0
                });

            Insert.IntoTable("Bookings")
                .Row(new BookingCreationDto
                {
                    ClientName = "Godwin",
                    ClientEmail = "godwin@company.com",
                    ClientPhone = "123-456-7890",
                    StartDateTime = System.DateTime.Now,
                    EndDateTime = System.DateTime.Now.AddHours(1),
                    Photo = 30,
                    Video = 0,
                    Comments = "Plz Patrick",
                    Price = 110,
                    Paid = 0
                });

            Insert.IntoTable("Bookings")
                .Row(new BookingCreationDto
                {
                    ClientName = "Morris",
                    ClientEmail = "morris@company.com",
                    ClientPhone = "123-456-7890",
                    StartDateTime = System.DateTime.Now,
                    EndDateTime = System.DateTime.Now.AddHours(1),
                    Photo = 30,
                    Video = 0,
                    Comments = ">|",
                    Price = 110,
                    Paid = 0
                });

            Insert.IntoTable("Bookings")
                .Row(new BookingCreationDto
                {
                    ClientName = "Naseem",
                    ClientEmail = "naseem@company.com",
                    ClientPhone = "123-456-7890",
                    StartDateTime = System.DateTime.Now,
                    EndDateTime = System.DateTime.Now.AddHours(1),
                    Photo = 30,
                    Video = 0,
                    Comments = "Wide as possible",
                    Price = 110,
                    Paid = 0
                });

            Insert.IntoTable("Bookings")
                .Row(new BookingCreationDto
                {
                    ClientName = "Rachel",
                    ClientEmail = "rachel@company.com",
                    ClientPhone = "123-456-7890",
                    StartDateTime = System.DateTime.Now,
                    EndDateTime = System.DateTime.Now.AddHours(1),
                    Photo = 30,
                    Video = 0,
                    Comments = "",
                    Price = 110,
                    Paid = 1
                });

            Insert.IntoTable("Bookings")
                .Row(new BookingCreationDto
                {
                    ClientName = "Judit",
                    ClientEmail = "judit@company.com",
                    ClientPhone = "123-456-7890",
                    StartDateTime = System.DateTime.Now,
                    EndDateTime = System.DateTime.Now.AddHours(1),
                    Photo = 40,
                    Video = 0,
                    Comments = "Many photos please",
                    Price = 150,
                    Paid = 1
                });
        }
	}
}
