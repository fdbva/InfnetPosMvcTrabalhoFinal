using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InfnetPos.Mvc.TrabalhoFinal.SharedViewModels.ApiResponses;

namespace InfnetPos.Mvc.TrabalhoFinal.Presentation.Mvc.HttpClients.Interfaces
{
    public interface IQuestionClient
    {
        Task<IEnumerable<QuestionResponse>> GetAsync();
        Task<QuestionResponse> GetAsync(Guid id);
        Task PostAsync(QuestionResponse request);
        Task PutAsync(Guid id, QuestionResponse request);
        Task DeleteAsync(Guid id);
    }
}