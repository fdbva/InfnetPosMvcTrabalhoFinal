using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
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
        private const string JsonMediaType = "application/json";
        private readonly HttpClient _httpClient;

        public QuestionClient(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri("https://localhost:44375");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(JsonMediaType));
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

        public async Task<QuestionResponse> PostAsync(QuestionResponse request)
        {
            var uri = new Uri($"/{ApiVersion}/{ApiRoute}/", UriKind.Relative);
            var stringContent = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(request), Encoding.UTF8, JsonMediaType);
            var response = await _httpClient.PostAsync(uri, stringContent);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<QuestionResponse>();
        }

        public async Task<QuestionResponse> PutAsync(Guid id, QuestionResponse request)
        {
            var uri = new Uri($"/{ApiVersion}/{ApiRoute}/{id}", UriKind.Relative);
            var stringContent = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(request), Encoding.UTF8, JsonMediaType);
            var response = await _httpClient.PutAsync(uri, stringContent);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<QuestionResponse>();
        }

        public async Task DeleteAsync(Guid id)
        {
            var uri = new Uri($"/{ApiVersion}/{ApiRoute}/{id}/", UriKind.Relative);
            var response = await _httpClient.DeleteAsync(uri);
            response.EnsureSuccessStatusCode();
            //using (var request = new HttpRequestMessage(HttpMethod.Delete, uri))
            //using (var response = await _httpClient.SendAsync(request))
            //{
            //    response.EnsureSuccessStatusCode();
            //}
        }
    }
}