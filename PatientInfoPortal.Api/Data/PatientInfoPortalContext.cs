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
            entity.ToTable("Allergies_Details");

            entity.Property(e => e.Id).HasColumnName("ID");
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
            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<DiseaseInformation>(entity =>
        {
            entity.ToTable("Disease_Information");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(250);
        });

        modelBuilder.Entity<Ncd>(entity =>
        {
            entity.ToTable("NCD");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<NcdDetail>(entity =>
        {
            entity.ToTable("NCD_Details");

            entity.Property(e => e.Id).HasColumnName("ID");
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
            entity.ToTable("Patients_Information");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DiseaseId).HasColumnName("DiseaseID");
            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.Disease).WithMany(p => p.PatientsInformations)
                .HasForeignKey(d => d.DiseaseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Patients_Disease_Information");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
