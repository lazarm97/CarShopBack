using Application.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.Mobile
{
    public interface ICreateMobileCommand : ICommand<MobileCreateDto>
    {
    }
}
