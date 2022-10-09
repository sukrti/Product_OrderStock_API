using API_ConsoleApplication;
using APIBusinessLogic.Orders;
using APIBusinessLogic.Orders.Contracts;
using APIBusinessLogic.Stocks;
using APIBusinessLogic.Stocks.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

class program
{
    /// <summary>
    /// Main Entry point of the program . It creates host builder and calls RunAsunc() from ProductHandler 
    /// </summary>
    /// <param name="args"></param>
    public static void Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();
        var services = ActivatorUtilities.CreateInstance<ProductHandler>(host.Services);
        Task task = services.RunAsync();
        task.Wait(); 
        Console.ReadLine();
    }
    public static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((context, configuation) =>
            {
                configuation.Sources.Clear();
                configuation.AddJsonFile("Dev.appsettings.json", optional: true, reloadOnChange: true);
            })
            .ConfigureServices((context, services) =>
            {
                services.AddScoped<IProductOrderService, ProductOrderServices>();
                services.AddScoped<IProductStockService, ProductStockService>();

                services.AddOptions();
            });
    }
}












