using System.Collections.Generic;

namespace APIEntities.OrdersEntity
{
    /// <summary>
    /// This class is a part of CollectionOfMerchantResponses JSON data 
    /// </summary>
    public class Product_Contents
    {
        public List<Products_LineDetails> Lines { get; set; }
    }
}
