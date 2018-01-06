using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace WeeklyGoals.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var ctx = new GoalsContext(serviceProvider.GetRequiredService<DbContextOptions<GoalsContext>>()))
            {
                if (!ctx.Weeks.Any())
                {
                    ctx.Weeks.AddRange(
                    new Week() { Start = new DateTime(2018, 1, 1), End = new DateTime(2018, 1, 7) },
                    new Week() { Start = new DateTime(2018, 1, 8), End = new DateTime(2018, 1, 14) },
                    new Week() { Start = new DateTime(2018, 1, 15), End = new DateTime(2018, 1, 21) },
                    new Week() { Start = new DateTime(2018, 1, 22), End = new DateTime(2018, 1, 28) });
                }

                ctx.SaveChanges();
            }
        }
    }
}
