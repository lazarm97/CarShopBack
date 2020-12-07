using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Equipment : BaseEntity
    {
        public string NameOfEquipment { get; set; }
        public ICollection<Car_Equipment> CarEquipment { get; set; }
    }
}
