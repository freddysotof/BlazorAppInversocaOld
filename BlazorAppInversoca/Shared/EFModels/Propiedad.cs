using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BlazorAppInversoca.Shared.EFModels
{
    [Table("Propiedades", Schema = "dbo")]
    public class Propiedad
    {
        [Key]
        public int IdPropiedad { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Active { get; set; }
     
    }
}
