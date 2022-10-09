using APIBusinessLogic.Stocks.Contracts;
using APIEntities.StockEntity;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace APIBusinessLogic.Stocks
{
    public class ProductStockService : IProductStockService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="productNumber">string</param>
        /// <param name="stock">int</param>
        /// <param name="baseUrl">string</param>
        /// <param name="stockApi">string</param>
        /// <param name="apikey">string</param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> UpdateProductStock(string productNumber, int stock, string baseUrl, string stockApi,
            string apikey)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                List<ProductStockDetails> productstockdetails = new List<ProductStockDetails>()
                {
                    new ProductStockDetails
                    {
                        MerchantProductNo = productNumber,
                        Stock = stock
                    }
                };
                Dictionary<string, string> records = new Dictionary<string, string>()
                {
                    ["apikey"] = apikey,
                };
                
               
                var requestContent = new StringContent(JsonConvert.SerializeObject(productstockdetails), Encoding.UTF8, "application/json");
             
                var response = await httpClient.PutAsync(Path.Combine(QueryHelpers.AddQueryString(baseUrl + stockApi, records)), requestContent);
                response.EnsureSuccessStatusCode();

                return response;
            }

            catch (HttpRequestException ex)
            {
                throw ex;
            }

        }
    }
}
