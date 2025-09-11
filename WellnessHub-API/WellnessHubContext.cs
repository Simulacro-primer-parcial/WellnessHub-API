using Microsoft.EntityFrameworkCore;
using WellnessHub_API.Models;

namespace WellnessHub_API
{
    public class WellnessHubContext : DbContext
    {
        public WellnessHubContext(DbContextOptions<WellnessHubContext> options)
            : base(options)
        {
        }

        public DbSet<MoodEntry> MoodEntries { get; set; }

        // Otros DbSet (Habits, Meals, Workouts) pueden ir aquí
    }
}