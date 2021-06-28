using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class User : BaseEntity
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public string Mobile { get; set; }
        public virtual Address Address { get; set; }
        public virtual ICollection<UserUseCase> UserUseCases { get; set; }
        public string Token { get; set; }
    }
}
