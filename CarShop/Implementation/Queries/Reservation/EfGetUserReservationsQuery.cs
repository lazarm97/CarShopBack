using Application.DTO;
using Application.Queries.Reservation;
using Application.Searches;
using EfDataAccess;
using FluentValidation;
using Implementation.Validators.Reservation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Queries.Reservation
{
    public class EfGetUserReservationsQuery : IGetReservationQuery
    {
        private readonly EfContext _context;
        private readonly GetUserReservationsValidate _validator;

        public EfGetUserReservationsQuery(EfContext context, GetUserReservationsValidate validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 6;

        public string Name => "Get user reservation";

        public ReservationDto Execute(ReservationSearch search)
        {
            _validator.ValidateAndThrow(search);

            var query = _context.Reservations
                .Include(x => x.Car)
                .ThenInclude(x => x.Model)
                .ThenInclude(x => x.Brand)
                .Include(x => x.User)
                .Where(x => x.User.Id == search.IdUser && (x.State == "Aktivna" || x.State == "Otkazana"))
                .AsQueryable();

            var dto = new ReservationDto
            {
                Reservations = query.Select(x => new Dto
                {
                    Brand = x.Car.Model.Brand.Name,
                    Model = x.Car.Model.Name,
                    Mobile = x.User.Mobile,
                    UserEmail = x.User.Email,
                    UserFirstName = x.User.FirstName,
                    UserLastName = x.User.LastName,
                    Date = x.DateTime.Date.ToString(),
                    Time = x.DateTime.TimeOfDay.Hours.ToString() + ":" + x.DateTime.TimeOfDay.Minutes.ToString(),
                    Id = x.Id,
                    Price = x.Car.Price,
                    Vin = x.Car.Vin,
                    Year = x.Car.YearOfManufacture.Year,
                    Status = x.State
                }).ToList()
            };

            return dto;
        }
    }
}
