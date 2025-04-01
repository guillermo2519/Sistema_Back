namespace SistemaGestionDeCalidad.DTO
{
    public class AuditoriasDTO
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public int? IdAuditor { get; set; }

        public string? Resultado { get; set; }

        public string? Informe { get; set; }
    }
}
