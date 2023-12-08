using DataAccsesLayer.Entities;
using DataAccsesLayer.Repositories;
using System.Net.Security;

namespace DataAccsesLayer.Interfaces;

public interface ICategoryInterface
                    : IRepository<AnimalCategory>
{
    Task<IEnumerable<AnimalCategory>> GetAllCategoriesAnimalsAsync();
}
