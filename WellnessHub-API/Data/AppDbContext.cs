using Microsoft.EntityFrameworkCore;
using WellnessHubAPI.Models;

namespace WellnessHubAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    // ... otros DbSet del equipo
    public DbSet<Meal> Meals => Set<Meal>();

    protected override void OnModelCreating(ModelBuilder mb)
    {
        base.OnModelCreating(mb);

        // Opcional: índices útiles
        mb.Entity<Meal>().HasIndex(x => new { x.User, x.Entry_Date });
    }
}