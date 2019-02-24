using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;

namespace Auth.Api
{
    public class ApiBootstrapper
    {
        private static void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var exc = e.ExceptionObject as Exception;
            Console.WriteLine(exc?.ToString());
        }

        public static void Start(params string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .UseKestrel()
                .UseStartup<Startup>();
        }
    }
}
