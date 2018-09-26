using InfnetPos.Mvc.TrabalhoFinal.Domain.Model.Entities;
using InfnetPos.Mvc.TrabalhoFinal.Domain.Model.Interfaces.Repositories;
using InfnetPos.Mvc.TrabalhoFinal.Domain.Model.Interfaces.Services;

namespace InfnetPos.Mvc.TrabalhoFinal.Domain.Service.Services
{
    public class QuestionService : BaseService<Question>, IQuestionService
    {
        public QuestionService(IQuestionRepository repository) : base(repository)
        {
        }
    }
}