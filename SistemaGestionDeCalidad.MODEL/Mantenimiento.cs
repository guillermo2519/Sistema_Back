using System;
using System.Collections.Generic;

namespace SistemaGestionDeCalidad.MODEL;

public partial class Mantenimiento
{
    public int Id { get; set; }

    public string NombreEquipo { get; set; } = null!;

    public string? Tipo { get; set; }

    public DateOnly? FechaProgramada { get; set; }

    public DateOnly? FechaRealizada { get; set; }

    public string? Informe { get; set; }
}
