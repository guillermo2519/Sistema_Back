using System;
using System.Collections.Generic;

namespace SistemaGestionDeCalidad.MODEL;

public partial class MenuRol
{
    public int IdMenuRol { get; set; }

    public int? IdMenu { get; set; }

    public int? IdRol { get; set; }

    public virtual Menu? IdMenuNavigation { get; set; }

    public virtual Roles? IdRolNavigation { get; set; }
}
