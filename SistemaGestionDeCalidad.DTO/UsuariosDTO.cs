namespace SistemaGestionDeCalidad.DTO
{
    public class UsuariosDTO
    {
        public int idUsuario { get; set; }
        public string? Nombre { get; set; } = null!;
        public string? Email { get; set; } = null!;
        public int? Rol { get; set; }
        public string? Descripcion { get; set; }
        public string? PasswordHash { get; set; }
        public int? IdEmpresa { get; set; }
        public string? Proceso { get; set; }
    }
}
