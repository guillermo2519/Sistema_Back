namespace SistemaGestionDeCalidad.DTO
{
    public class EmpresaDTO
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string? Direccion { get; set; }

        public string? Telefono { get; set; }

        public string? Email { get; set; }
    }
}
