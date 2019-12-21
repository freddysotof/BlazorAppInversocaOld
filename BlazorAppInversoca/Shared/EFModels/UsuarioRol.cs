using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BlazorAppInversoca.Shared.EFModels
{
    [Table("Usuarios_Roles", Schema = "dbo")]
    public class UsuarioRol
    {
        public int IdUsuario { get; set; }
        public int IdRol { get; set; }
        public string Descripcion { get; set; }
        public Usuario Usuario { get; set; }
        public Rol Rol { get; set; }
    }
}
