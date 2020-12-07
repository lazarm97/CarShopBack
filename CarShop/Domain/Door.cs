using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Door : BaseEntity
    {
        public string NumberOfDoors { get; set; }
        public ICollection<Car> Cars { get; set; }
    }
}
