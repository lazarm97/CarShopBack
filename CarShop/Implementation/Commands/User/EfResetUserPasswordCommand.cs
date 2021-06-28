using Application.Commands.User;
using Application.DTO;
using Application.Exceptions;
using Application.Helpers;
using EfDataAccess;
using FluentValidation;
using Implementation.Validators.User;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Commands.User
{
    public class EfResetUserPasswordCommand : IResetUserPasswordCommand
    {
        private readonly EfContext _context;
        private readonly ResetPasswordValidate _validator;
        private readonly IHashPassword _hashPassword;

        public EfResetUserPasswordCommand(EfContext context, ResetPasswordValidate validator, IHashPassword hashPassword)
        {
            _context = context;
            _validator = validator;
            _hashPassword = hashPassword;
        }

        public int Id => 22;

        public string Name => "Reset user password!";

        public void Execute(ResetUserPasswordDto request)
        {
            var pass = _hashPassword.Encrypt(request.OldPassword);
            request.OldPassword = pass;
            _validator.ValidateAndThrow(request);

            var user = _context.Users
                .Where(x => x.Id == request.IdUser)
                .FirstOrDefault();

            if (user == null)
                throw new EntityNotFoundException(request.IdUser, typeof(Domain.User));

            var hashedPassword = _hashPassword.Encrypt(request.NewPassword);

            user.Password = hashedPassword;
            user.ModifiedAt = DateTime.Now;

            _context.SaveChanges();
        }
    }
}
