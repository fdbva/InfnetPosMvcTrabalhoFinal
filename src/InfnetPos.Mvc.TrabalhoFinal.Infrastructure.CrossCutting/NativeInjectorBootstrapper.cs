﻿using AutoMapper;
using InfnetPos.Mvc.TrabalhoFinal.Domain.Model.Interfaces.Repositories;
using InfnetPos.Mvc.TrabalhoFinal.Domain.Model.Interfaces.Services;
using InfnetPos.Mvc.TrabalhoFinal.Domain.Model.Interfaces.UnitOfWork;
using InfnetPos.Mvc.TrabalhoFinal.Domain.Service.Services;
using InfnetPos.Mvc.TrabalhoFinal.Infrastructure.Data.Context;
using InfnetPos.Mvc.TrabalhoFinal.Infrastructure.Data.Repositories;
using InfnetPos.Mvc.TrabalhoFinal.Infrastructure.Data.UoW;
using Microsoft.Extensions.DependencyInjection;

namespace Evaluation.Infrastructure.CrossCutting
{
    public static class NativeInjectorBootstrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // 2 - Application AutoMapper
            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(
                sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));

            // 3 - Domain Services
            services.AddScoped(typeof(IQuestionService), typeof(QuestionService));

            // 3 - Domain Repositories
            services.AddScoped(typeof(IQuestionRepository), typeof(QuestionRepository));

            // 4.1 - Infra.Data
            services.AddScoped<EvaluationContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}