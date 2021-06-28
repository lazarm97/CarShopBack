using Application.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.User
{
    public interface IResetUserPasswordCommand : ICommand<ResetUserPasswordDto>
    {
    }
}
