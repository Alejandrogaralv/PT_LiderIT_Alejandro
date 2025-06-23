using PT_LiderIT_Alejandro.Models.Entities;

namespace PT_LiderIT_Alejandro.Repositories.Interfaces
{
    public interface ITareaRepository
    {
        Task<IEnumerable<Tarea>> ObtenerTodasAsync();
        Task<Tarea> ObtenerPorIdAsync(int id);
        Task CrearAsync(Tarea tarea);
        Task MarcarComoCompletadaAsync(int id);
        Task EliminarAsync(int id);
    }
}
