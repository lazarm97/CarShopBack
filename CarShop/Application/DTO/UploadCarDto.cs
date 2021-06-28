using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO
{
    public class UploadCarDto
    {
        public string CurrentKm { get; set; }
        public string Cubic { get; set; }
        public string PowerKw { get; set; }
        public string Price { get; set; }
        public string Vin { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }
        public int ModelId { get; set; }
        public int CategoryId { get; set; }
        public int ColorId { get; set; }
        public int DoorId { get; set; }
        public int FuelId { get; set; }
        public int SeatId { get; set; }
        public int TransmissionId { get; set; }
        public int YearOfManufactureId { get; set; }
        public IEnumerable<int> Equipments { get; set; }
        public IEnumerable<IFormFile> ImagesUploader { get; set; }
    }

}
