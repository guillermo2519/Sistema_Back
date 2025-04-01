using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaGestionDeCalidad.MODEL;


        public partial class Tareas
        {
            public int ID { get; set; }
            public string TITLE { get; set; } = string.Empty;
            public string? DESCRIPCION { get; set; }
            public bool COMPLETED { get; set; } = false;
            public string PROCESO { get; set; } = string.Empty;
            public string APRUEBA { get; set; } = string.Empty;
            public DateTime CREATED_AT { get; set; } = DateTime.UtcNow;
            public DateTime? UPDATED_AT { get; set; }
            public int? ID_USUARIO { get; set; }
            public int? ID_EMPRESA { get; set; }

            public virtual Usuarios? Usuario { get; set; }
}

    

