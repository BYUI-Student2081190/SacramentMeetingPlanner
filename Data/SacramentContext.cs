using SacramentMeetingPlanner.Models;
using Microsoft.EntityFrameworkCore;

namespace SacramentMeetingPlanner.Data
{
    public class SacramentContext : DbContext
    {
        public SacramentContext(DbContextOptions<SacramentContext> options) : base(options) 
        {

        }

        public DbSet<Sacrament> Sacraments { get; set; }
        public DbSet<People> Peoples { get; set; }
        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<Hymn> Hymns { get; set; }

        // This was created to give the data tables different names.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sacrament>().ToTable("Sacrament");
            modelBuilder.Entity<People>().ToTable("People");
            modelBuilder.Entity<Speaker>().ToTable("Speaker");
            modelBuilder.Entity<Hymn>().ToTable("Hymn");
        }
    }
}
