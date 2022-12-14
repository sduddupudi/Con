using System;
using System.Collections.Generic;

namespace ConsumptionAPI.Models.DTO;

/// <summary>
/// Historique du type d&apos;énergie par véhicule
/// </summary>
public partial class VehicleEnergyType
{
    public long Id { get; set; }

    public int CompanyId { get; set; }

    public int VehicleId { get; set; }

    public DateTime Start { get; set; }

    public DateTime? End { get; set; }

    public int EnergyType { get; set; }

    public DateTime SysCreationTimeUtc { get; set; }

    public string SysCreationUser { get; set; } = null!;

    public DateTime SysLastUpdateTimeUtc { get; set; }

    public string SysLastUpdateUser { get; set; } = null!;
}
