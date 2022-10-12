using System;
using System.Threading.Tasks;
using APIBusinessLogic;
using API_ConsoleApplication.ProductStock;
using APIBusinessLogic.Orders.Contracts;
using APIBusinessLogic.Stocks.Contracts;

namespace API_ConsoleApplication
{
    /// <summary>
    /// This class handles the outcome results from Order/Stock APIs
    /// </summary>
    public class ProductHandler
    {
        #region Fields
        private readonly IProductOrderService _productorderservice;
        private readonly IProductStockService _productstockservice;
        #endregion

        #region Constructor
        public ProductHandler(IProductOrderService productorderservice, IProductStockService productstockservice)
        {
            _productorderservice = productorderservice;          
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
                productnumber = await ProductOrderHandler.GetTopFiveProductOrderDetails(_productorderservice);

                // Sendind productnumber,stock to the service to update the stock
                if (!string.IsNullOrEmpty(productnumber))
                    await ProductStockHandler.ProductUpdateStockDetails(_productstockservice, productnumber);
            }

            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong!" + ex.Message);
            }
        }

        #endregion
    }
}
