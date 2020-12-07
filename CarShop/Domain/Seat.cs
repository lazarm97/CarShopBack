using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Seat : BaseEntity
    {
        public int NumberOfSeats { get; set; }
        public ICollection<Car> Cars { get; set; }
    }
}
