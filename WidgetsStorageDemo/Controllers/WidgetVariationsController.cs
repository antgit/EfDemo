﻿using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WidgetsStorageDemo.Models;
using WidgetsStorageDemo.Services;

namespace WidgetsStorageDemo.Controllers
{
    [Route("variations")]
    public class WidgetVariationsController: Controller
    {
        private readonly WidgetsService _widgetsService;
        private readonly UnitOfWork _unitOfWork;

        public WidgetVariationsController(WidgetsService widgetsService, UnitOfWork unitOfWorkService)
        {
            _widgetsService = widgetsService;
            _unitOfWork = unitOfWorkService;
        }

        [HttpPost]
        public async Task<IActionResult> Create()
        {
            var id = await _widgetsService.Create();
            await _unitOfWork.Save();
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
            await _unitOfWork.Save();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            await _widgetsService.Delete(id);
            await _unitOfWork.Save();
            return NoContent();
        }
    }
}
