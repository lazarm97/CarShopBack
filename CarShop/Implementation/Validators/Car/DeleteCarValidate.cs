using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Validators.Car
{
    public class DeleteCarValidate : AbstractValidator<int>
    {
        public DeleteCarValidate()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("Nije selektovan id automobila!");
        }
    }
}
