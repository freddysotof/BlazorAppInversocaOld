using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlazorAppInversoca.Shared.ViewModels
{
    public class RolView
    {
        [Key]
        public int IdRol { get; set; }
        public string Nombre { get; set; }
        public bool TieneUsuarios { get; set; }
        public bool Active { get; set; }
        public virtual List<RolOperacionViewModel> OperacionesPermitidas { get; set; }
        public virtual List<UsuarioRolViewModel> UsuariosActivos { get; set; }
    }
}
