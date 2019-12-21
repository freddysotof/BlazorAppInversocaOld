using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BlazorAppInversoca.Shared.EFModels
{
    [Table("Roles_Operaciones", Schema = "dbo")]
    public class RolOperacion
    { 
    
        public int IdRol { get; set; }
        public int IdOperacion { get; set; }
        public Rol Rol { get; set; }
        public Operacion Operacion { get; set; }
        public string Descripcion { get; set; }
    }
}
