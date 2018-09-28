using InfnetPos.Mvc.TrabalhoFinal.Presentation.Mvc.HttpClients;
using InfnetPos.Mvc.TrabalhoFinal.Presentation.Mvc.HttpClients.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace InfnetPos.Mvc.TrabalhoFinal.Presentation.Mvc.IoC
{
    public static class NativeInjectorBootstrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //services.AddTransient(typeof(IBaseClient<,>), typeof(BaseClient<,>));
            //services.AddTransient(typeof(IQuestionClient), typeof(QuestionClient));
        }
    }
}