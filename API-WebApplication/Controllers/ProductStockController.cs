using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using API_WebApplication.Exceptions;
using APIBusinessLogic;
using APIBusinessLogic.Stocks.Contracts;
using APIEntities.StockEntity;

namespace API_WebApplication.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    public class ProductStockController : ControllerBase
    {
        #region Fields
        private readonly IProductStockService _service;
        private readonly IConfiguration _config;
        #endregion

        #region Constructor
        public ProductStockController(IProductStockService service, IConfiguration config)
        {
            _service = service;
            _config = config;
        }
        #endregion

        #region HTTP Requests

        /// <summary>
        /// This method updates the current stock number to 25.It accepts productnumber from the user
        /// which is to update
        /// </summary>
        /// <returns>HTTPResponseMessage</returns>

        [HttpPut]
        public async Task<HttpResponseMessage> UpdateStockData(ProductStockDetails productstock)
        {
            // Taking all the necessary configurations settings
            APIConfigDetails config = _config.GetSection("APIConfigurations").Get<APIConfigDetails>();

            // Sendind productnumber,stock and config settings to the Business logic to update the stock
            if (config != null && !string.IsNullOrEmpty(productstock.MerchantProductNo))
                return await _service.UpdateProductStock(productstock.MerchantProductNo, 25, config.BaseUrl, config.StockAPI, config.ApiKey);
            else
                throw new NotFoundException("No product number found");
            //  _logger.LogInformation($ "No product number given");
        }
        #endregion
    }
}
