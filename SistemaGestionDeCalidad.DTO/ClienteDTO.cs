namespace SistemaGestionDeCalidad.DTO
{
    public class ClienteDTO
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string? Contacto { get; set; }

        public string? Telefono { get; set; }

        public string? Email { get; set; }

    }
}
