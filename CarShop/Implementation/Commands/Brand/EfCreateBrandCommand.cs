using Application.Commands.Brand;
using Application.DTO;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands.Brand
{
    public class EfCreateBrandCommand : ICreateBrandCommand
    {
        private readonly EfContext _context;

        public EfCreateBrandCommand(EfContext context)
        {
            _context = context;
        }

        public int Id => 26;

        public string Name => "Create brand";

        public void Execute(CreateBrandDto request)
        {

            var x = new Domain.Brand
            {
                Name = request.Name,
                CreatedAt = DateTime.Now,
                IsActive = true
            };
            _context.Brands.Add(x);
            _context.SaveChanges();
        }
    }
}
