using System;
using Microsoft.AspNetCore.Mvc;
using photo_booking_system.Models;
using photo_booking_system.Services;
using photo_booking_system.Providers;
using photo_booking_system.Dto;
using photo_booking_system.ActionFilters;

namespace photo_booking_system.Controllers 
{

    [ApiController]
    [Route ("[controller]")]
    public class BookingController : ControllerBase 
    {

        private IBookingService _BookingService;
        private ISQLConnectionProvider _SQLConnectionProvider;

        public BookingController(IBookingService bookingService, ISQLConnectionProvider sQLConnectionProvider)
        {
            _BookingService = bookingService;
            _SQLConnectionProvider = sQLConnectionProvider;
        }


        [HttpGet]
        [Route("BookingList")]
        public async Task <IActionResult> GetBookingList()
        {
            var result = await _BookingService.GetBookingListAsync<Booking>();

            if (result == null)
            {
                return StatusCode(500);
            }

            return new OkObjectResult(result);
        }

        [HttpGet]
        [Route("{BookingId}")]
        public async Task <IActionResult> GetBooking(int BookingId)
        {
            if (BookingId <= 0) return BadRequest("Invalid Booking ID");

            var result = await _BookingService.GetBookingAsync<Booking>(BookingId);

            if (result == null) return NotFound();

            return new OkObjectResult(result);
        }

        [HttpPut]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [Route("Create")]
        public async Task<IActionResult> CreateBooking(BookingCreationDto Booking)
        {
            //TODO: Have CreateBooking return something so we can return an error response

            await _BookingService.CreateBookingAsync(Booking);

            return new OkResult();

        }

        [HttpPatch]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [Route("Update/{BookingId}")]
        public async Task<IActionResult> UpdateBooking(int BookingId, BookingUpdateDto Booking)
        {
            //TODO: Have UpdateBooking return something so we can return an error response

            if (BookingId <= 0) return BadRequest("Invalid Booking ID");

            var dbBooking = GetBooking(BookingId);
            if (dbBooking == null) return NotFound();

            await _BookingService.UpdateBookingAsync(BookingId, Booking);
            return new OkResult();            
        }

        [HttpDelete]
        [Route("Delete/{BookingId}")]
        public async Task<IActionResult> DeleteBooking(int BookingId) 
        {
            if (BookingId <= 0) return BadRequest("Invalid Booking ID");

            var result = await _BookingService.GetBookingAsync<Booking>(BookingId);
            if (result == null) return NotFound();

            await _BookingService.DeleteBookingAsync(BookingId);
            return new OkResult();
        }
    }
}

//TODO: Add some unit tests on the controller