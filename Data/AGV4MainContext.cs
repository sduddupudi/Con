using System;
using System.Collections.Generic;
using ConsumptionAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace ConsumptionAPI.Data;

public partial class AGV4MainContext : DbContext
{
    public AGV4MainContext()
    {
    }

    public AGV4MainContext(DbContextOptions<AGV4MainContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TotalFuelUsed> TotalFuelUseds { get; set; }

    public virtual DbSet<VehicleStat> VehicleStats { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=recette-sql-01.alertgasoil.corp;Database=AGV4Main; user id=s.duddupudi; password=DUDDUPUDI!2022!");
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TotalFuelUsed>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TotalFuelUsed");

            entity.HasIndex(e => new { e.Imei, e.TimestampUtc }, "IX_TotalFuelUsed_Imei_TimestampUtc");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.TimestampUtc).HasPrecision(0);
        });

        modelBuilder.Entity<VehicleStat>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VehicleStats", "app_agsup");

            entity.Property(e => e.DistanceTachoGps).HasColumnName("DistanceTachoGPS");
            entity.Property(e => e.DistanceTachoGpsfull).HasColumnName("DistanceTachoGPSFull");
            entity.Property(e => e.FirstFrame).HasPrecision(0);
            entity.Property(e => e.Gpsdistance).HasColumnName("GPSDistance");
            entity.Property(e => e.GpsindexEnd).HasColumnName("GPSIndexEnd");
            entity.Property(e => e.GpsindexEndCaughtUp).HasColumnName("GPSIndexEndCaughtUp");
            entity.Property(e => e.GpsmissingDistance).HasColumnName("GPSMissingDistance");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.LastFrame).HasPrecision(0);
            entity.Property(e => e.PeriodMax).HasColumnType("date");
            entity.Property(e => e.PeriodMin).HasColumnType("date");
            entity.Property(e => e.PtoonDuration).HasColumnName("PTOOnDuration");
            entity.Property(e => e.SysApplication).HasMaxLength(128);
            entity.Property(e => e.SysUser).HasMaxLength(128);
            entity.Property(e => e.TimestampUtcFirst).HasPrecision(0);
            entity.Property(e => e.TimestampUtcLast).HasPrecision(0);
            entity.Property(e => e.LastIndex).HasColumnName("LastIndex");
            entity.Property(e => e.FirstIndex).HasColumnName("FirstIndex");
        });



        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
