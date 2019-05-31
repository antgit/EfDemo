using FluentAssertions;
using NUnit.Framework;
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
            // Create 
            var postResponse = await _testFixture.HttpClient.PostAsync("", null);
            postResponse.EnsureSuccessStatusCode();
            var widgetId = int.Parse(await postResponse.Content.ReadAsStringAsync());

            // Get
            var getResponse = await _testFixture.HttpClient.GetAsync($"{widgetId}");
            getResponse.EnsureSuccessStatusCode();
            var widget = await _testFixture.GetResponseModelTyped<WidgetVariation>(getResponse);

            widget.Audiences.Clear();

            // Update
            var updateResponse = await _testFixture.HttpClient.PutAsync($"{widgetId}", new JsonContent(widget));
            updateResponse.EnsureSuccessStatusCode();

            var getResponse2 = await _testFixture.HttpClient.GetAsync($"{widgetId}");
            var widgetAfterUpdate = await _testFixture.GetResponseModelTyped<WidgetVariation>(getResponse2);
            widgetAfterUpdate.Audiences.Should().BeEmpty();
            widgetAfterUpdate.States.Should().HaveCount(2);

            var deleteResponse = await _testFixture.HttpClient.DeleteAsync($"{widgetId}");
            deleteResponse.EnsureSuccessStatusCode();
        }
    }
}
