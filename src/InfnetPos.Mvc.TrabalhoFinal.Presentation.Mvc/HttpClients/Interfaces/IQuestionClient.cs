using InfnetPos.Mvc.TrabalhoFinal.Presentation.Mvc.ViewModels;
using InfnetPos.Mvc.TrabalhoFinal.SharedViewModels.ApiResponses;

namespace InfnetPos.Mvc.TrabalhoFinal.Presentation.Mvc.HttpClients.Interfaces
{
    public interface IQuestionClient : IBaseClient<QuestionResponse, QuestionViewModel>
    {
    }
}