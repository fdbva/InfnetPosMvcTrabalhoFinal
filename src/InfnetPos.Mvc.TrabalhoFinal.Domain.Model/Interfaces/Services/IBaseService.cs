using InfnetPos.Mvc.TrabalhoFinal.Domain.Model.Entities;
using InfnetPos.Mvc.TrabalhoFinal.Domain.Model.Interfaces.Repositories;

namespace InfnetPos.Mvc.TrabalhoFinal.Domain.Model.Interfaces.Services
{
    public interface IBaseService<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
    }
}