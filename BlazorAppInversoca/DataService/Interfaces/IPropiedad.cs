using BlazorAppInversoca.Shared.EFModels;
using BlazorAppInversoca.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorAppInversoca.DataService.Interfaces
{
    public interface IPropiedad
    {
        List<PropiedadViewModel> BuscarRegistroSP();
        List<PropiedadView> BuscarSP(bool isAll, bool isActive);
        List<Propiedad> BuscarEF();
        string CrearSP(PropiedadViewModel model);
        string ActualizarSP(PropiedadViewModel model);
        string EliminarSP(PropiedadView model);
        string CrearEF(Propiedad model);
        string ActualizarEF(Propiedad model);
        string EliminarEF(Propiedad model);
    }
}
