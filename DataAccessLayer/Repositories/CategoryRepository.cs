using DataAccsesLayer.Entities;
using DataAccsesLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Net.Security;

namespace DataAccsesLayer.Repositories;

public class CategoryRepository : Repository<AnimalCategory>, ICategoryInterface
{
    public CategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
    {

    }

    public async Task<IEnumerable<AnimalCategory>> GetAllCategoriesAnimalsAsync()
       => await _dbContext.AnimalCategories
                            .Include(c => c.Animals)
                            .ToListAsync();
}
