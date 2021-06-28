using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO
{
    public class CarEditDto
    {
        public int Id { get; set; }
        public int CurrentKm { get; set; }
        public int Cubic { get; set; }
        public int PowerKw { get; set; }
        public int Price { get; set; }
        public string Vin { get; set; }
        public string Note { get; set; }
        public int ModelId { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public int ColorId { get; set; }
        public int DoorId { get; set; }
        public int FuelId { get; set; }
        public int SeatId { get; set; }
        public int TransmissionId { get; set; }
        public int YearOfManufactureId { get; set; }
        public IEnumerable<int> Equipments { get; set; }
        public IEnumerable<string> ExistImages { get; set; }
        public IEnumerable<IFormFile> ImagesUploader { get; set; }
    }
}
