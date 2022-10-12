using System.Net.Http;
using System.Threading.Tasks;

namespace APIBusinessLogic.Stocks.Contracts
{
    public interface IProductStockService
    {
        /// <summary>
        /// Decalation of Method with required parameters to update stock
        /// </summary>
        public Task<HttpResponseMessage> UpdateProductStock(string productNumber, int stock);
    }
}
