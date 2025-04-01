namespace SistemaGestionDeCalidad.DTO
{
    public class Propiedad_ClienteDTO
    {
        public int Id { get; set; }

        public string NombreActivo { get; set; } = null!;

        public int? IdCliente { get; set; }

        public string? Descripcion { get; set; }

        public string? Estado { get; set; }

    }
}
