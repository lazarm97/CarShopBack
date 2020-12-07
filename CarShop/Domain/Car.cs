using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Car : BaseEntity
    {
        public int CurrentKm { get; set; }
        public int Cubic { get; set; }
        public int PowerKw { get; set; }
        public int Price { get; set; }
        public int Vin { get; set; }
        public string Note { get; set; }
        public Model Model { get; set; }
        public Category Category { get; set; }
        public Color Color { get; set; }
        public Door Door { get; set; }
        public Fuel Fuel { get; set; }
        public Seat Seat { get; set; }
        public Transmission Transmission { get; set; }
        public YearOfManufacture YearOfManufacture { get; set; }
        public ICollection<Car_Equipment> CarEquipments { get; set; }
        public ICollection<Image> Images { get; set; }
    }
}
