using System;
using System.Collections.Generic;

namespace ConsumptionAPI.Models.DTO;

public partial class VehicleStat
{

    public double VolumeStart { get; set; } 

    public double VolumeEnd { get; set; } 

    public double Refueling { get; set; }
    public int GpsDistanceFirst { get; set; }

    public long? FirstIndex { get; set; }

    public long? LastIndex { get; set; }

    public long? GpsindexEnd { get; set; }

    public int VehicleId { get; set; }

    public DateTime PeriodMin { get; set; }

    public DateTime? PeriodMax { get; set; }

    public int Id { get; set; }

    public int CompanyId { get; set; }

}
