using Application.DTO;
using Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries.Color
{
    public interface IGetColorsQuery : IQuery<ColorSearch, ColorsDto>
    {
    }
}
