using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO
{
    public class AddressCreateDto
    {
        public int AdminId { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
    }
}
