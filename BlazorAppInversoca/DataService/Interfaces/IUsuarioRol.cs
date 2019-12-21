using BlazorAppInversoca.Shared.EFModels;
using BlazorAppInversoca.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorAppInversoca.DataService.Interfaces
{
    public interface IUsuarioRol
    {
        List<UsuarioRolViewModel> BuscarRegistroSP();
        List<UsuarioRolView> BuscarSP(int IdUsuario = 0, int IdRol = 0);
        List<UsuarioRol> BuscarEF();
        string CrearSP(UsuarioRolViewModel model);
        string ActualizarSP(UsuarioRolViewModel model);
        string EliminarSP(UsuarioRolView model);
        string CrearEF(UsuarioRol model);
        string ActualizarEF(UsuarioRol model);
        string EliminarEF(UsuarioRol model);
    }
}
