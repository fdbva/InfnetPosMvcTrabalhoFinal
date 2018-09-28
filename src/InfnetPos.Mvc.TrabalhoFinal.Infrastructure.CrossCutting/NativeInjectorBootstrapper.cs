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
            // 3 - Domain Services
            services.AddScoped(typeof(IQuestionService), typeof(QuestionService));

            // 3 - Domain Repositories
            services.AddScoped(typeof(IQuestionRepository), typeof(QuestionRepository));

            // 4.1 - Infra.Data
            services.AddDbContext<InfnetPosMvcContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}