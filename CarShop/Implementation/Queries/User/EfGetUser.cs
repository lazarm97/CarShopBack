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
            var user = _context.Users
                .Include(a => a.Address)
                .Include(a => a.Role)
                .Where(x => x.Id == search)
                .FirstOrDefault();

            if (user == null)
                throw new EntityNotFoundException(search, typeof(Domain.User));

            var userDto = new UserInfo
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.Username,
                Mobile = user.Mobile,
                Address = new AddressDto
                {
                    Id = user.Address.Id,
                    City = user.Address.City,
                    Street = user.Address.Street,
                    UserId = user.Id
                },
                Role = user.Role.Name
            };


            return userDto;
        }
    }
}
