using Application.DTO;
using Application.Exceptions;
using Application.Queries.User;
using Application.Searches;
using Domain;
using EfDataAccess;
using FluentValidation;
using Implementation.Validators.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Queries.User
{
    public class EfLogUser : ILogUserQuery
    {
        private readonly EfContext _context;
        private readonly LogUserValidate _validator;

        public EfLogUser(EfContext context, LogUserValidate validator)
        {
            _context = context;
            _validator = validator;
        }
        public int Id => 1;

        public string Name => "User loggin";

        public UserLogginDto Execute(UserSearch search)
        {
            _validator.ValidateAndThrow(search);

            var user = _context.Users
                .Where(u => u.Username == search.Email && u.Password == search.Password)
                .FirstOrDefault();

            if (user == null)
                throw new EntityNotFoundException(1, typeof(UserLogginDto));

            var userDto = new UserLogginDto
            {
                Id = user.Id,
                Username = user.Username
            };

            return userDto;

        }
    }
}
