using System.Net.Http;
using System.Threading.Tasks;
using API_WebApplication.Exceptions;
using APIBusinessLogic.Stocks.Contracts;
using APIEntities.StockEntity;
using Microsoft.AspNetCore.Mvc;

namespace API_WebApplication.Controllers
{
    /// <summary>
    /// ProductStockController declaration
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    public class ProductStockController : ControllerBase
    {
        #region Fields Declaration
        private readonly IProductStockService _service;
        #endregion

        #region Constructor Declaration
        public ProductStockController(IProductStockService service)
        {
            _service = service;           
        }
        #endregion

        #region HTTP Requests Declaration

        /// <summary>
        /// This method updates the stock
        /// </summary>
        /// <returns>HTTPResponseMessage</returns>
        [HttpPut]
        public async Task<HttpResponseMessage> UpdateStockData(ProductStockDetails productstock)
        {
            // Sendind productnumber,stock to the service to update the stock
            if (!string.IsNullOrEmpty(productstock.MerchantProductNo))
                return await _service.UpdateProductStock(productstock.MerchantProductNo, 25);
            else
                throw new NotFoundException("No product number found");
            //  _logger.LogInformation($ "No product number given");
        }
        #endregion
    }
}
