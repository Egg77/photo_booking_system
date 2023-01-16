using System;
using System.ComponentModel.DataAnnotations;

namespace photo_booking_system.Dto
{
    public class BookingCreationDto
    {
        [Required(ErrorMessage = "A client name is required.")]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "Character limit exceeded.")]
        public string? ClientName { get; set; }

        [Required(ErrorMessage = "An e-mail address is required.")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [StringLength(50, ErrorMessage = "Character limit exceeded.")]
        public string? ClientEmail { get; set; }

        [Required(ErrorMessage = "A contact phone number is required.")]
        [DataType(DataType.PhoneNumber)]
        [Phone]
        public string? ClientPhone { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime StartDateTime { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string? Address { get; set; }

        [Range(0, 200, ErrorMessage = "Please choose between 0 and 200 photos.")]
        public int? Photo { get; set; }

        [Range(0,10, ErrorMessage = "Please choose between 0 and 10 minutes of video.")]
        public int? Video { get; set; }

        public string? Comments { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public double? Price { get; set; }

        public short Paid { get; set; }
    }
}