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

        private Mock<IBookingService> _mockBookingService;
        private Mock<ISQLConnectionProvider> _mockSqlConnectionProvider;

        private BookingController _bookingController;

        private BookingCreationDto testCreationDto =  new BookingCreationDto() { ClientName = "test1", ClientEmail = "test@test.test", ClientPhone = "123-456-7890", StartDateTime = System.DateTime.Now, EndDateTime = System.DateTime.Now, Comments = "blah", Photo = 30, Video = 0, Price = 100, Paid = 0};

        private BookingUpdateDto testUpdateDto = new BookingUpdateDto() { ClientName = "test1", ClientEmail = "test@test.test", ClientPhone = "123-456-7890", StartDateTime = System.DateTime.Now, EndDateTime = System.DateTime.Now, Comments = "blah", Photo = 30, Video = 0, Price = 100, Paid = 0 };

        public BookingControllerTests()
        {
            _mockBookingService = new Mock<IBookingService>();
            _mockSqlConnectionProvider = new Mock<ISQLConnectionProvider>();

            _bookingController = new BookingController(_mockBookingService.Object, _mockSqlConnectionProvider.Object);
        }

        //TODO: Write test methods

        //TODO: Something is up with the get tests. The "OK" and "NotFound" tests aren't quite working. The "OK" one is returning OK successfully, but the retrieved Booking object is just blank. It should match what's in the database. Along those lines, the "NotFound" test is returning "OK" as well (should be returning NotFound). In both cases, when testing directly with Swagger, the expected OK and NotFound results are successfully occurring.

        [Fact]
        public async void GetBooking_ValidID_ReturnsOk_Async()
        {
            int validId = 1;
            _mockBookingService.Setup(x => x.GetBookingAsync<Booking>(validId)).ReturnsAsync(new Booking());
            var response = await _bookingController.GetBooking(validId);

            Assert.NotNull(response);
            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public async void GetBooking_IDLessThanOrEqualToZero_ReturnsBadRequest_Async()
        {
            int invalidId = 0;
            _mockBookingService.Setup(x => x.GetBookingAsync<Booking>(invalidId)).ReturnsAsync(new Booking());
            var response = await _bookingController.GetBooking(invalidId);

            Assert.NotNull(response);
            Assert.IsType<BadRequestObjectResult>(response);

        }

        [Fact]
        public async void GetBooking_IDNotFound_ReturnsNotFound_Async()
        {
            int nonExistingId = 1234;
            _mockBookingService.Setup(x => x.GetBookingAsync<Booking>(nonExistingId)).ReturnsAsync(new Booking());
            var response = await _bookingController.GetBooking(nonExistingId);

            Assert.NotNull(response);
            Assert.IsType<NotFoundObjectResult>(response);


        }

        [Fact]
        public async void Create_ValidData_ReturnsOk_Async()
        {
            //TODO: Test is passing but the database isn't creating a new entry....

            _mockBookingService.Setup(x => x.CreateBookingAsync(It.IsAny<BookingCreationDto>())).ReturnsAsync(true);

            var response = await _bookingController.CreateBooking(testCreationDto);

            Assert.NotNull(response);
            Assert.IsType<OkResult>(response);

        }

        [Fact]
        public async void Create_InvalidData_ReturnsBadRequest_ASync()
        {

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

        [Fact]
        public async void Update_ValidData_ReturnsOk_Async()
        {
            //TODO: Test is passing but the database isn't updating the entry....

            _mockBookingService.Setup(x => x.UpdateBookingAsync(1, It.IsAny<BookingUpdateDto>())).ReturnsAsync(true);

            var response = await _bookingController.UpdateBooking(1, testUpdateDto);

            Assert.NotNull(response);
            Assert.IsType<OkResult>(response);
        }

        [Fact]
        public async void Update_InvalidData_ReturnsBadRequest_ASync()
        {

        }

        [Fact]
        public async void Update_NullBooking_ReturnsInternalServerError_Async()
        {
            bool? test = null;
            _mockBookingService.Setup(x => x.UpdateBookingAsync(1, testUpdateDto)).ReturnsAsync(test);

            var response = await _bookingController.UpdateBooking(1, testUpdateDto);

            Assert.IsType<StatusCodeResult>(response);
        }

        //[Fact]
        //public async void Delete_ValidId_ReturnsOk_Async()
        //{

        //}

        //[Fact]
        //public async void Delete_IDLessThanOrEqualToZero_ReturnsBadRequest_Async()
        //{

        //}

        //[Fact]
        //public async void Delete_IdNotFound_ReturnsNotFound_Async()
        //{

        //}

        //Create and Update Tests



    }
}

