using BlazorAppInversoca.Shared.EFModels;
using BlazorAppInversoca.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorAppInversoca.DataService.Interfaces
{
    public interface IUsuario
    {
        List<UsuarioViewModel> BuscarRegistroSP();
        List<UsuarioView> BuscarSP(bool isAll, bool isActive);
        List<Usuario> BuscarEF();
        string CrearSP(UsuarioViewModel model);
        string ActualizarSP(UsuarioViewModel model);
        string EliminarSP(UsuarioView model);
        string CrearEF(Usuario model);
        string ActualizarEF(Usuario model);
        string EliminarEF(Usuario model);
    }
}
