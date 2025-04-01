namespace SistemaGestionDeCalidad.DTO
{
    public class MejoraContinuaDTO
    {
        public int Id { get; set; }

        public string Idea { get; set; } = null!;

        public int? Responsable { get; set; }

        public string? Estado { get; set; }

        public string? Metodologia { get; set; }

        public DateOnly? FechaCreacion { get; set; }

    }
}
