using Application.DTO;
using Application.Queries.Reservation;
using Application.Searches;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Queries.Reservation
{
    public class EfGetReservationsStatisticQuery : IGetReservationsStatisticQuery
    {
        private readonly EfContext context;

        public EfGetReservationsStatisticQuery(EfContext context)
        {
            this.context = context;
        }

        public int Id => 34;

        public string Name => "Get reservations statistic";

        public ReservationsStatisticDto Execute(ReservationStatisticSearch search)
        {
            var query = context.Reservations.GroupBy(x => x.State).AsQueryable();

            var y = new ReservationsStatisticDto
            {
                Statistic = query.Select(x => new StatisticDto
                {
                    State = x.Key,
                    Count = x.Count()
                }).ToList()
            };

            return y;
        }
    }
}
