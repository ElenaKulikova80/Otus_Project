using Budget.DAL.Abstractions;
using Budget.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Budget.DAL.Repositories.EF;

public class BasicRepository<T> : IRepository<T> where T : BasicItem
{
    private readonly DbContext _dataContext;
    public BasicRepository(DbContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dataContext.Set<T>().ToListAsync();
    }

    public async Task<T?> GetAsync(int id)
    {
        return await _dataContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task AddAsync(T entity)
    {
        await _dataContext.Set<T>().AddAsync(entity);
        await _dataContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        var entity2 = await _dataContext.Set<T>().FirstOrDefaultAsync(x => x.Id == entity.Id);
        if (entity2 != null)
        {
            entity2 = entity;
            await _dataContext.SaveChangesAsync();
        }
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _dataContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        if (entity != null)
        {
            _dataContext.Set<T>().Remove(entity);
            await _dataContext.SaveChangesAsync();
        }
    }
}
