using System;
using System.Data;
using Microsoft.AspNetCore.Mvc;

using photo_booking_system.Models;
using photo_booking_system.Providers;
using photo_booking_system.Dto;

namespace photo_booking_system.Services
{
    public class BookingService : IBookingService
    {
        private readonly ISQLConnectionProvider _SQLConnectionProvider;

        public BookingService(ISQLConnectionProvider sQLConnectionProvider)
        {
            _SQLConnectionProvider = sQLConnectionProvider;
        }

        #region Public Methods
        public async Task<Booking> GetBookingAsync<T>(int BookingId)
        {
            return await _SQLConnectionProvider.GetBooking<Booking>(BookingId);
        }

        public async Task<List<Booking>> GetBookingListAsync<T>()
        {
            return await _SQLConnectionProvider.GetBookingList<Booking>();
        }

        public async Task<bool?> CreateBookingAsync(BookingCreationDto Booking)
        {
            CalculatePrice(Booking);
            return await _SQLConnectionProvider.CreateBooking(Booking);
        }

        public async Task<bool?> UpdateBookingAsync(int BookingId, BookingUpdateDto Booking)
        {
            CalculatePrice(Booking);
            return await _SQLConnectionProvider.UpdateBooking(BookingId, Booking);
        }

        public async Task<bool?> DeleteBookingAsync(int BookingId)
        {
            return await _SQLConnectionProvider.DeleteBooking(BookingId);
        }
        #endregion

        #region Private Methods
        public void CalculatePrice(BookingCreationDto Booking)
        {
            if (Booking == null)
                return;

            double? BasePrice = 30.00;
            int PhotoRate = 2;
            int VideoRate = 50;

            double? temp = BasePrice;

            if (Booking.Photo != null)
            {
                temp += Booking.Photo * PhotoRate;
            }

            if (Booking.Video != null)
            {
                temp += Booking.Video * (double)VideoRate;
            }

            Booking.Price = temp;
        }

        public void CalculatePrice(BookingUpdateDto Booking)
        {
            if (Booking == null)
                return;

            double? BasePrice = 30.00;
            int PhotoRate = 2;
            int VideoRate = 50;

            double? temp = BasePrice;

            if (Booking.Photo != null)
            {
                temp += Booking.Photo * PhotoRate;
            }

            if (Booking.Video != null)
            {
                temp += Booking.Video * (double)VideoRate;
            }

            Booking.Price = temp;
        }
        #endregion
    }
}