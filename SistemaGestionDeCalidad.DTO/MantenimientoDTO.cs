namespace SistemaGestionDeCalidad.DTO
{
    public class MantenimientoDTO
    {
        public int Id { get; set; }

        public string NombreEquipo { get; set; } = null!;

        public string? Tipo { get; set; }

        public string? Informe { get; set; }
    }
}
