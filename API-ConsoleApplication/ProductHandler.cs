using System;
using System.Threading.Tasks;
using APIBusinessLogic;
using API_ConsoleApplication.ProductStock;
using APIBusinessLogic.Orders.Contracts;
using APIBusinessLogic.Stocks.Contracts;
using Microsoft.Extensions.Configuration;

namespace API_ConsoleApplication
{
    /// <summary>
    /// This class handles the outcome results from Order/Stock APIs
    /// </summary>
    public class ProductHandler
    {
        #region Fields
        private readonly IConfiguration _configuration;
        private readonly IProductOrderService _productorderservice;
        private readonly IProductStockService _productstockservice;
        #endregion

        #region Constructor
        public ProductHandler(IProductOrderService productorderservice, IProductStockService productstockservice, IConfiguration configuration)
        {
            _productorderservice = productorderservice;
            _configuration = configuration;
            _productstockservice = productstockservice;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Starts the main logic to call to services for API
        /// </summary>
        /// <returns>Task</returns>
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
                Console.WriteLine("Something went wrong!" + ex.Message);
            }
        }
        #endregion
    }
}
