using BlazorAppInversoca.Shared.EFModels;
using BlazorAppInversoca.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorAppInversoca.DataService.Interfaces
{
    public interface IRolOperacion
    {
        List<RolOperacionViewModel> BuscarRegistroSP();
        List<RolOperacionView> BuscarSP(int IdRol=0,int IdOperacion=0);
        List<RolOperacion> BuscarEF();
        string CrearSP(RolOperacionViewModel model);
        string ActualizarSP(RolOperacionViewModel model);
        string EliminarSP(RolOperacionView model);
        string CrearEF(RolOperacion model);
        string ActualizarEF(RolOperacion model);
        string EliminarEF(RolOperacion model);
    }
}
