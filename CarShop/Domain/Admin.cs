using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Admin : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual ICollection<UserUseCase> UserUseCases { get; set; }
        public virtual ICollection<Mobile> Mobiles { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
