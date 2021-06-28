using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Searches
{
    public class ReservationSearch
    {
        public int IdUser { get; set; }
        public bool OnlyExpired { get; set; } = false;
    }
}
