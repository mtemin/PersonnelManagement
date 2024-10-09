using System.ComponentModel.DataAnnotations;
using PersonnelManagement.Domain;
using PersonnelManagement.Domain.Repositories;
using PersonnelManagement.Domain.Services;

namespace PersonnelManagement.Services;

public abstract class BaseService<T> : IService<T> where T : class 

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
}