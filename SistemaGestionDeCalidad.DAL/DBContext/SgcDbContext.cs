using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SistemaGestionDeCalidad.MODEL;

namespace SistemaGestionDeCalidad.DAL.DBContext;

public partial class SgcDbContext : DbContext 
{
    public SgcDbContext()
    {
    }

    public SgcDbContext(DbContextOptions<SgcDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Acciones> Acciones { get; set; }

    public virtual DbSet<Auditorias> Auditorias { get; set; }

    public virtual DbSet<Capacitaciones> Capacitaciones { get; set; }

    public virtual DbSet<Clientes> Clientes { get; set; }

    public virtual DbSet<Documentos> Documentos { get; set; }

    public virtual DbSet<Empleado_Capacitacion> EmpleadoCapacitacions { get; set; }

    public virtual DbSet<Empresa> Empresas { get; set; }

    public virtual DbSet<Historial_Cambio> HistorialCambios { get; set; }

    public virtual DbSet<Indicadores> Indicadores { get; set; }

    public virtual DbSet<Mantenimiento> Mantenimientos { get; set; }

    public virtual DbSet<MejoraContinua> MejoraContinuas { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<MenuRol> MenuRols { get; set; }

    public virtual DbSet<No_Conformidades> NoConformidades { get; set; }

    public virtual DbSet<Propiedad_Cliente> PropiedadClientes { get; set; }

    public virtual DbSet<Proveedores> Proveedores { get; set; }

    public virtual DbSet<Rh> Rhs { get; set; }

    public virtual DbSet<Riesgos> Riesgos { get; set; }

    public virtual DbSet<Roles> Roles { get; set; }

    public virtual DbSet<Satisfaccion_Cliente> SatisfaccionClientes { get; set; }

    public virtual DbSet<Usuarios> Usuarios { get; set; }

    public virtual DbSet<ControlDocumental> ControlDocumental { get; set; }

    public virtual DbSet<Tareas> Tareas { get; set; }
    public virtual DbSet<Notificaciones> Notificaciones { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Acciones>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ACCIONES__3214EC27434C0295");

            entity.ToTable("ACCIONES");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("DESCRIPCION");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ESTADO");
            entity.Property(e => e.FechaCierre).HasColumnName("FECHA_CIERRE");
            entity.Property(e => e.FechaInicio).HasColumnName("FECHA_INICIO");
            entity.Property(e => e.IdNoConformidad).HasColumnName("ID_NO_CONFORMIDAD");
            entity.Property(e => e.Responsable).HasColumnName("RESPONSABLE");
            entity.Property(e => e.TipoAccion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TIPO_ACCION");

            entity.HasOne(d => d.IdNoConformidadNavigation).WithMany(p => p.Acciones)
                .HasForeignKey(d => d.IdNoConformidad)
                .HasConstraintName("FK__ACCIONES__ID_NO___4F7CD00D");

            entity.HasOne(d => d.ResponsableNavigation).WithMany(p => p.Acciones)
                .HasForeignKey(d => d.Responsable)
                .HasConstraintName("FK__ACCIONES__RESPON__5070F446");
        });

        modelBuilder.Entity<Auditorias>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AUDITORI__3214EC27EB276AF3");

            entity.ToTable("AUDITORIAS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.FechaProgramada).HasColumnName("FECHA_PROGRAMADA");
            entity.Property(e => e.FechaRealizada).HasColumnName("FECHA_REALIZADA");
            entity.Property(e => e.IdAuditor).HasColumnName("ID_AUDITOR");
            entity.Property(e => e.Informe)
                .HasColumnType("text")
                .HasColumnName("INFORME");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.Resultado)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("RESULTADO");

            entity.HasOne(d => d.IdAuditorNavigation).WithMany(p => p.Auditoria)
                .HasForeignKey(d => d.IdAuditor)
                .HasConstraintName("FK__AUDITORIA__ID_AU__3F466844");
        });

        modelBuilder.Entity<Capacitaciones>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CAPACITA__3214EC27F1B37BBA");

            entity.ToTable("CAPACITACIONES");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ESTADO");
            entity.Property(e => e.FechaFin).HasColumnName("FECHA_FIN");
            entity.Property(e => e.FechaInicio).HasColumnName("FECHA_INICIO");
            entity.Property(e => e.IdEmpleado).HasColumnName("ID_EMPLEADO");
            entity.Property(e => e.NombreCurso)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_CURSO");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.Capacitaciones)
                .HasForeignKey(d => d.IdEmpleado)
                .HasConstraintName("FK__CAPACITAC__ID_EM__5BE2A6F2");
        });

        modelBuilder.Entity<Clientes>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CLIENTES__3214EC271EC710A3");

            entity.ToTable("CLIENTES");

            entity.HasIndex(e => e.Email, "UQ__CLIENTES__161CF7247E503FAE").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Contacto)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CONTACTO");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("TELEFONO");
        });

        modelBuilder.Entity<Documentos>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DOCUMENT__3214EC27C9842E81");

            entity.ToTable("DOCUMENTOS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ArchivoUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ARCHIVO_URL");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("DESCRIPCION");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ESTADO");
            entity.Property(e => e.FechaActualizacion)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_ACTUALIZACION");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("FECHA_CREACION");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.Titulo)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("TITULO");
            entity.Property(e => e.Version)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("VERSION");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Documentos)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__DOCUMENTO__ID_US__3C69FB99");
        });

        modelBuilder.Entity<Empleado_Capacitacion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__EMPLEADO__3214EC27A0414B3B");

            entity.ToTable("EMPLEADO_CAPACITACION");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdCurso).HasColumnName("ID_CURSO");
            entity.Property(e => e.IdEmpleado).HasColumnName("ID_EMPLEADO");

            entity.HasOne(d => d.IdCursoNavigation).WithMany(p => p.EmpleadoCapacitacions)
                .HasForeignKey(d => d.IdCurso)
                .HasConstraintName("FK__EMPLEADO___ID_CU__6477ECF3");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.EmpleadoCapacitacions)
                .HasForeignKey(d => d.IdEmpleado)
                .HasConstraintName("FK__EMPLEADO___ID_EM__6383C8BA");
        });

        modelBuilder.Entity<Empresa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__EMPRESA__3214EC27D54DE217");

            entity.ToTable("EMPRESA");

            entity.HasIndex(e => e.Email, "UQ__EMPRESA__161CF7249E3D07A8").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("DIRECCION");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("FECHA_REGISTRO");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("TELEFONO");
        });

        modelBuilder.Entity<Historial_Cambio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__HISTORIA__3214EC27C31D5CC5");

            entity.ToTable("HISTORIAL_CAMBIOS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Accion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ACCION");
            entity.Property(e => e.Entidad)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ENTIDAD");
            entity.Property(e => e.FechaCambio)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("FECHA_CAMBIO");
            entity.Property(e => e.IdEntidad).HasColumnName("ID_ENTIDAD");
            entity.Property(e => e.Usuario).HasColumnName("USUARIO");

            entity.HasOne(d => d.UsuarioNavigation).WithMany(p => p.HistorialCambios)
                .HasForeignKey(d => d.Usuario)
                .HasConstraintName("FK__HISTORIAL__USUAR__68487DD7");
        });

        modelBuilder.Entity<Indicadores>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__INDICADO__3214EC27F86DBD6D");

            entity.ToTable("INDICADORES");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("DESCRIPCION");
            entity.Property(e => e.FechaMedicion).HasColumnName("FECHA_MEDICION");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.ValorActual).HasColumnName("VALOR_ACTUAL");
            entity.Property(e => e.ValorMeta).HasColumnName("VALOR_META");
        });

        modelBuilder.Entity<Mantenimiento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MANTENIM__3214EC271103A5C3");

            entity.ToTable("MANTENIMIENTO");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.FechaProgramada).HasColumnName("FECHA_PROGRAMADA");
            entity.Property(e => e.FechaRealizada).HasColumnName("FECHA_REALIZADA");
            entity.Property(e => e.Informe)
                .HasColumnType("text")
                .HasColumnName("INFORME");
            entity.Property(e => e.NombreEquipo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_EQUIPO");
            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TIPO");
        });

        modelBuilder.Entity<MejoraContinua>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MEJORA_C__3214EC2710F66ACC");

            entity.ToTable("MEJORA_CONTINUA");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ESTADO");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("FECHA_CREACION");
            entity.Property(e => e.Idea)
                .HasColumnType("text")
                .HasColumnName("IDEA");
            entity.Property(e => e.Metodologia)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("METODOLOGIA");
            entity.Property(e => e.Responsable).HasColumnName("RESPONSABLE");

            entity.HasOne(d => d.ResponsableNavigation).WithMany(p => p.MejoraContinuas)
                .HasForeignKey(d => d.Responsable)
                .HasConstraintName("FK__MEJORA_CO__RESPO__59063A47");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.IdMenu).HasName("PK__MENU__C26AF483E4858F9B");

            entity.ToTable("MENU");

            entity.Property(e => e.IdMenu).HasColumnName("idMenu");
            entity.Property(e => e.Icono)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("icono");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Url)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("url");
        });

        modelBuilder.Entity<MenuRol>(entity =>
        {
            entity.HasKey(e => e.IdMenuRol).HasName("PK__MENU_ROL__9D6D61A4D505DA85");

            entity.ToTable("MENU_ROL");

            entity.Property(e => e.IdMenuRol).HasColumnName("idMenuRol");
            entity.Property(e => e.IdMenu).HasColumnName("idMenu");
            entity.Property(e => e.IdRol).HasColumnName("idRol");

            entity.HasOne(d => d.IdMenuNavigation).WithMany(p => p.MenuRols)
                .HasForeignKey(d => d.IdMenu)
                .HasConstraintName("FK__MENU_ROL__idMenu__7F2BE32F");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.MenuRols)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK__MENU_ROL__idRol__00200768");
        });

        modelBuilder.Entity<No_Conformidades>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__NO_CONFO__3214EC2764A3EB1A");

            entity.ToTable("NO_CONFORMIDADES");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("DESCRIPCION");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ESTADO");
            entity.Property(e => e.FechaCierre).HasColumnName("FECHA_CIERRE");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("FECHA_REGISTRO");
            entity.Property(e => e.IdAuditoria).HasColumnName("ID_AUDITORIA");
            entity.Property(e => e.PlanAccion)
                .HasColumnType("text")
                .HasColumnName("PLAN_ACCION");

            entity.HasOne(d => d.IdAuditoriaNavigation).WithMany(p => p.NoConformidades)
                .HasForeignKey(d => d.IdAuditoria)
                .HasConstraintName("FK__NO_CONFOR__ID_AU__4316F928");
        });

        modelBuilder.Entity<Propiedad_Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PROPIEDA__3214EC278F782894");

            entity.ToTable("PROPIEDAD_CLIENTE");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("DESCRIPCION");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ESTADO");
            entity.Property(e => e.FechaEntrega).HasColumnName("FECHA_ENTREGA");
            entity.Property(e => e.IdCliente).HasColumnName("ID_CLIENTE");
            entity.Property(e => e.NombreActivo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_ACTIVO");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.PropiedadClientes)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK_PropiedadCliente_Clientes");
        });

        modelBuilder.Entity<Proveedores>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PROVEEDO__3214EC279798D6C8");

            entity.ToTable("PROVEEDORES");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("DESCRIPCION");
            entity.Property(e => e.Evaluacion)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("EVALUACION");
            entity.Property(e => e.FechaEvaluacion).HasColumnName("FECHA_EVALUACION");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
        });

        modelBuilder.Entity<Rh>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RH__3214EC27CB1BD617");

            entity.ToTable("RH");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ExpedienteUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("EXPEDIENTE_URL");
            entity.Property(e => e.FechaIngreso).HasColumnName("FECHA_INGRESO");
            entity.Property(e => e.NombreEmpleado)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_EMPLEADO");
            entity.Property(e => e.Puesto)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("PUESTO");
        });

        modelBuilder.Entity<Riesgos>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RIESGOS__3214EC271FE93044");

            entity.ToTable("RIESGOS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("DESCRIPCION");
            entity.Property(e => e.Impacto)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("IMPACTO");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.PlanMitigacion)
                .HasColumnType("text")
                .HasColumnName("PLAN_MITIGACION");
            entity.Property(e => e.Probabilidad)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PROBABILIDAD");
        });

        modelBuilder.Entity<Roles>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ROLES__3214EC272120119C");

            entity.ToTable("ROLES");

            entity.HasIndex(e => e.Nombre, "UQ__ROLES__B21D0AB9032A56A8").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("DESCRIPCION");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
        });

        modelBuilder.Entity<Satisfaccion_Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SATISFAC__3214EC275F35A604");

            entity.ToTable("SATISFACCION_CLIENTE");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Cliente)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CLIENTE");
            entity.Property(e => e.Comentarios)
                .HasColumnType("text")
                .HasColumnName("COMENTARIOS");
            entity.Property(e => e.FechaEvaluacion).HasColumnName("FECHA_EVALUACION");
            entity.Property(e => e.Puntuacion).HasColumnName("PUNTUACION");
        });

        modelBuilder.Entity<Usuarios>(entity =>
        {
            entity.HasKey(e => e.idUsuario).HasName("PK__USUARIOS__3214EC2786251B49");

            entity.ToTable("USUARIOS");

            entity.HasIndex(e => e.Email, "UQ__USUARIOS__161CF7249B0E523F").IsUnique();

            entity.Property(e => e.idUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("FECHA_REGISTRO");
            entity.Property(e => e.IdEmpresa).HasColumnName("ID_EMPRESA");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("PASSWORD_HASH");
            entity.Property(e => e.Rol).HasColumnName("ROL");
            entity.Property(e => e.Proceso)
        .HasMaxLength(255) // Define el tamaño de la columna en la base de datos
        .IsUnicode(false)
        .HasColumnName("PROCESO");

            entity.HasOne(d => d.IdEmpresaNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdEmpresa)
                .HasConstraintName("FK__USUARIOS__ID_EMP__0F624AF8");

            entity.HasOne(d => d.RolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.Rol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Usuarios_Roles");
        });

        modelBuilder.Entity<ControlDocumental>(entity =>
        {
            entity.ToTable("CONTROL_DOCUMENTAL");

            entity.HasKey(e => e.ID);

            entity.Property(e => e.MOTIVO_ALTA).IsRequired().HasMaxLength(50);
            entity.Property(e => e.TIPO_DOCUMENTO).IsRequired().HasMaxLength(50);
            entity.Property(e => e.CODIGO).IsRequired().HasMaxLength(50);
            entity.Property(e => e.NOMBRE_DOCUMENTO).IsRequired().HasMaxLength(200);
            entity.Property(e => e.PROCESO).IsRequired().HasMaxLength(50);
            entity.Property(e => e.APRUEBA).IsRequired().HasMaxLength(50);
            entity.Property(e => e.ARCHIVO_URL).HasMaxLength(500);
            entity.Property(e => e.ESTADO).HasMaxLength(50).HasDefaultValue("Activo");
            entity.Property(e => e.FECHA_CREACION).HasDefaultValueSql("GETDATE()");
            entity.Property(e => e.COMENTARIOS).HasMaxLength(500);

            // Relación con la tabla USUARIOS por ID_USUARIO
            entity.HasOne(d => d.Usuario)
                .WithMany()
                .HasForeignKey(d => d.ID_USUARIO)
                .OnDelete(DeleteBehavior.ClientSetNull);

            // Relación con la tabla USUARIOS por ID_EMPRESA
            entity.HasOne(d => d.Usuario)  // Relación con usuario
                .WithMany()  // Relación inversa, si es necesario
                .HasForeignKey(d => d.ID_EMPRESA)  // Relación por IdEmpresa
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Tareas>(entity =>
        {
            entity.ToTable("TAREAS");  

            entity.HasKey(e => e.ID);  

            // Propiedades de la entidad Tareas
            entity.Property(e => e.TITLE)
                .IsRequired()  
                .HasMaxLength(200);  

            entity.Property(e => e.DESCRIPCION)
                .HasMaxLength(500);  

            entity.Property(e => e.COMPLETED)
                .IsRequired()  
                .HasDefaultValue(false);  

            entity.Property(e => e.PROCESO)
                .IsRequired()  
                .HasMaxLength(50);  

            entity.Property(e => e.APRUEBA)
                .IsRequired()  
                .HasMaxLength(50);  

            entity.Property(e => e.ID_USUARIO)
                .IsRequired();  

            entity.Property(e => e.ID_EMPRESA)
                .IsRequired(); 

            entity.Property(e => e.UPDATED_AT)
               .HasDefaultValueSql("GETDATE()");  

            entity.Property(e => e.CREATED_AT)
                .HasDefaultValueSql("GETDATE()");  

            // Relación con la tabla USUARIOS por ID_USUARIO
            entity.HasOne(d => d.Usuario)  // Relación con Usuario
                .WithMany()  // Relación inversa (si es necesario)
                .HasForeignKey(d => d.ID_USUARIO)  // Relación por ID_USUARIO
                .OnDelete(DeleteBehavior.ClientSetNull);  // Comportamiento al eliminar

            entity.HasOne(d => d.Usuario)  // Relación con usuario
                .WithMany()  // Relación inversa, si es necesario
                .HasForeignKey(d => d.ID_EMPRESA)  // Relación por IdEmpresa
                .OnDelete(DeleteBehavior.ClientSetNull);
        });




        modelBuilder.Entity<Notificaciones>(entity =>
        {
            entity.ToTable("NOTIFICACIONES");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.IdUsuario)
                .HasColumnName("ID_USUARIO") // Mapea correctamente el nombre de la columna
                .IsRequired();

            entity.Property(e => e.IdEmpresa)
                .HasColumnName("ID_EMPRESA") // Mapea correctamente el nombre de la columna
                .IsRequired(false); // Si no es obligatorio, puedes permitir nulos

            entity.Property(e => e.Mensaje)
                .HasColumnName("MENSAJE")
                .IsRequired();

            entity.Property(e => e.Tipo)
                .HasColumnName("TIPO")
                .IsRequired();

            entity.Property(e => e.FechaCreacion)
                .HasColumnName("FECHA_CREACION") // Mapea correctamente el nombre de la columna
                .HasDefaultValueSql("GETDATE()");

            entity.Property(e => e.Leido)
                .HasColumnName("LEIDO")
                .IsRequired()
                .HasDefaultValue(false);
        });




        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
