using System;
using System.Collections.Generic;

namespace SistemaGestionDeCalidad.MODEL;

public partial class Acciones
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public string TipoAccion { get; set; } = null!;

    public int? IdNoConformidad { get; set; }

    public int? Responsable { get; set; }

    public DateOnly? FechaInicio { get; set; }

    public DateOnly? FechaCierre { get; set; }

    public string? Estado { get; set; }

    public virtual No_Conformidades? IdNoConformidadNavigation { get; set; }

    public virtual Usuarios? ResponsableNavigation { get; set; }
}
