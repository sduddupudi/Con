using System;
using System.Collections.Generic;

namespace ConsumptionAPI.Models.Domain;

public partial class VTrace
{
    public long Idtraces { get; set; }

    public DateTime? DateTraces { get; set; }

    public string? SerialBoitier { get; set; }

    public int? Idfvehicule { get; set; }

    public DateTime? DateUtcTraces { get; set; }

    public double? DistanceParcourue { get; set; }

    public string? Moteur { get; set; }

    public string? Ignition { get; set; }

    public float? RegimeMoteur { get; set; }

    public double? FuelSender1 { get; set; }

    public double? FuelSender2 { get; set; }

    public double? ResteR1 { get; set; }

    public double? ResteR2 { get; set; }

    public double? SommeReste { get; set; }

    public string? Lattitude { get; set; }

    public string? Longitude { get; set; }

    public byte StatutJauge1 { get; set; }

    public byte StatutJauge2 { get; set; }

    public short Altitude { get; set; }

    public bool Tor3 { get; set; }

    public bool Tor4 { get; set; }

    public long? AlerteConso { get; set; }

    public float IndexKm { get; set; }

    public string? SenseurMasse { get; set; }

    public float? VitesseTachy { get; set; }

    public float VitesseGps { get; set; }

    public double? VitesseKmh { get; set; }

    public short? QualiteSignalGsm { get; set; }

    public short? QualiteSignalGps { get; set; }

    public long? Plein { get; set; }

    public long? Fraude { get; set; }

    public bool ValidFraude { get; set; }

    public bool? ConnexionGprs { get; set; }

    public string? AlimentationPrincipale { get; set; }

    public string? AlimentationAux { get; set; }

    public string? GpsonOff { get; set; }

    public bool ConnexionTachy { get; set; }

    public string? SenseurVoltage { get; set; }

    public int? TensionAlimentation { get; set; }

    public int? DelaiReception { get; set; }

    public short Cap { get; set; }

    public int? TempsEcouleDernierTrame { get; set; }
}
