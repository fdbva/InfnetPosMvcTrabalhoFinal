﻿using AutoMapper;
using InfnetPos.Mvc.TrabalhoFinal.Domain.Model.Entities;
using InfnetPos.Mvc.TrabalhoFinal.SharedViewModels.ApiResponses;

namespace InfnetPos.Mvc.TrabalhoFinal.Application.WebApi.AutoMapper
{
    public class MappingsWithReverse : Profile
    {
        public MappingsWithReverse()
        {
            CreateMap<Question, QuestionResponse>().ReverseMap();
        }
    }
}