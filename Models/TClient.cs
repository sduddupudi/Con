using System;
using System.Collections.Generic;

namespace ConsumptionAPI.Models;

/// <summary>
/// Tables des clients
/// </summary>
public partial class TClient
{
    /// <summary>
    /// Identifiant du client dans la table
    /// </summary>
    public int IdClient { get; set; }

    /// <summary>
    /// Nom du client
    /// </summary>
    public string NomClient { get; set; } = null!;

    /// <summary>
    /// [Tech] Nom de la base de données du client
    /// </summary>
    public string Bddclient { get; set; } = null!;

    /// <summary>
    /// [Tech] Version de la base de données du client
    /// </summary>
    public int VersionBdd { get; set; }

    /// <summary>
    /// Indique si le client est actif ou non
    /// </summary>
    public bool? Actif { get; set; }

    /// <summary>
    /// Date de création de l&apos;enregistrement dans la base de données
    /// </summary>
    public DateTime DateInsert { get; set; }

    /// <summary>
    /// Date de dernière modification de l&apos;enregistrement dans la base de données
    /// </summary>
    public DateTime DateUpdate { get; set; }

    /// <summary>
    /// [Tech] Numéro de lot pour les traitements de consolidation
    /// </summary>
    public byte BddlotTraitement { get; set; }

    /// <summary>
    /// [Settings] Coefficient de conversion du TMAVA en minutes au TMAVA en litres
    /// </summary>
    public double CoefTmava { get; set; }

    /// <summary>
    /// [Settings] Distance minimum parcourue pour la prise en compte de la consommation
    /// </summary>
    public double SeuilConsoKm { get; set; }

    /// <summary>
    /// [Obsolete]
    /// </summary>
    public short NbJourVeqMois { get; set; }

    /// <summary>
    /// [Settings] Nombre de jours pris en compte pour le calcul du TMAVA equivalent sur l&apos;année
    /// </summary>
    public short NbJourVeqAnnee { get; set; }

    /// <summary>
    /// [Obsolete]
    /// </summary>
    public bool AfficherPleins { get; set; }

    /// <summary>
    /// [Settings] Seuil minimum pour la détection de vol
    /// </summary>
    public int? SensibiliteLitrePourVol { get; set; }

    /// <summary>
    /// [Obsolete]
    /// </summary>
    public int? SensibiliteVitessePourVol { get; set; }

    /// <summary>
    /// [Settings] Volume minimum pour la prise e n compte d&apos;un plein sur un petit réservoir (Reservoir &lt; 200L)
    /// </summary>
    public int? SeuilPleinPetitReservoir { get; set; }

    /// <summary>
    /// [Settings] Volume minimum pour la prise e n compte d&apos;un plein sur un grand réservoir (Reservoir &gt; 200L)
    /// </summary>
    public int? SeuilPleinGrandReservoir { get; set; }

    /// <summary>
    /// [Settings] Coefficient de conversion des litres en Co2
    /// </summary>
    public double? TeqCombustion { get; set; }

    /// <summary>
    /// [Obsolete]
    /// </summary>
    public DateTime? DateMinInterfaceEcotaxe { get; set; }

    /// <summary>
    /// [Obsolete]
    /// </summary>
    public string IntituleCompte { get; set; } = null!;

    /// <summary>
    /// [Obsolete]
    /// </summary>
    public string LicenceCompte { get; set; } = null!;

    /// <summary>
    /// [Obsolete]
    /// </summary>
    public string EmailContact { get; set; } = null!;

    /// <summary>
    /// [Obsolete]
    /// </summary>
    public int? TypeCompte { get; set; }

    /// <summary>
    /// Etat du compte
    /// </summary>
    public int? StatutCompte { get; set; }

    /// <summary>
    /// Date de mise à  jour de l&apos;enregistrement
    /// </summary>
    public DateTime? DateMajcompte { get; set; }

    /// <summary>
    /// [Obsolete]
    /// </summary>
    public string AuteurMaj { get; set; } = null!;

    /// <summary>
    /// [Settings] Seuil en minutes pour la prise en compte d&apos;un TMAVA
    /// </summary>
    public int SeuilTmavamini { get; set; }

    /// <summary>
    /// [Settings] Seuil minimum pour l&apos;emmission d&apos;alerte TMAVA
    /// </summary>
    public int SeuilAlerteTmavamini { get; set; }

    /// <summary>
    /// [Settings] Temps minimum en minutes pour l&apos;envoie d&apos;alerte email
    /// </summary>
    public int DelaiAlerteTmava { get; set; }

    /// <summary>
    /// [Settings] Temps minimum en minutes pour l&apos;envoie d&apos;alerte email
    /// </summary>
    public int DelaiAlerteVol { get; set; }

    /// <summary>
    /// [Settings] 
    /// </summary>
    public DateTime DateMinAlerte { get; set; }

    /// <summary>
    /// [Obsolete] Instance sur laquelle se trouve la base de données du client
    /// </summary>
    public string Bddinstance { get; set; } = null!;

    /// <summary>
    /// La base est en maintenance
    /// </summary>
    public bool Bddmaintenance { get; set; }

    /// <summary>
    /// [Obsolete] Identifiant du domaine de valeur &quot;StatutClient&quot;
    /// </summary>
    public int IdDomStatutClient { get; set; }

    /// <summary>
    /// [Obsolete] 
    /// </summary>
    public DateTime? Bddcreation { get; set; }

    /// <summary>
    /// Identifiant de SalesForce
    /// </summary>
    public string IdSalesForce { get; set; } = null!;

    /// <summary>
    /// [Settings] Seuil d&apos;alerte batterie condition optimale moteur tournant (27200 mV)
    /// </summary>
    public int SeuilAlerteBatterie0 { get; set; }

    /// <summary>
    /// [Settings] Seuil d&apos;alerte batterie condition optimale moteur à l&apos;arrêt (25200 mV)
    /// </summary>
    public int SeuilAlerteBatterie1 { get; set; }

    /// <summary>
    /// [Settings] Seuil d&apos;alerte batterie accumulateur à recharger (23600 mV)
    /// </summary>
    public int SeuilAlerteBatterie2 { get; set; }

    /// <summary>
    /// [Settings] Délai en min entre 2 alertes batterie
    /// </summary>
    public int DelaiAlerteBatterie { get; set; }

    /// <summary>
    /// [Settings] Seuil d&apos;alerte Stock
    /// </summary>
    public int SeuilAlerteStock { get; set; }

    /// <summary>
    /// [Settings] Seuile d&apos;alerte coupe-circuit (1000 mV)
    /// </summary>
    public int SeuilAlerteCoupeCircuit { get; set; }

    /// <summary>
    /// [Settings] Délai en min entre 2 alertes stock
    /// </summary>
    public int DelaiAlerteStock { get; set; }

    /// <summary>
    /// Durée en secondes de la période avant émission del l&apos;alerte sirène
    /// </summary>
    public int PeriodeSirene { get; set; }

    /// <summary>
    /// [Settings] Débit minium pour détection d&apos;un plein
    /// </summary>
    public double DebitMinPlein { get; set; }

    /// <summary>
    /// [Settings] Débit minium pour détection d&apos;un vol
    /// </summary>
    public double DebitMinVol { get; set; }

    /// <summary>
    /// [Settings] Débit minium pour le déclenchement de l&apos;alerte Sirène
    /// </summary>
    public double DebitMinSirene { get; set; }

    /// <summary>
    /// [Settings] Heure debut de la plage d&apos;émission d&apos;alerte en semaine
    /// </summary>
    public TimeSpan HeureDebut { get; set; }

    /// <summary>
    /// [Settings] heure Fin de la plage d&apos;émission d&apos;alerte en semaine
    /// </summary>
    public TimeSpan HeureFin { get; set; }

    /// <summary>
    /// [Settings] Indique si l&apos;alerte sirène est active durant tout le week-end (24h/24) ou non
    /// </summary>
    public bool SonnerieWe { get; set; }

    /// <summary>
    /// [Settings] Date à partir de laquelle le traitement de consommation de reference doit être appliqué sur le compte client (Si NULL pas de traitement)
    /// </summary>
    public DateTime? DateConsoRef { get; set; }

    /// <summary>
    /// [Settings] Seuil Min de consommation pour la conso chauffeur
    /// </summary>
    public double? SeuilChauffeurConsoMin { get; set; }

    /// <summary>
    /// [Settings] Seuil Max de consommation pour la conso chauffeur
    /// </summary>
    public double? SeuilChauffeurConsoMax { get; set; }

    /// <summary>
    /// [Settings] Seuil Min de distance pour la conso chauffeur
    /// </summary>
    public double? SeuilChauffeurDistanceMin { get; set; }

    /// <summary>
    /// [Settings] Active ou non l&apos;option EcoConduite dans AGPRO
    /// </summary>
    public bool EcoConduiteOption { get; set; }

    /// <summary>
    /// [Settings] Valeur maximum pour les scores EcoConduite
    /// </summary>
    public int? EcoConduiteScoreMax { get; set; }

    /// <summary>
    /// [Settings] Prix au litre du carburant
    /// </summary>
    public double? FuelCost { get; set; }

    /// <summary>
    /// [Settings] 	Durée a partir de laquelle on considÃ¨re une coupure
    /// </summary>
    public int? MissingBreakingDurationInSecond { get; set; }

    /// <summary>
    /// [Settings] 	Nombre de jours pris en compte pour le calcul de la conso moyenne
    /// </summary>
    public int? AverageConsoCalculationPeriodReferenceInDays { get; set; }

    /// <summary>
    /// [Settings] 	Option eco-consuite (Stabilité vitesse)
    /// </summary>
    public int? DailyCruiseTimeThresholdInSecond { get; set; }

    public bool? MaintenanceBatch { get; set; }

    public bool? LunchBox { get; set; }

    public string? CustomField1 { get; set; }

    public string? CustomField2 { get; set; }

    public string? CustomField3 { get; set; }

    public string TimeZoneId { get; set; } = null!;

    public bool? DaylightSaving { get; set; }

    public int? PaysId { get; set; }

    public bool? IdleTimeSmsDriverNotification { get; set; }

    public int WorkingDays { get; set; }

    public string CountryCode { get; set; } = null!;

    public bool EnableHolidays { get; set; }

    /// <summary>
    /// [Settings] the company has a tacofresh account
    /// </summary>
    public bool? HasTacofresh { get; set; }

    /// <summary>
    /// [Settings] the driver has a TacofreshIdentifier
    /// </summary>
    public string? TacofreshIdentifier { get; set; }

    public int? MinOperationTimeForActivityInMinute { get; set; }

    public bool? VehicleNotCalibratedHidden { get; set; }

    public int? ThresholdSuspicionTheftInStop { get; set; }
}
