using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlazorAppInversoca.Shared.ViewModels
{
    public class RolOperacionViewModel
    {
        [Required(ErrorMessage = "Debe seleccionar un Rol")]
        public int IdRol { get; set; }
        [Required(ErrorMessage = "Debe seleccionar una Operacion")]
        public int IdOperacion { get; set; }

        public string Descripcion { get; set; }
        public RolView Rol { get; set; }
        public OperacionView Operacion { get; set; }
    }
}
