using System;
using System.Collections.Generic;

namespace SistemaGestionDeCalidad.MODEL;

public partial class Historial_Cambio
{
    public int Id { get; set; }

    public string? Entidad { get; set; }

    public int? IdEntidad { get; set; }

    public string? Accion { get; set; }

    public int? Usuario { get; set; }

    public DateTime? FechaCambio { get; set; }

    public virtual Usuarios? UsuarioNavigation { get; set; }
}
