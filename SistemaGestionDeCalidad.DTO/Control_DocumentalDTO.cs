using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaGestionDeCalidad.DTO
{
    public class Control_DocumentalDTO
    {
        public int? ID { get; set; } //acepta nulo
        public string MOTIVO_ALTA { get; set; }
        public string TIPO_DOCUMENTO { get; set; }
        public string CODIGO { get; set; }
        public int? TIEMPO_RETENCION { get; set; } // Acepta nulo
        public string NOMBRE_DOCUMENTO { get; set; }
        public string PROCESO { get; set; }
        public string APRUEBA { get; set; }
        public string ARCHIVO_URL { get; set; }
        public DateTime? FECHA_CREACION { get; set; } // Acepta nulo
        public DateTime? FECHA_ACTUALIZACION { get; set; } // Acepta nulo
        public int? ID_USUARIO { get; set; } // Acepta nulo
        public string? ESTADO { get; set; } // Acepta nulo
        [Column("ID_EMPRESA")]  // Esto mapea la propiedad IdEmpresa a la columna ID_EMPRESA
        public int? ID_EMPRESA { get; set; }
        public string? COMENTARIOS { get; set; } // ➕ Agregado

        public string? NombreUsuario { get; set; } // Acepta nulo// Extra: Nombre del usuario que creó el documento
    }
}
