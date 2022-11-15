using System;
using Moq;
using Microsoft.AspNetCore.Mvc;

using photo_booking_system.Controllers;
using photo_booking_system.Services;
using photo_booking_system.Providers;
using photo_booking_system.Models;
using photo_booking_system.Dto;

namespace photo_booking_system.Backend.Tests
{
    public class BookingServiceTests
    {
        private BookingService _mockBookingService;
    
        private Mock<ISQLConnectionProvider> _mockSqlConnectionProvider;

        private BookingCreationDto testCreationDto = new BookingCreationDto() { ClientName = "test1", ClientEmail = "test@test.test", ClientPhone = "123-456-7890", StartDateTime = System.DateTime.Now, EndDateTime = System.DateTime.Now, Comments = "blah", Photo = 30, Video = 2, Price = 100, Paid = 0 };
        private BookingUpdateDto testUpdateDto = new BookingUpdateDto() { ClientName = "test1", ClientEmail = "test@test.test", ClientPhone = "123-456-7890", StartDateTime = System.DateTime.Now, EndDateTime = System.DateTime.Now, Comments = "blah", Photo = 30, Video = 2, Price = 100, Paid = 0 };
        Booking mockBooking = new Booking();
        List<Booking> mockBookingList = new List<Booking>();
        private int validId = 1;
        private int invalidId = 0;
        private int nonExistingId = 1234;

        public BookingServiceTests()
        {
            _mockSqlConnectionProvider = new Mock<ISQLConnectionProvider>();
            _mockBookingService = new BookingService(_mockSqlConnectionProvider.Object);
        }

        //Get

        [Fact]
        public async Task GetBookingAsync_ReturnsBooking()
        {
            _mockSqlConnectionProvider.Setup(x => x.GetBooking<Booking>(validId)).ReturnsAsync(mockBooking);

            var response = await _mockBookingService.GetBookingAsync<Booking>(validId);

            Assert.NotNull(response);
            Assert.IsType<Booking>(response);
        }

        [Fact]
        public async Task GetBookingListAsync_ReturnsBookingList()
        {
            _mockSqlConnectionProvider.Setup(x => x.GetBookingList<Booking>()).ReturnsAsync(mockBookingList);

            var response = await _mockBookingService.GetBookingListAsync<List<Booking>>();

            Assert.NotNull(response);
            Assert.IsType<List<Booking>>(response);
        }

        //Create

        [Fact]
        public async Task CreateBooking_ReturnsTrue()
        {
            _mockSqlConnectionProvider.Setup(x => x.CreateBooking(testCreationDto)).ReturnsAsync(true);

            var response = await _mockBookingService.CreateBookingAsync(testCreationDto);

            Assert.NotNull(response);
            Assert.True(response);
        }

        [Fact]
        public async Task CreateBooking_ReturnsFalse()
        {
            _mockSqlConnectionProvider.Setup(x => x.CreateBooking(testCreationDto)).ReturnsAsync(false);

            var response = await _mockBookingService.CreateBookingAsync(testCreationDto);

            Assert.NotNull(response);
            Assert.False(response);
        }


        //Update

        [Fact]
        public async Task UpdateBooking_ReturnsTrue()
        {
            _mockSqlConnectionProvider.Setup(x => x.UpdateBooking(validId, testUpdateDto)).ReturnsAsync(true);

            var response = await _mockBookingService.UpdateBookingAsync(validId, testUpdateDto);

            Assert.NotNull(response);
            Assert.True(response);
        }

        [Fact]
        public async Task UpdateBooking_ReturnsFalse()
        {
            _mockSqlConnectionProvider.Setup(x => x.UpdateBooking(validId, testUpdateDto)).ReturnsAsync(false);

            var response = await _mockBookingService.UpdateBookingAsync(validId, testUpdateDto);

            Assert.NotNull(response);
            Assert.False(response);
        }


        //Delete

        [Fact]
        public async Task DeleteBooking_ReturnsTrue()
        {
            _mockSqlConnectionProvider.Setup(x => x.DeleteBooking(validId)).ReturnsAsync(true);

            var response = await _mockBookingService.DeleteBookingAsync(validId);

            Assert.NotNull(response);
            Assert.True(response);
        }

        [Fact]
        public async Task DeleteBooking_ReturnsFalse()
        {
            _mockSqlConnectionProvider.Setup(x => x.DeleteBooking(validId)).ReturnsAsync(false);

            var response = await _mockBookingService.DeleteBookingAsync(validId);

            Assert.NotNull(response);
            Assert.False(response);
        }

        //Calculate Price

        [Fact]
        public void CalculatePrice_ReturnsCorrectPrice_Creation()
        {
            int correctPrice = 190;

            _mockBookingService.CalculatePrice(testCreationDto);

            var result = testCreationDto;

            Assert.Equal(correctPrice, result.Price);

        }


        //Update Price

        [Fact]
        public void CalculatePrice_ReturnsCorrectPrice_Update()
        {
            int correctPrice = 190;

            _mockBookingService.CalculatePrice(testUpdateDto);

            var result = testUpdateDto;

            Assert.Equal(correctPrice, result.Price);
        }

    }
}