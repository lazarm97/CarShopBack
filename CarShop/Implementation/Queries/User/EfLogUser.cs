using Application.DTO;
using Application.Exceptions;
using Application.Queries.User;
using Application.Searches;
using Domain;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Queries.User
{
    public class EfLogUser : ILogUserQuery
    {
        private readonly EfContext _context;

        public EfLogUser(EfContext context)
        {
            _context = context;
        }
        public int Id => 1;

        public string Name => "User loggin";

        public UserLogginDto Execute(UserSearch search)
        {
            var user = _context.Admins
                .Where(u => u.Email == search.Email && u.Password == search.Password)
                .FirstOrDefault();

            if (user == null)
                throw new EntityNotFoundException(1, typeof(UserLogginDto));

            var userDto = new UserLogginDto
            {
                Id = user.Id,
                Email = user.Email
            };

            return userDto;

        }
    }
}
