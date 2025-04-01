using System;
using System.Collections.Generic;

namespace SistemaGestionDeCalidad.MODEL;

public partial class Empleado_Capacitacion
{
    public int Id { get; set; }

    public int? IdEmpleado { get; set; }

    public int? IdCurso { get; set; }

    public virtual Capacitaciones? IdCursoNavigation { get; set; }

    public virtual Rh? IdEmpleadoNavigation { get; set; }
}
