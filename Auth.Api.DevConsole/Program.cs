using System;

namespace Auth.Api.DevConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            ApiBootstrapper.Start();
            Console.WriteLine("AUTH Endpoint is running...");
            Console.WriteLine("Press ENTER to exit...");
            Console.ReadLine();
        }
    }
}
