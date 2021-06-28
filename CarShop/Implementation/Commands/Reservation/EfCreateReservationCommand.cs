using Application.Commands.Reservation;
using Application.DTO;
using AutoMapper;
using EfDataAccess;
using FluentValidation;
using Hangfire;
using Implementation.Validators.Reservation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands.Reservation
{
    public class EfCreateReservationCommand : ICreateReservationCommand
    {
        private readonly EfContext _context;
        private readonly IMapper _mapper;
        private readonly CreateReservationValidate _validator;
        private readonly IBackgroundJobClient backgroundJobClient;

        public EfCreateReservationCommand(EfContext context, IMapper mapper, CreateReservationValidate validator, IBackgroundJobClient backgroundJobClient)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
            this.backgroundJobClient = backgroundJobClient;
        }

        public int Id => 5;

        public string Name => "Create reservation";

        public void Execute(CreateReservationDto request)
        {
            _validator.ValidateAndThrow(request);

            var x = new Domain.Reservation
            {
                Car = _context.Cars.Find(request.CarId),
                User = _context.Users.Find(request.UserId),
                DateTime = request.DateTime,
                CreatedAt = DateTime.Now,
                IsActive = true,
                State = "Aktivna"
            };

            var breakDateTime = x.DateTime.AddHours(1);
            var scheduleTime = breakDateTime.Ticks - x.CreatedAt.Ticks;

            _context.Reservations.Add(x);
            _context.SaveChanges();

            backgroundJobClient.Schedule(
                () => CancelReservation(x.Id), 
                    TimeSpan.FromTicks(scheduleTime)
                );
        }

        public void CancelReservation(int id)
        {
            var reservation = _context.Reservations.Find(id);
            reservation.IsActive = false;
            reservation.IsDeleted = false;
            reservation.State = "Istekla";
            _context.SaveChanges();
        }
    }
}
