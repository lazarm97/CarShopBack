using Application.DTO;
using Application.Queries.Brand;
using Application.Searches;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Queries.Brand
{
    public class EfGetBrandsQuery : IGetBrandsQuery
    {

        private readonly EfContext _context;

        public EfGetBrandsQuery(EfContext context)
        {
            _context = context;
        }

        public int Id => 11;

        public string Name => "Get brands";

        public BrandsDto Execute(BrandSearch search)
        {
            var query = _context.Brands.AsQueryable();

            var brands = new BrandsDto
            {
                Brands = query.Select(x => new BrandDto
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList()
            };

            return brands;
        }
    }
}
