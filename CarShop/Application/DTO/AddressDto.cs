﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO
{
    public class AddressDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
    }
}
