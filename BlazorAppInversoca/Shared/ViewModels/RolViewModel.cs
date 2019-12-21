using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlazorAppInversoca.Shared.ViewModels
{
    public class RolViewModel
    {
        [Key]
        public int IdRol { get; set; }
        [Required(ErrorMessage = "Este Campo es requerido")]
        [MaxLength(50)]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Active { get; set; }
        //public virtual List<RolOperacionViewModel> OperacionesPermitidas { get; set; } = new List<RolOperacionViewModel>();
    }
}
