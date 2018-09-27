using InfnetPos.Mvc.TrabalhoFinal.Presentation.Mvc.HttpClients.Interfaces;
using InfnetPos.Mvc.TrabalhoFinal.Presentation.Mvc.ViewModels;
using InfnetPos.Mvc.TrabalhoFinal.SharedViewModels.ApiResponses;

namespace InfnetPos.Mvc.TrabalhoFinal.Presentation.Mvc.Controllers
{
    public class QuestionController : BaseCrudController<QuestionResponse, QuestionViewModel>
    {
        public QuestionController(IBaseClient<QuestionResponse, QuestionViewModel> baseClient) : base(baseClient)
        {
        }
    }
}