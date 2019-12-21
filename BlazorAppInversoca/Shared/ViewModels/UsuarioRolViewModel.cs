using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlazorAppInversoca.Shared.ViewModels
{
    public class UsuarioRolViewModel
    {
        [Required(ErrorMessage = "Debe Seleccionar un Usuario")]
        public int IdUsuario { get; set; }
        [Required(ErrorMessage = "Debe seleccionar un Rol")]
        public int IdRol { get; set; }
        public string Descripcion { get; set; }
        public UsuarioView Usuario { get; set; } 
        public RolView Rol { get; set; } 
    }
}
