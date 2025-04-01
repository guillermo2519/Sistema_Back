using System;
using System.Collections.Generic;

namespace SistemaGestionDeCalidad.MODEL;

public partial class Indicadores
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public double? ValorMeta { get; set; }

    public double? ValorActual { get; set; }

    public DateOnly? FechaMedicion { get; set; }
}
