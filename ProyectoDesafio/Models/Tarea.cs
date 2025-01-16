using ProyectoDesafio.Assets;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProyectoDesafio.Models
{
    public partial class Tarea
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Titulo { get; set; } = default!;

        [Required]
        [MaxLength(50)]
        public string Descripcion { get; set; } = default!;

        [Required]
        [MaxLength(20)]
        public EstadoTarea Estado { get; set; } = EstadoTarea.PENDIENTE;

        [Required]
        public DateTime Fechavencimiento { get; set; }

        [Required]
        public Usuario Usuario { get; set; } = null!;
    }
}
