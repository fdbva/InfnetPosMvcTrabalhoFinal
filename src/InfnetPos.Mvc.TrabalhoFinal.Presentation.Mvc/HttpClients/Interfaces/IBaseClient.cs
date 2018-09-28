//using System;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using InfnetPos.Mvc.TrabalhoFinal.Presentation.Mvc.ViewModels;
//using InfnetPos.Mvc.TrabalhoFinal.SharedViewModels.ApiResponses;

//namespace InfnetPos.Mvc.TrabalhoFinal.Presentation.Mvc.HttpClients.Interfaces
//{
//    public interface IBaseClient<TResponse, TViewModel>
//        where TResponse : BaseResponse
//        where TViewModel : BaseViewModel
//    {
//        Task<IEnumerable<TViewModel>> GetAsync();
//        Task<TViewModel> GetAsync(Guid id);
//        Task PostAsync(TViewModel viewModel);
//        Task PutAsync(Guid id, TViewModel viewModel);
//        Task DeleteAsync(Guid id);
//    }
//}