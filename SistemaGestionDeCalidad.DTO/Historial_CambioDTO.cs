namespace SistemaGestionDeCalidad.DTO
{
    public class Historial_CambioDTO
    {
        public int Id { get; set; }

        public string? Entidad { get; set; }

        public int? IdEntidad { get; set; }

        public string? Accion { get; set; }

        public int? Usuario { get; set; }

        // Nueva propiedad para el nombre del usuario
        public string? UsuarioNombre { get; set; }
    }
}
