namespace SistemaGestionDeCalidad.DTO
{
    public class DocumentosDTO
    {
        public int Id { get; set; }

        public string Titulo { get; set; } = null!;

        public string? Descripcion { get; set; }

        public string? Version { get; set; }

        public int? IdUsuario { get; set; }

        public string? Estado { get; set; }

        public string? ArchivoUrl { get; set; }

        public string? UsuarioNombre { get; set; } //propiedad adicional 
    }
}
