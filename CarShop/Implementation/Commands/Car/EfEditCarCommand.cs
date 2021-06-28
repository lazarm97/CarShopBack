using Application.Commands.Car;
using Application.DTO;
using Application.Exceptions;
using EfDataAccess;
using FluentValidation;
using Implementation.Validators.Car;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Implementation.Commands.Car
{
    public class EfEditCarCommand : IEditCarCommand
    {
        private readonly EfContext _context;
        private readonly EditCarValidate _validator;

        public EfEditCarCommand(EfContext context, EditCarValidate validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 18;

        public string Name => "Edit car command";

        public void Execute(CarEditDto request)
        {
            _validator.ValidateAndThrow(request);

            var car = _context.Cars
                .Include(x => x.Images)
                .Include(x => x.CarEquipments)
                .ThenInclude(x => x.Equipment)
                .Where(x => x.Id == request.Id)
                .First();

            if (car == null)
                throw new EntityNotFoundException(request.Id, typeof(Domain.Car));

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

            car.Category = _context.Categories.Find(request.CategoryId);
            car.Fuel = _context.Fuels.Find(request.FuelId);
            car.Model = _context.Models.Find(request.ModelId);
            car.Color = _context.Colors.Find(request.ColorId);
            car.Cubic = request.Cubic;
            car.CurrentKm = request.CurrentKm;
            car.Door = _context.Doors.Find(request.DoorId);
            car.Note = request.Note;
            car.PowerKw = request.PowerKw;
            car.Price = request.Price;
            car.Seat = _context.Seats.Find(request.SeatId);
            car.Transmission = _context.Transmissions.Find(request.TransmissionId);
            car.Vin = request.Vin;
            car.Description = request.Description;
            car.YearOfManufacture = _context.YearOfManufactures.Find(request.YearOfManufactureId);
            var toRemoveImages = car.Images.Where(x => !request.ExistImages.Contains(x.Src)).ToList();
            var toRemoveEquipments = car.CarEquipments.Where(x => !request.Equipments.Contains(x.Equipment.Id)).ToList();
            var toAddEquipments = request.Equipments.Where(x => !car.CarEquipments.Select(e => e.Equipment.Id).Contains(x)).ToList();
            foreach (var item in toRemoveEquipments)
            {
                car.CarEquipments.Remove(item);
            }
            foreach(var item in toRemoveImages)
            {
                _context.Images.Remove(item);
            }
            var newImages = images.Select(x => new Domain.Image
            {
                Alt = "asd",
                Src = x
            }).ToList();
            foreach(var item in newImages)
            {
                car.Images.Add(item);
            }
            var newEquipments = toAddEquipments.Select(x => new Domain.Car_Equipment
            {
                Equipment = _context.Equipments.Find(x)
            }).ToList();
            foreach (var item in newEquipments)
            {
                car.CarEquipments.Add(item);
            }

            _context.SaveChanges();
        }
    }
}
