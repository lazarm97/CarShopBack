using Application.Commands.Brand;
using Application.DTO;
using Application.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands.Brand
{
    public class EfEditBrandCommand : IEditBrandCommand
    {
        private readonly EfContext _context;

        public EfEditBrandCommand(EfContext context)
        {
            _context = context;
        }

        public int Id => 29;

        public string Name => "Edit brand";

        public void Execute(BrandEditDto request)
        {
            var brand = _context.Brands.Find(request.Id);

            if (brand == null)
                throw new EntityNotFoundException(request.Id, typeof(Domain.Brand));

            brand.ModifiedAt = DateTime.Now;
            brand.Name = request.Name;

            _context.SaveChanges();
        }
    }
}
