using Application.Commands.Reservation;
using Application.DTO;
using Application.Email;
using Application.Exceptions;
using EfDataAccess;
using FluentValidation;
using Implementation.Validators.Reservation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Commands.Reservation
{
    public class EfEditReservationCommand : IEditReservationCommand
    {

        private readonly EfContext _context;
        private readonly EditReservationValidate _validator;
        private readonly IEmailSender _sender;

        public EfEditReservationCommand(EfContext context, EditReservationValidate validator, IEmailSender sender)
        {
            _context = context;
            _validator = validator;
            _sender = sender;
        }

        public int Id => 7;

        public string Name => "Edit reservation";

        public void Execute(EditReservationDto request)
        {
            _validator.ValidateAndThrow(request);

            var reservation = _context.Reservations
                .Include(x => x.User)
                .Where(x => x.Id == request.Id)
                .FirstOrDefault();
                

            if (reservation == null)
                throw new EntityNotFoundException(request.Id, typeof(Domain.Reservation));

            switch (request.Action)
            {
                case "Cancel":
                    reservation.State = "Otkazana";
                    SendEmail();
                    break;
                case "buy":
                    reservation.State = "Kupio";
                    break;
                case "notBuy":
                    reservation.State = "Nije kupio";
                    break;
                case "notArrive":
                    reservation.State = "Nije se pojavio";
                    var userReservations = _context.Reservations.Where(x => x.User.Id == reservation.User.Id)
                        .Where(x => x.State == "Nije se pojavio").Count();
                    if (userReservations == 2)
                    {
                        var user = _context.Users.Find(reservation.User.Id);
                        user.ModifiedAt = DateTime.Now;
                        user.IsActive = false;
                    }
                    break;
            }

            reservation.IsActive = false;
            reservation.IsDeleted = false;

            void SendEmail()
            {
                var userEmail = reservation.User.Email;
                _sender.Send(new SendEmailDto
                {
                    Content = "<h1>Vasa rezervacija je otkazana!</h1>",
                    SendTo = userEmail,
                    Subject = "Rezervacija"
                });
            }

            reservation.ModifiedAt = DateTime.Now;
            _context.SaveChanges();
        }
    }
}
