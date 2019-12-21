using BlazorAppInversoca.Shared.EFModels;
using BlazorAppInversoca.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorAppInversoca.DataService.Interfaces
{
    public interface IOperacion
    {
        List<OperacionViewModel> BuscarRegistroSP();
        List<OperacionView> BuscarSP(bool isAll, bool isActive);
        List<Operacion> BuscarEF();
        string CrearSP(OperacionViewModel model);
        string ActualizarSP(OperacionViewModel model);
        string EliminarSP(OperacionView model);
        string CrearEF(Operacion model);
        string ActualizarEF(Operacion model);
        string EliminarEF(Operacion model);
    }
}
