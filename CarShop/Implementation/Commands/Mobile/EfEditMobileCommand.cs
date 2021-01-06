using Application.Commands.Mobile;
using Application.DTO;
using Application.Exceptions;
using EfDataAccess;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands.Mobile
{
    public class EfEditMobileCommand : IEditMobileCommand
    {
        public readonly EfContext _context;

        public EfEditMobileCommand(EfContext context)
        {
            _context = context;
        }

        public int Id => 7;

        public string Name => "Edit mobile";

        public void Execute(MobileEditDto request)
        {
            var mobile = _context.Mobiles.Find(request.Id);

            if (mobile == null)
                throw new EntityNotFoundException(request.Id, typeof(Domain.Mobile));

            mobile.Number = request.Number;
            mobile.ModifiedAt = DateTime.Now;

            _context.SaveChanges();
        }
    }
}
