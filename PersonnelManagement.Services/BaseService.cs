using PersonnelManagement.Domain;
using PersonnelManagement.Domain.Repositories;

namespace PersonnelManagement.Services;

public abstract class BaseService<T> where T : class
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRepository<T> _repository;

    public BaseService(IUnitOfWork unitOfWork, IRepository<T> repository)
    {
        _unitOfWork = unitOfWork;
        _repository = repository;
    }

    public async Task<IEnumerable<T>> GetAllEntitiesAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<T> GetEntityByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<T> CreateEntityAsync(T entity)
    {
        await _repository.AddAsync(entity);
        await _unitOfWork.CommitAsync();
        return entity;
    }

    public async Task DeleteEntityAsync(T entity)
    {
        _repository.Remove(entity);
        await _unitOfWork.CommitAsync();
    }

    public async Task UpdateEntityAsync(T entity)
    {
        _repository.Update(entity);
        await _unitOfWork.CommitAsync();
    }
}