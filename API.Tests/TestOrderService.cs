using APIBusinessLogic.Orders;
using APIBusinessLogic.Orders.Contracts;
using APIEntities.OrdersEntity;
using Bogus;
using Moq;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using Xunit;

namespace API.Tests
{
    public class TestOrderService
    {
        private readonly IProductOrderService _orderService;

        [Fact]
        public void GetTopFiveOrdersRecord_ShouldReturn_CountFive()
        {
            // Mock productOrderService class to test GetTopFiveRecords() method
            var productOrderServices = new Mock<ProductOrderServices>();

            // Pass if records count is not more than 5
            Assert.InRange(productOrderServices.Object.GetTopFiveRecords(GetRecords()).Count(), 0, 5);
        }

        private Product_CollectionOfReponses GetRecords()
        {
            var lineFaker = new Faker<Products_LineDetails>()
                .RuleFor(x => x.MerchantProductNo, faker => faker.Commerce.Product())
                .RuleFor(x => x.Gtin, faker => faker.Commerce.Ean8())
                .RuleFor(x => x.Description, faker => faker.Commerce.ProductDescription())
                .RuleFor(x => x.Quantity, Faker => Faker.Commerce.Random.Number(0, 50));

            var contentFaker = new Faker<Product_Contents>()
                .RuleFor(x => x.Lines, l => lineFaker.Generate(5).ToList());

            var Product_CollectionOfReponses = new Faker<Product_CollectionOfReponses>()
               .RuleFor(x => x.Content, c => contentFaker.Generate(100));

            return Product_CollectionOfReponses;

        }
    }
}
