using Application.Commands.Model;
using Application.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands.Model
{
    public class EfDeleteModelCommand : IDeleteModelCommand
    {
        private readonly EfContext _context;

        public EfDeleteModelCommand(EfContext context)
        {
            _context = context;
        }

        public int Id => 25;

        public string Name => "Delete model";

        public void Execute(int request)
        {
            var model = _context.Models.Find(request);

            if (model == null)
                throw new EntityNotFoundException(request, typeof(Domain.Model));

            _context.Models.Remove(model);
            _context.SaveChanges();
        }
    }
}
