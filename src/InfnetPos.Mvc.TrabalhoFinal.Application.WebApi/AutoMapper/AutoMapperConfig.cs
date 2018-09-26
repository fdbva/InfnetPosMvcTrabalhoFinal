using AutoMapper;

namespace InfnetPos.Mvc.TrabalhoFinal.Application.WebApi.AutoMapper
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(x => { x.AddProfile(new MappingsWithReverse()); });
        }
    }
}