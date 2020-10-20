using System.Net.Http;
using AssistPurchaseCaseStudy;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;

namespace AssistPurchaseTests
{
    class TestProvider
    {
        public HttpClient Client { get; private set; }
        private TestServer _server;

        public TestProvider()
        {
            SetupClient();
        }

        private void SetupClient()
        {
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            Client = _server.CreateClient();
        }
    }
}
