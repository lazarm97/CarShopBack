using Application.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Validators.Reservation
{
    public class EditReservationValidate : AbstractValidator<EditReservationDto>
    {
        public EditReservationValidate()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Nije selektovan id korisnika!");
        }
    }
}
