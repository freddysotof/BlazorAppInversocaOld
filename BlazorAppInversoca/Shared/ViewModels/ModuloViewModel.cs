using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlazorAppInversoca.Shared.ViewModels
{
    public class ModuloViewModel
    {
        [Key]
        public int IdModulo { get; set; }
        [Required (ErrorMessage = "Este Campo es requerido")]
        [MaxLength(50)]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Active { get; set; }
        public List<OperacionViewModel> Operaciones { get; set; } = new List<OperacionViewModel>();

    }
}
