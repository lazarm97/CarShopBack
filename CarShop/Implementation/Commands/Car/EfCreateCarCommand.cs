using Application.Commands.Car;
using Application.DTO;
using EfDataAccess;
using FluentValidation;
using Implementation.Validators.Car;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Implementation.Commands.Car
{
    public class EfCreateCarCommand : ICreateCarCommand
    {
        private readonly EfContext _context;
        private readonly CreateCarValidate _validator;

        public EfCreateCarCommand(EfContext context, CreateCarValidate validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 17;

        public string Name => "Create car command";

        public void Execute(UploadCarDto request)
        {
            _validator.ValidateAndThrow(request);

            List<string> images = new List<string>();
            if (request.ImagesUploader != null)
            {
                foreach (var image in request.ImagesUploader)
                {
                    var guid = Guid.NewGuid();
                    var extension = Path.GetExtension(image.FileName);

                    var newFileName = guid + extension;

                    var path = Path.Combine("wwwroot", "images", newFileName);

                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        image.CopyTo(fileStream);
                    }
                    images.Add(newFileName);
                }
            }

            var car = new Domain.Car
            {
                Category = _context.Categories.Find(request.CategoryId),
                Color = _context.Colors.Find(request.ColorId),
                Cubic = Int32.Parse(request.Cubic),
                CurrentKm = Int32.Parse(request.CurrentKm),
                Door = _context.Doors.Find(request.DoorId),
                Fuel = _context.Fuels.Find(request.FuelId),
                Model = _context.Models.Find(request.ModelId),
                Note = request.Note,
                Price = Int32.Parse(request.Price),
                Description = request.Description,
                PowerKw = Int32.Parse(request.PowerKw),
                Seat = _context.Seats.Find(request.SeatId),
                Vin = request.Vin,
                Transmission = _context.Transmissions.Find(request.TransmissionId),
                YearOfManufacture = _context.YearOfManufactures.Find(request.YearOfManufactureId),
                Images = images.Select(x => new Domain.Image
                {
                    Alt = "asd",
                    Src = x
                }).ToList(),
                CarEquipments = request.Equipments.Select(x => new Domain.Car_Equipment
                {
                    Equipment = _context.Equipments.Find(x)
                }).ToList()
            };

            _context.Cars.Add(car);
            _context.SaveChanges();
        }
    }
}
