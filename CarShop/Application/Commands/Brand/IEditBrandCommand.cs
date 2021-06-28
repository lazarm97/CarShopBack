﻿using Application.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.Brand
{
    public interface IEditBrandCommand : ICommand<BrandEditDto>
    {
    }
}
