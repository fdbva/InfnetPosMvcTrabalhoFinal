using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InfnetPos.Mvc.TrabalhoFinal.Domain.Model.Entities;
using InfnetPos.Mvc.TrabalhoFinal.Domain.Model.Interfaces.Repositories;
using InfnetPos.Mvc.TrabalhoFinal.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace InfnetPos.Mvc.TrabalhoFinal.Infrastructure.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>, IDisposable where TEntity : BaseEntity
    {
        protected InfnetPosMvcContext Ctx { get; }
        protected DbSet<TEntity> Set { get; }

        public BaseRepository(InfnetPosMvcContext context)
        {
            Ctx = context;
            Set = Ctx.Set<TEntity>();
        }

        public virtual async Task<TEntity> AddAsync(TEntity tEntity)
        {
            var entity = await Set.AddAsync(tEntity);
            return entity.Entity;
        }

        public virtual async Task<TEntity> FindAsync(Guid id)
        {
            return await Set.FindAsync(id);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsNoTrackingAsync()
        {
            return await Set.AsNoTracking().ToListAsync();
        }

        public virtual TEntity Update(TEntity tEntity)
        {
            var entry = Ctx.Entry(tEntity);
            Set.Attach(tEntity);
            entry.State = EntityState.Modified;

            return tEntity;
        }

        public virtual void Remove(TEntity tEntity)
        {
            Set.Remove(tEntity);
        }

        public virtual async Task RemoveAsync(Guid id)
        {
            Set.Remove(await Set.FindAsync(id));
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Ctx?.Dispose();
            }
        }
    }
}