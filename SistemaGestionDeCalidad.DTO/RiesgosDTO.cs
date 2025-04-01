namespace SistemaGestionDeCalidad.DTO
{
    public class RiesgosDTO
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string? Descripcion { get; set; }

        public string? Impacto { get; set; }

        public string? Probabilidad { get; set; }

        public string? PlanMitigacion { get; set; }
    }
}
