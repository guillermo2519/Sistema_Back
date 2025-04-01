namespace SistemaGestionDeCalidad.DTO
{
    public class ProveedoresDTO
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string? Descripcion { get; set; }

        public string? Evaluacion { get; set; }
    }
}
