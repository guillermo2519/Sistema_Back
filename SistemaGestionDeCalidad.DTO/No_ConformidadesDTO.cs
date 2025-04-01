namespace SistemaGestionDeCalidad.DTO
{
    public class No_ConformidadesDTO
    {
        public int Id { get; set; }

        public int? IdAuditoria { get; set; }

        public string? Descripcion { get; set; }

        public string? Estado { get; set; }

        public string? PlanAccion { get; set; }
    }
}
