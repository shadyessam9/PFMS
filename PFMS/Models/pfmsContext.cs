using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace PFMS.Models
{
    public partial class pfmsContext : DbContext
    {
        public pfmsContext()
            : base("name=pfmsContext")
        {
        }

        public virtual DbSet<Personnel> Personnels { get; set; }
        public virtual DbSet<Scan> Scans { get; set; }
        public virtual DbSet<Ship> Ships { get; set; }
        public virtual DbSet<Site> Sites { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<VehicleCompany> VehicleCompanies { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }
        public virtual DbSet<Violation> Violations { get; set; }
        public virtual DbSet<Shift> Shifts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Scan>()
                .Property(e => e.time)
                .HasPrecision(0);

            modelBuilder.Entity<Scan>()
                .Property(e => e.trip_time)
                .HasPrecision(0);

            modelBuilder.Entity<Scan>()
                .Property(e => e.loading_time)
                .HasPrecision(0);

            modelBuilder.Entity<Scan>()
                .Property(e => e.delay)
                .HasPrecision(0);

            modelBuilder.Entity<Violation>()
                .Property(e => e.time)
                .HasPrecision(0);
        }
    }
}
