namespace SistemaGestionDeCalidad.DTO
{
    public class Satisfaccion_ClienteDTO
    {
        public int Id { get; set; }

        public string Cliente { get; set; } = null!;

        public int? Puntuacion { get; set; }

        public string? Comentarios { get; set; }
    }
}
