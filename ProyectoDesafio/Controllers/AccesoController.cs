using Microsoft.AspNetCore.Http;
using ProyectoDesafio.Custom;
using ProyectoDesafio.Models;
using ProyectoDesafio.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ProyectoDesafio.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class AccesoController : Controller
    {
        #region SERVICES
        private readonly DesafiodesarrolladorContext _context;
        private readonly Utilidades _utilidades;
        #endregion


        #region CONSTRUCTORS
        public AccesoController(DesafiodesarrolladorContext context, Utilidades utilidades)
        {
            _context = context;
            _utilidades = utilidades;
        }
        #endregion
        #region METHODS
        /// <summary>
        /// Puede agregar un usuario para tener acceso a la plataforma web.
        /// </summary>
        /// <returns>Un 200 cuando es un registro exitoso</returns>
        [HttpPost]
        [Route("crearusuario")]
        public async Task<IActionResult> Crear(UsuarioDto usuario)
        {
            var clave = Utilidades.sha256_hash(usuario.Clave);
            usuario.Clave = clave;
            var model = new Usuario
            {
                Nombre = usuario.Nombre,
                Correo = usuario.Correo,
                Clave = clave
            };
            await _context.Usuarios.AddAsync(model);
            await _context.SaveChangesAsync();
            return Ok();
        }
        /// <summary>
        /// Inicio de sesión para ingresar.
        /// </summary>
        /// <returns>Un 200 cuando esté Ok con un mensaje de Credenciales correctas y token y cuando no, Credenciales incorrectas</returns>
        [HttpPost]
        [Route("loginusuario")]
        public async Task<IActionResult> Login(LoginDto login)
        {
            var usuarioEncontrado = await _context.Usuarios.Where(x => x.Correo == login.Correo && x.Clave == Utilidades.sha256_hash(login.Clave)).FirstOrDefaultAsync();
            if (usuarioEncontrado == null)
            {
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = false, message = "Credenciales incorrectas", token = ""});
            }
            else {
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = true, message = "Credenciales correctas", token = _utilidades.generaJWT(usuarioEncontrado) });
            }
        }
        #endregion
    }
}
