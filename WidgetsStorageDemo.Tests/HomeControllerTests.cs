using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using WidgetsStorageDemo.Models;

namespace WidgetsStorageDemo.Tests
{
    public class HomeControllerTests
    {
        private TestFixture _testFixture;

        [SetUp]
        public async Task Setup()
        {
            _testFixture = new TestFixture();
        }

        [Test]
        public async Task CreateAndGetAndDeleteTest()
        {
            var postResponse = await _testFixture.HttpClient.PostAsync("", null);
            var widgetId = int.Parse(await postResponse.Content.ReadAsStringAsync());

            var getResponse = await _testFixture.HttpClient.GetAsync($"{widgetId}");
            var widget = await _testFixture.GetResponseModelTyped<WidgetVariation>(getResponse);

            var deleteResponse = await _testFixture.HttpClient.DeleteAsync($"{widgetId}");
            deleteResponse.EnsureSuccessStatusCode();
        }
    }
}
