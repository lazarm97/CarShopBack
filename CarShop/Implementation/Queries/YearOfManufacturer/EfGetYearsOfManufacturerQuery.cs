using Application.DTO;
using Application.Queries.YearOfManufacturer;
using Application.Searches;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Queries.YearOfManufacturer
{
    public class EfGetYearsOfManufacturerQuery : IGetYearsOfManufacturerQuery
    {
        private readonly EfContext _context;

        public EfGetYearsOfManufacturerQuery(EfContext context)
        {
            _context = context;
        }

        public int Id => 15;

        public string Name => "Get years";

        public YearsOfManufacturerDto Execute(YearOfManufacturerSearch search)
        {
            var query = _context.YearOfManufactures
                .AsQueryable();

            var years = new YearsOfManufacturerDto
            {
                YearsOfManufacturer = query.Select(x => new YearOfManufacturerDto
                {
                    Id = x.Id,
                    Year = x.Year
                }).ToList()
            };

            return years;
        }
    }
}
