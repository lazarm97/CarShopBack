﻿using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO
{
    public class UserInfo 
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public AddressDto Address { get; set; }
        public string Mobile { get; set; }
        public string Role { get; set; }
    }

}
