using Application.Searches;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Validators.User
{
    public class LogUserValidate : AbstractValidator<UserSearch>
    {
        public LogUserValidate()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress(FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible)
                .WithMessage("Neispravna email adresa");

            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(3)
                .WithMessage("Sifra mora da sadrzi bar 3 karaktera!");
        }
    }
}
