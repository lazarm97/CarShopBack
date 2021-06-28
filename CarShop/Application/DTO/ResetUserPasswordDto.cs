using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO
{
    public class ResetUserPasswordDto
    {
        public int IdUser { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
