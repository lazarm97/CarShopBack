using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Fuel : BaseEntity
    {
        public string NameOfFuel { get; set; }
        public ICollection<Car> Cars { get; set; }
    }
}
