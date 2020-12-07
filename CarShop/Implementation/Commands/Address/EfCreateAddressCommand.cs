using Application.Commands.Address;
using Application.DTO;
using Application.Exceptions;
using AutoMapper;
using Domain;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands.Address
{
    public class EfCreateAddressCommand : ICreateAddressCommand
    {
        private readonly EfContext _context;
        private readonly IMapper _mapper;

        public EfCreateAddressCommand(EfContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 3;

        public string Name => "Create address";

        public void Execute(AddressCreateDto request)
        {
            var user = _context.Admins.Find(request.AdminId);

            if (user == null)
                throw new EntityNotFoundException(request.AdminId, typeof(Admin));

            var newAddress = new Domain.Address
            {
                Admin = user,
                City = request.City,
                Street = request.Street,
                IsActive = true
            };

            _context.Addresses.Add(newAddress);
            _context.SaveChanges();
        }
    }
}
