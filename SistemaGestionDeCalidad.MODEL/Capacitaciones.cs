using System;
using System.Collections.Generic;

namespace SistemaGestionDeCalidad.MODEL;

public partial class Capacitaciones
{
    public int Id { get; set; }

    public string NombreCurso { get; set; } = null!;

    public int? IdEmpleado { get; set; }

    public DateOnly? FechaInicio { get; set; }

    public DateOnly? FechaFin { get; set; }

    public string? Estado { get; set; }

    public virtual ICollection<Empleado_Capacitacion> EmpleadoCapacitacions { get; set; } = new List<Empleado_Capacitacion>();

    public virtual Rh? IdEmpleadoNavigation { get; set; }

}
