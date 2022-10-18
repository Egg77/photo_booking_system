using System;
using System.Data;
using Microsoft.AspNetCore.Mvc;

using photo_booking_system.Models;
using photo_booking_system.Providers;
using photo_booking_system.Dto;
using photo_booking_system.ActionFilters;

namespace photo_booking_system.Services
{
    public class BookingService : IBookingService
    {
        private readonly ISQLConnectionProvider _SQLConnectionProvider;


        public BookingService(ISQLConnectionProvider sQLConnectionProvider)
        {
            _SQLConnectionProvider = sQLConnectionProvider;
        }

        public async Task<Booking> GetBookingAsync<T>(int BookingId)
        {
            return await _SQLConnectionProvider.GetBooking<Booking>(BookingId);
        }

        public async Task<List<Booking>> GetBookingListAsync<T>()
        {
            return await _SQLConnectionProvider.GetBookingList<Booking>();
        }

        public async Task CreateBookingAsync(BookingCreationDto Booking)
        {
            await _SQLConnectionProvider.CreateBooking(Booking);
        }

        public async Task UpdateBookingAsync(int BookingId, BookingUpdateDto Booking)
        {
            await _SQLConnectionProvider.UpdateBooking(BookingId, Booking);
        }

        public async Task DeleteBookingAsync(int BookingId)
        {
            await _SQLConnectionProvider.DeleteBooking(BookingId);
        }
    }
}