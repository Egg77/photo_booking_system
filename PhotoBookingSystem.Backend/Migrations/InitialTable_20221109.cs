using System;
using FluentMigrator;
using FluentMigrator.SqlServer;

namespace photo_booking_system.Migrations
{
	[Migration(2022110901)]
	public class InitialTable_20221109 : Migration
    {
		public override void Down()
		{
            Delete.Table("Bookings");
		}

        public override void Up()
        {
            Create.Table("Bookings")
                .WithColumn("BookingId").AsInt32().NotNullable().PrimaryKey().Identity(1,1)
                .WithColumn("ClientName").AsString(50).NotNullable()
                .WithColumn("ClientEmail").AsString(50).NotNullable()
                .WithColumn("ClientPhone").AsString(20).NotNullable()
                .WithColumn("StartDateTime").AsDateTime().NotNullable()
                .WithColumn("EndDateTime").AsDateTime().NotNullable()
                .WithColumn("Photo").AsInt32()
                .WithColumn("Video").AsInt32()
                .WithColumn("Comments").AsString(500)
                .WithColumn("Price").AsCurrency()
                .WithColumn("Paid").AsInt16(); //AsBit() doesn't seem to be a thing...
        }
    }
}



/*
 *BookingId int IDENTITY(1,1) NOT NULL PRIMARY KEY,
 ClientName nvarchar(50) NOT NULL,
 ClientEmail nvarchar(50) NOT NULL,
 ClientPhone nvarchar(20) NOT NULL,
 StartDateTime datetime NOT NULL,
 EndDateTime datetime NOT NULL,
 Photo int,
 Video int,
 Comments nvarchar(500),
 Price money,
 Paid bit
*/