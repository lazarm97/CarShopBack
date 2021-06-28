﻿using Application.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.Reservation
{
    public interface ICreateReservationCommand : ICommand<CreateReservationDto>
    {
    }
}
