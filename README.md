# ProyectoDesafioHF
Proyecto para agregar Usuarios y tareas con acceso controlado mediante JWT


Pasos Ejecutados para la creación del Proyecto
------- SQL SERVER ------
* Crear base de datos "Desafiodesarrollador"

------- Visual Studio ------
* Crear Proyecto "ASP.NET Core Web API" - ProyectoDesafio
* Instalar Paquetes Nuget para EF y JWT
* Configurar base de datos en carpeta Models
* Configurar conexión DB y JWT en appsetting.json
* Configurar DBContext y JWT en Program.cs
* Crear encriptor SHA256 y JWT en Utilidades.cs - carpeta Custom
* Configurar servicios BD, Utilidades y JWT en Program.cs
* Crear clases DTO para login, usuario y tarea dentro de Models
* Crear controlador(api) Acceso para registrar e iniciar sesión
* Crear controlador(api) CRUD de Tarea y aplicar autenticación
* Activar Cors en Program.cs
* Crear un proyecto nuevo para el test (ProyectoPruebas)
* Instalar Paquetes xunit para el ProyectoPruebas y package Microsoft.EntityFrameworkCore.InMemory
* Crear clases respectivas para aplicar las pruebas a Tarea

Los primeros paso para utilizar la API:

Se debe aplicar Migrations, este desarrollo se hizo con Entity Framework:
* Update-Database

Una vez creada las tablas procedemos a ejecutar el proyecto. Lo siguientes es crear un nuevo usuario desde Swagger
Acceso -> /api/Acceso/crearusuario
Body
{
  "nombre": "string",
  "correo": "string",
  "clave": "string"
}
luego procedemos a solicitar el token de acceso:
Acceso -> /api/Acceso/loginusuario
Body
{
  "correo": "string",
  "clave": "string"
}
Esto nos devolverá un token, debemos copiar el token, luego daremos click en la opción Authorize que brinda Swagger, nos pedirá que introduzcamos el token copiado, previamente debemos colocar
Bearer (luego el token) y luego damos click en Authorize. Una vez realizado eso podemos acceder al CRUD de Tarea.

************ Para la Prueba Unitaria ***************
Se seleccionó como prueba la creación de una Tarea para un usuario existente, en este caso Id = 1. Esta Prueba como registro se guarda en Memoria y no afecta los datos de la BD.
