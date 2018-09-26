using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using InfnetPos.Mvc.TrabalhoFinal.Domain.Model.Entities;
using InfnetPos.Mvc.TrabalhoFinal.Domain.Model.Interfaces.Services;
using InfnetPos.Mvc.TrabalhoFinal.Domain.Model.Interfaces.UnitOfWork;
using InfnetPos.Mvc.TrabalhoFinal.SharedViewModels.ViewModels;

namespace InfnetPos.Mvc.TrabalhoFinal.Application.WebApi.Controllers
{
    public class QuestionController : BaseCrudController<IQuestionService, Question, QuestionViewModel>
    {
        public QuestionController(IQuestionService baseService, IUnitOfWork uow, IMapper autoMapper) 
            : base(baseService, uow, autoMapper)
        {
        }
    }
}
