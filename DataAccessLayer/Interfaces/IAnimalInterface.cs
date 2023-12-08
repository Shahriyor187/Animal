using DataAccsesLayer.Entities;

namespace DataAccsesLayer.Interfaces;

public interface IAnimalInterface : IRepository<Animal>
{
    Task DeleteAsync(Animal existingAnimal);
    Task<IEnumerable<Animal>> GetAnimalsWithCategoryAsync();

}
