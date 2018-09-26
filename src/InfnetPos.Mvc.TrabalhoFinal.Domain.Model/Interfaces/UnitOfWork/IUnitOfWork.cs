using System.Threading.Tasks;

namespace InfnetPos.Mvc.TrabalhoFinal.Domain.Model.Interfaces.UnitOfWork
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        Task CommitAsync();
        void Commit();
    }
}