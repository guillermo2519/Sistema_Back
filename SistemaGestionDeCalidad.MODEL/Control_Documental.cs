using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaGestionDeCalidad.MODEL;

public partial class ControlDocumental
{
    public int ID { get; set; }
    public string MOTIVO_ALTA { get; set; } = null!;
    public string TIPO_DOCUMENTO { get; set; } = null!;
    public string CODIGO { get; set; } = null!;
    public int? TIEMPO_RETENCION { get; set; }
    public string NOMBRE_DOCUMENTO { get; set; } = null!;
    public string PROCESO { get; set; } = null!;
    public string APRUEBA { get; set; } = null!;
    public string? ARCHIVO_URL { get; set; }
    public DateTime FECHA_CREACION { get; set; }
    public DateTime? FECHA_ACTUALIZACION { get; set; }
    public int? ID_USUARIO { get; set; }
    public string ESTADO { get; set; } = "Activo";
    [Column("ID_EMPRESA")]  // Esto mapea la propiedad IdEmpresa a la columna ID_EMPRESA
    public int? ID_EMPRESA { get; set; }
    public string? COMENTARIOS { get; set; } // ➕ Agregado el campo de comentarios

    // Relaciones
    public virtual Usuarios? Usuario { get; set; }

}
