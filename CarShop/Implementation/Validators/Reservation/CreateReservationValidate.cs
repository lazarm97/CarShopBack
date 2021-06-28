using Application.DTO;
using EfDataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Validators.Reservation
{
    public class CreateReservationValidate : AbstractValidator<CreateReservationDto>
    {
        public CreateReservationValidate(EfContext context)
        {
            RuleFor(x => x.CarId)
                .NotEmpty()
                .Must(id => context.Cars.Any(x => x.Id == id))
                .WithMessage("Ne postoji izabrani automobil!");

            RuleFor(x => x.UserId)
                .NotEmpty()
                .Must(id => context.Users.Any(x => x.Id == id))
                .WithMessage("Ne postoji izabrani korisnik!");

            RuleFor(x => x.DateTime)
                .NotEmpty()
                .WithMessage("Datum nije izabran!");

            RuleFor(x => x.DateTime)
                .GreaterThan(DateTime.Now)
                .WithMessage("Datum mora biti u budućnosti!");

            RuleFor(x => x.DateTime)
                .Must(dt => !context.Reservations.Any(x => (dt >= x.DateTime && dt <= x.DateTime.AddHours(1)) || (dt.AddHours(1) >= x.DateTime && dt.AddHours(1) <= x.DateTime.AddHours(1))))
                .WithMessage("Izabrani termin je zauzet!");

            RuleFor(x => x.DateTime)
                .Must(dt => dt.Hour > 8 && dt.Hour < 16)
                .WithMessage("Radno vreme je od 08:00 do 17:00, zadnje vreme početka rezervacije je 16:00");
        }
    }
}
