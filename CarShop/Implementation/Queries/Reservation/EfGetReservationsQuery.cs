using Application.DTO;
using Application.Queries.Reservation;
using Application.Searches;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Queries.Reservation
{
    public class EfGetReservationsQuery : IGetReservationsQuery
    {
        private readonly EfContext _context;

        public EfGetReservationsQuery(EfContext context)
        {
            _context = context;
        }

        public int Id => 8;

        public string Name => "Get reservations";

        public ReservationDto Execute(ReservationSearch search)
        {
            var query = _context.Reservations
                .Include(x => x.Car)
                .ThenInclude(x => x.Model)
                .ThenInclude(x => x.Brand)
                .Include(x => x.User)
                .AsQueryable();

            if (search.OnlyExpired == true)
            {
                query = query.Where(x => x.State == "Istekla");
            }

            if (search.OnlyExpired == false)
            {
                query = query.Where(x => x.IsActive == true);
            }

            var dto = new ReservationDto
            {
                Reservations = query.Select(x => new Dto
                {
                    Brand = x.Car.Model.Brand.Name,
                    Model = x.Car.Model.Name,
                    UserEmail = x.User.Email,
                    UserFirstName = x.User.FirstName,
                    UserLastName = x.User.LastName,
                    Mobile = x.User.Mobile,
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
