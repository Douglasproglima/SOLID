using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Alura.LeilaoOnline.WebApp.Dados;
using Alura.LeilaoOnline.WebApp.Dados.EFCore;
using Alura.LeilaoOnline.WebApp.Services;
using Alura.LeilaoOnline.WebApp.Services.Handlers;

namespace Alura.LeilaoOnline.WebApp
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //Todas entidades que solicitarem a instância de ILeilaoDao, será resolvido essa abstração com o LeilaoDaoEFCore
            services.AddTransient<ICategoriaDao, CategoriaDaoEFCore>();
            services.AddTransient<ILeilaoDao, LeilaoDaoEFCore>();
            services.AddTransient<IProductService, DefaultProductService>();
            //services.AddTransient<IAdminService, DefaultAdminService>();
            services.AddTransient<IAdminService, ArchiveAdminService>();
            services.AddDbContext<AppDbContext>();

            services
                .AddControllersWithViews()
                .AddNewtonsoftJson(options => 
                {
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePagesWithRedirects("/Home/StatusCode/{0}");
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
