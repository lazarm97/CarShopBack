using Application.DTO;
using Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries.Reservation
{
    public interface IGetReservationsStatisticQuery : IQuery<ReservationStatisticSearch, ReservationsStatisticDto>
    {
    }
}
