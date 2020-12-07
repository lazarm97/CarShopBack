using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Domain
{
    public class Model : BaseEntity
    {
        public string Name { get; set; }
        public Brand Brand { get; set; }
        public ICollection<Car> Cars { get; set; }
    }
}
