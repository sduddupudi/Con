using System;
using System.Collections.Generic;
using ConsumptionAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace ConsumptionAPI.Data;

public partial class MauffreyDBContext : DbContext
{
    public MauffreyDBContext()
    {
    }

    public MauffreyDBContext(DbContextOptions<MauffreyDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<VTrace> VTraces { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=recette-sql-01.alertgasoil.corp;Database=DBAlertGasoilMauffrey; user id=s.duddupudi; password=DUDDUPUDI!2022! ;Connect Timeout=200; Pooling=true; Max Pool Size=200");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<VTrace>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_Traces");

            entity.Property(e => e.AlimentationAux).HasMaxLength(1);
            entity.Property(e => e.AlimentationPrincipale).HasMaxLength(1);
            entity.Property(e => e.ConnexionGprs).HasColumnName("ConnexionGPRS");
            entity.Property(e => e.DateTraces).HasColumnType("datetime");
            entity.Property(e => e.DateUtcTraces).HasColumnType("datetime");
            entity.Property(e => e.GpsonOff)
                .HasMaxLength(1)
                .HasColumnName("GPSOnOff");
            entity.Property(e => e.Idfvehicule).HasColumnName("IDFVehicule");
            entity.Property(e => e.Idtraces)
                .ValueGeneratedOnAdd()
                .HasColumnName("IDTraces");
            entity.Property(e => e.Ignition).HasMaxLength(1);
            entity.Property(e => e.IndexKm).HasColumnName("IndexKM");
            entity.Property(e => e.Lattitude).HasMaxLength(50);
            entity.Property(e => e.Longitude).HasMaxLength(50);
            entity.Property(e => e.Moteur).HasMaxLength(1);
            entity.Property(e => e.QualiteSignalGps).HasColumnName("QualiteSignalGPS");
            entity.Property(e => e.QualiteSignalGsm).HasColumnName("QualiteSignalGSM");
            entity.Property(e => e.SenseurMasse).HasMaxLength(1);
            entity.Property(e => e.SenseurVoltage).HasMaxLength(1);
            entity.Property(e => e.SerialBoitier).HasMaxLength(50);
            entity.Property(e => e.Tor3).HasColumnName("TOR3");
            entity.Property(e => e.Tor4).HasColumnName("TOR4");
            entity.Property(e => e.VitesseGps).HasColumnName("VitesseGPS");
            entity.Property(e => e.VitesseKmh).HasColumnName("VitesseKMH");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
