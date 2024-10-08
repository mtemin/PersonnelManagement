using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PersonnelManagement.Domain.Repositories;

namespace PersonnelManagement.Data.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly DbContext context;

    public Repository(DbContext _context)
    {
        context = _context;
    }
    
    public async Task AddAsync(T entity)
    {
        await context.Set<T>().AddAsync(entity);
    }

    public async Task AddRangeAsync(IEnumerable<T> entities)
    {
        await context.Set<T>().AddRangeAsync(entities);
    }

    public IEnumerable<T> Find(Expression<Func<T, bool>> filter)
    {
        return context.Set<T>().Where(filter);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await context.Set<T>().ToListAsync();
    }

    public ValueTask<T> GetByIdAsync(int id)
    {
        return context.Set<T>().FindAsync(id);
    }

    public void Remove(T entity)
    {
        context.Set<T>().Remove(entity);
    }

    public void Update(T entity)
    {
        context.Set<T>().Update(entity);
    }

    public void Remove(int id)
    {
        var entity = context.Set<T>().Find(id);
        if (entity != null)
        {
            context.Set<T>().Remove(entity);
        }
    }

    public void RemoveRange(IEnumerable<T> entities)
    {
        context.Set<T>().RemoveRange(entities);
    }

    public Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> filter)
    {
        return context.Set<T>().SingleOrDefaultAsync(filter);
    }
    
}