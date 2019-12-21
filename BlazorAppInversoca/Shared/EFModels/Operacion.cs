using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BlazorAppInversoca.Shared.EFModels
{
    [Table("Operaciones", Schema = "dbo")]
    public class Operacion
    {
        public Operacion()
        {
            RolesOperaciones = new HashSet<RolOperacion>();
        }
        [Key]
        public int IdOperacion { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int IdModulo { get; set; }
        public bool Active { get; set; }
        public Modulo Modulo { get; set; }
        public virtual ICollection<RolOperacion> RolesOperaciones { get; set; }
    }
}
