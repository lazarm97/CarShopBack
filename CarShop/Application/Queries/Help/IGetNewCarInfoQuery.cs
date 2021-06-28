using Application.DTO;
using Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries.Help
{
    public interface IGetNewCarInfoQuery : IQuery<NewCarInfoSearch, NewCarInfoDto>
    {
    }
}
