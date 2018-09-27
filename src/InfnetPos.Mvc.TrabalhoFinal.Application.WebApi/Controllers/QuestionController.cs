using AutoMapper;
using InfnetPos.Mvc.TrabalhoFinal.Domain.Model.Entities;
using InfnetPos.Mvc.TrabalhoFinal.Domain.Model.Interfaces.Services;
using InfnetPos.Mvc.TrabalhoFinal.Domain.Model.Interfaces.UnitOfWork;
using InfnetPos.Mvc.TrabalhoFinal.SharedViewModels.ApiResponses;

namespace InfnetPos.Mvc.TrabalhoFinal.Application.WebApi.Controllers
{
    public class QuestionController : BaseCrudController<IQuestionService, Question, QuestionResponse>
    {
        public QuestionController(IQuestionService baseService, IUnitOfWork uow, IMapper autoMapper)
            : base(baseService, uow, autoMapper)
        {
        }
    }
}