using AutoMapper;

namespace InfnetPos.Mvc.TrabalhoFinal.Presentation.Mvc.AutoMapper
{
    public static class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(x => { x.AddProfile(new MappingsWithReverse()); });
        }
    }
}