using Microsoft.EntityFrameworkCore;
using JobSearchPortal.Models;
namespace JobSearchPortal.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobCategory> JobCategories { get; set; }
        public DbSet<JobGrade> JobGrades { get; set; }
        public DbSet<PositionSchedule> PositionSchedules { get; set; }
        public DbSet<PositionOfferingType> PositionOfferingTypes { get; set; }
        public DbSet<PositionRemuneration> PositionRemunerations { get; set; }
        public DbSet<PositionLocation> PositionLocations { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder )
        {
            modelBuilder.Entity<Job>()
                .HasMany(j=> j.JobCategories)
                .WithOne(c => c.Job)
                .HasForeignKey(c => c.JobId);

            modelBuilder.Entity<Job>()
                .HasMany(j => j.JobGrades)
                .WithOne(g => g.Job)
                .HasForeignKey(g => g.JobId);

            modelBuilder.Entity<Job>()
                .HasMany(j => j.PositionSchedules)
                .WithOne(s => s.Job)
                .HasForeignKey(s => s.JobId);

            modelBuilder.Entity<Job>()
                .HasMany(j => j.PositionOfferingTypes)
                .WithOne(o => o.Job)
                .HasForeignKey(o => o.JobId);

            modelBuilder.Entity<Job>()
                .HasMany(j => j.PositionRemunerations)
                .WithOne(r => r.Job)
                .HasForeignKey(r => r.JobId);

            modelBuilder.Entity<Job>()
                .HasMany(j => j.PositionLocations)
                .WithOne(l => l.Job)
                .HasForeignKey(l => l.JobId);

            
        }
    }
}
