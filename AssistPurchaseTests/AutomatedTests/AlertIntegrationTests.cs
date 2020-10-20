
using AssistPurchaseCaseStudy.Models;
using System.Text;
using Xunit;
using Newtonsoft.Json;
using System.Net;
using System.Threading.Tasks;

using System.Net.Http;


namespace AssistPurchaseTests.AutomatedTests
{
    public class AlertIntegrationTests
    {
        private readonly TestProvider _test;
        private static string url = "https://localhost:5001/api/Alert";
        public AlertIntegrationTests()
        {
            _test = new TestProvider();
        }
        [Fact]
        public async Task TestGetConsumers()
        {
            var response = await _test.Client.GetAsync(url + "/Consumers");
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        [Fact]
        public async Task TestGetRegionSpecificConsumers()
        {
            var response = await _test.Client.GetAsync(url + "/Consumers/Pune");
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        [Fact]
        public async Task TestPostWhenCustomerConfirmsProduct()
        {
            var customer = new AlertDataModel()
            {
                CustomerName = "Jack",
                CustomerContactNo = "9876543210",
                CustomerEmailId = "jack@gmail.com",
                CustomerRegion = "Aurangabad",
                ProductIdConfirmed = "P103"

            };
            var response = await _test.Client.PostAsync(url + "/ConfirmationAlert",
                new StringContent(JsonConvert.SerializeObject(customer), Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

    }
}
