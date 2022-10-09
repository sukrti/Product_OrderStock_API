﻿using APIBusinessLogic;
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
        /// Send the required information to business layer service to update stock
        /// </summary>
        /// <param name="productstockservice">IProductStockService</param>
        /// <param name="config">APIConfigDetails</param>
        /// <param name="productnumber">string</param>
        /// <returns>Task</returns>
        public static async Task ProductUpdateStockDetails(IProductStockService productstockservice, APIConfigDetails config, string productnumber)
        {
            try
            {
                await productstockservice.UpdateProductStock(productnumber, 25, config.BaseUrl, config.StockAPI, config.ApiKey);

                System.Console.WriteLine("Stock of product number " + productnumber + " is updated to 25");

                Console.WriteLine();

                System.Console.WriteLine("Press any key to exit...");
            }

            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong while updating the stock " + ex.Message);
            }
        }
    }
}
