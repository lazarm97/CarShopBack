using Application.DTO;
using Application.Exceptions;
using Application.Queries.User;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using EfDataAccess;
using Implementation.Profiles;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Implementation.Queries.User
{
    public class EfGetUser : IGetUserQuery
    {
        private readonly EfContext _context;
        private readonly IMapper _mapper;

        public EfGetUser(EfContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 2;

        public string Name => "Get user info";

        public UserInfo Execute(int search)
        {
            var user = _context.Admins
                .Include(m => m.Mobiles)
                .Include(a => a.Addresses)
                .Where(x => x.Id == search)
                .FirstOrDefault();

            // provera za null


            var userDto = new UserInfo
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Mobiles = user.Mobiles.Select(x => new MobileDto
                {
                    Id = x.Id,
                    Number = x.Number
                }).ToList(),
                Addresses = user.Addresses.Select(x => new AddressDto
                {
                    Id = x.Id,
                    City = x.City,
                    Street = x.Street
                }).ToList()
            };


            return userDto;
        }
    }
}
