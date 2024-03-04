using Budget.DAL.Entities;

namespace Budget.DAL.Abstractions;

public interface IRepository<T> where T : BasicItem
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetAsync(int id);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(int id);
}
