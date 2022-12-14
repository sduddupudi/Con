using System;
using System.Collections.Generic;

namespace ConsumptionAPI.Models.Domain;

public partial class VehicleStat
{
    public double Refueling { get; set; }

    public int Id { get; set; }

    public int CompanyId { get; set; }

    public int VehicleId { get; set; }

    public DateTime PeriodMin { get; set; }

    public DateTime? PeriodMax { get; set; }

    public DateTime FirstFrame { get; set; }

    public DateTime LastFrame { get; set; }

    public DateTime TimestampUtcFirst { get; set; }

    public DateTime TimestampUtcLast { get; set; }

    public int ConsumptionDistance { get; set; }

    public double ConsumptionVolume { get; set; }

    public double? ConsumptionRef { get; set; }

    public long? ConsumptionRefMask { get; set; }

    public double ComsumptionByHour { get; set; }

    public double AverageSpeed { get; set; }

    public double TeqCo2 { get; set; }

    public int DistanceTachoGps { get; set; }

    public long? DistanceTachoGpsfull { get; set; }

    public int GpsDistanceFirst { get; set; }

    public int GpsDistanceLast { get; set; }

    public long? FirstIndex { get; set; }

    public long? LastIndex { get; set; }

    public long IndexCorrection { get; set; }

    public double StockMoving { get; set; }

    public double StockStationary { get; set; }

    public int FrameCountMoving { get; set; }

    public int FrameCountStationary { get; set; }

    public bool DaysOfActivity { get; set; }

    public double VolumeStart { get; set; }

    public double VolumeEnd { get; set; }

    public DateTime SysCreationTimeUtc { get; set; }

    public DateTime SysLastUpdateTimeUtc { get; set; }

    public string SysUser { get; set; } = null!;

    public string SysApplication { get; set; } = null!;

    public long? EngineOnDuration { get; set; }

    public int? Gpsdistance { get; set; }

    public long? GpsindexEnd { get; set; }

    public double? AverageConsumption { get; set; }

    public double? DailyDistance { get; set; }

    public int? GpsmissingDistance { get; set; }

    public long? GpsindexEndCaughtUp { get; set; }

    public double? MissingVolume { get; set; }

    public long? PtoonDuration { get; set; }
}
