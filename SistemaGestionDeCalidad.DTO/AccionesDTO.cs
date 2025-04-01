namespace SistemaGestionDeCalidad.DTO
{
    public class AccionesDTO
    {
        public int Id { get; set; }

        public string Descripcion { get; set; } = null!;

        public string TipoAccion { get; set; } = null!;

        public int? IdNoConformidad { get; set; }

        public int? Responsable { get; set; }
    }
}
