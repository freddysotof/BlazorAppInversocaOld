using BlazorAppInversoca.Shared.EFModels;
using BlazorAppInversoca.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorAppInversoca.DataService.Interfaces
{
    public interface IModulo
    {
        List<ModuloViewModel> BuscarRegistroSP();
        List<ModuloView> BuscarSP(bool isAll, bool isActive);
        List<Modulo> BuscarEF();
        string CrearSP(ModuloViewModel model);
        string ActualizarSP(ModuloViewModel model);
        string EliminarSP(ModuloView model);
        string CrearEF(Modulo model);
        string ActualizarEF(Modulo model);
        string EliminarEF(Modulo model);
    }
}
