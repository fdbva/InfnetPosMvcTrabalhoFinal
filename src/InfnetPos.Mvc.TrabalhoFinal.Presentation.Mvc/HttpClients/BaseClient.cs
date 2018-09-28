//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Http;
//using System.Threading.Tasks;
//using AutoMapper;
//using InfnetPos.Mvc.TrabalhoFinal.Presentation.Mvc.Converters;
//using InfnetPos.Mvc.TrabalhoFinal.Presentation.Mvc.HttpClients.Interfaces;
//using InfnetPos.Mvc.TrabalhoFinal.Presentation.Mvc.ViewModels;
//using InfnetPos.Mvc.TrabalhoFinal.SharedViewModels.ApiResponses;

//namespace InfnetPos.Mvc.TrabalhoFinal.Presentation.Mvc.HttpClients
//{
//    public class BaseClient<TResponse, TViewModel> : IBaseClient<TResponse, TViewModel> where TResponse : BaseResponse where TViewModel : BaseViewModel
//    {
//        private readonly HttpClient _httpClient;
//        private readonly IMapper _mapper;

//        public BaseClient(HttpClient httpClient, IMapper mapper)
//        {
//            httpClient.BaseAddress = new Uri("https://localhost:44375/");
//            _httpClient = httpClient;
//            _mapper = mapper;
//        }

//        public async Task<IEnumerable<TViewModel>> GetAsync()
//        {
//            using (var request = new HttpRequestMessage(HttpMethod.Get, "/"))
//            using (var response = await _httpClient.SendAsync(request))
//            {
//                if (response.IsSuccessStatusCode)
//                {
//                    return _mapper.Map<IEnumerable<TViewModel>>(await response.Content.ReadAsAsync<IEnumerable<TResponse>>());
//                }
//            }

//            return Enumerable.Empty<TViewModel>();
//        }

//        public async Task<TViewModel> GetAsync(Guid id)
//        {
//            using (var request = new HttpRequestMessage(HttpMethod.Get, $"/{id}"))
//            using (var response = await _httpClient.SendAsync(request))
//            {
//                if (response.IsSuccessStatusCode)
//                {
//                    return _mapper.Map<TViewModel>(await response.Content.ReadAsAsync<TResponse>());
//                }
//            }

//            return null;
//        }

//        public async Task PostAsync(TViewModel viewModel)
//        {
//            var request = _mapper.Map<TResponse>(viewModel);
//            var response = await _httpClient.PostAsync(new Uri("/"), new JsonContent(request));
//            response.EnsureSuccessStatusCode();
//        }

//        public async Task PutAsync(Guid id, TViewModel viewModel)
//        {
//            var request = _mapper.Map<TResponse>(viewModel);
//            var response = await _httpClient.PutAsync(new Uri($"/{id}"), new JsonContent(request));
//            response.EnsureSuccessStatusCode();
//        }

//        public async Task DeleteAsync(Guid id)
//        {
//            using (var request = new HttpRequestMessage(HttpMethod.Delete, $"Delete/{id}"))
//            using (var response = await _httpClient.SendAsync(request))
//            {
//                response.EnsureSuccessStatusCode();
//            }
//        }
//    }
//}