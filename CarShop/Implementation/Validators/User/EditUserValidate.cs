using Application.DTO;
using EfDataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Validators.User
{
    public class EditUserValidate : AbstractValidator<UserEditDto>
    {
        public EditUserValidate(EfContext context)
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Nije prosledjen id korisnika!");

            RuleFor(x => x.Mobile)
                .NotEmpty()
                .MinimumLength(8)
                .MaximumLength(11)
                .WithMessage("Broj telefona mora da sadrzi minimalno 8 a maksimalno 11 brojeva!");

            RuleFor(x => x.Street)
                .NotEmpty()
                .MinimumLength(4)
                .MaximumLength(25)
                .WithMessage("Ulica mora da sadrzi minimum 4 a maksimum 25 slova!");

            RuleFor(x => x.City)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(25)
                .WithMessage("Grad mora da sadrzi minimalno 2 a maksimalno 25 slova!");
        }
    }
}
