using AssistPurchaseCaseStudy.Controllers;
using AssistPurchaseCaseStudy.Repository;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using AssistPurchaseCaseStudy.Models;

namespace AssistPurchaseTests
{
    public class AlertControllerTests
    {
        AlertController _productsController;
        public AlertControllerTests()
        {
            IAlertRepository repository = new AlertRepository();
            _productsController = new AlertController(repository);
        }
        [Fact]
        public void TestPostWithValidData()
        {

            AlertDataModel alertDataModel = new AlertDataModel()
            {
                CustomerName = "Tom",
                CustomerContactNo = "8765432019",
                CustomerRegion = "Pune",
                CustomerEmailId = "tom@gmail.com",
                ProductIdConfirmed = "P101"
            };
            var codereceived = _productsController.Post(alertDataModel);
            Assert.IsType<OkObjectResult>(codereceived);

        }
        [Fact]
        public void TestPostWithEmptyInValidData()
        {

            AlertDataModel alertDataModel = new AlertDataModel()
            { };
            var codereceived = _productsController.Post(alertDataModel);
            Assert.IsType<BadRequestObjectResult>(codereceived);

        }
       
        [Fact]
        public void TestPostWithNoCustomerName()
        {

            AlertDataModel alertDataModel = new AlertDataModel()
            {
                CustomerRegion = "Pune",
                CustomerEmailId = "tom@gmail.com",
                ProductIdConfirmed = "P101"
            };
            var codereceived = _productsController.Post(alertDataModel);
            Assert.IsType<BadRequestObjectResult>(codereceived);

        }
        [Fact]
        public void TestPostWithInvalidContactNo()
        {

            AlertDataModel alertDataModel = new AlertDataModel()
            {
                CustomerName = "tom",
                CustomerContactNo = "87654320",
                CustomerRegion = "Pune",
                CustomerEmailId = "tom@gmail.com",
                ProductIdConfirmed = "P101"
            };
            var codereceived = _productsController.Post(alertDataModel);
            Assert.IsType<BadRequestObjectResult>(codereceived);

        }
        [Fact]
        public void TestPostWithInvalidProductIdConfirmed()
        {

            AlertDataModel alertDataModel = new AlertDataModel()
            {
                CustomerName = "tom",
                CustomerContactNo = "8765432078",
                CustomerRegion = "Pune",
                CustomerEmailId = "tom@gmail.com",
                ProductIdConfirmed = "P2309"
            };
            var codereceived = _productsController.Post(alertDataModel);
            Assert.IsType<BadRequestObjectResult>(codereceived);

        }
        [Fact]
        public void TestGetCustomer()
        {
            AlertDataModel alertDataModel = new AlertDataModel()
            {
                CustomerName = "Tom",
                CustomerContactNo = "8765432019",
                CustomerRegion = "Pune",
                CustomerEmailId = "tom@gmail.com",
                ProductIdConfirmed = "P101"
            };
            _productsController.Post(alertDataModel);

            var datareceived = _productsController.Get();
            Assert.NotEmpty(datareceived);

        }
        [Fact]
        public void TestGetCustomersOfSpecificRegion()
        {
            AlertDataModel alertDataModel = new AlertDataModel()
            {
                CustomerName = "Tom",
                CustomerContactNo = "8765432019",
                CustomerRegion = "Pune",
                CustomerEmailId = "tom@gmail.com",
                ProductIdConfirmed = "P101"
            };
            _productsController.Post(alertDataModel);

            var datareceived = _productsController.Get("Pune");
            Assert.IsType<OkObjectResult>(datareceived);

        }
        [Fact]
        public void TestWhenThereAreNoCustomersOfSpecificRegion()
        {
            AlertDataModel alertDataModel = new AlertDataModel()
            {
                CustomerName = "Tom",
                CustomerContactNo = "8765432019",
                CustomerRegion = "Pune",
                CustomerEmailId = "tom@gmail.com",
                ProductIdConfirmed = "P101"
            };
            _productsController.Post(alertDataModel);

            var datareceived = _productsController.Get("Mumbai");
            Assert.IsType<NotFoundObjectResult>(datareceived);
        }

    }
}
