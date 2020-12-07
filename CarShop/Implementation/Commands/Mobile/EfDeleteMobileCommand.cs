using Application.Commands.Mobile;
using Application.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands.Mobile
{
    public class EfDeleteMobileCommand : IDeleteMobileCommand
    {
        public readonly EfContext _context;

        public EfDeleteMobileCommand(EfContext context)
        {
            _context = context;
        }

        public int Id => 5;

        public string Name => "Delete mobile";

        public void Execute(int request)
        {
            var mobile = _context.Mobiles.Find(request);

            if (mobile == null)
                throw new EntityNotFoundException(request, typeof(Domain.Mobile));

            _context.Mobiles.Remove(mobile);
            _context.SaveChanges();
        }
    }
}
