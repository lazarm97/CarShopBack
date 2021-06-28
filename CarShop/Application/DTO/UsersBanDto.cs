using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO
{

    public class UsersBanDto
    {
        public IEnumerable<UserBanDto> UsersBannedDto { get; set; }
    }
    public class UserBanDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string DateTime { get; set; }
        public string Status { get; set; }
    }
}
