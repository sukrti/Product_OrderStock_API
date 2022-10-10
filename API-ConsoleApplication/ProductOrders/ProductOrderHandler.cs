using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using ConsoleTables;
using APIBusinessLogic;
using APIBusinessLogic.Orders.Contracts;
using APIEntities.Enums;
using APIEntities.OrdersEntity;

namespace API_ConsoleApplication
{
    /// <summary>
    /// This class send the required information to business layer service to fetch top 5
    /// orders that are in IN_PROGRESS and shows the result in the console table
    /// </summary>
    public static class ProductOrderHandler
    {
        /// <summary>
        /// Sends required information to business layer service
        /// </summary>
        /// <param name="productorderservice">IProductOrderService</param>
        /// <param name="config">APIConfigDetails</param>
        /// <returns>string</returns>
        public static async Task<string> GetTopFiveProductOrderDetails(IProductOrderService productorderservice, APIConfigDetails config)
        {
            string productNumber = string.Empty;
            try
            {
                // Make request to service 
                if (config != null)
                {
                    IEnumerable<ProductOrderDetails> topfiveorders = await productorderservice.GetAllInProgressProducts(new List<Product_Statuses> { Product_Statuses.IN_PROGRESS },
                     config.BaseUrl, config.OrderAPI, config.ApiKey);

                    //print top 5 records 
                    PrintTopFiveProductsOnConsole(topfiveorders.ToArray());

                    //Ask user to choose the product number 
                    while (true)
                    {
                        Console.WriteLine("Select a product number to update its stock to 25:");
                        productNumber = Console.ReadLine();
                        if (topfiveorders.Any(c => c.ProductNumber == productNumber)) break;
                        Console.WriteLine("Product not exists!");
                    }
                }
                else
                {
                    Console.WriteLine("Error occurred !! Press any key to exit...");
                }
                
            }

            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong while fetching the records " + ex.Message);
            }

            return productNumber;
        }

        /// <summary>
        /// This method prints the result
        /// </summary>
        /// <param name="topProducts">ProductOrderDetails[]</param>
        private static void PrintTopFiveProductsOnConsole(ProductOrderDetails[] topProducts)
        {
            try
            {
                var table = new ConsoleTable();

                IEnumerable<string> alldetails = ProductOrderDetails.GetProductData();

                table.AddColumn(alldetails);

                foreach (var orders in topProducts)
                {
                    table.AddRow(orders.ProductNumber, orders.Gtin, orders.Quantity, orders.Description);
                }

                table.Write();
            }

            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong:"+ex.Message);
            }
        }
    }
}
