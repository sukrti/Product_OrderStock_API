using APIBusinessLogic;
using APIBusinessLogic.Stocks.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace API_WebApplication.Controllers
{
    [ApiController]

    [Route("api/v1/[controller]/[action]")]
    public class ProductStockController : ControllerBase
    {
        private readonly IProductStockService _service;
        private readonly IConfiguration _config;
        public ProductStockController(IProductStockService service, IConfiguration config)
        {
            _service = service;
            _config = config;
        }

        /// <summary>
        /// This method updates the current stock number to 25.It accepts productnumber from the user
        /// which is to update
        /// </summary>
        /// <returns>HTTPResponseMessage</returns>

        [HttpPut]
        public async Task<HttpResponseMessage> UpdateStockData(string productnumber)
        {
            try
            {
                // Taking all the necessary configurations settings
                APIConfigDetails config = _config.GetSection("APIConfigurations").Get<APIConfigDetails>();

                // Sendind productnumber,stock and config settings to the Business logic to update the stock
                if (config != null)
                    return await _service.UpdateProductStock(productnumber, 25, config.BaseUrl, config.StockAPI, config.ApiKey);
                else
                    return null;
            }

            catch (Exception)
            {
                // logger can be used to log the exceptions with - _logger.LogError("something went wrong!"{ex})
                return null;
            }
        }
    }
}
