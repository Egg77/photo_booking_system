USE master
GO
IF NOT EXISTS (
 SELECT name
 FROM sys.databases
 WHERE name = N'PhotoBookingDB'
)
 CREATE DATABASE [PhotoBookingDB];
GO
IF SERVERPROPERTY('ProductVersion') > '12'
 ALTER DATABASE [PhotoBookingDB] SET QUERY_STORE=ON;
GO