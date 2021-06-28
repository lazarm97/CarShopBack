using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Mobile : BaseEntity
    {
        public User User { get; set; }
        public string Number { get; set; }
    }
}
