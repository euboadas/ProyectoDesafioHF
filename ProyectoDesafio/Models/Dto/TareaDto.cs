using ProyectoDesafio.Assets;
using System.ComponentModel.DataAnnotations;

namespace ProyectoDesafio.Models.Dto
{
    public class TareaDto
    {
        [Required]
        [MaxLength(50)]
        public string Titulo { get; set; } = default!;

        [Required]
        [MaxLength(50)]
        public string Descripcion { get; set; } = default!;

        [Required]
        public EstadoTarea Estado { get; set; }

        [Required]
        public DateTime Fechavencimiento { get; set; }
    }
}
