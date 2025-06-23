using PT_LiderIT_Alejandro.Models.Entities;
using PT_LiderIT_Alejandro.Services.Interfaces;
using PT_LiderIT_Alejandro.Repositories.Interfaces;

namespace PT_LiderIT_Alejandro.Services
{
    public class TareaService: ITareaService
    {
        private readonly ITareaRepository _repository;

        public TareaService(ITareaRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Tarea>> ObtenerTodasAsync()
        {
            return await _repository.ObtenerTodasAsync();
        }

        public async Task<Tarea> ObtenerPorIdAsync(int id)
        {
            return await _repository.ObtenerPorIdAsync(id);
        }

        public async Task CrearAsync(Tarea tarea)
        {
            await _repository.CrearAsync(tarea);
        }

        public async Task MarcarComoCompletadaAsync(int id)
        {
            await _repository.MarcarComoCompletadaAsync(id);
        }

        public async Task EliminarAsync(int id)
        {
            await _repository.EliminarAsync(id);
        }
    }
}
