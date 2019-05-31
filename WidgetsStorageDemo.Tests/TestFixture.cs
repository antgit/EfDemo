using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace WidgetsStorageDemo.Tests
{
    public class TestFixture
    {
        public HttpClient HttpClient { get; }

        public TestFixture()
        {
            var builder = new WebHostBuilder()
                .UseStartup<Startup>();

            
            var testServer = new TestServer(builder);

            HttpClient = testServer.CreateClient();
        }

        public async Task<T> GetResponseModelTyped<T>(HttpResponseMessage response)
        {
            string content = await response.Content.ReadAsStringAsync();            
            var responseModel = JsonConvert.DeserializeObject<T>(content);
            return responseModel;            
        }
    }
}
