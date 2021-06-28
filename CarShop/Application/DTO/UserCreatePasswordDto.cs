using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO
{
    public class UserCreatePasswordDto
    {
        public string Password { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
