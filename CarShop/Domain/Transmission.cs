using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Transmission : BaseEntity
    {
        public string Type { get; set; }
        public ICollection<Car> Cars { get; set; }
    }
}
