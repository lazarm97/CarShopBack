using Application.DTO;
using Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries.Model
{
    public interface IGetModelsQuery : IQuery<ModelSearch,ModelDto>
    {
    }
}
