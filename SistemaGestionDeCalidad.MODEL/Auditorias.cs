using System;
using System.Collections.Generic;

namespace SistemaGestionDeCalidad.MODEL;

public partial class Auditorias
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int? IdAuditor { get; set; }

    public DateTime? FechaProgramada { get; set; } // se cambio de DateOnly a DateTime

    public DateOnly? FechaRealizada { get; set; }

    public string? Resultado { get; set; }

    public string? Informe { get; set; }

    public virtual Usuarios? IdAuditorNavigation { get; set; }

    public virtual ICollection<No_Conformidades> NoConformidades { get; set; } = new List<No_Conformidades>();
}
