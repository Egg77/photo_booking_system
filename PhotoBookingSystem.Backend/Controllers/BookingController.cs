using System;
using Microsoft.AspNetCore.Mvc;
using photo_booking_system.Models;
using photo_booking_system.Services;
using photo_booking_system.Providers;
using photo_booking_system.Dto;

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

                if (result == null) return NotFound();

                return new OkObjectResult(result);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }    
            return null;
        }

        [HttpPut]
        [Route("Create")]
        public async Task<IActionResult> CreateBooking(BookingCreationDto Booking)
        {
            try
            {
                await _BookingService.CreateBooking(Booking);
                return new OkResult();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
            return null;
        }

        [HttpPatch]
        [Route("Update/{BookingId}")]
        public async Task<IActionResult> UpdateBooking(int BookingId, BookingUpdateDto Booking)
        {
            try
            {
                if (BookingId <= 0) return BadRequest("Invalid Booking ID");

                var dbBooking = GetBooking(BookingId);
                if (dbBooking == null) return NotFound();

                await _BookingService.UpdateBooking(BookingId, Booking);
                return new OkResult();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
            return null;
            
        }

        [HttpDelete]
        [Route("Delete/{BookingId}")]
        public async Task<IActionResult> DeleteBooking(int BookingId) 
        {
            try
            {
                if (BookingId <= 0) return BadRequest("Invalid Booking ID");

                var dbBooking = GetBooking(BookingId);
                if (dbBooking == null) return NotFound();

                await _BookingService.DeleteBooking(BookingId);
                return new OkResult();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
            return null;
        }
    }
}