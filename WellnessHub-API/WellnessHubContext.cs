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

        // Aquí se agregan otras entidades como:
        // public DbSet<Habit> Habits { get; set; }
        // public DbSet<Meal> Meals { get; set; }
        // public DbSet<Workout> Workouts { get; set; }
    }
}