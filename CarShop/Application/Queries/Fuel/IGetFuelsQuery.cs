using Application.DTO;
using Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries.Fuel
{
    public interface IGetFuelsQuery : IQuery<FuelSearch,FuelsDto>
    {
    }
}
