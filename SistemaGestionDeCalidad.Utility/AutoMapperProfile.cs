using AutoMapper;
using SistemaGestionDeCalidad.DTO;
using SistemaGestionDeCalidad.MODEL;

namespace SistemaGestionDeCalidad.Utility
{
    public class AutoMapperProfile : Profile
    {
        //Dentro del constructor se crearan los mapeos
        public AutoMapperProfile()
        {
            #region Rol

            CreateMap<Roles, RolDTO>().ReverseMap();

            #endregion Rol

            #region Menu

            CreateMap<Menu, MenuDTO>().ReverseMap();

            #endregion Menu

            #region Usuario

            CreateMap<Usuarios, UsuariosDTO>()
                .ForMember(destino =>
                  destino.Descripcion,
                  opt => opt.MapFrom(origen => origen.IdEmpresaNavigation.Nombre)
                );

            CreateMap<Usuarios, SesionDTO>()
            .ForMember(dest => dest.Rol, opt => opt.MapFrom(src => src.RolNavigation.Id))
            .ForMember(dest => dest.IdEmpresa, opt => opt.MapFrom(src => src.IdEmpresa));


            CreateMap<UsuariosDTO, Usuarios>()
                 .ForMember(destino =>
                   destino.IdEmpresaNavigation,
                   opt => opt.Ignore()
                   );

            #endregion Usuario

            #region Control_Documental 
            // Mapeo de ControlDocumental a ControlDocumentalDTO
            CreateMap<ControlDocumental, Control_DocumentalDTO>()
                .ForMember(dest => dest.NombreUsuario, opt => opt.MapFrom(src => src.Usuario.Nombre)) // Si quieres incluir el nombre del usuario
                .ForMember(dest => dest.FECHA_CREACION, opt => opt.MapFrom(src => src.FECHA_CREACION))
                .ForMember(dest => dest.FECHA_ACTUALIZACION, opt => opt.MapFrom(src => src.FECHA_ACTUALIZACION))
                .ForMember(dest => dest.ID_EMPRESA, opt => opt.MapFrom(src => src.ID_EMPRESA))  // Mapeo de IdEmpresa
                .ForMember(dest => dest.COMENTARIOS, opt => opt.MapFrom(src => src.COMENTARIOS));

            // Mapeo inverso de ControlDocumentalDTO a ControlDocumental
            CreateMap<Control_DocumentalDTO, ControlDocumental>()
                .ForMember(dest => dest.Usuario, opt => opt.Ignore()) // Ignorar la propiedad de navegación
                .ForMember(dest => dest.FECHA_CREACION, opt => opt.Ignore()) // Ignorar al actualizar
                .ForMember(dest => dest.FECHA_ACTUALIZACION, opt => opt.MapFrom(_ => DateTime.Now))
                .ForMember(dest => dest.ID_EMPRESA, opt => opt.MapFrom(src => src.ID_EMPRESA))
                .ForMember(dest => dest.COMENTARIOS, opt => opt.MapFrom(src => src.COMENTARIOS)); ;  // Mapeo de IdEmpresa

            #endregion

            #region Tareas

            // Mapeo de Tareas a TareasDTO.TareaDto
            CreateMap<Tareas, TareasDTO>()
                .ForMember(dest => dest.TITLE, opt => opt.MapFrom(src => src.TITLE))
                .ForMember(dest => dest.DESCRIPCION, opt => opt.MapFrom(src => src.DESCRIPCION))
                .ForMember(dest => dest.COMPLETED, opt => opt.MapFrom(src => src.COMPLETED))
                .ForMember(dest => dest.PROCESO, opt => opt.MapFrom(src => src.PROCESO))
                .ForMember(dest => dest.APRUEBA, opt => opt.MapFrom(src => src.APRUEBA))
                .ForMember(dest => dest.ID_USUARIO, opt => opt.MapFrom(src => src.ID_USUARIO))
                .ForMember(dest => dest.ID_EMPRESA, opt => opt.MapFrom(src => src.ID_EMPRESA))
                .ForMember(dest => dest.UPDATED_AT, opt => opt.MapFrom(src => src.UPDATED_AT))
                .ForMember(dest => dest.CREATED_AT, opt => opt.MapFrom(src => src.CREATED_AT));

            // Mapeo inverso de TareasDTO.TareaDto a Tareas
            CreateMap<TareasDTO, Tareas>()
                .ForMember(dest => dest.TITLE, opt => opt.MapFrom(src => src.TITLE))
                .ForMember(dest => dest.DESCRIPCION, opt => opt.MapFrom(src => src.DESCRIPCION))
                .ForMember(dest => dest.COMPLETED, opt => opt.MapFrom(src => src.COMPLETED))
                .ForMember(dest => dest.PROCESO, opt => opt.MapFrom(src => src.PROCESO))
                .ForMember(dest => dest.APRUEBA, opt => opt.MapFrom(src => src.APRUEBA))
                .ForMember(dest => dest.ID_USUARIO, opt => opt.MapFrom(src => src.ID_USUARIO))
                .ForMember(dest => dest.ID_EMPRESA, opt => opt.MapFrom(src => src.ID_EMPRESA))
                .ForMember(dest => dest.UPDATED_AT, opt => opt.MapFrom(src => src.UPDATED_AT))
                .ForMember(dest => dest.CREATED_AT, opt => opt.MapFrom(src => src.CREATED_AT));

            #endregion Tareas

            #region Empresa

            CreateMap<Empresa, EmpresaDTO>().ReverseMap();

            #endregion Empresa

            #region Menu

            CreateMap<MenuRol, MenuRolDTO>()
                .ForMember(dest => dest.MenuNombre, opt => opt.MapFrom(src => src.IdMenuNavigation != null ? src.IdMenuNavigation.Nombre : null))
                .ForMember(dest => dest.RolNombre, opt => opt.MapFrom(src => src.IdRol != null ? src.IdRolNavigation.Nombre : null))
                .ReverseMap();

            #endregion Menu

            #region Documentos

            CreateMap<Documentos, DocumentosDTO>()
                .ForMember(dest => dest.UsuarioNombre,
                           opt => opt.MapFrom(src => src.IdUsuarioNavigation != null ? src.IdUsuarioNavigation.Nombre : null))
                .ReverseMap();

            #endregion Documentos

            #region Auditorias

            CreateMap<Auditorias, AuditoriasDTO>()
               .ForMember(dest => dest.IdAuditor, opt => opt.MapFrom(src => src.IdAuditorNavigation != null ? src.IdAuditorNavigation.Nombre : null))
               .ReverseMap();

            CreateMap<No_Conformidades, No_ConformidadesDTO>()
                .ForMember(dest => dest.IdAuditoria, opt => opt.MapFrom(src => src.IdAuditoriaNavigation.Nombre))
                .ReverseMap();

            #endregion Auditorias

            #region Indicadores

            CreateMap<Indicadores, IndicadoresDTO>().ReverseMap();

            #endregion Indicadores

            #region Riesgos

            CreateMap<Riesgos, RiesgosDTO>().ReverseMap();

            #endregion Riesgos

            #region Proveedores

            CreateMap<Proveedores, ProveedoresDTO>().ReverseMap();

            #endregion Proveedores

            #region Mantenimiento

            CreateMap<Mantenimiento, MantenimientoDTO>().ReverseMap();

            #endregion Mantenimiento

            #region Capacitaciones

            CreateMap<Capacitaciones, CapacitacionesDTO>().ReverseMap();

            CreateMap<Empleado_Capacitacion, Empleado_CapacitacionDTO>()
                    .ForMember(dest => dest.NombreEmpleado,
                opt => opt.MapFrom(src => src.IdEmpleadoNavigation != null ? src.IdEmpleadoNavigation.NombreEmpleado : null))
                   .ForMember(dest => dest.NombreCurso,
                opt => opt.MapFrom(src => src.IdCursoNavigation != null ? src.IdCursoNavigation.NombreCurso : null))
                   .ReverseMap();

            #endregion Capacitaciones

            #region HistorialCambios

            CreateMap<Historial_Cambio, Historial_CambioDTO>()
                .ForMember(dest => dest.UsuarioNombre,
                           opt => opt.MapFrom(src => src.UsuarioNavigation != null ? src.UsuarioNavigation.Nombre : null))
                .ReverseMap();

            // Mapeo inverso de Historial_CambioDTO a Historial_Cambio
            CreateMap<Historial_CambioDTO, Historial_Cambio>()
                .ForMember(dest => dest.UsuarioNavigation,
                           opt => opt.Ignore()); // Ignorar si no necesitas asignar este campo

            #endregion HistorialCambios

            #region Notificaciones
            
            CreateMap<Notificaciones, NotificacionesDTO>().ReverseMap();

            #endregion




        }
    }
}
