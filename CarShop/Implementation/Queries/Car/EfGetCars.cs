using Application.DTO;
using Application.Queries;
using Application.Queries.Car;
using Application.Searches;
using AutoMapper;
using EfDataAccess;
using Implementation.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Queries.Car
{
    public class EfGetCars : IGetCarsQuery
    {
        private readonly EfContext _context;
        private readonly IMapper _mapper;

        public EfGetCars(EfContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 8;

        public string Name => "Get cars";

        public PagedResponse<CarDto> Execute(CarSearch search)
        {
            var query = _context.Cars
                .Include(x => x.Category)
                .Include(x => x.Color)
                .Include(x => x.Door)
                .Include(x => x.Fuel)
                .Include(x => x.Model)
                .ThenInclude(x => x.Brand)
                .Include(x => x.Seat)
                .Include(x => x.Transmission)
                .Include(x => x.YearOfManufacture)
                .AsQueryable();

            return query.Paged<CarDto, Domain.Car>(search, _mapper);
        }
    }
}
