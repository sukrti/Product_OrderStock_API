using System;
using System.Threading.Tasks;
using APIBusinessLogic.Stocks.Contracts;



namespace API_ConsoleApplication.ProductStock
{
    /// <summary>
    /// This class send calls service layer to update  the stock
    /// </summary>
    public class ProductStockHandler
    {
        /// <summary>
        /// Send the required information to business layer service to update stock
        /// </summary>
        /// <param name="productstockservice">IProductStockService</param>
        /// <param name="productnumber">string</param>
        /// <returns>Task</returns>
        public static async Task ProductUpdateStockDetails(IProductStockService productstockservice,string productnumber)
        {
            try
            {
                await productstockservice.UpdateProductStock(productnumber, 25);

                System.Console.WriteLine("Stock of product number " + productnumber + " is updated to 25");
                Console.WriteLine();
            }

            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong while updating the stock " + ex.Message);               
            }
            Environment.Exit(0);
        }
    }
}
