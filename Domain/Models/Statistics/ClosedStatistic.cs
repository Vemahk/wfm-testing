using System;

namespace Domain.Models.Statistics
{
    public class ClosedStatistic : BaseWfmObject
    {
        public DateTime Time { get; set; }
        public int Volume { get; set; }
    }
}
