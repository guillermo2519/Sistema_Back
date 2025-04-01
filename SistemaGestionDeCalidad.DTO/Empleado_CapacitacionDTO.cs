namespace SistemaGestionDeCalidad.DTO
{
    public class Empleado_CapacitacionDTO
    {
        public int Id { get; set; }

        public int? IdEmpleado { get; set; }

        public int? IdCurso { get; set; }

        // Nuevas propiedades para mostrar nombres
        public string? NombreEmpleado { get; set; }
        public string? NombreCurso { get; set; }

    }
}
