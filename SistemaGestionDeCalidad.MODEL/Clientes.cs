using System;
using System.Collections.Generic;

namespace SistemaGestionDeCalidad.MODEL;

public partial class Clientes
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Contacto { get; set; }

    public string? Telefono { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Propiedad_Cliente> PropiedadClientes { get; set; } = new List<Propiedad_Cliente>();
}
