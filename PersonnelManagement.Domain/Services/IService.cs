namespace PersonnelManagement.Domain.Services;

public interface IService<T> where T : class
{
    Task<IEnumerable<T>> GetAllEntitiesAsync();
    Task<T> GetEntityByIdAsync(int id);
    Task<T> CreateEntityAsync(T entity);
    Task UpdateEntityAsync(T entity);
    Task DeleteEntityAsync(T entity); 
}