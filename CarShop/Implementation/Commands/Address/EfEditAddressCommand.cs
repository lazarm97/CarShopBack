using Application.Commands.Address;
using Application.DTO;
using Application.Exceptions;
using Domain;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands.Address
{
    public class EfEditAddressCommand : IEditAddressCommand
    {
        private readonly EfContext _context;

        public EfEditAddressCommand(EfContext context)
        {
            _context = context;
        }

        public int Id => 8;

        public string Name => "Edit address";

        public void Execute(AddressDto request)
        {
            var address = _context.Addresses.Find(request.Id);

            if (address == null)
                throw new EntityNotFoundException(request.Id, typeof(Domain.Address));

            address.City = request.City;
            address.Street = request.Street;
            address.ModifiedAt = DateTime.Now;

            _context.SaveChanges();
        }
    }
}
