using Microsoft.AspNetCore.Mvc;
using PT_LiderIT_Alejandro.Models.Entities;
using PT_LiderIT_Alejandro.Services.Interfaces;

namespace PT_LiderIT_Alejandro.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TareasCotroller: ControllerBase
    {
        private readonly ITareaService _service;

        public TareasCotroller(ITareaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tareas = await _service.ObtenerTodasAsync();
            return Ok(tareas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var tarea = await _service.ObtenerPorIdAsync(id);
            if (tarea == null) return NotFound();
            return Ok(tarea);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Tarea tarea)
        {
            await _service.CrearAsync(tarea);
            return CreatedAtAction(nameof(GetById), new { id = tarea.Id }, tarea);
        }

        [HttpPatch("{id}/completar")]
        public async Task<IActionResult> MarcarComoCompletada(int id)
        {
            await _service.MarcarComoCompletadaAsync(id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.EliminarAsync(id);
            return NoContent();
        }
    }
}
