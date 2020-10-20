using Xunit;
using AssistPurchaseCaseStudy.Models;
using AssistPurchaseCaseStudy.Controllers;
using AssistPurchaseCaseStudy.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AssistPurchaseTests
{
    public class ConfigureProductsControllerTests
    {
        ConfigureProductsController _productsController;
        public ConfigureProductsControllerTests()

        {
            IProductRepository productDataBaseRepository = new ProductRepository();
            _productsController = new ConfigureProductsController(productDataBaseRepository);
        }

        [Fact]
        public void GetWhenCalledReturnsNonEmptyList()
        {
            var products = _productsController.Get();
            Assert.NotEmpty(products);
        }
        [Fact]
        public void TestWithValidProductIdWhenGetSpecificProductByProductIdCalled()
        {
            var result = _productsController.GetSpecificProductByProductId("P101");
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public void TestWithInValidProductIdWhenGetSpecificProductByProductIdCalled()
        {
            var result = _productsController.GetSpecificProductByProductId("90876");
            Assert.IsType<NotFoundResult>(result);
        }
        [Fact]
        public void TestPostWithEmptyData()
        {
            Products product = new Products() { };
            var codeReceived = _productsController.Post(product);
            Assert.Equal(HttpStatusCode.BadRequest, codeReceived);
        }
        [Fact]
        public void TestPostWithEmptyProductIdData()
        {
            Products product = new Products()
            {
                Name="IntelliVue MX550",
                Services=new string[] {"Alarm"}
            };
           
            var codeReceived = _productsController.Post(product);
            Assert.Equal(HttpStatusCode.BadRequest, codeReceived);
        }
        [Fact]
        public void TestDeleteWithValidProductId()
        {

            var codeReceived = _productsController.Delete("P109");
            Assert.Equal(HttpStatusCode.OK, codeReceived);
        }
        [Fact]
        public void TestDeleteWithInValidProductId()
        {

            var codeReceived = _productsController.Delete("PX12011");
            Assert.Equal(HttpStatusCode.NotFound, codeReceived);
        }
        [Fact]
        public void TestPutWithValidData()
        {
            Products product = new Products()
            {
                ID = "P104",
                Name = "IntelliVue MX100",
                DisplaySize="above 15"
                
            };

            var codeReceived = _productsController.Put("P104", product);
            Assert.Equal(HttpStatusCode.OK, codeReceived);
        }
        [Fact]
        public void TestPutWithInValidProductId()
        {
            Products product = new Products()
            {
                ID = "P12090",
                Name = "IntelliVue MP3",
                DisplaySize = "10"
            };

            var codeReceived = _productsController.Put("P12090", product);
            Assert.Equal(HttpStatusCode.NotFound, codeReceived);
        }
        [Fact]
        public void TestPutWithMismatchData()
        {
            Products product = new Products()
            {
                ID = "P12090",//mismatch ids
                Name = "IntelliVue MP3",
                Services=new string[] {"Only Spo2"},
                DisplaySize = "10"
            };

            var codeReceived = _productsController.Put("P120790", product);//id not equal 
            Assert.Equal(HttpStatusCode.BadRequest, codeReceived);
        }
    }
}
