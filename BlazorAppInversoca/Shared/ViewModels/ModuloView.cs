using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlazorAppInversoca.Shared.ViewModels
{
    public class ModuloView
    {
        [Key]
        public int IdModulo { get; set; }
        public string Nombre { get; set; }
        public bool TieneOperaciones { get; set; }
        public bool Active { get; set; }
        public List<OperacionViewModel> Operaciones { get; set; }
    }
}
