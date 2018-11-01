using Microsoft.EntityFrameworkCore;

namespace WeeklyGoals.Models
{
    public class GoalsContext : DbContext
    {
        public GoalsContext(DbContextOptions<GoalsContext> options) : base(options)
        {
        }

        public DbSet<Goal> Goals { get; set; }
        public DbSet<Progress> Progress { get; set; }
    }
}
