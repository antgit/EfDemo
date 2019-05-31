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

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var widget = await _widgetsService.GetWidget(id);
            return Ok(widget);
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            var id = await _widgetsService.CreateWidget();
            return Ok(id);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _widgetsService.Delete(id);
            return Ok();
        }
    }
}
