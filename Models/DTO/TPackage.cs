using System;
using System.Collections.Generic;

namespace ConsumptionAPI.Models.DTO;

/// <summary>
/// Tables des véhicules gérés par AlertGasoil
/// </summary>
public partial class TPackage
{
    /// <summary>
    /// Identifiant du package dans la table
    /// </summary>
    public int IdPackage { get; set; }

    /// <summary>
    /// Date de création du package
    /// </summary>
    public DateTime DatePackage { get; set; }

    /// <summary>
    /// Identifiant du véhicule sur lequel est installé le package
    /// </summary>
    public int? IdVehicule { get; set; }

    /// <summary>
    /// Numéro de série du boitier associé à ce package
    /// </summary>
    public string? SerialBoitier { get; set; }

    /// <summary>
    /// [Obsolete] Indique si le suivi par mail est activé pour ce package
    /// </summary>
    public bool SuiviMail { get; set; }

    /// <summary>
    /// [Evol] Commentaire sur le package (doit etre géré par l&apos;historisation)
    /// </summary>
    public string? Commentaire { get; set; }

    /// <summary>
    /// Numéro de carte SIM associé à ce package
    /// </summary>
    public string? NumSim { get; set; }

    /// <summary>
    /// Date de début d&apos;activité du package
    /// </summary>
    public DateTime? DebutActif { get; set; }

    /// <summary>
    /// Date de fin d&apos;activité du package.
    ///    ATTENTION : le package est considéré comme inactif SSI le champ FinActif est saisi (i.e différent de NULL) il n&apos;y a pas de contrôle sur l&apos;antériorité vis-à-vis de la date du jour.
    /// </summary>
    public DateTime? FinActif { get; set; }

    /// <summary>
    /// [Obsolete] Indique si le package est relié à une prise Gen10400
    /// </summary>
    public bool? Gen10400 { get; set; }

    /// <summary>
    /// Numéro IMEI du modem associé à ce package
    /// </summary>
    public string? Imei { get; set; }

    /// <summary>
    /// [Obsolete] Indique si le package est relié à la prise de freins ou non.
    /// </summary>
    public bool PriseFreins { get; set; }

    /// <summary>
    /// [Obsolete] Indique si le package est relié à la prise odomètre ou non.
    /// </summary>
    public bool PriseOdometre { get; set; }

    /// <summary>
    /// [Evol] Indique si le package est relié à la prise de force ou non. 
    /// Valeur possibles (0 - Non branchée, 1 - Branchée signal normal, -1 Branchée signal inversé) 
    /// Règle de calcul : (Signal et (PFinv &lt;&gt; 00)) xor (PFinv &lt; 0)
    /// </summary>
    public short PriseForce { get; set; }

    /// <summary>
    /// Date de création de l&apos;enregistrement dans la base de données
    /// </summary>
    public DateTime DateInsert { get; set; }

    /// <summary>
    /// Date de dernière modification de l&apos;enregistrement dans la base de données
    /// </summary>
    public DateTime DateUpdate { get; set; }

    /// <summary>
    /// [Evol] Si vrai, le vehicule est equipe de la sirene
    /// </summary>
    public bool Sirene { get; set; }

    public int? PriseForceType { get; set; }
}
