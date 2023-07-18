using ClinicsManagementsSystem.Models;
using Microsoft.EntityFrameworkCore;
namespace Clinic.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Specialization>()
            //    .HasMany(x=>x.Clinics)
            //    .WithOne(a=>a.specialization)
            //    .HasForeignKey(x=>x.SpecializationId)
            //    .OnDelete(DeleteBehavior.NoAction);
        }


        public DbSet<ClinicEntity> Clinics { get; set; }
        public DbSet<Specialization> Specializtions { get; set; }

    }
}