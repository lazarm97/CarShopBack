using Application.Searches;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Validators.Reservation
{
    public class GetUserReservationsValidate : AbstractValidator<ReservationSearch>
    {
        public GetUserReservationsValidate()
        {
            RuleFor(x => x.IdUser)
                .NotEmpty()
                .WithMessage("Nije selektovan id korisnika!");
        }
    }
}
