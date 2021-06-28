using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO
{
    public class CreateReservationDto
    {
        public int UserId { get; set; }
        public int CarId { get; set; }
        public DateTime DateTime { get; set; }
    }
}
