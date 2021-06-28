using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO
{
    public class ReservationsStatisticDto
    {
        public IEnumerable<StatisticDto> Statistic { get; set; }
    }

    public class StatisticDto
    {
        public string State { get; set; }
        public int Count { get; set; }
    }
}
