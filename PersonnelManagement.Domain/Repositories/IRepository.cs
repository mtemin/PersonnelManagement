using System.Linq.Expressions;

namespace PersonnelManagement.Domain.Repositories;

public interface IRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    ValueTask<T> GetByIdAsync(int id);
    Task AddAsync(T entity);
    void Remove(T entity);
    void Update(T entity);
    void RemoveRange(IEnumerable<T> entities);
    Task AddRangeAsync(IEnumerable<T> entities);
    IEnumerable<T> Find(Expression<Func<T, bool>> filter);
    Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> filter);
}