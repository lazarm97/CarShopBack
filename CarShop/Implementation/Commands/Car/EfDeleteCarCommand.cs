using Application.Commands.Car;
using Application.Exceptions;
using EfDataAccess;
using FluentValidation;
using Implementation.Validators.Car;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands.Car
{
    public class EfDeleteCarCommand : IDeleteCarCommand
    {

        private readonly EfContext _context;
        private readonly DeleteCarValidate _validator;

        public EfDeleteCarCommand(EfContext context, DeleteCarValidate validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 3;

        public string Name => "Delete car";

        public void Execute(int request)
        {
            _validator.ValidateAndThrow(request);

            var car = _context.Cars.Find(request);

            if (car == null)
                throw new EntityNotFoundException(request, typeof(Domain.Car));

            car.IsDeleted = true;
            _context.SaveChanges();
        }
    }
}
