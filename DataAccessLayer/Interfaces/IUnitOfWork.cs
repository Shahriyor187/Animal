using DataAccsesLayer.Interfaces;

namespace DataAccessLayer.Interfaces;

public interface IUnitOfWork : IDisposable
{
    ICategoryInterface CategoryInterface { get; }
    IAnimalInterface AnimalInterface { get; }
    Task SaveAsync();
}