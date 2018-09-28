using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using InfnetPos.Mvc.TrabalhoFinal.Presentation.Mvc.Converters;
using InfnetPos.Mvc.TrabalhoFinal.Presentation.Mvc.HttpClients.Interfaces;
using InfnetPos.Mvc.TrabalhoFinal.SharedViewModels.ApiResponses;

namespace InfnetPos.Mvc.TrabalhoFinal.Presentation.Mvc.HttpClients
{
    public class QuestionClient : IQuestionClient
    {
        private const string ApiRoute = "Question";
        private const string ApiVersion = "api";
        private readonly HttpClient _httpClient;

        public QuestionClient(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri("https://localhost:44375");
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<QuestionResponse>> GetAsync()
        {
            using (var request = new HttpRequestMessage(HttpMethod.Get, $"/{ApiVersion}/{ApiRoute}"))
            using (var response = await _httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsAsync<IEnumerable<QuestionResponse>>();
            }
        }

        public async Task<QuestionResponse> GetAsync(Guid id)
        {
            using (var request = new HttpRequestMessage(HttpMethod.Get, $"/{ApiVersion}/{ApiRoute}/{id}"))
            using (var response = await _httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsAsync<QuestionResponse>();
            }
        }

        public async Task PostAsync(QuestionResponse request)
        {
            var response = await _httpClient.PostAsync(new Uri($"/{ApiVersion}/{ApiRoute}/"), new JsonContent(request));
            response.EnsureSuccessStatusCode();
        }

        public async Task PutAsync(Guid id, QuestionResponse request)
        {
            var response = await _httpClient.PutAsync(new Uri($"/{ApiVersion}/{ApiRoute}/{id}"), new JsonContent(request));
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync(Guid id)
        {
            using (var request = new HttpRequestMessage(HttpMethod.Delete, $"/{ApiVersion}/{ApiRoute}/Delete/{id}"))
            using (var response = await _httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
            }
        }
    }
}