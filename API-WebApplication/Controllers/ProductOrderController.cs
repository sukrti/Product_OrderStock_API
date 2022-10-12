using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using APIBusinessLogic.Orders.Contracts;
using APIEntities.Enums;
using APIEntities.OrdersEntity;
using Microsoft.AspNetCore.Mvc;

namespace API_WebApplication.Controllers
{
    /// <summary>
    /// ProductOrderController decalartion
    /// </summary>    
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    public class ProductOrderController : ControllerBase
    {
        #region Fields Declaration
        private readonly IProductOrderService _service;
        #endregion

        #region Constructor Declaration
        public ProductOrderController(IProductOrderService service)
        {
            _service = service;
        }
        #endregion

        #region HTTP Requests Declaration
        /// <summary>
        /// This method fetches the top five orders whose status is in IN_PROGRESS
        /// </summary>
        /// <returns>IEnumerable<ProductOrderDetails></returns>
        [HttpGet]
        public async Task<IEnumerable<ProductOrderDetails>> GetTopFiveProductDetails()
        {
            try
            {
                // Sendind status to the service to fetch the orders from API              
                return await _service.GetAllInProgressProducts(new List<Product_Statuses> { Product_Statuses.IN_PROGRESS });
            }

            catch (Exception)
            {
                // logger can be used to log the exceptions with - _logger.LogError("something went wrong!"{ex})
                return null;
            }
        }
        #endregion
    }
}
