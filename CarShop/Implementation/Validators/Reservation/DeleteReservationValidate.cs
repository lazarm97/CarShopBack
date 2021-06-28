using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Validators.Reservation
{
    public class DeleteReservationValidate : AbstractValidator<int>
    {
        public DeleteReservationValidate()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("Nije selektovan id rezervacije!");
        }
    }
}
