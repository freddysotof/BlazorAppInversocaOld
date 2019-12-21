using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlazorAppInversoca.Shared.ViewModels
{
    public class UsuarioView
    {
        [Key]
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public bool TieneMovimientos { get; set; }
        public bool Active { get; set; }
        public List<UsuarioRolViewModel> RolesAsignados { get; set; }
    }
}
