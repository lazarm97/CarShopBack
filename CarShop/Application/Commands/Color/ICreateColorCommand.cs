using Application.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.Color
{
    public interface ICreateColorCommand : ICommand<CreateColorDto>
    {
    }
}
