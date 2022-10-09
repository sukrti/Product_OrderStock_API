using APIBusinessLogic;
using APIBusinessLogic.Stocks.Contracts;
using System;
using System.Threading.Tasks;

namespace API_ConsoleApplication.ProductStock
{
    /// <summary>
    /// This class send the required information to business layer service to update  the stock
    /// </summary>
    public class ProductStockHandler
    {
        /// <summary>
        /// send the required information to business layer service to update stock
        /// </summary>
        /// <param name="productstockservice"></param>
        /// <param name="config"></param>
        /// <param name="productnumber"></param>
        /// <returns></returns>
        public static async Task ProductUpdateStockDetails(IProductStockService productstockservice, APIConfigDetails config,string productnumber)
        {
            try
            {
                
                await productstockservice.UpdateProductStock(productnumber, 25, config.BaseUrl, config.StockAPI, config.ApiKey);

                System.Console.WriteLine("Stock of product number " + productnumber + " is updated to 25");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                
            }
        }
    }
}
