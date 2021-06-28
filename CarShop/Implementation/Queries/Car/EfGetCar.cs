using Application.DTO;
using Application.Queries.Car;
using AutoMapper;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Queries.Car
{
    public class EfGetCar : IGetCarQuery
    {
        private readonly EfContext _context;
        private readonly IMapper _mapper;

        public EfGetCar(EfContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public int Id => 10;

        public string Name => "Get car query";

        public CarDto Execute(int search)
        {
            var query = _context.Cars
                .Include(x => x.CarEquipments)
                .ThenInclude(x => x.Equipment)
                .Include(x => x.Category)
                .Include(x => x.Color)
                .Include(x => x.Door)
                .Include(x => x.Fuel)
                .Include(x => x.Images)
                .Include(x => x.Model)
                .ThenInclude(x => x.Brand)
                .Include(x => x.Seat)
                .Include(x => x.Transmission)
                .Include(x => x.YearOfManufacture)
                .Where(x => x.Id == search)
                .FirstOrDefault();

            return _mapper.Map<CarDto>(query);
        }
    }
}
