using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoDesafio.Assets;
using ProyectoDesafio.Models;
using ProyectoDesafio.Models.Dto;
using System.Security.Claims;

namespace ProyectoDesafio.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class TareaController : ControllerBase
    {
        #region SERVICES
        private readonly DesafiodesarrolladorContext _context;
        #endregion
        #region CONSTRUCTORS
        public TareaController(DesafiodesarrolladorContext context)
        {
            _context = context;
        }
        #endregion
        #region METHODS
        /// <summary>
        /// Permite visualizar un listado de las tareas creadas por el usuario activo.
        /// </summary>
        /// <returns>Lista de Tareas</returns>
        [HttpGet]
        public async Task<IActionResult> Get(int numPagina = 1, int tamPag = 10, EstadoTarea estadoTarea = EstadoTarea.PENDIENTE, DateTime? fechaVencimiento = default)
        {
            try
            {
                var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
                var listTarea = await _context.Tareas.Where(x => x.Usuario.Id == Int32.Parse(userId)
                 && (x.Estado == estadoTarea || x.Fechavencimiento == fechaVencimiento)
                 ).Include(x => x.Usuario).OrderBy(d => d.Id).Skip((numPagina - 1) * tamPag).ToListAsync();
                return Ok(listTarea);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Permite crear una tarea por el usuario activo.
        /// </summary>
        /// <returns>200 OK si fue exitoso el registro</returns>
        [HttpPost]
        [Route("crear")]
        public async Task<IActionResult> CrearTarea(TareaDto tarea)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
            var user = await _context.Usuarios.FindAsync(Int32.Parse(userId));
            var model = new Tarea
            {   
                Titulo = tarea.Titulo,
                Descripcion = tarea.Descripcion,
                Estado = tarea.Estado,
                Fechavencimiento = tarea.Fechavencimiento,
                Usuario = user!
            };

            await _context.Tareas.AddAsync(model);
            await _context.SaveChangesAsync();
            return Ok();
        }
        /// <summary>
        /// Permite ver una tarea por el usuario activo mediante el Id del registro de la tarea.
        /// </summary>
        /// <returns>El objecto tarea con los datos registrado, si no un NotFound con un texto, No se encuentra la tarea </returns>
        [HttpGet]
        [Route("ver")]
        public async Task<IActionResult> VerTarea(int id)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
            var tarea = await _context.Tareas.Where(x => x.Id == id && x.Usuario.Id == Int32.Parse(userId)).Include(x => x.Usuario).FirstOrDefaultAsync();
            if (tarea == null)
            { 
                return NotFound("No se encuentra la tarea");
            }
            return Ok(tarea);
        }
        /// <summary>
        /// Permite editar una tarea por el usuario activo.
        /// </summary>
        /// <returns>200 OK si fue exitosa la modificación</returns>
        [HttpPut]
        [Route("editar")]

        public async Task<IActionResult> EditarTarea(int id, TareaDto tarea)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
            var tareaExiste = await _context.Tareas.Where(x => x.Id == id && x.Usuario.Id == Int32.Parse(userId)).Include(x => x.Usuario).FirstOrDefaultAsync();
            if (tareaExiste == null)
            {
                return NotFound("No se encuentra la tarea");
            }
            tareaExiste.Titulo = tarea.Titulo;
            tareaExiste.Descripcion = tarea.Descripcion;
            tareaExiste.Estado = tarea.Estado;
            tareaExiste.Fechavencimiento = tarea.Fechavencimiento;
            await _context.SaveChangesAsync();

            return Ok();
        }
        /// <summary>
        /// Permite eliminar una tarea por el usuario activo.
        /// </summary>
        /// <returns>200 OK si fue eliminada la tarea</returns>
        [HttpDelete]
        [Route("eliminar")]

        public async Task<IActionResult> EliminarTarea(int id)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
            var tareaExiste = await _context.Tareas.Where(x => x.Id == id && x.Usuario.Id == Int32.Parse(userId)).FirstOrDefaultAsync();
            if (tareaExiste == null)
            {
                return NotFound("No se encuentra la tarea");
            }
            _context.Tareas.Remove(tareaExiste!);
            await _context.SaveChangesAsync();

            return Ok();
        }
        #endregion
    }
}
