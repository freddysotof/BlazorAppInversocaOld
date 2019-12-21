﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorAppInversoca.Shared.Components_Models
{
    public class ConfirmationModelView
    {
        public string Titulo { get; set; }
        public string Mensaje { get; set; }
        public string Action { get; set; }
        public TiposMensaje TipoMensaje { get; set; }
        public enum TiposMensaje 
        {
            question, warning, success, info,error
        }
    }
}
