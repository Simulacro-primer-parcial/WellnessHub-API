using Microsoft.EntityFrameworkCore;
using WellnessHub.Models;

namespace WellnessHub_API.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Habit> Habits { get; set; }
}