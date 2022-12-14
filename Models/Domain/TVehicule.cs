using System;
using System.Collections.Generic;

namespace ConsumptionAPI.Models.Domain;

/// <summary>
/// Tables des véhicules gérés par AlertGasoil
/// </summary>
public partial class TVehicule
{
    /// <summary>
    /// Identifiant du véhicule dans la table
    /// </summary>
    public int IdVehicule { get; set; }

    /// <summary>
    /// [Evol] Immatriculation du véhicule ( saisie par le client )
    /// </summary>
    public string Immatriculation { get; set; }

    /// <summary>
    /// Identifiant du site
    /// </summary>
    public int? IdSite { get; set; }

    /// <summary>
    /// Identifiant du réservoir n°1
    /// </summary>
    public int? Reservoir1 { get; set; }

    /// <summary>
    /// Identifiant du réservoir n°2
    /// </summary>
    public int? Reservoir2 { get; set; }

    /// <summary>
    /// [Calc] Nombre de réservoirs équipant ce véhicule
    /// </summary>
    public int? NbReservoirs { get; set; }

    /// <summary>
    /// Numéro de chassis du véhicule
    /// </summary>
    public string NumChassis { get; set; } = null!;

    /// <summary>
    /// Année de fabrication du véhicule
    /// </summary>
    public int? AnneeFabrication { get; set; }

    /// <summary>
    /// [Obsolete] Facteur kilométrique du véhicule
    /// </summary>
    public int? FacteurK { get; set; }

    /// <summary>
    /// Indique si une prise FMS est détecté
    /// </summary>
    public bool Fms { get; set; }

    /// <summary>
    /// [Obsolete] Indique si un espace est disponible entre le reservoir et la caisse
    /// </summary>
    public bool EspaceCaisseReservoir { get; set; }

    /// <summary>
    /// Identifiant du modèle de véhicule
    /// </summary>
    public int? IdModele { get; set; }

    /// <summary>
    /// [Evol] Indique si le véhicule est actif ou non
    /// </summary>
    public bool? Actif { get; set; }

    /// <summary>
    /// [Evol] Commentaire sur le véhicule (devrait etre géré par l&apos;historique)
    /// </summary>
    public string Commentaire { get; set; } = null!;

    /// <summary>
    /// [Obsolete] URL du fichier image dans le référentiel fichier des photos
    /// </summary>
    public string UrlPhoto { get; set; } = null!;

    /// <summary>
    /// [Obsolete] Identifiant du type de véhicule (CodeDomaine=TypesVehicules)
    /// </summary>
    public int? IdDomTypeVehicule { get; set; }

    /// <summary>
    /// Identifiant du tachyographe numérique (CodeDomaine=Tachy)
    /// </summary>
    public int? IdDomTachy { get; set; }

    /// <summary>
    /// [Evol] Indique si le montage du système AlertGasoil a été validé par l&apos;installateur ou non.
    /// </summary>
    public bool Valide { get; set; }

    /// <summary>
    /// Date de création de l&apos;enregistrement dans la base de données
    /// </summary>
    public DateTime DateInsert { get; set; }

    /// <summary>
    /// Date de dernière modification de l&apos;enregistrement dans la base de données
    /// </summary>
    public DateTime DateUpdate { get; set; }

    /// <summary>
    /// Numéro du véhicule dans le Parc
    /// </summary>
    public string NumParc { get; set; } = null!;

    /// <summary>
    /// [Calc] Immatriculation nettoyée de tous les caractères qui ne sont ni des chiffres ni des lettres. Ce champ est unique.
    /// </summary>
    public string? CodeImmatriculation { get; set; }

    /// <summary>
    /// [Obsolete]
    /// </summary>
    public string? Telephone { get; set; }

    /// <summary>
    /// [Settings]
    /// </summary>
    public bool? EmissionAlerteTmava { get; set; }

    /// <summary>
    /// [Settings]
    /// </summary>
    public bool? EmissionAlerteVol { get; set; }

    /// <summary>
    /// [Settings] Si vrai, le vehicule emet des alertes Sirene
    /// </summary>
    public bool EmissionAlerteSirene { get; set; }

    /// <summary>
    /// [Evol] VehiculeStatus from T_DomaineValeur
    /// </summary>
    public int IdDomVehicleStatus { get; set; }

    /// <summary>
    /// [Settings] Indique si la détection du Moteur via la tension doit être appliquée ou non (1=Non ; 2=Tension ; 3=Tension+IgnitionON)
    /// </summary>
    public int IdDomDetectionMoteur { get; set; }

    /// <summary>
    /// [Settings] Autorise ou non l&apos;émission d&apos;alertes stock pour ce véhicule
    /// </summary>
    public bool? EmissionAlerteStock { get; set; }

    /// <summary>
    /// [Settings] Autorise ou non l&apos;émission d&apos;alertes batterie pour ce véhicule
    /// </summary>
    public bool? EmissionAlerteBatterie { get; set; }

    /// <summary>
    /// [Settings] Durée en secondes de la période avant émission del l&apos;alerte sirène
    /// </summary>
    public int? PeriodeSirene { get; set; }

    /// <summary>
    /// [Settings] Débit minium pour détection d&apos;un plein
    /// </summary>
    public double? DebitMinPlein { get; set; }

    /// <summary>
    /// [Settings] Débit minium pour détection d&apos;un vol
    /// </summary>
    public double? DebitMinVol { get; set; }

    /// <summary>
    /// [Settings] Débit minium pour le déclenchement de l&apos;alerte Sirène
    /// </summary>
    public double? DebitMinSirene { get; set; }

    /// <summary>
    /// [Settings] Heure debut de la plage d&apos;émission d&apos;alerte en semaine
    /// </summary>
    public TimeSpan? HeureDebut { get; set; }

    /// <summary>
    /// [Settings] heure Fin de la plage d&apos;émission d&apos;alerte en semaine
    /// </summary>
    public TimeSpan? HeureFin { get; set; }

    /// <summary>
    /// [Settings] Indique si l&apos;alerte sirène est active durant tout le week-end (24h/24) ou non
    /// </summary>
    public bool? SonnerieWe { get; set; }

    /// <summary>
    /// [Settings] Consommation de reference fixée arbitrairement pour initialiser le cacul de consommation de référence
    /// </summary>
    public double? ConsoRef0 { get; set; }

    /// <summary>
    /// [Settings]
    /// </summary>
    public decimal? GpsspeedMeanThreshold { get; set; }

    /// <summary>
    /// Activité du véhicule
    /// </summary>
    public int? Category { get; set; }

    /// <summary>
    /// Tracteur / Porteur
    /// </summary>
    public int? Type { get; set; }

    /// <summary>
    /// [Obsolete]
    /// </summary>
    public DateTime? InstallationDate { get; set; }

    /// <summary>
    /// Index Km au jour de l&apos;installation
    /// </summary>
    public long? InstallIndex { get; set; }

    /// <summary>
    /// Date du relevé d&apos;index
    /// </summary>
    public DateTime? InstallIndexTimestampUtc { get; set; }

    /// <summary>
    /// [Settings]
    /// </summary>
    public int? Rpmthreshold { get; set; }

    /// <summary>
    /// [Settings]
    /// </summary>
    public int? MaxSpeedAuthorized { get; set; }

    /// <summary>
    /// [Settings]
    /// </summary>
    public int? AcceleratorPositionThreshold { get; set; }

    /// <summary>
    /// [Settings]
    /// </summary>
    public int? DecelerationThreshold { get; set; }

    /// <summary>
    /// [Settings]
    /// </summary>
    public int? CruiseSpeedCoefficient { get; set; }

    /// <summary>
    /// [Settings] [AlertV2]
    /// </summary>
    public bool? SlowTheftAlertOn { get; set; }

    /// <summary>
    /// [Settings] [AlertV2]
    /// </summary>
    public int? SlowTheftMinVolumeThreshold { get; set; }

    /// <summary>
    /// [Settings] [AlertV2]
    /// </summary>
    public bool? IdleTimeAlertOn { get; set; }

    /// <summary>
    /// [Settings] [AlertV2]
    /// </summary>
    public int? IdleTimeAlertMinTimeThreshold { get; set; }

    /// <summary>
    /// [Settings] [AlertV2]
    /// </summary>
    public int? IdleTimeAlertPauseInterval { get; set; }

    /// <summary>
    /// [Settings] [AlertV2]
    /// </summary>
    public int? IdleTimeHornActivationTimeSpan { get; set; }

    /// <summary>
    /// [Settings] [AlertV2]
    /// </summary>
    public bool? CableCutAlertOn { get; set; }

    /// <summary>
    /// [Settings] [AlertV2]
    /// </summary>
    public int? CableCutAlertMinTimeThreshold { get; set; }

    /// <summary>
    /// [Settings] [AlertV2]
    /// </summary>
    public bool? IdleTimeAlertHornActivation { get; set; }

    /// <summary>
    /// [Settings] [AlertV2]
    /// </summary>
    public bool? CableCutAlertHornActivation { get; set; }

    /// <summary>
    /// [Settings] [AlertV2]
    /// </summary>
    public int? CableCutHornActivationTimeSpan { get; set; }

    /// <summary>
    /// [Settings]
    /// </summary>
    public int? SeuilMiniPeriodeEnMin { get; set; }

    public bool? ConnectedFms { get; set; }

    public bool? PermanentPhase { get; set; }

    public bool? TachoFreshEquiped { get; set; }

    public int? TachyConnectedState { get; set; }

    public long? LastTankEntryId { get; set; }

    public bool? Fmsdetected { get; set; }

    public bool? ExportD8data { get; set; }

    public int GearBox { get; set; }

    public int? EnginePower { get; set; }

    public long? TachoFreshImei { get; set; }

    public int? Ptac { get; set; }

    public int Metier { get; set; }

    /// <summary>
    /// [Settings] d�termine si le v�hicule doit passer dans l&apos;auto calibration
    /// </summary>
    public bool? NotCalibrable { get; set; }

    /// <summary>
    /// [Settings] détermine si le véhicule possède un boitier Inventure
    /// </summary>
    public bool? InventureEquiped { get; set; }

    public bool? UseConstructorGauges { get; set; }

    public int ActivityDetectionForConsumptionType { get; set; }

    public int? MinOperationTimeForActivityInMinute { get; set; }

    public DateTime? FirstDateOfCalibration { get; set; }

    public long? HorometerIndex { get; set; }

    public DateTime? HorometerDate { get; set; }

    public long? WorkTimeIndex { get; set; }

    public DateTime? WorkTimeIndexDate { get; set; }

    public int? DriverIdentificationSystem { get; set; }

    public bool? DrivingBuzzer { get; set; }

    public int? Rdlconnection { get; set; }

    public bool? Simslot1HasSim { get; set; }

    public bool? Simslot2HasSim { get; set; }

    public bool? HornAlertEnabled { get; set; }

    public bool? EmbeddedTheftDetectionEnabled { get; set; }

    public int? PtodetectionType { get; set; }

    public int? DefaultEnergyQuantitySourceForConsumptionCalculation { get; set; }

    public bool? PermanentPto { get; set; }
}
