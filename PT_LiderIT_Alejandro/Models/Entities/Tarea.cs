namespace PT_LiderIT_Alejandro.Models.Entities
{
    public class Tarea
    {
        public int Id { get; set; }
        public required string Titulo { get; set; }
        public  string? Descripcion { get; set; }
        public bool EstaCompleta { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
