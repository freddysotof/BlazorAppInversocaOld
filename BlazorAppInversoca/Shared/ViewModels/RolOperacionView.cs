using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlazorAppInversoca.Shared.ViewModels
{
    public class RolOperacionView
    {
        public int IdRol { get; set; }
        public int IdOperacion { get; set; }
        public string NombreRol { get; set; }
        public string NombreOperacion { get; set; }
        //public string NombreModulo { get; set; }

        public string Descripcion { get; set; }

    }
}
