using Application.DTO;
using Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries.YearOfManufacturer
{
    public interface IGetYearsOfManufacturerQuery : IQuery<YearOfManufacturerSearch,YearsOfManufacturerDto>
    {
    }
}
