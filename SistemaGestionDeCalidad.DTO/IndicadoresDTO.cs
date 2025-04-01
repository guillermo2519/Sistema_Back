namespace SistemaGestionDeCalidad.DTO
{
    public class IndicadoresDTO
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string? Descripcion { get; set; }

        public double? ValorMeta { get; set; }

        public double? ValorActual { get; set; }
    }
}
