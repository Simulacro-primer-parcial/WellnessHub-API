using Microsoft.EntityFrameworkCore;
using WellnessHub.Models;

namespace WellnessHub.Data;
public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Workout> Workouts { get; set; }
    public DbSet<Habit> Habits { get; set; }

}