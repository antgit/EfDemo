using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WidgetsStorageDemo.Models;
using WidgetsStorageDemo.Services;

namespace WidgetsStorageDemo.Controllers
{
    [Route("variations")]
    public class WidgetVariationsController: Controller
    {
        private readonly WidgetsService _widgetsService;

        public WidgetVariationsController(WidgetsService widgetsService)
        {
            _widgetsService = widgetsService;
        }

        [HttpPost]
        public async Task<IActionResult> Create()
        {
            var id = await _widgetsService.Create();
            return Ok(id);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Read([FromRoute]int id)
        {
            var widget = await _widgetsService.Get(id);

            if(widget == null)
            {
                return NotFound();
            }

            return Ok(widget);
        }

        [HttpGet()]
        public async Task<IActionResult> Read()
        {
            var widget = await _widgetsService.GetAll();
            return Ok(widget);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute]int id, [FromBody]WidgetVariation model)
        {
            await _widgetsService.Update(id, model);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            await _widgetsService.Delete(id);
            return NoContent();
        }
    }
}
