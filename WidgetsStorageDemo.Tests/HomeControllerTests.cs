using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
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
            var postResponse = await _testFixture.HttpClient.PostAsync("variations", null);
            postResponse.EnsureSuccessStatusCode();
            var widgetId = int.Parse(await postResponse.Content.ReadAsStringAsync());

            // Get
            var getResponse = await _testFixture.HttpClient.GetAsync($"variations/{widgetId}");
            getResponse.EnsureSuccessStatusCode();
            var widget = await _testFixture.GetResponseModelTyped<WidgetVariation>(getResponse);

            widget.Audiences.Clear();

            // Update
            var updateResponse = await _testFixture.HttpClient.PutAsync($"variations/{widgetId}", new JsonContent(widget));
            updateResponse.EnsureSuccessStatusCode();

            var getResponse2 = await _testFixture.HttpClient.GetAsync($"variations/{widgetId+1}");
            var widgetAfterUpdate = await _testFixture.GetResponseModelTyped<WidgetVariation>(getResponse2);
            widgetAfterUpdate.Audiences.Should().BeEmpty();
            widgetAfterUpdate.States.Should().HaveCount(2);

            var deleteResponse = await _testFixture.HttpClient.DeleteAsync($"variations/{widgetId}");
            deleteResponse.EnsureSuccessStatusCode();
        }

        [Test]
        public async Task CanDeleteAll()
        {
            var getResponse = await _testFixture.HttpClient.GetAsync("variations");
            getResponse.EnsureSuccessStatusCode();

            var widgets = await _testFixture.GetResponseModelTyped<List<WidgetVariation>>(getResponse);

            foreach (var widget in widgets)
            {
                var deleteResponse = await _testFixture.HttpClient.DeleteAsync($"variations/{widget.Id}");
                deleteResponse.EnsureSuccessStatusCode();
            }
        }
    }
}
