using System;
using System.Collections.Generic;

namespace SistemaGestionDeCalidad.MODEL;

public partial class Propiedad_Cliente
{
    public int Id { get; set; }

    public string NombreActivo { get; set; } = null!;

    public int? IdCliente { get; set; }

    public string? Descripcion { get; set; }

    public DateOnly? FechaEntrega { get; set; }

    public string? Estado { get; set; }

    public virtual Clientes? IdClienteNavigation { get; set; }
}
