using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlazorAppInversoca.Shared.ViewModels
{
    public class UsuarioRolView
    {

        public int IdUsuario { get; set; }
        public int IdRol { get; set; }
        public string NombreUsuario { get; set; }
        public string NombreRol { get; set; }
        public string Descripcion { get; set; }
    }
}
