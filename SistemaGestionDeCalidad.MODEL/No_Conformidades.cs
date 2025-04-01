using System;
using System.Collections.Generic;

namespace SistemaGestionDeCalidad.MODEL;

public partial class No_Conformidades
{
    public int Id { get; set; }

    public int? IdAuditoria { get; set; }

    public string? Descripcion { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public string? Estado { get; set; }

    public string? PlanAccion { get; set; }

    public DateOnly? FechaCierre { get; set; }

    public virtual ICollection<Acciones> Acciones { get; set; } = new List<Acciones>();

    public virtual Auditorias? IdAuditoriaNavigation { get; set; }
}
