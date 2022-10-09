using API_ConsoleApplication.ProductStock;
using APIBusinessLogic;
using APIBusinessLogic.Orders.Contracts;
using APIBusinessLogic.Stocks.Contracts;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System;

namespace API_ConsoleApplication
{
    /// <summary>
    /// This class handles the outcome results from Order/Stock APIs
    /// </summary>
    public class ProductHandler
    {
        private readonly IConfiguration _configuration;
        private readonly IProductOrderService _productorderservice;
        private readonly IProductStockService _productstockservice;
        public ProductHandler(IProductOrderService productorderservice, IProductStockService productstockservice, IConfiguration configuration)
        {
            _productorderservice = productorderservice;
            _configuration = configuration;
            _productstockservice = productstockservice;
        }
        public async Task RunAsync()
        {
            string productnumber = string.Empty;

            try
            {
                //Getting the config details
                APIConfigDetails config = _configuration.GetSection("APIConfigurations").Get<APIConfigDetails>();

                // Sendind status and config settings to the ProductOrderHandler service to fetch the orders from API
                if (config != null)
                    productnumber = await ProductOrderHandler.GetTopFiveProductOrderDetails(_productorderservice, config);

                // Sendind productnumber,stock and config settings to the Business logic to update the stock
                if (!string.IsNullOrEmpty(productnumber))
                    await ProductStockHandler.ProductUpdateStockDetails(_productstockservice, config, productnumber);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

    }
}
