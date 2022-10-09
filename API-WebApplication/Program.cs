using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace API_WebApplication
{
    /// <summary>
    /// This class is the main entry point of the web application. Here it sets up the host
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((context, configuation) =>
            {
                configuation.Sources.Clear();
                configuation.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            })
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
        });
    }
}
