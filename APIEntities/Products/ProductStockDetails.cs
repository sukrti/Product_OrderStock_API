namespace APIEntities.StockEntity
{
    /// <summary>
    ///This class defines the required parameters needed to pass to a Stock API to update stock
    /// </summary>
    public class ProductStockDetails
    {
        public string MerchantProductNo { get; set; }
        public int Stock { get; set; }
        public ProductStockDetails()
        {

        }
    }
}
