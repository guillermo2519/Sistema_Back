namespace SistemaGestionDeCalidad.DTO
{
    public class MenuRolDTO
    {
        public int IdMenuRol { get; set; }

        public int? IdMenu { get; set; }

        public int? IdRol { get; set; }

        // Propiedades adicionales
        public string? MenuNombre { get; set; }
        public string? RolNombre { get; set; }

    }
}
