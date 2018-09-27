using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InfnetPos.Mvc.TrabalhoFinal.Domain.Model.Entities;

namespace InfnetPos.Mvc.TrabalhoFinal.Domain.Model.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> AddAsync(TEntity tEntity);
        Task<TEntity> FindAsync(Guid id);
        Task<IEnumerable<TEntity>> GetAllAsNoTrackingAsync();
        TEntity Update(TEntity tEntity);
        Task RemoveAsync(Guid id);
        void Remove(TEntity tEntity);
        void Dispose();
    }
}