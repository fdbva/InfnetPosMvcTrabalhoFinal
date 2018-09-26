using InfnetPos.Mvc.TrabalhoFinal.Domain.Model.Entities;
using InfnetPos.Mvc.TrabalhoFinal.Domain.Model.Interfaces.Repositories;
using InfnetPos.Mvc.TrabalhoFinal.Infrastructure.Data.Context;

namespace InfnetPos.Mvc.TrabalhoFinal.Infrastructure.Data.Repositories
{
    public class QuestionRepository : BaseRepository<Question>, IQuestionRepository
    {
        public QuestionRepository(EvaluationContext context) : base(context)
        {
        }
    }
}