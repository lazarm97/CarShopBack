using Application.Commands.Color;
using Application.DTO;
using Application.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands.Color
{
    public class EfEditColorCommand : IEditColorCommand
    {
        private readonly EfContext _context;

        public EfEditColorCommand(EfContext context)
        {
            _context = context;
        }

        public int Id => 30;

        public string Name => "Edit color";

        public void Execute(ColorEditDto request)
        {
            var color = _context.Colors.Find(request.Id);

            if (color == null)
                throw new EntityNotFoundException(request.Id, typeof(Domain.Color));

            color.ModifiedAt = DateTime.Now;
            color.NameOfColor = request.Name;

            _context.SaveChanges();
        }
    }
}
