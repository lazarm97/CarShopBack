using Application.DTO;
using Application.Queries.Help;
using Application.Searches;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace Implementation.Queries.Help
{
    public class EfGetNewReservationInfoQuery : IGetNewReservationInfoQuery
    {
        private readonly EfContext _context;
        private readonly IMapper _mapper;

        public EfGetNewReservationInfoQuery(EfContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 4;

        public string Name => "Get new reservation info";

        public NewReservationInfoDto Execute(NewReservationInfoSearch search)
        {
            var userQuery = _context.Users
                .Include(x => x.Address)
                .Where(x => x.Id == search.IdUser)
                .AsQueryable();

            var carQuery = _context.Cars
                .Include(x => x.Model)
                .ThenInclude(x => x.Brand)
                .Where(x => x.Id == search.IdCar)
                .AsQueryable();

            var reservationDto = new NewReservationInfoDto
            {
               Address = userQuery.Select(x => x.Address.City + ", " + x.Address.Street).FirstOrDefault(),
               ModelBrand = carQuery.Select(x => x.Model.Brand.Name + " " + x.Model.Name).FirstOrDefault(),
               Email = userQuery.Select(x => x.Email).FirstOrDefault(),
               FirstName = userQuery.Select(x => x.FirstName).FirstOrDefault(),
               LastName = userQuery.Select(x => x.LastName).FirstOrDefault(),
               Mobile = userQuery.Select(x => x.Mobile).FirstOrDefault(),
               Vin = carQuery.Select(x => x.Vin).FirstOrDefault()
            };

            return reservationDto;

        }
    }
}
