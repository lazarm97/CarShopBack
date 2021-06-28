using Application.Commands.Reservation;
using Application.Exceptions;
using EfDataAccess;
using FluentValidation;
using Implementation.Validators.Reservation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands.Reservation
{
    public class EfDeleteReservationCommand : IDeleteReservationCommand
    {
        private readonly EfContext _context;
        private readonly DeleteReservationValidate _validator;

        public EfDeleteReservationCommand(EfContext context, DeleteReservationValidate validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 19;

        public string Name => "Delete reservation";

        public void Execute(int request)
        {
            _validator.ValidateAndThrow(request);

            var reservation = _context.Reservations.Find(request);

            if (reservation == null)
                throw new EntityNotFoundException(request, typeof(Domain.Reservation));

            reservation.IsActive = false;
            reservation.IsDeleted = true;
            reservation.ModifiedAt = DateTime.Now;
            _context.SaveChanges();
        }
    }
}
