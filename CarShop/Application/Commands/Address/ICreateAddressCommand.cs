using Application.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.Address
{
    public interface ICreateAddressCommand : ICommand<AddressCreateDto>
    {
    }
}
