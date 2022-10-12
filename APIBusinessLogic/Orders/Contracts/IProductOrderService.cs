using APIEntities.Enums;
using APIEntities.OrdersEntity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIBusinessLogic.Orders.Contracts
{
    public interface IProductOrderService
    {
        /// <summary>
        /// This method takes the product collective data and returns top five records 
        /// </summary>
        public IEnumerable<ProductOrderDetails> GetTopFiveRecords(Product_CollectionOfReponses responses);

        /// <summary>
        /// This method takes the product status and returns product collection from API 
        /// </summary>
        public Task <Product_CollectionOfReponses> GetOrdersByStatus(List<Product_Statuses> statuses);

        /// <summary>
        /// This method takes the product status and returns all the products that having In_Progress status
        /// </summary>
        public Task <IEnumerable<ProductOrderDetails>> GetAllInProgressProducts(List<Product_Statuses> statuses);
        
    }
}
