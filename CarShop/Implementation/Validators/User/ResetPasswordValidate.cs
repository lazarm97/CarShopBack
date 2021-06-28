using Application.DTO;
using Application.Helpers;
using EfDataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Validators.User
{
    public class ResetPasswordValidate : AbstractValidator<ResetUserPasswordDto>
    {
        public ResetPasswordValidate(EfContext _context)
        {
            RuleFor(x => x.IdUser)
                .NotEmpty()
                .Must(id => _context.Users.Any(x => x.Id == id))
                .WithMessage("Ne postoji korisnik sa prosledjem id-jem!");

            RuleFor(x => x)
                .NotEmpty()
                .Must(dto => _context.Users.Where(x => x.Id == dto.IdUser).Any(x => x.Password == dto.OldPassword))
                .WithMessage("Trenutna sifra se nepodudara!");

            RuleFor(x => x.NewPassword)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(15)
                .WithMessage("Sifra mora sadrzati od 3 do 15 karaktera!");
        }
    }
}
