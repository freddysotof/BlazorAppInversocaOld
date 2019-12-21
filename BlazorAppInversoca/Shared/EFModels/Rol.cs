using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BlazorAppInversoca.Shared.EFModels
{

    [Table("Roles", Schema = "dbo")]
    public class Rol
    {
        public Rol()
        {
            UsuariosActivos = new HashSet<UsuarioRol>();
            OperacionesPermitidas = new HashSet<RolOperacion>();
        }
        [Key]
        public int IdRol { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Active { get; set; }
        public virtual ICollection<UsuarioRol> UsuariosActivos { get; set; }
        public virtual ICollection<RolOperacion> OperacionesPermitidas { get; set; }

    }
}
