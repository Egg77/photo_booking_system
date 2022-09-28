using System;
using System.ComponentModel.DataAnnotations;

namespace photo_booking_system.Models 
{

    public class Booking 
    {

        #region Variables

        private const double BasePrice = 30.00;
        private const int PhotoRate = 2;
        private const int VideoRate = 50;

        #endregion

        #region Constructors

        public Booking()
        {
        }

        #endregion

        #region Properties

        [Key]
        public int BookingId {get; set;}

        [Required]
        public string ClientName {get; set;}

        [Required]
        public string ClientEmail {get; set;}

        [Required]
        public string ClientPhone {get; set;}

        [Required]
        public DateTime StartDateTime {get; set;}

        [Required]
        public DateTime EndDateTime {get; set;}

        public int? Photos {get; set;}

        public int? Video {get; set;}

        public string? Comments {get; set;}

        public double? Price {get; set;}

        public short Paid {get; set;}

        #endregion

        #region Methods
        //Put this stuff elsewhere...
        public void CalculatePrice() 
        {

            double? temp = BasePrice;

            if(Photos!= null)
            {
                temp += Photos * (double) PhotoRate;
            }

            if(Video != null) 
            {
                temp += Video * (double) VideoRate;
            }

            Price = temp;
        }

        #endregion
    }
}