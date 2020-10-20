using AssistPurchaseCaseStudy.Models;
using System.Text;
using Xunit;
using Newtonsoft.Json;
using System.Net;
using System.Threading.Tasks;
using System.Net.Http;

namespace AssistPurchaseTests.AutomatedTests
{
    public class ConfigureProductsIntegrationTests
    {

        private readonly TestProvider _test;
        private static string url = "https://localhost:5001/api/ConfigureProducts";
        public ConfigureProductsIntegrationTests()
        {
            _test = new TestProvider();
        }
        [Fact]
        public async Task TestGetData()
        {
            var response = await _test.Client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        [Fact]
        public async Task TestGetDataWithSpecificId()
        {
            var response = await _test.Client.GetAsync(url + "/P101");
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        [Fact]
        public async Task TestPostData()
        {
            var product = new Products()
            {
                ID = "P113",
                Name = "IntelliVue MNP78",
                Features = new string[] { "Alarm", "Battery" },
                Services = new string[] { "Resp", "ESN" },
                DisplaySize = "upto 10"


            };
            var response = await _test.Client.PostAsync(url + "/AddProduct",
                 new StringContent(JsonConvert.SerializeObject(product), Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        [Fact]
        public async Task TestDeleteData()
        {

            var response = await _test.Client.DeleteAsync(url + "/RemoveProduct/P111");

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        [Fact]
        public async Task TestUpdateData()
        {
            var product = new Products()
            {
                ID = "P102",
                Name = "IntelliVue MNP78",

            };
            var response = await _test.Client.PutAsync(url + "/UpdateProduct/P102",
              new StringContent(JsonConvert.SerializeObject(product), Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

    }
}

