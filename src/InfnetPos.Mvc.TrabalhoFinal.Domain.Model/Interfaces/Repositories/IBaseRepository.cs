using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InfnetPos.Mvc.TrabalhoFinal.Domain.Model.Entities;

namespace InfnetPos.Mvc.TrabalhoFinal.Domain.Model.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> AddAsync(TEntity obj);
        Task<TEntity> FindAsync(Guid id);
        Task<IEnumerable<TEntity>> GetAllAsNoTrackingAsync();
        TEntity Update(TEntity obj);
        Task RemoveAsync(Guid id);
        void Remove(TEntity obj);
        void Dispose();
    }
}