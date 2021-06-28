using Application.Commands.Model;
using Application.DTO;
using Application.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands.Model
{
    public class EfEditModelCommand : IEditModelCommand
    {
        private readonly EfContext _context;

        public EfEditModelCommand(EfContext context)
        {
            _context = context;
        }

        public int Id => 31;

        public string Name => "Edit model";

        public void Execute(ModelEditDto request)
        {
            var model = _context.Models.Find(request.Id);

            if (model == null)
                throw new EntityNotFoundException(request.Id, typeof(Domain.Model));

            model.ModifiedAt = DateTime.Now;
            model.Name = request.Name;

            _context.SaveChanges();
        }
    }
}
