using Application.DTO;
using Application.Queries.Model;
using Application.Searches;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Queries.Model
{
    public class EfGetModelsQuery : IGetModelsQuery
    {
        private readonly EfContext _context;

        public EfGetModelsQuery(EfContext context)
        {
            _context = context;
        }

        public int Id => 12;

        public string Name => "Get models";

        public ModelDto Execute(ModelSearch search)
        {
            var query = _context.Models
                .Where(x => x.Brand.Id == search.BrandId)
                .AsQueryable();

            var models = new ModelDto
            {
                Models = query.Select(x => new Application.DTO.Model
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList()
            };

            return models;
        }
    }
}
