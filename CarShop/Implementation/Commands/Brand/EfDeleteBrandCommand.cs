using Application.Commands.Brand;
using Application.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands.Brand
{
    public class EfDeleteBrandCommand : IDeleteBrandCommand
    {
        private readonly EfContext _context;

        public EfDeleteBrandCommand(EfContext context)
        {
            _context = context;
        }

        public int Id => 23;

        public string Name => "Delete brand";

        public void Execute(int request)
        {
            var brand = _context.Brands.Find(request);

            if (brand == null)
                throw new EntityNotFoundException(request, typeof(Domain.Brand));

            _context.Brands.Remove(brand);
            _context.SaveChanges();
        }
    }
}
