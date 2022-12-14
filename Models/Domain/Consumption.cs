using System;

namespace ConsumptionAPI.Models.Domain
{
    public class Consumption
    {
        public int? TotalVolume { get; set; }
        public int? TotalDistance { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? EnergyType { get; set; }

    }
}
