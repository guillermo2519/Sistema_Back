using System;
using System.Collections.Generic;

namespace SistemaGestionDeCalidad.MODEL;

public partial class Satisfaccion_Cliente
{
    public int Id { get; set; }

    public string Cliente { get; set; } = null!;

    public int? Puntuacion { get; set; }

    public string? Comentarios { get; set; }

    public DateOnly? FechaEvaluacion { get; set; }
}
