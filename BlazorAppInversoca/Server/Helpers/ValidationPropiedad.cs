using BlazorAppInversoca.DataService.Interfaces;
using BlazorAppInversoca.Shared.EFModels;
using BlazorAppInversoca.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorAppInversoca.Server.Helpers
{
    public class ValidationPropiedad
    {
        private readonly IPropiedad _servicioPropiedad;

        public ValidationPropiedad(IPropiedad Propiedad)
        {
            _servicioPropiedad = Propiedad;

        }
        public bool PropiedadesP(PropiedadViewModel model)
        {
            bool correct = false;
            int verificarPropiedadxID = _servicioPropiedad.BuscarSP(false, true).Where(a => a.IdPropiedad == model.IdPropiedad && a.Nombre.ToLower() == model.Nombre.Trim().ToLower()).Count();
            int verificarPropiedad = _servicioPropiedad.BuscarSP(false, true).Where(a => a.Nombre.ToLower() == model.Nombre.Trim().ToLower()).Count();
            if ((verificarPropiedad == 0 && verificarPropiedadxID == 1) || (verificarPropiedad == 1 && verificarPropiedadxID == 1) || (verificarPropiedad == 0 && verificarPropiedadxID == 0))
            {
                correct = true;
            }
            return correct;
        }

        public bool ExistsInactiveSP(PropiedadViewModel model)
        {
            bool correct = false;
            int verificarPropiedadxID = _servicioPropiedad.BuscarSP(false, false).Where(a => a.IdPropiedad == model.IdPropiedad).Count();
            int verificarPropiedad = _servicioPropiedad.BuscarSP(false, false).Where(a => a.Nombre.ToLower() == model.Nombre.Trim().ToLower()).Count();
            if (verificarPropiedad > 0 || verificarPropiedadxID > 0)
            {
                correct = true;
            }
            return correct;
        }
        public bool PropiedadEF(Propiedad model)
        {
            bool correct = false;
            int verificarPropiedadxID = _servicioPropiedad.BuscarEF().Where(a => a.IdPropiedad == model.IdPropiedad && (a.Active == true)).Count();
            int verificarPropiedad = _servicioPropiedad.BuscarEF().Where(a => a.Nombre.Trim() == model.Nombre.Trim() && (a.Active == true)).Count();

            if (verificarPropiedad == 0 || verificarPropiedadxID == 1)
            {
                correct = true;
            }
            return correct;
        }

        public bool ExistsInactiveEF(Propiedad model)
        {
            bool correct = false;
            int verificarPropiedadxID = _servicioPropiedad.BuscarEF().Where(a => a.IdPropiedad == model.IdPropiedad && (a.Active == false)).Count();
            int verificarPropiedad = _servicioPropiedad.BuscarEF().Where(a => a.Nombre.Trim() == model.Nombre.Trim() && (a.Active == false)).Count();
            if (verificarPropiedad > 0 || verificarPropiedadxID > 0)
            {
                correct = true;
            }
            return correct;
        }
    }
}
