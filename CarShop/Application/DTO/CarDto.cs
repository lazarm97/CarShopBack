using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO
{
    public class CarDto
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public int BrandId { get; set; }
        public int CurrentKm { get; set; }
        public int Cubic { get; set; }
        public int PowerKw { get; set; }
        public int Price { get; set; }
        public string Vin { get; set; }
        public string Note { get; set; }
        public string Description { get; set; }
        public string Model { get; set; }
        public int ModelId { get; set; }
        public string Category { get; set; }
        public int CategoryId { get; set; }
        public string Color { get; set; }
        public int ColorId { get; set; }
        public int Door { get; set; }
        public int DoorId { get; set; }
        public string Fuel { get; set; }
        public int FuelId { get; set; }
        public int Seat { get; set; }
        public int SeatId { get; set; }
        public string Transmission { get; set; }
        public int TransmissionId { get; set; }
        public int YearOfManufacture { get; set; }
        public int YearOfManufacturerId { get; set; }
        public ICollection<string> Equipments { get; set; }
        public ICollection<int> EquipmentsId { get; set; }
        public ICollection<string> Images { get; set; }
    }   
}
