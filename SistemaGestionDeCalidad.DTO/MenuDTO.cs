namespace SistemaGestionDeCalidad.DTO
{
    public class MenuDTO
    {
        public int IdMenu { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Icono { get; set; }
        public string Url { get; set; } = null!;
    }
}
