using DataAccessLayer.Interfaces;
using DataAccsesLayer.Interfaces;

namespace DataAccsesLayer.Repositories;

public class UnitOfWor(ApplicationDbContext dbContext,
                        ICategoryInterface categoryInterface, IAnimalInterface animalInterface) : IUnitOfWork
{
    private readonly ApplicationDbContext _dbContext = dbContext;

    public ICategoryInterface CategoryInterface { get; } = categoryInterface;

    public IAnimalInterface AnimalInterface { get; } = animalInterface;

    public void Dispose()
        => GC.SuppressFinalize(this);

    public async Task SaveAsync()
        => await _dbContext.SaveChangesAsync();
}
