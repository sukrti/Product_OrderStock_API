using APIBusinessLogic;
using APIBusinessLogic.Orders.Contracts;
using APIEntities.Enums;
using APIEntities.OrdersEntity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_WebApplication.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    public class ProductOrderController : ControllerBase
    {
        private readonly IProductOrderService _service;
        private readonly IConfiguration _config;
        public ProductOrderController(IProductOrderService service, IConfiguration config)
        {
            _service = service;
            _config = config;
        }

        /// <summary>
        /// This method fetches the top five orders whose status is in IN_PROGRESS
        /// </summary>
        /// <returns>List of Orders with the status IN_PROGRESS</returns>

        [HttpGet]
        public async Task<IEnumerable<ProductOrderDetails>> GetTopFiveProductDetails()
        {
            try
            {
                // Taking all the necessary configurations settings
                APIConfigDetails config = _config.GetSection("APIConfigurations").Get<APIConfigDetails>();

                // Sendind status and config settings to the Business logic to fetch the orders from API
                return await _service.GetAllInProgressProducts(new List<Product_Statuses> { Product_Statuses.IN_PROGRESS },
                    config.BaseUrl, config.OrderAPI, config.ApiKey);

            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
