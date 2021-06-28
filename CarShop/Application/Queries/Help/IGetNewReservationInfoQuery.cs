using Application.DTO;
using Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries.Help
{
    public interface IGetNewReservationInfoQuery : IQuery<NewReservationInfoSearch, NewReservationInfoDto>
    {
    }
}
