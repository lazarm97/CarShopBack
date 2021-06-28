using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Address : BaseEntity
    {
        public string City { get; set; }
        public string Street { get; set; }
    }
}
