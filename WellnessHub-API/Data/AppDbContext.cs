using Microsoft.EntityFrameworkCore;
using WellnessHubAPI.Models;

namespace WellnessHubAPI.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Meal> Meals { get; set; }
}

