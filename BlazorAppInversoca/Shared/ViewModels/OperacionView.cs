using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlazorAppInversoca.Shared.ViewModels
{
    public class OperacionView
    {
        [Key]
        public int IdOperacion { get; set; }
        public string Nombre { get; set; }
        public string Modulo { get; set; }
        public bool TieneRoles { get; set; }
        public bool Active { get; set; }
        public virtual List<RolOperacionViewModel> RolesPermitidos { get; set; }

    }
}
