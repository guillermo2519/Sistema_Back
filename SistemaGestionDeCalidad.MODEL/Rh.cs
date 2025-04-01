using System;
using System.Collections.Generic;

namespace SistemaGestionDeCalidad.MODEL;

public partial class Rh
{
    public int Id { get; set; }

    public string NombreEmpleado { get; set; } = null!;

    public DateOnly? FechaIngreso { get; set; }

    public string? Puesto { get; set; }

    public string? ExpedienteUrl { get; set; }

    public virtual ICollection<Capacitaciones> Capacitaciones { get; set; } = new List<Capacitaciones>();

    public virtual ICollection<Empleado_Capacitacion> EmpleadoCapacitacions { get; set; } = new List<Empleado_Capacitacion>();
}
