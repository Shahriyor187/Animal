using DataAccsesLayer.Entities;
using DataAccsesLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DataAccsesLayer.Repositories;

public class Repository<TEntity>(ApplicationDbContext dbContext)
        : IRepository<TEntity> where TEntity : BaseEntitiy
{
    protected readonly ApplicationDbContext _dbContext = dbContext;
    public async Task AddAsync(TEntity entity)
    => await _dbContext.Set<TEntity>().AddAsync(entity);

    public void Delete(int id)
    {
        var entity = _dbContext.Set<TEntity>()
                                .FirstOrDefault(x => x.Id == id);

        _dbContext.Set<TEntity>().Remove(entity ?? throw new ArgumentException(nameof(entity)));
    }

    public Task<IEnumerable<TEntity>> GetAllAsync()
    {
        var lsit = _dbContext.Set<TEntity>()
                                .AsNoTracking()
                                .AsEnumerable();
        return Task.FromResult(lsit);
    }

    public async Task<TEntity> GetByIdAsync(int id)
    {
        var entity = await _dbContext.Set<TEntity>()
                                     .FirstOrDefaultAsync(i =>
                                        i.Id == id);
        return entity ?? throw new 
            ArgumentException(nameof(entity));
    }

    public void Update(TEntity entity)
       => _dbContext.Set<TEntity>().Update(entity);  
}
