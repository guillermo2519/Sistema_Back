using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaGestionDeCalidad.MODEL;

public partial class Usuarios
{
    [Column("idUsuario")] // Nombre exacto de la columna en la base de datos
    public int idUsuario { get; set; }

    public string Nombre { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public DateTime? FechaRegistro { get; set; }

    public int Rol { get; set; }

    public int? IdEmpresa { get; set; }
    public string? Proceso { get; set; }


    public virtual ICollection<Acciones> Acciones { get; set; } = new List<Acciones>();

    public virtual ICollection<Auditorias> Auditoria { get; set; } = new List<Auditorias>();

    public virtual ICollection<Documentos> Documentos { get; set; } = new List<Documentos>();

    public virtual ICollection<Historial_Cambio> HistorialCambios { get; set; } = new List<Historial_Cambio>();

    public virtual Empresa? IdEmpresaNavigation { get; set; }

    public virtual ICollection<MejoraContinua> MejoraContinuas { get; set; } = new List<MejoraContinua>();

    public virtual Roles RolNavigation { get; set; } = null!; //relaciona el usuario con el rol
}
