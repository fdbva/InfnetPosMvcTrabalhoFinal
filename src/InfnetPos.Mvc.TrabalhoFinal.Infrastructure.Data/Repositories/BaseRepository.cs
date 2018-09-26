using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InfnetPos.Mvc.TrabalhoFinal.Domain.Model.Entities;
using InfnetPos.Mvc.TrabalhoFinal.Domain.Model.Interfaces.Repositories;
using InfnetPos.Mvc.TrabalhoFinal.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Extensions.Internal;

namespace InfnetPos.Mvc.TrabalhoFinal.Infrastructure.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected EvaluationContext Ctx;
        protected DbSet<TEntity> DbSet;

        public BaseRepository(EvaluationContext context)
        {
            Ctx = context;
            DbSet = Ctx.Set<TEntity>();
        }

        public virtual async Task<TEntity> AddAsync(TEntity obj)
        {
            var entity = await DbSet.AddAsync(obj);
            return entity.Entity;
        }

        public virtual async Task<TEntity> FindAsync(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsNoTrackingAsync()
        {
            return await DbSet.AsNoTracking().ToListAsync();
        }

        public virtual TEntity Update(TEntity obj)
        {
            var entry = Ctx.Entry(obj);
            DbSet.Attach(obj);
            entry.State = EntityState.Modified;

            return obj;
        }

        public virtual void Remove(TEntity obj)
        {
            DbSet.Remove(obj);
        }

        public virtual async Task RemoveAsync(Guid id)
        {
            DbSet.Remove(await DbSet.FindAsync(id));
        }

        public void Dispose()
        {
            Ctx.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}