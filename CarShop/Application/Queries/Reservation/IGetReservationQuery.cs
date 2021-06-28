using Application.DTO;
using Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries.Reservation
{
    public interface IGetReservationQuery : IQuery<ReservationSearch, ReservationDto>
    {
    }
}
