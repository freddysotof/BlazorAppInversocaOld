using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlazorAppInversoca.Shared.ViewModels
{
    public class PropiedadView
    {
        [Key]
        public int IdPropiedad { get; set; }
        public string Nombre { get; set; }
        public bool TieneMovimientos { get; set; }
        public bool Active { get; set; }
    }
}
