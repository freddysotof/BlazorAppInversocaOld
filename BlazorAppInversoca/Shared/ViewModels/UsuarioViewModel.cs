using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlazorAppInversoca.Shared.ViewModels
{
    public class UsuarioViewModel
    {
        [Key]
        public int IdUsuario { get; set; }
        [Required(ErrorMessage= "Este Campo es requerido")]
        [MaxLength(50)]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Debe escribir una contraseña")]
        [StringLength(255, ErrorMessage = "La Contraseña debe tener un minimo de 8 caracteres", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Compare("Contrasena")]
        public string Contrasena { get; set; }
        [Required(ErrorMessage = "Debe confirmar la contraseña")]
        [DataType(DataType.Password)]
        [Compare("Contrasena", ErrorMessage = "Las contraseña no coinciden")]
        public virtual string ConfirmarContrasena { get; set; }
        [Required (ErrorMessage = "Debe escribir un correo")]
        [EmailAddress (ErrorMessage = "El correo electronico no es valido")]
        public string Correo { get; set; }
        public bool Active { get; set; }
    }
}
