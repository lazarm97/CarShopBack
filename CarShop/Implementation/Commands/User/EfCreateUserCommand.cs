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
    public class EfCreateUserCommand : ICreateUserCommand
    {
        private readonly EfContext _context;
        private readonly IHashPassword _hashPassword;

        public EfCreateUserCommand(EfContext context, IHashPassword hashPassword)
        {
            _context = context;
            _hashPassword = hashPassword;
        }

        public int Id => 20;

        public string Name => "Create user!";

        public void Execute(CreateUserDto request)
        {
            var hashedPassword = _hashPassword.Encrypt(request.Password);

            var user = new Domain.User
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Mobile = request.Mobile,
                Password = hashedPassword,
                Username = request.Username,
                Address = new Domain.Address
                {
                    City = request.City,
                    CreatedAt = DateTime.Now,
                    Street = request.Street
                },
                Role = _context.Roles.Where(x => x.Name == "Customer").FirstOrDefault(),
                CreatedAt = DateTime.Now,
                IsActive = true
            };
            _context.Users.Add(user);

            var userUseCaseEntities = UserAllowedUseCase().Select(x => new Domain.UserUseCase
            {
                UseCaseId = x,
                User = user
            }).ToList();

            _context.UserUseCases.AddRange(userUseCaseEntities);
            _context.SaveChanges();
        }

        private static IEnumerable<int> UserAllowedUseCase()
        {
            return new List<int> { 2,32,22,21,9,10,16,4,5,7,6 };
        }
    }
}
