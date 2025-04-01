﻿using System;
using System.Collections.Generic;

namespace SistemaGestionDeCalidad.MODEL;

public partial class Roles
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public virtual ICollection<MenuRol> MenuRols { get; set; } = new List<MenuRol>();

    public virtual ICollection<Usuarios> Usuarios { get; set; } = new List<Usuarios>();
}
