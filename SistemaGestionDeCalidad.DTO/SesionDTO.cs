namespace SistemaGestionDeCalidad.DTO
{
    public class SesionDTO
    {
        public int idUsuario { get; set; }
        public string? Nombre { get; set; } = null!;
        public string? Email { get; set; } = null!;
        public string? Descripcion { get; set; }
        public int Rol { get; set; } // Agregar esta propiedad
        public int IdEmpresa { get; set; }
        public string? Proceso { get; set; }
    }
}
