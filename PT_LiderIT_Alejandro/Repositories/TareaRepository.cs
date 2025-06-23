using PT_LiderIT_Alejandro.Models.Entities;
using PT_LiderIT_Alejandro.Repositories.Interfaces;
using PT_LiderIT_Alejandro.Data;
using System;
using Microsoft.EntityFrameworkCore;
namespace PT_LiderIT_Alejandro.Repositories
{
    public class TareaRepository: ITareaRepository
    {
        private readonly ApplicationDbContext _context;

        public TareaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tarea>> ObtenerTodasAsync()
        {
            return await _context.Tareas.ToListAsync();
        }

        public async Task<Tarea> ObtenerPorIdAsync(int id)
        {
            return await _context.Tareas.FindAsync(id);
        }

        public async Task CrearAsync(Tarea tarea)
        {
            tarea.FechaCreacion = DateTime.UtcNow;
            _context.Tareas.Add(tarea);
            await _context.SaveChangesAsync();
        }

        public async Task MarcarComoCompletadaAsync(int id)
        {
            var tarea = await _context.Tareas.FindAsync(id);
            if (tarea != null)
            {
                tarea.EstaCompleta = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task EliminarAsync(int id)
        {
            var tarea = await _context.Tareas.FindAsync(id);
            if (tarea != null)
            {
                _context.Tareas.Remove(tarea);
                await _context.SaveChangesAsync();
            }
        }
    }
}
