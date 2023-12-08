using DataAccsesLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccsesLayer;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Animal> Animals { get; set; }
    public  DbSet<AnimalCategory> AnimalCategories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AnimalCategory>()
                    .HasMany(c => c.Animals)
                    .WithOne(b => b.AnimalCategory)
                    .HasForeignKey(b => b.Id)
                    .OnDelete(DeleteBehavior.ClientCascade);
        base.OnModelCreating(modelBuilder);
    }
}