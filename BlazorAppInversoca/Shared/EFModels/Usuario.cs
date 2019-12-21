using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BlazorAppInversoca.Shared.EFModels
{

    [Table("Usuarios", Schema = "dbo")]
    public class Usuario
    {
        public Usuario()
        {
            RolesAsignados = new HashSet<UsuarioRol>();
        }
        [Key]
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Contrasena { get; set; }
        public string Correo { get; set; }
        public bool Active { get; set; }
        public virtual ICollection<UsuarioRol> RolesAsignados { get; set; }
    }
}
