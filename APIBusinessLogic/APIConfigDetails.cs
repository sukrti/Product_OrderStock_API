using System;
namespace APIBusinessLogic
{
    /// <summary>
    /// This class carray all the required configurations that is required to call the APIs
    /// </summary>
    public class APIConfigDetails
    {
        public string BaseUrl { get; set; }
        public string OrderAPI { get; set; }
        public string StockAPI { get; set; }
        public string ApiKey { get; set; }
        public Tuple<string, string> GetApiKeyQueryString()
        {
            return new Tuple<string, string>("apiKey", ApiKey);
        }
    }
}
