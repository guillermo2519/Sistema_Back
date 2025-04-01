using System;
using System.Collections.Generic;

namespace SistemaGestionDeCalidad.MODEL;

public partial class MejoraContinua
{
    public int Id { get; set; }

    public string Idea { get; set; } = null!;

    public int? Responsable { get; set; }

    public string? Estado { get; set; }

    public string? Metodologia { get; set; }

    public DateOnly? FechaCreacion { get; set; }

    public virtual Usuarios? ResponsableNavigation { get; set; }
}
