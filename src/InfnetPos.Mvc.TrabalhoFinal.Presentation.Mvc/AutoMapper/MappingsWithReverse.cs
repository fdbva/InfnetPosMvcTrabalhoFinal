using AutoMapper;
using InfnetPos.Mvc.TrabalhoFinal.Presentation.Mvc.ViewModels;
using InfnetPos.Mvc.TrabalhoFinal.SharedViewModels.ApiResponses;

namespace InfnetPos.Mvc.TrabalhoFinal.Presentation.Mvc.AutoMapper
{
    public class MappingsWithReverse : Profile
    {
        public MappingsWithReverse()
        {
            CreateMap<QuestionViewModel, QuestionResponse>().ReverseMap();
        }
    }
}