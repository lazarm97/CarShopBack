using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO
{
    public class ReservationDto
    {
        public IEnumerable<Dto> Reservations { get; set; }
    }

    public class Dto
    {
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserEmail { get; set; }
        public string Mobile { get; set; }
        public int Id { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Vin { get; set; }
        public int Price { get; set; }
        public string Status { get; set; }
    }
}
