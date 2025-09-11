using Microsoft.EntityFrameworkCore;
using WellnessHub.Models;

<<<<<<< HEAD
namespace WellnessHub.Data;
public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Workout> Workouts { get; set; }
    public DbSet<Habit> Habits { get; set; }

=======
namespace WellnessHub_API.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Habit> Habits { get; set; }
>>>>>>> 621bf5f93f4082647d40392a08238f1dc30f0cf0
}