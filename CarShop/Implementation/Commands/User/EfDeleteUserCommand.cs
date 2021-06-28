using Application.Commands.User;
using Application.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Commands.User
{
    public class EfDeleteUserCommand : IDeleteUserCommand
    {
        protected EfContext _context;

        public EfDeleteUserCommand(EfContext context)
        {
            _context = context;
        }

        public int Id => 21;

        public string Name => "Delete user command!";

        public void Execute(int request)
        {
            var user = _context.Users.Find(request);

            if (user == null)
                throw new EntityNotFoundException(request, typeof(Domain.User));

            user.IsDeleted = true;
            user.ModifiedAt = DateTime.Now;

            var reservations = _context.Reservations.Where(x => x.User.Id == user.Id).ToList();
            foreach(var reservation in reservations)
            {
                reservation.IsActive = false;
                reservation.IsDeleted = true;
                reservation.ModifiedAt = DateTime.Now;
            }
            _context.SaveChanges();
        }
    }
}
