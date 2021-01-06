using Application.DTO;
using Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries.Car
{
    public interface IGetCarsQuery : IQuery<CarSearch, PagedResponse<CarDto>>
    {
    }
}
