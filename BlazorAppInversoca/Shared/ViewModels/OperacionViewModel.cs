using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlazorAppInversoca.Shared.ViewModels
{
    public class OperacionViewModel
    {
        [Key]
        public int IdOperacion { get; set; }
        [Required(ErrorMessage = "Este Campo es requerido")]
        [MaxLength(50)]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        
        public int IdModulo { get; set; }
        public bool Active { get; set; }
        [Required(ErrorMessage = "Debe Seleccionar un modulo")]
        public ModuloView Modulo { get; set; } 
    }
}
