using Application.Commands.Address;
using Application.Exceptions;
using Domain;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands.Address
{
    public class EfDeleteAddressCommand : IDeleteAddressCommand
    {
        public readonly EfContext _context;

        public EfDeleteAddressCommand(EfContext context)
        {
            _context = context;
        }

        public int Id => 4;

        public string Name => "Delete address";

        public void Execute(int request)
        {
            var address = _context.Addresses.Find(request);

            if (address == null)
                throw new EntityNotFoundException(request, typeof(Domain.Address));

            _context.Addresses.Remove(address);
            _context.SaveChanges();
        }
    }
}
