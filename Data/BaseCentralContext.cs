using System;
using System.Collections.Generic;
using ConsumptionAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace ConsumptionAPI.Data;

public partial class BaseCentralContext : DbContext
{
    public BaseCentralContext()
    {
    }

    public BaseCentralContext(DbContextOptions<BaseCentralContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TClient> TClients { get; set; }

    public virtual DbSet<TPackage> TPackages { get; set; }

    public virtual DbSet<VehicleEnergyType> VehicleEnergyTypes { get; set; }

    public virtual DbSet<TVehicule> TVehicules { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=recette-sql-01.alertgasoil.corp;Database=BaseCentraleADD; user id=s.duddupudi; password=DUDDUPUDI!2022!");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TClient>(entity =>
        {
            entity.HasKey(e => e.IdClient);

            entity.ToTable("T_Clients", tb =>
                {
                    tb.HasComment("Tables des clients");
                    tb.HasTrigger("TRG_Clients_Insert");
                    tb.HasTrigger("TRG_Clients_Insert_CreateGroup");
                    tb.HasTrigger("TRG_Clients_Update");
                });

            entity.HasIndex(e => e.Actif, "IDX_T_Clients_Actif");

            entity.HasIndex(e => e.Bddclient, "IDX_T_Clients_BDDClient");

            entity.Property(e => e.IdClient).HasComment("Identifiant du client dans la table");
            entity.Property(e => e.Actif)
                .IsRequired()
                .HasDefaultValueSql("((1))")
                .HasComment("Indique si le client est actif ou non");
            entity.Property(e => e.AfficherPleins).HasComment("[Obsolete]");
            entity.Property(e => e.AuteurMaj)
                .HasMaxLength(50)
                .HasDefaultValueSql("('')")
                .HasComment("[Obsolete]")
                .HasColumnName("AuteurMAJ");
            entity.Property(e => e.AverageConsoCalculationPeriodReferenceInDays)
                .HasDefaultValueSql("((30))")
                .HasComment("[Settings] 	Nombre de jours pris en compte pour le calcul de la conso moyenne");
            entity.Property(e => e.Bddclient)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasComment("[Tech] Nom de la base de données du client")
                .HasColumnName("BDDClient");
            entity.Property(e => e.Bddcreation)
                .HasComment("[Obsolete] ")
                .HasColumnType("datetime")
                .HasColumnName("BDDCreation");
            entity.Property(e => e.Bddinstance)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasComment("[Obsolete] Instance sur laquelle se trouve la base de données du client")
                .HasColumnName("BDDInstance");
            entity.Property(e => e.BddlotTraitement)
                .HasComment("[Tech] Numéro de lot pour les traitements de consolidation")
                .HasColumnName("BDDLotTraitement");
            entity.Property(e => e.Bddmaintenance)
                .HasComment("La base est en maintenance")
                .HasColumnName("BDDMaintenance");
            entity.Property(e => e.CoefTmava)
                .HasComment("[Settings] Coefficient de conversion du TMAVA en minutes au TMAVA en litres")
                .HasColumnName("CoefTMAVA");
            entity.Property(e => e.CountryCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasDefaultValueSql("('FR')");
            entity.Property(e => e.CustomField1).HasMaxLength(255);
            entity.Property(e => e.CustomField2).HasMaxLength(255);
            entity.Property(e => e.CustomField3).HasMaxLength(255);
            entity.Property(e => e.DailyCruiseTimeThresholdInSecond).HasComment("[Settings] 	Option eco-consuite (Stabilité vitesse)");
            entity.Property(e => e.DateConsoRef)
                .HasDefaultValueSql("(getdate())")
                .HasComment("[Settings] Date à partir de laquelle le traitement de consommation de reference doit être appliqué sur le compte client (Si NULL pas de traitement)")
                .HasColumnType("datetime");
            entity.Property(e => e.DateInsert)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date de création de l'enregistrement dans la base de données")
                .HasColumnType("datetime");
            entity.Property(e => e.DateMajcompte)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date de mise à  jour de l'enregistrement")
                .HasColumnType("datetime")
                .HasColumnName("DateMAJCompte");
            entity.Property(e => e.DateMinAlerte)
                .HasDefaultValueSql("('20140528')")
                .HasComment("[Settings] ")
                .HasColumnType("datetime");
            entity.Property(e => e.DateMinInterfaceEcotaxe)
                .HasComment("[Obsolete]")
                .HasColumnType("datetime");
            entity.Property(e => e.DateUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date de dernière modification de l'enregistrement dans la base de données")
                .HasColumnType("datetime");
            entity.Property(e => e.DaylightSaving)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.DebitMinPlein)
                .HasDefaultValueSql("((8.0))")
                .HasComment("[Settings] Débit minium pour détection d'un plein");
            entity.Property(e => e.DebitMinSirene)
                .HasDefaultValueSql("((8.0))")
                .HasComment("[Settings] Débit minium pour le déclenchement de l'alerte Sirène");
            entity.Property(e => e.DebitMinVol)
                .HasDefaultValueSql("((8.0))")
                .HasComment("[Settings] Débit minium pour détection d'un vol");
            entity.Property(e => e.DelaiAlerteBatterie)
                .HasDefaultValueSql("((30))")
                .HasComment("[Settings] Délai en min entre 2 alertes batterie");
            entity.Property(e => e.DelaiAlerteStock)
                .HasDefaultValueSql("((30))")
                .HasComment("[Settings] Délai en min entre 2 alertes stock");
            entity.Property(e => e.DelaiAlerteTmava)
                .HasComment("[Settings] Temps minimum en minutes pour l'envoie d'alerte email")
                .HasColumnName("DelaiAlerteTMAVA");
            entity.Property(e => e.DelaiAlerteVol).HasComment("[Settings] Temps minimum en minutes pour l'envoie d'alerte email");
            entity.Property(e => e.EcoConduiteOption).HasComment("[Settings] Active ou non l'option EcoConduite dans AGPRO");
            entity.Property(e => e.EcoConduiteScoreMax)
                .HasDefaultValueSql("((10))")
                .HasComment("[Settings] Valeur maximum pour les scores EcoConduite");
            entity.Property(e => e.EmailContact)
                .HasMaxLength(50)
                .HasDefaultValueSql("('')")
                .HasComment("[Obsolete]");
            entity.Property(e => e.FuelCost)
                .HasDefaultValueSql("((1.0123))")
                .HasComment("[Settings] Prix au litre du carburant");
            entity.Property(e => e.HasTacofresh).HasComment("[Settings] the company has a tacofresh account");
            entity.Property(e => e.HeureDebut)
                .HasDefaultValueSql("('22:00:00')")
                .HasComment("[Settings] Heure debut de la plage d'émission d'alerte en semaine");
            entity.Property(e => e.HeureFin)
                .HasDefaultValueSql("('07:00:00')")
                .HasComment("[Settings] heure Fin de la plage d'émission d'alerte en semaine");
            entity.Property(e => e.IdDomStatutClient)
                .HasDefaultValueSql("((1))")
                .HasComment("[Obsolete] Identifiant du domaine de valeur \"StatutClient\"");
            entity.Property(e => e.IdSalesForce)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasComment("Identifiant de SalesForce");
            entity.Property(e => e.IdleTimeSmsDriverNotification).HasDefaultValueSql("((0))");
            entity.Property(e => e.IntituleCompte)
                .HasMaxLength(50)
                .HasDefaultValueSql("('')")
                .HasComment("[Obsolete]");
            entity.Property(e => e.LicenceCompte)
                .HasMaxLength(50)
                .HasDefaultValueSql("('')")
                .HasComment("[Obsolete]");
            entity.Property(e => e.LunchBox).HasDefaultValueSql("((0))");
            entity.Property(e => e.MissingBreakingDurationInSecond).HasComment("[Settings] 	Durée a partir de laquelle on considÃ¨re une coupure");
            entity.Property(e => e.NbJourVeqAnnee)
                .HasDefaultValueSql("((312))")
                .HasComment("[Settings] Nombre de jours pris en compte pour le calcul du TMAVA equivalent sur l'année");
            entity.Property(e => e.NbJourVeqMois)
                .HasDefaultValueSql("((26))")
                .HasComment("[Obsolete]");
            entity.Property(e => e.NomClient)
                .HasMaxLength(50)
                .HasDefaultValueSql("('')")
                .HasComment("Nom du client");
            entity.Property(e => e.PeriodeSirene)
                .HasDefaultValueSql("((60))")
                .HasComment("Durée en secondes de la période avant émission del l'alerte sirène");
            entity.Property(e => e.SensibiliteLitrePourVol)
                .HasDefaultValueSql("((10))")
                .HasComment("[Settings] Seuil minimum pour la détection de vol");
            entity.Property(e => e.SensibiliteVitessePourVol)
                .HasDefaultValueSql("((0))")
                .HasComment("[Obsolete]");
            entity.Property(e => e.SeuilAlerteBatterie0)
                .HasDefaultValueSql("((25000))")
                .HasComment("[Settings] Seuil d'alerte batterie condition optimale moteur tournant (27200 mV)");
            entity.Property(e => e.SeuilAlerteBatterie1)
                .HasDefaultValueSql("((21600))")
                .HasComment("[Settings] Seuil d'alerte batterie condition optimale moteur à l'arrêt (25200 mV)");
            entity.Property(e => e.SeuilAlerteBatterie2)
                .HasDefaultValueSql("((18000))")
                .HasComment("[Settings] Seuil d'alerte batterie accumulateur à recharger (23600 mV)");
            entity.Property(e => e.SeuilAlerteCoupeCircuit)
                .HasDefaultValueSql("((1000))")
                .HasComment("[Settings] Seuile d'alerte coupe-circuit (1000 mV)");
            entity.Property(e => e.SeuilAlerteStock)
                .HasDefaultValueSql("((20))")
                .HasComment("[Settings] Seuil d'alerte Stock");
            entity.Property(e => e.SeuilAlerteTmavamini)
                .HasDefaultValueSql("((15))")
                .HasComment("[Settings] Seuil minimum pour l'emmission d'alerte TMAVA")
                .HasColumnName("SeuilAlerteTMAVAmini");
            entity.Property(e => e.SeuilChauffeurConsoMax)
                .HasDefaultValueSql("((55))")
                .HasComment("[Settings] Seuil Max de consommation pour la conso chauffeur");
            entity.Property(e => e.SeuilChauffeurConsoMin)
                .HasDefaultValueSql("((17))")
                .HasComment("[Settings] Seuil Min de consommation pour la conso chauffeur");
            entity.Property(e => e.SeuilChauffeurDistanceMin)
                .HasDefaultValueSql("((300))")
                .HasComment("[Settings] Seuil Min de distance pour la conso chauffeur");
            entity.Property(e => e.SeuilConsoKm).HasComment("[Settings] Distance minimum parcourue pour la prise en compte de la consommation");
            entity.Property(e => e.SeuilPleinGrandReservoir).HasComment("[Settings] Volume minimum pour la prise e n compte d'un plein sur un grand réservoir (Reservoir > 200L)");
            entity.Property(e => e.SeuilPleinPetitReservoir).HasComment("[Settings] Volume minimum pour la prise e n compte d'un plein sur un petit réservoir (Reservoir < 200L)");
            entity.Property(e => e.SeuilTmavamini)
                .HasDefaultValueSql("((6))")
                .HasComment("[Settings] Seuil en minutes pour la prise en compte d'un TMAVA")
                .HasColumnName("SeuilTMAVAmini");
            entity.Property(e => e.SonnerieWe)
                .HasComment("[Settings] Indique si l'alerte sirène est active durant tout le week-end (24h/24) ou non")
                .HasColumnName("SonnerieWE");
            entity.Property(e => e.StatutCompte).HasComment("Etat du compte");
            entity.Property(e => e.TacofreshIdentifier)
                .HasMaxLength(50)
                .HasComment("[Settings] the driver has a TacofreshIdentifier");
            entity.Property(e => e.TeqCombustion).HasComment("[Settings] Coefficient de conversion des litres en Co2");
            entity.Property(e => e.TimeZoneId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('Romance Standard Time')");
            entity.Property(e => e.TypeCompte).HasComment("[Obsolete]");
            entity.Property(e => e.VersionBdd)
                .HasDefaultValueSql("((1))")
                .HasComment("[Tech] Version de la base de données du client")
                .HasColumnName("VersionBDD");
            entity.Property(e => e.WorkingDays).HasDefaultValueSql("((31))");
        });

        modelBuilder.Entity<TPackage>(entity =>
        {
            entity.HasKey(e => e.IdPackage);

            entity.ToTable("T_Packages", tb =>
                {
                    tb.HasComment("Tables des véhicules gérés par AlertGasoil");
                    tb.HasTrigger("TRG_Packages_Insert");
                    tb.HasTrigger("TRG_Packages_Update");
                });

            entity.HasIndex(e => e.FinActif, "IDX_T_Packages_FinActif");

            entity.HasIndex(e => e.Imei, "IDX_T_Packages_IMEI");

            entity.HasIndex(e => e.IdVehicule, "IDX_T_Packages_IdVehicule");

            entity.HasIndex(e => e.NumSim, "IDX_T_Packages_NumSIM");

            entity.HasIndex(e => e.SerialBoitier, "IDX_T_Packages_SerialBoitier");

            entity.HasIndex(e => e.DatePackage, "T_Packages_DatePackage");

            entity.Property(e => e.IdPackage).HasComment("Identifiant du package dans la table");
            entity.Property(e => e.Commentaire)
                .HasMaxLength(2000)
                .HasDefaultValueSql("('')")
                .HasComment("[Evol] Commentaire sur le package (doit etre géré par l'historisation)");
            entity.Property(e => e.DateInsert)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date de création de l'enregistrement dans la base de données")
                .HasColumnType("datetime");
            entity.Property(e => e.DatePackage)
                .HasDefaultValueSql("(getutcdate())")
                .HasComment("Date de création du package")
                .HasColumnType("datetime");
            entity.Property(e => e.DateUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date de dernière modification de l'enregistrement dans la base de données")
                .HasColumnType("datetime");
            entity.Property(e => e.DebutActif)
                .HasComment("Date de début d'activité du package")
                .HasColumnType("datetime");
            entity.Property(e => e.FinActif)
                .HasComment("Date de fin d'activité du package.\r\n   ATTENTION : le package est considéré comme inactif SSI le champ FinActif est saisi (i.e différent de NULL) il n'y a pas de contrôle sur l'antériorité vis-à-vis de la date du jour.")
                .HasColumnType("datetime");
            entity.Property(e => e.Gen10400)
                .IsRequired()
                .HasDefaultValueSql("((1))")
                .HasComment("[Obsolete] Indique si le package est relié à une prise Gen10400");
            entity.Property(e => e.IdVehicule).HasComment("Identifiant du véhicule sur lequel est installé le package");
            entity.Property(e => e.Imei)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasComment("Numéro IMEI du modem associé à ce package")
                .HasColumnName("IMEI");
            entity.Property(e => e.NumSim)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasComment("Numéro de carte SIM associé à ce package")
                .HasColumnName("NumSIM");
            entity.Property(e => e.PriseForce).HasComment("[Evol] Indique si le package est relié à la prise de force ou non. \nValeur possibles (0 - Non branchée, 1 - Branchée signal normal, -1 Branchée signal inversé) \nRègle de calcul : (Signal et (PFinv <> 00)) xor (PFinv < 0)");
            entity.Property(e => e.PriseFreins).HasComment("[Obsolete] Indique si le package est relié à la prise de freins ou non.");
            entity.Property(e => e.PriseOdometre).HasComment("[Obsolete] Indique si le package est relié à la prise odomètre ou non.");
            entity.Property(e => e.SerialBoitier)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("Numéro de série du boitier associé à ce package");
            entity.Property(e => e.Sirene).HasComment("[Evol] Si vrai, le vehicule est equipe de la sirene");
            entity.Property(e => e.SuiviMail).HasComment("[Obsolete] Indique si le suivi par mail est activé pour ce package");
        });

        modelBuilder.Entity<VehicleEnergyType>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.Start });

            entity.ToTable("VehicleEnergyType", tb => tb.HasComment("Historique du type d'énergie par véhicule"));

            entity.HasIndex(e => new { e.VehicleId, e.Start }, "UK_VehicleEnergyType_VehicleId_Start").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Start).HasPrecision(0);
            entity.Property(e => e.End).HasPrecision(0);
            entity.Property(e => e.SysCreationTimeUtc).HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.SysCreationUser)
                .HasMaxLength(128)
                .HasDefaultValueSql("(suser_sname())");
            entity.Property(e => e.SysLastUpdateTimeUtc).HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.SysLastUpdateUser)
                .HasMaxLength(128)
                .HasDefaultValueSql("(app_name())");
        });

        modelBuilder.Entity<TVehicule>(entity =>
        {
            entity.HasKey(e => e.IdVehicule);

            entity.ToTable("T_Vehicules", tb =>
            {
                tb.HasComment("Tables des véhicules gérés par AlertGasoil");
                tb.HasTrigger("TRG_Vehicules_Insert_CreateLienVehiculeGroupe");
                tb.HasTrigger("TRG_Vehicules_Update");
            });

            entity.HasIndex(e => e.Actif, "IDX_T_Vehicules_Actif");

            entity.HasIndex(e => e.IdDomTachy, "IDX_T_Vehicules_IdDomTachy");

            entity.HasIndex(e => e.IdDomTypeVehicule, "IDX_T_Vehicules_IdDomTypeVehicule");

            entity.HasIndex(e => e.IdModele, "IDX_T_Vehicules_IdModele");

            entity.HasIndex(e => e.IdSite, "IDX_T_Vehicules_IdSite");

            entity.HasIndex(e => e.Immatriculation, "IDX_T_Vehicules_Immatriculation");

            entity.HasIndex(e => e.LastTankEntryId, "IDX_T_Vehicules_LastTankEntryId");

            entity.HasIndex(e => e.Reservoir1, "IDX_T_Vehicules_Reservoir1");

            entity.HasIndex(e => e.Reservoir2, "IDX_T_Vehicules_Reservoir2");

            entity.HasIndex(e => e.Valide, "IDX_T_Vehicules_Valide");

            entity.HasIndex(e => e.CodeImmatriculation, "U_T_Vehicules_CodeImmatriculation").IsUnique();

            entity.Property(e => e.IdVehicule).HasComment("Identifiant du véhicule dans la table");
            entity.Property(e => e.AcceleratorPositionThreshold).HasComment("[Settings]");
            entity.Property(e => e.Actif)
                .IsRequired()
                .HasDefaultValueSql("((1))")
                .HasComment("[Evol] Indique si le véhicule est actif ou non");
            entity.Property(e => e.ActivityDetectionForConsumptionType).HasDefaultValueSql("((1))");
            entity.Property(e => e.AnneeFabrication).HasComment("Année de fabrication du véhicule");
            entity.Property(e => e.CableCutAlertHornActivation).HasComment("[Settings] [AlertV2]");
            entity.Property(e => e.CableCutAlertMinTimeThreshold).HasComment("[Settings] [AlertV2]");
            entity.Property(e => e.CableCutAlertOn).HasComment("[Settings] [AlertV2]");
            entity.Property(e => e.CableCutHornActivationTimeSpan).HasComment("[Settings] [AlertV2]");
            entity.Property(e => e.Category)
                .HasDefaultValueSql("((0))")
                .HasComment("Activité du véhicule");
            entity.Property(e => e.CodeImmatriculation)
                .HasMaxLength(50)
                .HasComputedColumnSql("([dbo].[fnStrCleanUp]([Immatriculation]))", true)
                .HasComment("[Calc] Immatriculation nettoyée de tous les caractères qui ne sont ni des chiffres ni des lettres. Ce champ est unique.");
            entity.Property(e => e.Commentaire)
                .HasMaxLength(200)
                .HasDefaultValueSql("('')")
                .HasComment("[Evol] Commentaire sur le véhicule (devrait etre géré par l'historique)");
            entity.Property(e => e.ConnectedFms).HasColumnName("ConnectedFMS");
            entity.Property(e => e.ConsoRef0).HasComment("[Settings] Consommation de reference fixée arbitrairement pour initialiser le cacul de consommation de référence");
            entity.Property(e => e.CruiseSpeedCoefficient).HasComment("[Settings]");
            entity.Property(e => e.DateInsert)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date de création de l'enregistrement dans la base de données")
                .HasColumnType("datetime");
            entity.Property(e => e.DateUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date de dernière modification de l'enregistrement dans la base de données")
                .HasColumnType("datetime");
            entity.Property(e => e.DebitMinPlein).HasComment("[Settings] Débit minium pour détection d'un plein");
            entity.Property(e => e.DebitMinSirene).HasComment("[Settings] Débit minium pour le déclenchement de l'alerte Sirène");
            entity.Property(e => e.DebitMinVol).HasComment("[Settings] Débit minium pour détection d'un vol");
            entity.Property(e => e.DecelerationThreshold).HasComment("[Settings]");
            entity.Property(e => e.EmissionAlerteBatterie)
                .IsRequired()
                .HasDefaultValueSql("((1))")
                .HasComment("[Settings] Autorise ou non l'émission d'alertes batterie pour ce véhicule");
            entity.Property(e => e.EmissionAlerteSirene).HasComment("[Settings] Si vrai, le vehicule emet des alertes Sirene");
            entity.Property(e => e.EmissionAlerteStock)
                .IsRequired()
                .HasDefaultValueSql("((1))")
                .HasComment("[Settings] Autorise ou non l'émission d'alertes stock pour ce véhicule");
            entity.Property(e => e.EmissionAlerteTmava)
                .IsRequired()
                .HasDefaultValueSql("((1))")
                .HasComment("[Settings]")
                .HasColumnName("EmissionAlerteTMAVA");
            entity.Property(e => e.EmissionAlerteVol)
                .IsRequired()
                .HasDefaultValueSql("((1))")
                .HasComment("[Settings]");
            entity.Property(e => e.EspaceCaisseReservoir).HasComment("[Obsolete] Indique si un espace est disponible entre le reservoir et la caisse");
            entity.Property(e => e.ExportD8data)
                .HasDefaultValueSql("((0))")
                .HasColumnName("ExportD8Data");
            entity.Property(e => e.FacteurK).HasComment("[Obsolete] Facteur kilométrique du véhicule");
            entity.Property(e => e.Fms)
                .HasComment("Indique si une prise FMS est détecté")
                .HasColumnName("FMS");
            entity.Property(e => e.Fmsdetected).HasColumnName("FMSDetected");
            entity.Property(e => e.GpsspeedMeanThreshold)
                .HasComment("[Settings]")
                .HasColumnType("decimal(9, 3)")
                .HasColumnName("GPSSpeedMeanThreshold");
            entity.Property(e => e.HeureDebut).HasComment("[Settings] Heure debut de la plage d'émission d'alerte en semaine");
            entity.Property(e => e.HeureFin).HasComment("[Settings] heure Fin de la plage d'émission d'alerte en semaine");
            entity.Property(e => e.IdDomDetectionMoteur)
                .HasDefaultValueSql("((1))")
                .HasComment("[Settings] Indique si la détection du Moteur via la tension doit être appliquée ou non (1=Non ; 2=Tension ; 3=Tension+IgnitionON)");
            entity.Property(e => e.IdDomTachy).HasComment("Identifiant du tachyographe numérique (CodeDomaine=Tachy)");
            entity.Property(e => e.IdDomTypeVehicule).HasComment("[Obsolete] Identifiant du type de véhicule (CodeDomaine=TypesVehicules)");
            entity.Property(e => e.IdDomVehicleStatus)
                .HasDefaultValueSql("((1))")
                .HasComment("[Evol] VehiculeStatus from T_DomaineValeur");
            entity.Property(e => e.IdModele).HasComment("Identifiant du modèle de véhicule");
            entity.Property(e => e.IdSite).HasComment("Identifiant du site");
            entity.Property(e => e.IdleTimeAlertHornActivation).HasComment("[Settings] [AlertV2]");
            entity.Property(e => e.IdleTimeAlertMinTimeThreshold).HasComment("[Settings] [AlertV2]");
            entity.Property(e => e.IdleTimeAlertOn).HasComment("[Settings] [AlertV2]");
            entity.Property(e => e.IdleTimeAlertPauseInterval).HasComment("[Settings] [AlertV2]");
            entity.Property(e => e.IdleTimeHornActivationTimeSpan).HasComment("[Settings] [AlertV2]");
            entity.Property(e => e.Immatriculation)
                .HasMaxLength(50)
                .HasDefaultValueSql("('')")
                .HasComment("[Evol] Immatriculation du véhicule ( saisie par le client )");
            entity.Property(e => e.InstallIndex).HasComment("Index Km au jour de l'installation");
            entity.Property(e => e.InstallIndexTimestampUtc).HasComment("Date du relevé d'index");
            entity.Property(e => e.InstallationDate)
                .HasComment("[Obsolete]")
                .HasColumnType("datetime");
            entity.Property(e => e.InventureEquiped).HasComment("[Settings] détermine si le véhicule possède un boitier Inventure");
            entity.Property(e => e.MaxSpeedAuthorized).HasComment("[Settings]");
            entity.Property(e => e.NbReservoirs).HasComment("[Calc] Nombre de réservoirs équipant ce véhicule");
            entity.Property(e => e.NotCalibrable).HasComment("[Settings] d�termine si le v�hicule doit passer dans l'auto calibration");
            entity.Property(e => e.NumChassis)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasComment("Numéro de chassis du véhicule");
            entity.Property(e => e.NumParc)
                .HasMaxLength(50)
                .HasDefaultValueSql("('')")
                .HasComment("Numéro du véhicule dans le Parc");
            entity.Property(e => e.PeriodeSirene).HasComment("[Settings] Durée en secondes de la période avant émission del l'alerte sirène");
            entity.Property(e => e.PermanentPto).HasColumnName("PermanentPTO");
            entity.Property(e => e.Ptac).HasColumnName("PTAC");
            entity.Property(e => e.PtodetectionType).HasColumnName("PTODetectionType");
            entity.Property(e => e.Rdlconnection).HasColumnName("RDLConnection");
            entity.Property(e => e.Reservoir1).HasComment("Identifiant du réservoir n°1");
            entity.Property(e => e.Reservoir2).HasComment("Identifiant du réservoir n°2");
            entity.Property(e => e.Rpmthreshold)
                .HasComment("[Settings]")
                .HasColumnName("RPMThreshold");
            entity.Property(e => e.SeuilMiniPeriodeEnMin).HasComment("[Settings]");
            entity.Property(e => e.Simslot1HasSim).HasColumnName("SIMSlot1HasSIM");
            entity.Property(e => e.Simslot2HasSim).HasColumnName("SIMSlot2HasSIM");
            entity.Property(e => e.SlowTheftAlertOn).HasComment("[Settings] [AlertV2]");
            entity.Property(e => e.SlowTheftMinVolumeThreshold).HasComment("[Settings] [AlertV2]");
            entity.Property(e => e.SonnerieWe)
                .HasComment("[Settings] Indique si l'alerte sirène est active durant tout le week-end (24h/24) ou non")
                .HasColumnName("SonnerieWE");
            entity.Property(e => e.Telephone)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasComment("[Obsolete]");
            entity.Property(e => e.Type)
                .HasDefaultValueSql("((0))")
                .HasComment("Tracteur / Porteur");
            entity.Property(e => e.UrlPhoto)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasComment("[Obsolete] URL du fichier image dans le référentiel fichier des photos");
            entity.Property(e => e.Valide).HasComment("[Evol] Indique si le montage du système AlertGasoil a été validé par l'installateur ou non.");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
