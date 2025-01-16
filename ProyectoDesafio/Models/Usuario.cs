using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProyectoDesafio.Models
{
    public partial class Usuario
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; } = default!;

        [Required]
        [MaxLength(50)]
        public string Correo { get; set; } = default!;

        [Required]
        [MaxLength(100)]
        public string Clave { get; set; } = default!;
    }
}
