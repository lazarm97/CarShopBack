using Application.DTO;
using Application.Queries.Color;
using Application.Searches;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Queries.Color
{
    public class EfGetColorsQuery : IGetColorsQuery
    {
        private readonly EfContext _context;

        public EfGetColorsQuery(EfContext context)
        {
            _context = context;
        }

        public int Id => 23;

        public string Name => "Get colors";

        public ColorsDto Execute(ColorSearch search)
        {
            var query = _context.Colors.AsQueryable();

            var colors = new ColorsDto
            {
                Colors = query.Select(x => new ColorDto
                {
                    Id = x.Id,
                    Name = x.NameOfColor
                }).ToList()
            };

            return colors;
        }
    }
}
