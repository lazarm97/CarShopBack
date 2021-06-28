using Application.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Searches
{
    public class CarSearch : PagedSearch
    {
        public string CarName { get; set; }
        public string CarFilter { get; set; }
        public bool RecentAdded { get; set; } = false;
        public int IdBrand { get; set; }
        public int IdModel { get; set; }
        public int IdYearFrom { get; set; }
        public int IdYearTo { get; set; }
        public int IdCategory { get; set; }
        public int IdDoors { get; set; }
        public int IdFuel { get; set; }
        public int PriceFrom { get; set; }
        public int PriceTo { get; set; }
    }
}
