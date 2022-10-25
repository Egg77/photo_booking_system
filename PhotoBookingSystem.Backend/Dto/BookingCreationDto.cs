using System;
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
        [StringLength(50, ErrorMessage = "Character limit exceeded.")]
        public string? ClientEmail { get; set; }

        [Required(ErrorMessage = "A contact phone number is required.")]
        [DataType(DataType.PhoneNumber)]
        public string? ClientPhone { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDateTime { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDateTime { get; set; }

        public int? Photo { get; set; }

        public int? Video { get; set; }

        public string? Comments { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public double? Price { get; set; }

        public short Paid { get; set; }
    }
}