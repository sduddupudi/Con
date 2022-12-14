using System;
using System.Collections.Generic;

namespace ConsumptionAPI.Models.Domain;

public partial class TotalFuelUsed
{
    public long Id { get; set; }

    public DateTime TimestampUtc { get; set; }

    public long Imei { get; set; }

    public long? LowRes { get; set; }

    public long? HiRes { get; set; }
}
