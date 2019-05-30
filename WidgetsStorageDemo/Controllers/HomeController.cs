using Microsoft.AspNetCore.Mvc;

namespace WidgetsStorageDemo.Controllers
{
    [Route("")]
    public class HomeController: Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post()
        {
            return Ok();
        }
    }
}
