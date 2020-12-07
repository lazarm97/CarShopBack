using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Mobile : BaseEntity
    {
        public Admin Admin { get; set; }
        public string Number { get; set; }
    }
}
