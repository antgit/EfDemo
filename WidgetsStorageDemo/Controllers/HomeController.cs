using Microsoft.AspNetCore.Mvc;
using WidgetsStorageDemo.Models;

namespace WidgetsStorageDemo.Controllers
{
    [Route("")]
    public class HomeController: Controller
    {
        private readonly WidgetsContext _widgetsContext;

        public HomeController(WidgetsContext widgetsContext)
        {
            _widgetsContext = widgetsContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var widget = new WidgetVariation
            {
                Name = "Demo widget"
            };

            _widgetsContext.WidgetVariations.Add(widget);
            _widgetsContext.SaveChanges();

            return Ok();
        }

        [HttpPost]
        public IActionResult Post()
        {
            return Ok();
        }
    }
}
