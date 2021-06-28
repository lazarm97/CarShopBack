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

        public int Id => 9;

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
                .Include(x => x.Images)
                .Include(x => x.Transmission)
                .Include(x => x.YearOfManufacture)
                .Include(x => x.Images)
                .Where(x => x.IsDeleted == false)
                .AsQueryable();

            if (!string.IsNullOrEmpty(search.CarName) || !string.IsNullOrWhiteSpace(search.CarName))
            {
                query = query.Where(x => (x.Model.Brand.Name + " " + x.Model.Name + " " + x.Description).ToLower().Contains(search.CarName.ToLower()));
            }

            if(search.IdBrand > 0)
            {
                query = query.Where(x => x.Model.Brand.Id == search.IdBrand);
            }

            if (search.IdModel > 0)
            {
                query = query.Where(x => x.Model.Id == search.IdModel);
            }

            if (search.IdFuel > 0)
            {
                query = query.Where(x => x.Fuel.Id == search.IdFuel);
            }

            if (search.IdCategory > 0)
            {
                query = query.Where(x => x.Category.Id == search.IdCategory);
            }

            if (search.IdDoors > 0)
            {
                query = query.Where(x => x.Door.Id == search.IdDoors);
            }

            if (search.IdYearFrom > 0)
            {
                query = query.Where(x => x.YearOfManufacture.Year >= _context.YearOfManufactures.Find(search.IdYearFrom).Year);
            }

            if (search.IdYearTo > 0)
            {
                query = query.Where(x => x.YearOfManufacture.Year <= _context.YearOfManufactures.Find(search.IdYearTo).Year);
            }

            if (search.PriceFrom >= 0)
            {
                query = query.Where(x => x.Price >= search.PriceFrom);
            }

            if (search.PriceTo >= 0)
            {
                query = query.Where(x => x.Price <= search.PriceTo);
            }

            if (!string.IsNullOrEmpty(search.CarFilter) || !string.IsNullOrWhiteSpace(search.CarFilter))
            {
                switch (search.CarFilter)
                {
                    case "title-desc":
                        query = query.OrderByDescending(x => x.Model.Brand.Name);
                        break;
                    case "title-asc":
                        query = query.OrderBy(x => x.Model.Brand.Name);
                        break;
                    case "price-desc":
                        query = query.OrderByDescending(x => x.Price);
                        break;
                    case "price-asc":
                        query = query.OrderBy(x => x.Price);
                        break;
                }
            }

            if(search.RecentAdded != false)
            {
                query = query.OrderByDescending(x => x.CreatedAt).Take(3);
            }

            return query.Paged<CarDto, Domain.Car>(search, _mapper);
        }
    }
}
