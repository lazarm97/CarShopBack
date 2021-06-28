using Application.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries.Car
{
    public interface IGetCarQuery : IQuery<int,CarDto>
    {
    }
}
