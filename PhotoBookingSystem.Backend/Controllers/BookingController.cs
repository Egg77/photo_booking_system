using System;
using Microsoft.AspNetCore.Mvc;
using photo_booking_system.Models;
using photo_booking_system.Services;
using photo_booking_system.Providers;

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
        public async Task <IActionResult> GetBookingList()
        {
            try
            {
                var result = await _BookingService.GetBookingListAsync<Booking>();
                return new OkObjectResult(result);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
            return null;
        }

        [HttpGet]
        [Route("{BookingId}")]
        public async Task <IActionResult> GetBooking(int BookingId)
        {
            try
            {
                if (BookingId <= 0) return BadRequest("Invalid Booking ID");

                var result = await _BookingService.GetBookingAsync<Booking>(BookingId);
                return new OkObjectResult(result);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }    
            return null;
        }


        //TODO: Not implemented
        [HttpPut]
        [Route("Booking/Create")]
        public async Task<IActionResult> CreateBooking()
        {
            return new OkResult();
        }

        //TODO: Not implemented
        [HttpPatch]
        [Route("Booking/Update/{BookingId}")]
        public async Task<IActionResult> UpdateBooking()
        {
            return new OkResult();
        }

        //TODO: Not implemented
        [HttpDelete]
        [Route("Booking/Delete/{BookingId}")]
        public async Task<IActionResult> DeleteBooking() 
        {
            return new OkResult();
        }

    }

}