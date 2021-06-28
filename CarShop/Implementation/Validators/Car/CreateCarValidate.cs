using Application.DTO;
using EfDataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Validators.Car
{
    public class CreateCarValidate : AbstractValidator<UploadCarDto>
    {
        public CreateCarValidate(EfContext context)
        {
            RuleFor(x => x.CategoryId)
                .Must(id => context.Categories.Any(x => x.Id == id))
                .WithMessage("Ne postoji kategorija sa prosledjenim id-jem!");

            RuleFor(x => x.ColorId)
                .Must(id => context.Colors.Any(x => x.Id == id))
                .WithMessage("Ne postoji boja sa prosledjenim id-jem!");

            RuleFor(x => x.DoorId)
                .Must(id => context.Doors.Any(x => x.Id == id))
                .WithMessage("Ne postoji broj vrata sa prosledjenim id-jem!");

            RuleFor(x => x.FuelId)
                .Must(id => context.Fuels.Any(x => x.Id == id))
                .WithMessage("Ne postoji gorivo sa prosledjenim id-jem!");

            RuleFor(x => x.ModelId)
                .Must(id => context.Models.Any(x => x.Id == id))
                .WithMessage("Ne postoji model sa prosledjenim id-jem!");

            RuleFor(x => x.SeatId)
                .Must(id => context.Seats.Any(x => x.Id == id))
                .WithMessage("Ne postoji broj sedista sa prosledjenim id-jem!");

            RuleFor(x => x.TransmissionId)
                .Must(id => context.Transmissions.Any(x => x.Id == id))
                .WithMessage("Ne postoji menjac sa prosledjenim id-jem!");

            RuleFor(x => x.YearOfManufactureId)
                .Must(id => context.YearOfManufactures.Any(x => x.Id == id))
                .WithMessage("Ne postoji godina proizvodnje sa prosledjenim id-jem!");

            RuleFor(x => x.Cubic)
                .Must(x => !(x == null || Int32.Parse(x) < 100))
                .WithMessage("Vrednost kubikaze nije ispravna!");

            RuleFor(x => x.CurrentKm)
                .Must(x => !(x == null || Int32.Parse(x) < 0))
                .WithMessage("Nije uneta kilometraza!");

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("Nije unet opis!");

            RuleFor(x => x.PowerKw)
                .Must(x => !(x == null || Int32.Parse(x) < 21))
                .WithMessage("Vrednost kw mora biti veca od 20!");

            RuleFor(x => x.Price)
                .Must(x => !(x == null || Int32.Parse(x) < 100))
                .WithMessage("Nije uneta cena vozila!");

            RuleFor(x => x.Vin)
                .MinimumLength(6)
                .WithMessage("Broj sasije nije validan!");
        }
    }
}
