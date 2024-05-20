using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PatientInfoPortal.Api.Models;

namespace PatientInfoPortal.Api.Data;

public partial class PatientInfoPortalContext : DbContext
{
    public PatientInfoPortalContext()
    {
    }

    public PatientInfoPortalContext(DbContextOptions<PatientInfoPortalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AllergiesDetail> AllergiesDetails { get; set; }

    public virtual DbSet<Allergy> Allergies { get; set; }

    public virtual DbSet<DiseaseInformation> DiseaseInformations { get; set; }

    public virtual DbSet<Ncd> Ncds { get; set; }

    public virtual DbSet<NcdDetail> NcdDetails { get; set; }

    public virtual DbSet<PatientsInformation> PatientsInformations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DbConn");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AllergiesDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Allergie__3214EC27E2AC2851");

            entity.ToTable("Allergies_Details");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.AllergiesId).HasColumnName("AllergiesID");
            entity.Property(e => e.PatientId).HasColumnName("PatientID");

            entity.HasOne(d => d.Allergies).WithMany(p => p.AllergiesDetails)
                .HasForeignKey(d => d.AllergiesId)
                .HasConstraintName("FK_Allergies_Details_Allergies");

            entity.HasOne(d => d.Patient).WithMany(p => p.AllergiesDetails)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK_Allergies_Details_Patients_Information");
        });

        modelBuilder.Entity<Allergy>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Allergie__3214EC27117D327A");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(1);
        });

        modelBuilder.Entity<DiseaseInformation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Disease___3214EC27AB01E1FE");

            entity.ToTable("Disease_Information");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(1);
        });

        modelBuilder.Entity<Ncd>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__NCD__3214EC273D7A38E1");

            entity.ToTable("NCD");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(1);
        });

        modelBuilder.Entity<NcdDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__NCD_Deta__3214EC27E65622EF");

            entity.ToTable("NCD_Details");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Ncdid).HasColumnName("NCDID");
            entity.Property(e => e.PatientId).HasColumnName("PatientID");

            entity.HasOne(d => d.Ncd).WithMany(p => p.NcdDetails)
                .HasForeignKey(d => d.Ncdid)
                .HasConstraintName("FK_NCD_Details_NCD");

            entity.HasOne(d => d.Patient).WithMany(p => p.NcdDetails)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK_NCD_Details_Patients_Information");
        });

        modelBuilder.Entity<PatientsInformation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Patients__3214EC274AA5EFF7");

            entity.ToTable("Patients_Information");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(1);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
