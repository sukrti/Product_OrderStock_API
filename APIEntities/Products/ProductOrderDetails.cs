using System.Collections.Generic;
namespace APIEntities.OrdersEntity
{
    /// <summary>
    /// This class defines the required parameters needed to pass to a Order API 
    /// to fetch all the orders with the status IN_PROGRESS
    /// </summary>
    public class ProductOrderDetails
    {
        public string ProductNumber { get; set; }
        public string Gtin { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public static IEnumerable<string> GetProductData()
        {
            return new[] { "Product Number", "Gtin", "Quantity", "Description" };
        }
    }
}
