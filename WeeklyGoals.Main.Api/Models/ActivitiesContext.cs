using Microsoft.EntityFrameworkCore;

namespace WeeklyGoals.Main.Api.Models
{
    public class ActivitiesContext : DbContext
    {
        public ActivitiesContext(DbContextOptions<ActivitiesContext> options) : base(options) {}

        public DbSet<Activity> Activities { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Activity>().Property(p => p.Id).ValueGeneratedOnAdd();
        }
    }
}