using Application.Commands.Mobile;
using Application.DTO;
using Application.Exceptions;
using AutoMapper;
using Domain;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands.Mobile
{
    public class EfCreateMobileCommand : ICreateMobileCommand
    {
        private readonly EfContext _context;
        private readonly IMapper _mapper;

        public EfCreateMobileCommand(EfContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 6;

        public string Name => "Create mobile";

        public void Execute(MobileCreateDto request)
        {
            var user = _context.Admins.Find(request.AdminId);

            if (user == null)
                throw new EntityNotFoundException(request.AdminId, typeof(Admin));

            var newMobile = new Domain.Mobile
            {
                Admin = user,
                Number = request.Number,
                IsActive = true
            };

            _context.Mobiles.Add(newMobile);
            _context.SaveChanges();
        }
    }
}
