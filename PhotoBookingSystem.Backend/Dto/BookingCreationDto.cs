using System;

namespace photo_booking_system.Dto
{
    public class BookingCreationDto
    {
        public string ClientName { get; set; }

        public string ClientEmail { get; set; }

        public string ClientPhone { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public int? Photo { get; set; }

        public int? Video { get; set; }

        public string? Comments { get; set; }

        public double? Price { get; set; }

        public short Paid { get; set; }
    }
}

