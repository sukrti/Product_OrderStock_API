using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace API_WebApplication
{
    /// <summary>
    /// This class is the entry point of the application
    /// </summary>
    public class Program
    {
        /// <summary>
        ///  Execution starts
        /// </summary>
        /// <param name="args">string[]</param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// This method creats the host builder
        /// </summary>
        /// <param name="args">string[]</param>
        /// <returns>IHostBuilder</returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
        });
    }
}
