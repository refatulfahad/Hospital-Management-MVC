using Hospital_Management.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {
          
        }
        public DbSet<Doctor> tbl_Doctors { get; set; }
        public DbSet<Patient> tbl_Patients { get; set; }
        public DbSet<PatientDoctor> PatientDoctor { get; set; }
        public DbSet<PatientBill> tbl_PatientBill { get; set; }
        public DbSet<MedicalReport> tbl_MedicalReport { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PatientDoctor>().HasKey(sc => new { sc.PatientId, sc.DoctorId });
            foreach(var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e=>e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior=DeleteBehavior.Restrict;
            }
            modelBuilder.Entity<spSearchDoctorById>().HasNoKey().ToView(null);
        }
        
        public DbSet<spSearchDoctorById> spSearchDoctorByIds { get; set; }
    }
}
