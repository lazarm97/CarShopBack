using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO
{
    public class CreateUserDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
    }
}
