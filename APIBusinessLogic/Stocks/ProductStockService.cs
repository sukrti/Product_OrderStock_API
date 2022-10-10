using System;
using System.IO;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using APIBusinessLogic.Stocks.Contracts;
using APIEntities.StockEntity;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;


namespace APIBusinessLogic.Stocks
{
    /// <summary>
    /// Main logic to call APIs
    /// </summary>
    public class ProductStockService : IProductStockService
    {
        /// <summary>
        /// This is the decalartion of a method that updates the product stock
        /// </summary>
        /// <param name="productNumber">string</param>
        /// <param name="stock">int</param>
        /// <param name="baseUrl">string</param>
        /// <param name="stockApi">string</param>
        /// <param name="apikey">string</param>
        /// <returns>HttpResponseMessage</returns>
        public async Task<HttpResponseMessage> UpdateProductStock(string productNumber, int stock, string baseUrl, string stockApi,
            string apikey)
        {
            HttpResponseMessage response = null;
            try
            {
                // Create http client object
                HttpClient httpClient = new HttpClient();

                //Create object of ProductStockDetails
                List<ProductStockDetails> productstockdetails = new List<ProductStockDetails>(){
                    new ProductStockDetails
                    {
                        MerchantProductNo = productNumber,
                        Stock = stock
                    }};

                //create a dictionary obj to pass the apikey
                Dictionary<string, string> record = new Dictionary<string, string>()
                {
                    ["apikey"] = apikey,
                };

                StringContent requestContent = new StringContent(JsonConvert.SerializeObject(productstockdetails), Encoding.UTF8, "application/json");
                if (requestContent != null)
                    response = await httpClient.PutAsync(Path.Combine(QueryHelpers.AddQueryString(baseUrl + stockApi, record)), requestContent);
               response.EnsureSuccessStatusCode();
                return response;
            }

            catch (HttpRequestException ex)
            {
                // logger can be used to log the exceptions with - _logger.LogError("something went wrong!"{ex})
                throw new Exception("Error occurred while updating the stock number:" + ex.Message);
            }
        }
    }
}
