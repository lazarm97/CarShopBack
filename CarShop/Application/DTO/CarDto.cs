using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO
{
    public class CarDto
    {
        public string Brand { get; set; }
        public int CurrentKm { get; set; }
        public int Cubic { get; set; }
        public int PowerKw { get; set; }
        public int Price { get; set; }
        public string Vin { get; set; }
        public string Note { get; set; }
        public string Model { get; set; }
        public string Category { get; set; }
        public string Color { get; set; }
        public int Door { get; set; }
        public string Fuel { get; set; }
        public int Seat { get; set; }
        public string Transmission { get; set; }
        public int YearOfManufacture { get; set; }
        //public ICollection<Car_Equipment> CarEquipments { get; set; }
        //public ICollection<Image> Images { get; set; }
    }
}
