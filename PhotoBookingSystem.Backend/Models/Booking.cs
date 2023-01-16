using System;
using System.ComponentModel.DataAnnotations;

namespace photo_booking_system.Models 
{

    public class Booking 
    {
        [Key]
        public int BookingId {get; set;}

        [Required(ErrorMessage = "A client name is required.")]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "Character limit exceeded.")]
        public string? ClientName {get; set;}

        [Required(ErrorMessage = "An e-mail address is required.")]
        [DataType(DataType.EmailAddress)]
        [StringLength(50, ErrorMessage = "Character limit exceeded.")]
        public string? ClientEmail {get; set;}

        [Required(ErrorMessage = "A contact phone number is required.")]
        [DataType(DataType.PhoneNumber)]
        public string? ClientPhone {get; set;}

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime StartDateTime {get; set;}

        [Required]
        [DataType(DataType.Text)]
        public string? Address { get; set; }

        public int? Photo {get; set;}

        public int? Video {get; set;}

        public string? Comments {get; set;}

        public double? Price {get; set;}

        public short Paid {get; set;}

    }
}