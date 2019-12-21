using BlazorAppInversoca.Shared.EFModels;
using BlazorAppInversoca.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorAppInversoca.DataService.Interfaces
{
    public interface IRol
    {
        List<RolViewModel> BuscarRegistroSP();
        List<RolView> BuscarSP(bool isAll, bool isActive);
        List<Rol> BuscarEF();
        string CrearSP(RolViewModel model);
        string ActualizarSP(RolViewModel model);
        string EliminarSP(RolView model);
        string CrearEF(Rol model);
        string ActualizarEF(Rol model);
        string EliminarEF(Rol model);
    }
}
