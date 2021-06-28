using Application.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.Color
{
    public interface IEditColorCommand : ICommand<ColorEditDto>
    {
    }
}
