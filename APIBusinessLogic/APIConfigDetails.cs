using System;
namespace APIBusinessLogic
{
    /// <summary>
    /// This class carries required configurations required to call the APIs
    /// </summary>
    public class APIConfigDetails
    {
        #region Properties
        public string BaseUrl { get; set; }
        public string OrderAPI { get; set; }
        public string StockAPI { get; set; }
        public string ApiKey { get; set; }
        public Tuple<string, string> GetApiKeyQueryString()
        {
            return new Tuple<string, string>("apiKey", ApiKey);
        }
        #endregion
    }
}
