# Sistema de Gestión de Tareas - Back-End

Este es el back-end de un sistema de gestión de tareas desarrollado con .NET Core. Proporciona una API RESTful que permite la autenticación de usuarios y la gestión de tareas, incluyendo su creación, modificación y eliminación.

## Descripción

Este sistema maneja la lógica de negocio y la persistencia de datos para la gestión de tareas. Se conecta con una base de datos para almacenar información sobre los usuarios y las tareas creadas. 

### **Credenciales de prueba**
Para probar el sistema, puedes usar las siguientes credenciales:

- **Correo:** `oper@gmail.com`  
- **Contraseña:** `12345`

## Instrucciones para ejecutar el proyecto

1. **Clona el repositorio del back-end**:  
   Si aún no has clonado el repositorio, ejecuta el siguiente comando en tu terminal:

   ```bash
   git clone https://github.com/

2. Restaura las dependencias del proyecto:
    Si utilizas .NET CLI, ejecuta:
    dotnet restore

4.Configura la base de datos:

  Asegúrate de tener instalado SQL Server o la base de datos que el proyecto utiliza.

  Verifica que la cadena de conexión en appsettings.json sea correcta:

     "ConnectionStrings": {
      "DefaultConnection": "Server=tu-servidor;Database=nombre-bd;User Id=usuario;Password=contraseña;"
      }

   Si es necesario, ejecuta las migraciones para generar la base de datos:

     dotnet ef database update


## Dependencias necesarias
Este proyecto depende de las siguientes herramientas y tecnologías:

.NET Core: Framework principal para la aplicación.

Entity Framework Core: ORM para interactuar con la base de datos.

SQL Server: Base de datos recomendada para el proyecto.

Swagger: Documentación interactiva de la API.

## Explicación del Sistema
Este sistema gestiona la autenticación de usuarios y la administración de tareas mediante una API RESTful.

Funcionalidades principales
Gestión de usuarios
Inicio de sesión con credenciales.

Manejo de sesiones y tokens de autenticación.

Gestión de tareas
Crear nuevas tareas.

Editar tareas existentes.

Eliminar tareas cuando ya no sean necesarias.

Obtener la lista de tareas disponibles.

Interacción con el front-end
El back-end proporciona endpoints que son consumidos por el front-end de Angular.

La comunicación entre el front-end y el back-end se realiza usando JSON a través de HTTP.

