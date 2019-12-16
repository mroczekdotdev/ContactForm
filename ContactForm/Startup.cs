using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MroczekDotDev.ContactForm.Services.EmailSender;
using MroczekDotDev.ContactForm.Services.Repository;

namespace MroczekDotDev.ContactForm
{
    public class Startup
    {
        private readonly IConfiguration cfg;
        private readonly IWebHostEnvironment env;

        public Startup(IConfiguration cfg, IWebHostEnvironment env)
        {
            this.cfg = cfg;
            this.env = env;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
            services.AddRepository(options => options.UseSqlServer(cfg.GetConnectionString("SqlServer")));
            services.AddLocalEmailSender();
        }

        public void Configure(IApplicationBuilder app)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
            }

            app.UseStatusCodePagesWithRedirects("/StatusCode?code={0}");
            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                   name: "Error",
                   pattern: "error",
                   new { controller = "Home", action = "error" });
                endpoints.MapControllerRoute(
                    name: "Success",
                    pattern: "success",
                    new { controller = "Home", action = "success" });
                endpoints.MapControllerRoute(
                    name: "StatusCode",
                    pattern: "StatusCode/{code:int?}",
                    new { controller = "StatusCode", action = "Index" });
                endpoints.MapControllerRoute(
                    name: "Default",
                    pattern: "",
                    new { controller = "Home", action = "Index" });
            });
        }
    }
}
