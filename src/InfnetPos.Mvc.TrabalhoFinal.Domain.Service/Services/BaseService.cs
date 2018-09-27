using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InfnetPos.Mvc.TrabalhoFinal.Domain.Model.Entities;
using InfnetPos.Mvc.TrabalhoFinal.Domain.Model.Interfaces.Repositories;
using InfnetPos.Mvc.TrabalhoFinal.Domain.Model.Interfaces.Services;

namespace InfnetPos.Mvc.TrabalhoFinal.Domain.Service.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity
    {
        private readonly IBaseRepository<TEntity> _repository;

        public BaseService(IBaseRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public virtual async Task<TEntity> AddAsync(TEntity tEntity)
        {
            return await _repository.AddAsync(tEntity);
        }

        public virtual async Task<TEntity> FindAsync(Guid id)
        {
            return await _repository.FindAsync(id);
        }

        public virtual Task<IEnumerable<TEntity>> GetAllAsNoTrackingAsync()
        {
            return _repository.GetAllAsNoTrackingAsync();
        }

        public virtual TEntity Update(TEntity tEntity)
        {
            return _repository.Update(tEntity);
        }

        public virtual async Task RemoveAsync(Guid id)
        {
            await _repository.RemoveAsync(id);
        }

        public virtual void Remove(TEntity tEntity)
        {
            _repository.Remove(tEntity);
        }

        public virtual void Dispose()
        {
            _repository.Dispose();
        }
    }
}