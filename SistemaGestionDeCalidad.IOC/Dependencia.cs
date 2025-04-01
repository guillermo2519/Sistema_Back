using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SistemaGestionDeCalidad.DAL.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SistemaGestionDeCalidad.DAL.Repositorios.Contrato;
using SistemaGestionDeCalidad.DAL.Repositorios;
using SistemaGestionDeCalidad.MODEL;

using SistemaGestionDeCalidad.Utility;
using SistemaGestionDeCalidad.BLL.Servicios.Contrato;
using SistemaGestionDeCalidad.BLL.Servicios;

namespace SistemaGestionDeCalidad.IOC
{
    public static class Dependencia
    {
        public static void InyectarDependencias(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SgcDbContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("cadenaSQL"));
            });

            // Inyectar el repositorio genérico
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            // Inyectar el repositorio específico para Documentos
            services.AddScoped<IDocumentos, DocumentosRepository>();

            // Inyectar el servicio específico para Usuarios
            services.AddScoped<IUsuarioService, UsuarioService>();

            // Inyectar el servicio específico para Roles
            services.AddScoped<IRolService, RolService>();

            // Inyectar el servicio específico para Menu
            services.AddScoped<IMenuService, MenuService>();

            // Inyectar el servicio específico para Dashboard
            services.AddScoped<IDashBoardService, DashBoardService>();

            // Inyectar el servicio específico para Control Documental
            services.AddScoped<IControl_Documental, Control_DocumentalService>();

            // Inyectar el servicio específico para Empresa
            services.AddScoped<IEmpresaService, EmpresaService>();

            services.AddScoped<ITareas, Tareas_Service>();

            // Inyectar el servicio específico para Notificaciones
            services.AddScoped<INotificacionesService, NotificacionesService>();

            services.AddAutoMapper(typeof(AutoMapperProfile));

        }
    }
}
