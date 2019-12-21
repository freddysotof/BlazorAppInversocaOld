using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BlazorAppInversoca.Shared.EFModels
{

    [Table("Modulos", Schema = "dbo")]
    public class Modulo
    {
        public Modulo()
        {
            Operaciones = new HashSet<Operacion>();
        }
        [System.ComponentModel.DataAnnotations.Key]
        public int IdModulo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Active { get; set; }
        public virtual ICollection<Operacion> Operaciones { get; set; }
    }
}
