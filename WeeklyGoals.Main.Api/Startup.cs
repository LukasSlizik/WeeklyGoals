using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WeeklyGoals.Main.Api.Models;
using WeeklyGoals.Main.Api.Services;

namespace WeeklyGoals.Main.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // health check
            app.Use(async (context, next) =>
            {
                if (context.Request.Path.StartsWithSegments("/healthcheck"))
                {
                    context.Response.StatusCode = (int)HttpStatusCode.OK;
                    await context.Response.WriteAsync("Succeeded");
                }
                else
                    await next.Invoke();
            });

            app.UseMvc();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}");
            });
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<ActivitiesContext>(options => options.UseNpgsql(Configuration.GetConnectionString("ActivitiesContext")));
            services.AddScoped<IActivityRepository, DbActivityRepository>();
        }
    }
}
