using Application.Commands.Model;
using Application.DTO;
using Application.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands.Model
{
    public class EfCreateModelCommand : ICreateModelCommand
    {
        private readonly EfContext _context;

        public EfCreateModelCommand(EfContext context)
        {
            _context = context;
        }

        public int Id => 27;

        public string Name => "Create model";

        public void Execute(CreateModelDto request)
        {
            var brand = _context.Brands.Find(Int32.Parse(request.BrandId));

            if (brand == null)
                throw new EntityNotFoundException(Int32.Parse(request.BrandId), typeof(Domain.Brand));

            var x = new Domain.Model
            {
                Brand = brand,
                Name = request.Name,
                CreatedAt = DateTime.Now,
                IsActive = true
            };
            _context.Models.Add(x);
            _context.SaveChanges();
        }
    }
}
