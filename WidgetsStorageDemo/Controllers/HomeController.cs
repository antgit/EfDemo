using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WidgetsStorageDemo.Services;

namespace WidgetsStorageDemo.Controllers
{
    [Route("")]
    public class HomeController: Controller
    {
        private readonly WidgetsService _widgetsService;

        public HomeController(WidgetsService widgetsService)
        {
            _widgetsService = widgetsService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var widget = await _widgetsService.GetWidget(2);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            return Ok();
        }
    }
}
