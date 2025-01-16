using System.ComponentModel.DataAnnotations;

namespace ProyectoDesafio.Models.Dto
{
    public class UsuarioDto
    {
        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; } = string.Empty;
        [Required]
        [MaxLength(50)]
        public string Correo { get; set; } = string.Empty;
        [Required]
        [MaxLength(100)]
        public string Clave { get; set; } = string.Empty;
    }
}
