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


        public BookingController(IBookingService bookingService, ISQLConnectionProvider sQLConnectionProvider)
        {
            _BookingService = bookingService;
        }


        [HttpGet]
        [Route("BookingList")]
        public async Task <IActionResult> GetBookingList()
        {
            var result = await _BookingService.GetBookingListAsync<Booking>();

            if (result == null)
                return StatusCode(500);

            return new OkObjectResult(result);

        }

        [HttpGet]
        [Route("{BookingId}")]
        public async Task<IActionResult> GetBooking(int BookingId)
        {
            if (BookingId <= 0)
                return BadRequest("Invalid Booking ID");

            try
            {
                var result = await _BookingService.GetBookingAsync<Booking>(BookingId);

                if (result == null)
                    return NotFound();

                return new OkObjectResult(result);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPut]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [Route("Create")]
        public async Task<IActionResult> CreateBooking([FromBody]BookingCreationDto Booking)
        {
            var result = await _BookingService.CreateBookingAsync(Booking);

            if (result == null)
                return StatusCode(500);

            else
                return new OkResult();

        }

        [HttpPatch]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [Route("Update/{BookingId}")]
        public async Task<IActionResult> UpdateBooking(int BookingId, [FromBody]BookingUpdateDto Booking)
        {
            if (BookingId <= 0) return BadRequest("Invalid Booking ID");

            var result = await _BookingService.UpdateBookingAsync(BookingId, Booking);

            if (result == null)
                return StatusCode(500);

            else if (result == false)
                return NotFound();

            else
                return new OkResult();            
        }

        [HttpDelete]
        [Route("Delete/{BookingId}")]
        public async Task<IActionResult> DeleteBooking(int BookingId) 
        {
            if (BookingId <= 0) return BadRequest("Invalid Booking ID");

            var result = await _BookingService.DeleteBookingAsync(BookingId);

            if (result == null)
                return StatusCode(500);

            else if (result == false)
                return NotFound();

            else
                return new OkResult();
        }
    }
}