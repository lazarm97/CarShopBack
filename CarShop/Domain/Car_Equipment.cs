using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Car_Equipment : BaseEntity
    {
        public Car Car { get; set; }
        public Equipment Equipment { get; set; }
    }
}
