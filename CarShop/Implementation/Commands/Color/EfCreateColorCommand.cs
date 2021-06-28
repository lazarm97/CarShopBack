using Application.Commands.Color;
using Application.DTO;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands.Color
{
    public class EfCreateColorCommand : ICreateColorCommand
    {
        private readonly EfContext _context;

        public EfCreateColorCommand(EfContext context)
        {
            _context = context;
        }

        public int Id => 28;

        public string Name => "Create color";

        public void Execute(CreateColorDto request)
        {

            var x = new Domain.Color
            {
                NameOfColor = request.Name,
                CreatedAt = DateTime.Now,
                IsActive = true
            };
            _context.Colors.Add(x);
            _context.SaveChanges();
        }
    }
}
