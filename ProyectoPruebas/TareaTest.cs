
using Microsoft.EntityFrameworkCore;
using Xunit;
using ProyectoDesafio.Models;

namespace ProyectoPruebas
{
    public class TareaTest
    {
        private DbContextOptions<DesafiodesarrolladorContext> CrearOpcionesEnMemoria()
        {
            return new DbContextOptionsBuilder<DesafiodesarrolladorContext>()
                .UseInMemoryDatabase("Desafiodesarrollador")
                .Options;
        }
        [Fact]
        public void AgregarTarea_DeberiaGuardarloEnLaBaseDeDatos()
        {
            // Arrange
            var opciones = CrearOpcionesEnMemoria();

            using (var contexto = new DesafiodesarrolladorContext(opciones))
            {
                var tarea = new Tarea { 
                    Id = 1, 
                    Titulo = "Tarea 1", 
                    Descripcion="Prueba", 
                    Usuario= new Usuario { Id=1, Correo = "euboadas@gmail.com" , Clave = "123456", Nombre = "Euclides Boadas" }, 
                    Estado = ProyectoDesafio.Assets.EstadoTarea.PENDIENTE };

                // Act
                contexto.Tareas.Add(tarea);
                contexto.SaveChanges();
            }

            // Assert
            using (var contexto = new DesafiodesarrolladorContext(opciones))
            {
                var tareaGuardado = contexto.Tareas.Find(1);
                Assert.NotNull(tareaGuardado);
                Assert.Equal("Tarea 1", tareaGuardado!.Titulo);
            }
        }
    }
}
