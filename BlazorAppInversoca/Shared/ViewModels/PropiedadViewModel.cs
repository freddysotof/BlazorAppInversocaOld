using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace BlazorAppInversoca.Shared.ViewModels
{
    public class PropiedadViewModel
    {
        [Key]
        public int IdPropiedad { get; set; }
        [Required(ErrorMessage = "Este Campo es requerido")]
        [MaxLength(50)]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Active { get; set; }
    }
}
