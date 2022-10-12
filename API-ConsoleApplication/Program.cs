using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using APIBusinessLogic.Orders;
using APIBusinessLogic.Stocks;
using APIBusinessLogic.Orders.Contracts;
using APIBusinessLogic.Stocks.Contracts;

namespace API_ConsoleApplication
{
    /// <summary>
    /// This class is the main entry point of the application
    /// </summary>
    class program
    {
        /// <summary>
        /// Execution starts from Main
        /// </summary>
        /// <param name="args">string[]</param>
        public static void Main(string[] args)
        {
            IHost host = CreateHostBuilder(args).Build();

            ProductHandler services = ActivatorUtilities.CreateInstance<ProductHandler>(host.Services);

            Task task = services.RunAsync();
            task.Wait();

            Console.ReadLine();
        }

        /// <summary>
        /// This is the declartion of a method that create hosts and configure services 
        /// </summary>
        /// <param name="args">string[]</param>
        /// <returns>IHostBuilder</returns>
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
            .ConfigureServices((context, services) =>
            {
                services.AddScoped<IProductOrderService, ProductOrderServices>();
                services.AddScoped<IProductStockService, ProductStockService>();
                services.AddOptions();
            });
        }
    }
}
