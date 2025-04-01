using System;
using System.Collections.Generic;

namespace SistemaGestionDeCalidad.MODEL;

public partial class Menu
{
    public int IdMenu { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Icono { get; set; }

    public string Url { get; set; } = null!;

    public virtual ICollection<MenuRol> MenuRols { get; set; } = new List<MenuRol>();
}
