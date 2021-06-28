using Application.Commands.User;
using Application.DTO;
using Application.Helpers;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Commands.User
{
    public class EfCreateUserPasswordCommand : ICreateUserPasswordCommand
    {
        private readonly EfContext _context;
        private readonly IHashPassword _hashPassword;

        public EfCreateUserPasswordCommand(EfContext context, IHashPassword hashPassword)
        {
            _context = context;
            _hashPassword = hashPassword;
        }

        public int Id => 33;

        public string Name => "Create user new password";

        public void Execute(UserCreatePasswordDto request)
        {
            var user = _context.Users.Where(x => x.Email == request.Email).FirstOrDefault();
            
            if(user == null)
                throw new Exception("Korisnik sa ovim email-om ne postoji!");

            var token = user.Token;

            if(token != request.Token)
                throw new Exception("Validacioni kod je istekao ili ne postoji!");

            var hashedPassword = _hashPassword.Encrypt(request.Password);

            user.Password = hashedPassword;
            user.ModifiedAt = DateTime.Now;
            user.Token = null;
            _context.SaveChanges();
        }
    }
}
