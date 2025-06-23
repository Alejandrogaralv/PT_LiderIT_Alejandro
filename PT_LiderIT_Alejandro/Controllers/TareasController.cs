using Microsoft.AspNetCore.Mvc;
using PT_LiderIT_Alejandro.Models.Entities;
using PT_LiderIT_Alejandro.Services.Interfaces;

namespace PT_LiderIT_Alejandro.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TareasController: ControllerBase
    {
        private readonly ITareaService _service;

        public TareasController(ITareaService service)
        {
            _service = service;
        }

        /// <summary>
        /// Obtiene la lista de todas las tareas.
        /// </summary>
        /// <returns>Una lista de tareas</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tareas = await _service.ObtenerTodasAsync();
            return Ok(tareas);
        }

        /// <summary>
        /// Obtiene una tarea por su identificador.
        /// </summary>
        /// <param name="id">Identificador de la tarea.</param>
        /// <returns>La tarea correspondiente, si existe.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var tarea = await _service.ObtenerPorIdAsync(id);
            if (tarea == null) return NotFound();
            return Ok(tarea);
        }

        /// <summary>
        /// Crea una nueva tarea.
        /// </summary>
        /// <param name="tarea">La tarea a crear.</param>
        /// <returns>La tarea creada.</returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Tarea tarea)
        {
            await _service.CrearAsync(tarea);
            return CreatedAtAction(nameof(GetById), new { id = tarea.Id }, tarea);
        }

        /// <summary>
        /// Marca una tarea como completada.
        /// </summary>
        /// <param name="id">Identificador de la tarea a completar.</param>
        /// <returns>No devuelve contenido si se completa con éxito.</returns>
        [HttpPatch("{id}/completar")]
        public async Task<IActionResult> MarcarComoCompletada(int id)
        {
            await _service.MarcarComoCompletadaAsync(id);
            return NoContent();
        }

        /// <summary>
        /// Elimina una tarea por su identificador.
        /// </summary>
        /// <param name="id">Identificador de la tarea a eliminar.</param>
        /// <returns>No devuelve contenido si la eliminación es exitosa.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.EliminarAsync(id);
            return NoContent();
        }
    }
}
