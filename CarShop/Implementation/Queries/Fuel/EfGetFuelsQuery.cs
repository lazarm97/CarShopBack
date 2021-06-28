using Application.DTO;
using Application.Queries.Fuel;
using Application.Searches;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Queries.Fuel
{
    public class EfGetFuelsQuery : IGetFuelsQuery
    {
        private readonly EfContext _context;

        public EfGetFuelsQuery(EfContext context)
        {
            _context = context;
        }

        public int Id => 14;

        public string Name => "Get fuels";

        public FuelsDto Execute(FuelSearch search)
        {
            var query = _context.Fuels
                .AsQueryable();

            var fuels = new FuelsDto
            {
                Fuels = query.Select(x => new FuelDto
                {
                    Id = x.Id,
                    Name = x.NameOfFuel
                }).ToList()
            };

            return fuels;
        }
    }
}
