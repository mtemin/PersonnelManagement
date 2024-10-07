using System.Linq.Expressions;

namespace PersonnelManagement.Domain.Repository;

public  interface IRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    ValueTask<T> GetByIdAsync(int id);
    Task AddAsync(T entity);
    void Remove(T entity);
    Task AddRangeAsync(IEnumerable<T> entities);
    void RemoveRange(IEnumerable<T> entities);
    IEnumerable<T> Find(Expression<Func<T, bool>> filter);
    Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> filter);
}