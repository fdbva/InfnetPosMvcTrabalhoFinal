using AutoMapper;
using InfnetPos.Mvc.TrabalhoFinal.Presentation.Mvc.HttpClients;
using InfnetPos.Mvc.TrabalhoFinal.Presentation.Mvc.HttpClients.Interfaces;
using InfnetPos.Mvc.TrabalhoFinal.Presentation.Mvc.IoC;
using InfnetPos.Mvc.TrabalhoFinal.Presentation.Mvc.ViewModels;
using InfnetPos.Mvc.TrabalhoFinal.SharedViewModels.ApiResponses;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InfnetPos.Mvc.TrabalhoFinal.Presentation.Mvc
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddAutoMapper();
            //services.AddHttpClient<IBaseClient<QuestionResponse, QuestionViewModel>, BaseClient<QuestionResponse, QuestionViewModel>>();
            services.AddHttpClient<IQuestionClient, QuestionClient>();
            NativeInjectorBootstrapper.RegisterServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}