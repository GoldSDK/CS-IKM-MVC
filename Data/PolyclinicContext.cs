using Microsoft.EntityFrameworkCore;
using Polyclinic.Models;

namespace Polyclinic.Data
{
      /// <summary>
      /// DbContext для приложения
      /// наборы: Patients, Doctors, Appointments
      /// </summary>
      public class PolyclinicContext : DbContext
      {
            public PolyclinicContext(DbContextOptions<PolyclinicContext> options)
                : base(options)
            {
            }

            public DbSet<Patient> Patients
            {
                  get; set;
            } = null!;
            public DbSet<Doctor> Doctors
            {
                  get; set;
            } = null!;
            public DbSet<Appointment> Appointments
            {
                  get; set;
            } = null!;

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                  modelBuilder.Entity<Patient>(entity =>
                  {
                        entity.ToTable("patients");

                        entity.HasKey(p => p.Id);
                        entity.Property(p => p.Id).HasColumnName("id");

                        entity.Property(p => p.FullName)
                        .HasColumnName("fullname")
                        .HasMaxLength(100)
                        .IsRequired();

                        entity.Property(p => p.BirthDate)
                        .HasColumnName("birthdate")
                        .HasColumnType("timestamp without time zone");

                        entity.Property(p => p.Phone)
                        .HasColumnName("phone")
                        .HasMaxLength(50);
                  });

                  modelBuilder.Entity<Doctor>(entity =>
                  {
                        entity.ToTable("doctors");

                        entity.HasKey(d => d.Id);
                        entity.Property(d => d.Id).HasColumnName("id");

                        entity.Property(d => d.FullName)
                        .HasColumnName("fullname")
                        .HasMaxLength(100)
                        .IsRequired();

                        entity.Property(d => d.Specialty)
                        .HasColumnName("specialty")
                        .HasMaxLength(100);
                  });

                  modelBuilder.Entity<Appointment>(entity =>
                  {
                        entity.ToTable("appointments");

                        entity.HasKey(a => a.Id);
                        entity.Property(a => a.Id).HasColumnName("id");

                        entity.Property(a => a.DateTime)
                        .HasColumnName("datetime")
                        .HasColumnType("timestamp without time zone")
                        .IsRequired();

                        entity.Property(a => a.PatientId)
                        .HasColumnName("patientid")
                        .IsRequired();

                        entity.Property(a => a.DoctorId)
                        .HasColumnName("doctorid")
                        .IsRequired();

                        entity.Property(a => a.Notes)
                        .HasColumnName("notes")
                        .HasMaxLength(500);

                        entity.HasOne(a => a.Patient)
                        .WithMany(p => p.Appointments)
                        .HasForeignKey(a => a.PatientId)
                        .OnDelete(DeleteBehavior.Cascade);

                        entity.HasOne(a => a.Doctor)
                          .WithMany(d => d.Appointments)
                          .HasForeignKey(a => a.DoctorId)
                          .OnDelete(DeleteBehavior.Cascade);
                  });

                  base.OnModelCreating(modelBuilder);
            }
      }
}
