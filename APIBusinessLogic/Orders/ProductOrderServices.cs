using APIBusinessLogic.Orders.Contracts;
using APIEntities.Enums;
using APIEntities.OrdersEntity;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace APIBusinessLogic.Orders
{
    /// <summary>
    /// Main logic to call APIs
    /// </summary>
    public class ProductOrderServices : IProductOrderService
    {
        /// <summary>
        /// This method fetches all the orders from API that is in IN_PROGRESS  status
        /// </summary>
        /// <param name="Statuses">List<Product_Statuses></param>
        /// <param name="BaseUrl">string</param>
        /// <param name="OrderApi">string</param>
        /// <param name="apikey"></param>
        /// <returns>var</returns>
        public async Task<Product_CollectionOfReponses> GetOrdersByStatus(List<Product_Statuses> Statuses, string BaseUrl, string OrderApi, string apikey)
        {
            HttpResponseMessage results=null;
            try
            {
                //Creat http client object
                HttpClient client = new HttpClient();

                Dictionary<string, string> record = new Dictionary<string, string>()
                {
                    ["apikey"] = apikey,
                    ["statuses"] = Statuses.FirstOrDefault().ToString()
                };

                results = await client.GetAsync(QueryHelpers.AddQueryString(BaseUrl + OrderApi, record));
                results.EnsureSuccessStatusCode();
            }

            catch(Exception ex)
            {

            }

            return JsonConvert.DeserializeObject<Product_CollectionOfReponses>(await results.Content.ReadAsStringAsync()) != null ?
             JsonConvert.DeserializeObject<Product_CollectionOfReponses>(await results.Content.ReadAsStringAsync()) : null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="statuses">List<Product_Statuses></param>
        /// <param name="baseUrl">string</param>
        /// <param name="OrderApi">string</param>
        /// <param name="apikey">string</param>
        /// <returns></returns>
        public async Task<IEnumerable<ProductOrderDetails>> GetAllInProgressProducts(List<Product_Statuses> statuses, string baseUrl,
            string OrderApi, string apikey)
        {
            try
            {
                //Calling Method to get all orders 
                Product_CollectionOfReponses order_inprogress_details = await GetOrdersByStatus(statuses, baseUrl, OrderApi, apikey);

                if (order_inprogress_details != null)
                    return GetTopFiveRecords(order_inprogress_details);
                else
                    return null;

            }

            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// This method fetches the top 5 records from the data
        /// </summary>
        /// <param name="responses">Product_CollectionOfReponses</param>
        /// <returns></returns>
        public IEnumerable<ProductOrderDetails> GetTopFiveRecords(Product_CollectionOfReponses responses)
        {
            try
            {
                return responses.Content.SelectMany(x => x.Lines)
                     .GroupBy(productnumber => productnumber.MerchantProductNo)
                     .Select(item => new ProductOrderDetails
                     {
                         ProductNumber = item.FirstOrDefault().MerchantProductNo,
                         Gtin = item.FirstOrDefault().Gtin,
                         Description = item.FirstOrDefault().Description,
                         Quantity = item.Sum(s => s.Quantity)
                     }).OrderByDescending(desc => desc.Quantity).Take(5);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
