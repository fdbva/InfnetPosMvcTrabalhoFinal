using System;
using System.Threading.Tasks;
using InfnetPos.Mvc.TrabalhoFinal.Domain.Model.Interfaces.UnitOfWork;
using InfnetPos.Mvc.TrabalhoFinal.Infrastructure.Data.Context;

namespace InfnetPos.Mvc.TrabalhoFinal.Infrastructure.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EvaluationContext _context;
        private bool _disposed;

        public UnitOfWork(EvaluationContext context)
        {
            _context = context;
        }

        public void BeginTransaction()
        {
            _disposed = false;
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}