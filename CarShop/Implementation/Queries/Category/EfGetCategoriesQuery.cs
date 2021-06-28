using Application.DTO;
using Application.Queries.Category;
using Application.Searches;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Queries.Category
{
    public class EfGetCategoriesQuery : IGetCategoriesQuery
    {
        private readonly EfContext _context;

        public EfGetCategoriesQuery(EfContext context)
        {
            _context = context;
        }

        public int Id => 13;

        public string Name => "Get categories";

        public CategoriesDto Execute(CategorySearch search)
        {
            var query = _context.Categories
                .AsQueryable();

            var categories = new CategoriesDto
            {
                Categories = query.Select(x => new CategoryDto
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList()
            };

            return categories;
        }
    }
}
