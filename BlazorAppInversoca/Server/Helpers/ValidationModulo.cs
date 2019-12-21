using BlazorAppInversoca.DataService.Interfaces;
using BlazorAppInversoca.Shared.EFModels;
using BlazorAppInversoca.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorAppInversoca.Server.Helpers
{
    public class ValidationModulo
    {
        private readonly IModulo _servicioModulo;

        public ValidationModulo(IModulo Modulo)
        {
            _servicioModulo = Modulo;

        }
        public bool ModuloSP(ModuloViewModel model)
        {
            bool correct = false;
            int verificarModuloxID = _servicioModulo.BuscarSP(false, true).Where(a => a.IdModulo == model.IdModulo && a.Nombre.ToLower() == model.Nombre.Trim().ToLower()).Count();
            int verificarModulo = _servicioModulo.BuscarSP(false, true).Where(a => a.Nombre.ToLower() == model.Nombre.Trim().ToLower()).Count();
            if ((verificarModulo == 0 && verificarModuloxID == 1) || (verificarModulo == 1 && verificarModuloxID == 1) || (verificarModulo == 0 && verificarModuloxID == 0))
            {
                correct = true;
            }
            return correct;
        }

        public bool ExistsInactiveSP(ModuloViewModel model)
        {
            bool correct = false;
            int verificarModuloxID = _servicioModulo.BuscarSP(false, false).Where(a => a.IdModulo == model.IdModulo).Count();
            int verificarModulo = _servicioModulo.BuscarSP(false, false).Where(a => a.Nombre.ToLower() == model.Nombre.Trim().ToLower()).Count();
            if (verificarModulo > 0 || verificarModuloxID > 0)
            {
                correct = true;
            }
            return correct;
        }
        public bool ModuloEF(Modulo model)
        {
            bool correct = false;
            int verificarModuloxID = _servicioModulo.BuscarEF().Where(a => a.IdModulo == model.IdModulo && (a.Active == true)).Count();
            int verificarModulo = _servicioModulo.BuscarEF().Where(a => a.Nombre.Trim() == model.Nombre.Trim() && (a.Active == true)).Count();

            if (verificarModulo == 0 || verificarModuloxID == 1)
            {
                correct = true;
            }
            return correct;
        }

        public bool ExistsInactiveEF(Modulo model)
        {
            bool correct = false;
            int verificarModuloxID = _servicioModulo.BuscarEF().Where(a => a.IdModulo == model.IdModulo && (a.Active == false)).Count();
            int verificarModulo = _servicioModulo.BuscarEF().Where(a => a.Nombre.Trim() == model.Nombre.Trim() && (a.Active == false)).Count();
            if (verificarModulo > 0 || verificarModuloxID > 0)
            {
                correct = true;
            }
            return correct;
        }
    }
}
