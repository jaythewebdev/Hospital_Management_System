using Microsoft.EntityFrameworkCore;

namespace HospitalAPI.Models
{
    public class HospitalContext:DbContext
    {
        public HospitalContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User>? Users { get; set; }

        public DbSet<Patient>? Patients { get; set; }

        public DbSet<Doctor>? Doctors { get; set; }

        public DbSet<Admin>? Admins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>().Property(i => i.PatientId).ValueGeneratedNever();
            modelBuilder.Entity<Doctor>().Property(i => i.DoctorId).ValueGeneratedNever();
            modelBuilder.Entity<Admin>().Property(i => i.AdminId).ValueGeneratedNever();
            //modelBuilder.Entity<Employee>().HasIndex(e => new { e.DrivingLicenseNumber, e.Passport }).IsUnique(true);
        }

    }
}
