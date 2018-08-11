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

                ctx.SaveChanges();
            }
        }
    }
}
