IF OBJECT_ID('dbo.Bookings', 'U') IS NOT NULL
 DROP TABLE dbo.Bookings;
GO

CREATE TABLE dbo.Bookings
(
 BookingId int IDENTITY(1,1) NOT NULL PRIMARY KEY, -- primary key column
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
);
GO