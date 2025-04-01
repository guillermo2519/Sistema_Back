using System;
using System.Collections.Generic;

namespace SistemaGestionDeCalidad.MODEL;

public partial class Documentos
{
    public int Id { get; set; }

    public string Titulo { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string? Version { get; set; }

    public int? IdUsuario { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public string? Estado { get; set; }

    public string? ArchivoUrl { get; set; }

    public virtual Usuarios? IdUsuarioNavigation { get; set; }
}
