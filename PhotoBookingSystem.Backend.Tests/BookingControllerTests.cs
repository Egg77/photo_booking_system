using System;
using Moq;
using Xunit;
using Microsoft.AspNetCore.Mvc;

using photo_booking_system.Controllers;
using photo_booking_system.Services;
using photo_booking_system.Providers;
using photo_booking_system.Models;
using photo_booking_system.Dto;

namespace photo_booking_system.Backend.Tests
{
    public class BookingControllerTests
    {
        private BookingController _bookingController;
        private Mock<IBookingService> _mockBookingService;
        private Mock<ISQLConnectionProvider> _mockSqlConnectionProvider;


        private BookingCreationDto testCreationDto =  new BookingCreationDto() { ClientName = "test1", ClientEmail = "test@test.test", ClientPhone = "123-456-7890", StartDateTime = System.DateTime.Now, EndDateTime = System.DateTime.Now, Comments = "blah", Photo = 30, Video = 0, Price = 100, Paid = 0};
        private BookingUpdateDto testUpdateDto = new BookingUpdateDto() { ClientName = "test1", ClientEmail = "test@test.test", ClientPhone = "123-456-7890", StartDateTime = System.DateTime.Now, EndDateTime = System.DateTime.Now, Comments = "blah", Photo = 30, Video = 0, Price = 100, Paid = 0 };
        Booking mockBooking = new Booking();
        List<Booking> mockBookingList = new List<Booking>();
        private int validId = 1;
        private int invalidId = 0;
        private int nonExistingId = 1234;


        public BookingControllerTests()
        {
            _mockBookingService = new Mock<IBookingService>();
            _mockSqlConnectionProvider = new Mock<ISQLConnectionProvider>();
            _bookingController = new BookingController(_mockBookingService.Object, _mockSqlConnectionProvider.Object);
        }

        //Get

        [Fact]
        public async void GetBookingList_ReturnsOk_Async()
        {
            _mockBookingService.Setup(x => x.GetBookingListAsync<Booking>()).ReturnsAsync(mockBookingList);

            var response = await _bookingController.GetBookingList();

            Assert.NotNull(response);
            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public async void GetBooking_ValidID_ReturnsOk_Async()
        {
            _mockBookingService.Setup(x => x.GetBookingAsync<Booking>(validId)).ReturnsAsync(mockBooking);

            var response = await _bookingController.GetBooking(validId);

            Assert.NotNull(response);
            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public async void GetBooking_IDLessThanOrEqualToZero_ReturnsBadRequest_Async()
        {
            var response = await _bookingController.GetBooking(invalidId);

            Assert.NotNull(response);
            Assert.IsType<BadRequestObjectResult>(response);
        }

        [Fact]
        public async void GetBooking_IDNotFound_ReturnsNotFound_Async()
        {
            _mockBookingService.Setup(x => x.GetBookingAsync<Booking>(nonExistingId));

            var response = await _bookingController.GetBooking(nonExistingId);

            Assert.NotNull(response);
            Assert.IsType<NotFoundResult>(response);
        }

        //Create

        [Fact]
        public async void Create_ValidData_ReturnsOk_Async()
        {
            _mockBookingService.Setup(x => x.CreateBookingAsync(It.IsAny<BookingCreationDto>())).ReturnsAsync(true);

            var response = await _bookingController.CreateBooking(testCreationDto);

            Assert.NotNull(response);
            Assert.IsType<OkResult>(response);
        }

        [Fact]
        public async void Create_NullBooking_ReturnsInternalServerError_Async()
        {
            bool? test = null;
            _mockBookingService.Setup(x => x.CreateBookingAsync(testCreationDto)).ReturnsAsync(test);

            var response = await _bookingController.CreateBooking(testCreationDto);

            Assert.NotNull(response);
            Assert.IsType<StatusCodeResult>(response);
        }

        //Update

        [Fact]
        public async void Update_ValidData_ReturnsOk_Async()
        {
            _mockBookingService.Setup(x => x.UpdateBookingAsync(1, It.IsAny<BookingUpdateDto>())).ReturnsAsync(true);

            var response = await _bookingController.UpdateBooking(1, testUpdateDto);

            Assert.NotNull(response);
            Assert.IsType<OkResult>(response);
        }

        [Fact]
        public async void Update_NullBooking_ReturnsInternalServerError_Async()
        {
            bool? test = null;
            _mockBookingService.Setup(x => x.UpdateBookingAsync(1, testUpdateDto)).ReturnsAsync(test);

            var response = await _bookingController.UpdateBooking(1, testUpdateDto);

            Assert.NotNull(response);
            Assert.IsType<StatusCodeResult>(response);
        }

        [Fact]
        public async void Update_IDLessThanOrErqualToZero_ReturnsBadRequest_Async()
        {
            var response = await _bookingController.UpdateBooking(invalidId, testUpdateDto);

            Assert.NotNull(response);
            Assert.IsType<BadRequestObjectResult>(response);
        }

        [Fact]
        public async void Update_IDNotFound_ReturnsNotFound()
        {
            _mockBookingService.Setup(x => x.UpdateBookingAsync(nonExistingId, testUpdateDto)).ReturnsAsync(false);

            var response = await _bookingController.UpdateBooking(nonExistingId, testUpdateDto);

            Assert.NotNull(response);
            Assert.IsType<NotFoundResult>(response);
        }

        //Delete

        [Fact]
        public async void Delete_ValidId_ReturnsOk_Async()
        {
            _mockBookingService.Setup(x => x.DeleteBookingAsync(validId)).ReturnsAsync(true);

            var response = await _bookingController.DeleteBooking(validId);

            Assert.NotNull(response);
            Assert.IsType<OkResult>(response);
        }

        [Fact]
        public async void Delete_IDLessThanOrEqualToZero_ReturnsBadRequest_Async()
        {
            var response = await _bookingController.GetBooking(invalidId);

            Assert.NotNull(response);
            Assert.IsType<BadRequestObjectResult>(response);
        }

        [Fact]
        public async void Delete_IDNotFound_ReturnsNotFound()
        {
            _mockBookingService.Setup(x => x.DeleteBookingAsync(nonExistingId)).ReturnsAsync(false);

            var response = await _bookingController.DeleteBooking(nonExistingId);

            Assert.NotNull(response);
            Assert.IsType<NotFoundResult>(response);
        }
    }
}

