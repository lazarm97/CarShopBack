using Application.Commands.User;
using Application.DTO;
using Application.Exceptions;
using EfDataAccess;
using FluentValidation;
using Implementation.Validators.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Commands.User
{
    public class EfEditUserCommand : IEditUserCommand
    {
        public readonly EfContext _context;
        public readonly EditUserValidate _validator;

        public EfEditUserCommand(EfContext context, EditUserValidate validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 32;

        public string Name => "Edit user";

        public void Execute(UserEditDto request)
        {
            _validator.ValidateAndThrow(request);

            var user = _context.Users
                .Include(x => x.Address)
                .Where(x => x.Id == request.Id)
                .FirstOrDefault();

            if (user == null)
                throw new EntityNotFoundException(request.Id, typeof(Domain.User));
           
            user.Address.City = request.City;
            user.Address.Street = request.Street;
            user.Address.ModifiedAt = DateTime.Now;
            user.Mobile = request.Mobile;
            user.ModifiedAt = DateTime.Now;

            _context.SaveChanges();
        }
    }
}
