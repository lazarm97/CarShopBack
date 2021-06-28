using Application.Commands.User;
using Application.DTO;
using Application.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands.User
{
    public class EfAtivateBannedUserCommand : IActivateBannedUserCommand
    {
        private readonly EfContext context;

        public EfAtivateBannedUserCommand(EfContext context)
        {
            this.context = context;
        }

        public int Id => 35;

        public string Name => "Activate banned user";

        public void Execute(UserBannedActivateDto request)
        {
            var user = context.Users.Find(request.Id);

            if (user == null)
                throw new EntityNotFoundException(request.Id, typeof(Domain.User));

            user.IsActive = true;
            user.ModifiedAt = DateTime.Now;
            context.SaveChanges();
        }
    }
}
