using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PropertyRentalManagementWebSite.Models
{
    public partial class PropertyRentalManagementWebSiteDBContext : DbContext
    {
        public PropertyRentalManagementWebSiteDBContext()
        {
        }

        public PropertyRentalManagementWebSiteDBContext(DbContextOptions<PropertyRentalManagementWebSiteDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Administrator> Administrators { get; set; }
        public virtual DbSet<Apartment> Apartments { get; set; }
        public virtual DbSet<AppointmentAssignment> AppointmentAssignments { get; set; }
        public virtual DbSet<Manager> Managers { get; set; }
        public virtual DbSet<Tenant> Tenants { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-TDUEMAA8\\MSSQLSERVER2017;Initial Catalog=PropertyRentalManagementWebSiteDB;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrator>(entity =>
            {
                entity.HasKey(e => e.AdminId);

                entity.Property(e => e.AdminPassword)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.AdminUsername)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Apartment>(entity =>
            {
                entity.Property(e => e.ApartmentAddress).HasMaxLength(50);

                entity.Property(e => e.ApartmentPrice)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ApartmentType)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<AppointmentAssignment>(entity =>
            {
                entity.HasKey(e => e.AssignmentId);

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.NoteMessage).HasMaxLength(50);

                entity.HasOne(d => d.Apartment)
                    .WithMany(p => p.AppointmentAssignments)
                    .HasForeignKey(d => d.ApartmentId)
                    .HasConstraintName("FK_AppointmentAssignments_Apartments");

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.AppointmentAssignments)
                    .HasForeignKey(d => d.ManagerId)
                    .HasConstraintName("FK_AppointmentAssignments_Managers");

                entity.HasOne(d => d.Tenant)
                    .WithMany(p => p.AppointmentAssignments)
                    .HasForeignKey(d => d.TenantId)
                    .HasConstraintName("FK_AppointmentAssignments_Tenauts");
            });

            modelBuilder.Entity<Manager>(entity =>
            {
                entity.Property(e => e.ManagerPassword)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ManagerUsername)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Message).HasMaxLength(50);
            });

            modelBuilder.Entity<Tenant>(entity =>
            {
                entity.Property(e => e.TenantEmail).HasMaxLength(50);

                entity.Property(e => e.TenantFirstName).HasMaxLength(50);

                entity.Property(e => e.TenantLastName).HasMaxLength(50);

                entity.Property(e => e.TenantPassword).HasMaxLength(50);

                entity.Property(e => e.TenantPhonenumber).HasMaxLength(50);

                entity.Property(e => e.TenantUsername).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
