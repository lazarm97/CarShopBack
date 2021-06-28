using Application.Commands.Color;
using Application.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands.Color
{
    public class EfDeleteColorCommand : IDeleteColorCommand
    {
        private readonly EfContext _context;

        public EfDeleteColorCommand(EfContext context)
        {
            _context = context;
        }

        public int Id => 24;

        public string Name => "Delete color";

        public void Execute(int request)
        {
            var color = _context.Colors.Find(request);

            if (color == null)
                throw new EntityNotFoundException(request, typeof(Domain.Color));

            _context.Colors.Remove(color);
            _context.SaveChanges();
        }
    }
}
