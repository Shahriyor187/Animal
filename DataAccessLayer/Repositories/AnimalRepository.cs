using DataAccsesLayer.Entities;
using DataAccsesLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccsesLayer.Repositories;

public class AnimalRepository : Repository<Animal>, IAnimalInterface
{
    public AnimalRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task DeleteAsync(Animal existingAnimal)
    {
        _dbContext.Animals.Remove(existingAnimal);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Animal>> GetAnimalsWithCategoryAsync()
        => await _dbContext.Animals
                        .Include(b => b.AnimalCategory)
                        .ToListAsync();
}
