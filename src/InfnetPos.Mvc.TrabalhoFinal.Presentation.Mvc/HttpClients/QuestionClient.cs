using System.Net.Http;
using AutoMapper;
using InfnetPos.Mvc.TrabalhoFinal.Presentation.Mvc.HttpClients.Interfaces;
using InfnetPos.Mvc.TrabalhoFinal.Presentation.Mvc.ViewModels;
using InfnetPos.Mvc.TrabalhoFinal.SharedViewModels.ApiResponses;

namespace InfnetPos.Mvc.TrabalhoFinal.Presentation.Mvc.HttpClients
{
    public class QuestionClient : BaseClient<QuestionResponse, QuestionViewModel>, IQuestionClient
    {
        public QuestionClient(HttpClient httpClient, IMapper mapper) : base(httpClient, mapper)
        {
        }
    }
}