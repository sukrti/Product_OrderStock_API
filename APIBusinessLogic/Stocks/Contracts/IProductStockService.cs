using System.Net.Http;
using System.Threading.Tasks;

namespace APIBusinessLogic.Stocks.Contracts
{
    public interface IProductStockService
    {
        /// <summary>
        /// Decalation of Method to update stock
        /// </summary>
        public Task<HttpResponseMessage> UpdateProductStock(string productNumber, int stock, string baseUrl, string stockApi, string apikey);
    }
}
