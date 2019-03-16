using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using WeeklyGoals.Models;
using Microsoft.EntityFrameworkCore;
using WeeklyGoals.Services;

namespace WeeklyGoals1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<GoalsContext>(options => options.UseSqlServer(Configuration.GetConnectionString("GoalsContext")));
            services.AddSingleton<IUserService, DummyUserService>();

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;

            }).AddCookie(options =>
            {
                options.LoginPath = "/auth/login";
                options.AccessDeniedPath = "/auth/accessdenied";
            }).AddGoogle(options =>
            {
                options.ClientId = "Client Id";
                options.ClientSecret = "Client Secret";
            }).AddCookie("TempCookie");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseStaticFiles();
            //app.UseSpaStaticFiles();
            app.UseAuthentication();
            app.UseMvc();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            //app.UseSpa(spa =>
            //{
            //    // To learn more about options for serving an Angular SPA from ASP.NET Core,
            //    // see https://go.microsoft.com/fwlink/?linkid=864501

            //    spa.Options.SourcePath = "my-app";

            //    if (env.IsDevelopment())
            //       spa.UseAngularCliServer(npmScript: "start");
            //});
        }
    }
}
