using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Color : BaseEntity
    {
        public string NameOfColor { get; set; }
        public ICollection<Car> Cars { get; set; }
    }
}
