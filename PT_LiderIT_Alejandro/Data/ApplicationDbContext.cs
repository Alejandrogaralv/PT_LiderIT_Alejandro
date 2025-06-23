using Microsoft.EntityFrameworkCore;
using PT_LiderIT_Alejandro.Models.Entities;

namespace PT_LiderIT_Alejandro.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Tarea> Tareas { get; set; }
    }
}
