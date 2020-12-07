using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Image : BaseEntity
    {
        public string Alt { get; set; }
        public string Src { get; set; }
        public Car Car { get; set; }
    }
}
