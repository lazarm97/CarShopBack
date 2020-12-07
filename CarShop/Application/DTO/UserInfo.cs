using Domain;
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
        public string Email { get; set; }
        public ICollection<AddressDto> Addresses { get; set; }
        public ICollection<MobileDto> Mobiles { get; set; }
    }

    public class MobileDto
    {
        public int Id { get; set; }
        public string Number { get; set; }
    }

    public class AddressDto
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
    }
}
