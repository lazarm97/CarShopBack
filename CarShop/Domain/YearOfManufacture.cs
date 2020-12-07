using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class YearOfManufacture : BaseEntity
    {
        public int Year { get; set; }
        public ICollection<Car> Cars { get; set; }
    }
}
