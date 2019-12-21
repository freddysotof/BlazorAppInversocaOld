using BlazorAppInversoca.DataService.Interfaces;
using BlazorAppInversoca.Shared.EFModels;
using BlazorAppInversoca.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorAppInversoca.Server.Helpers
{
    public class ValidationOperacion
    {
        private readonly IOperacion _servicioOperacion;

        public ValidationOperacion(IOperacion Operacion)
        {
            _servicioOperacion = Operacion;

        }
        public bool OperacionSP(OperacionViewModel model)
        {
            bool correct = false;
            int verificarOperacionxID = _servicioOperacion.BuscarSP(false, true).Where(a => a.IdOperacion == model.IdOperacion && a.Nombre.ToLower() == model.Nombre.Trim().ToLower()).Count();
            int verificarOperacion = _servicioOperacion.BuscarSP(false, true).Where(a => a.Nombre.ToLower() == model.Nombre.Trim().ToLower()).Count();
            if ((verificarOperacion == 0 && verificarOperacionxID == 1) || (verificarOperacion == 1 && verificarOperacionxID == 1) || (verificarOperacion == 0 && verificarOperacionxID == 0))
            {
                correct = true;
            }
            return correct;
        }

        public bool ExistsInactiveSP(OperacionViewModel model)
        {
            bool correct = false;
            int verificarOperacionxID = _servicioOperacion.BuscarSP(false, false).Where(a => a.IdOperacion == model.IdOperacion).Count();
            int verificarOperacion = _servicioOperacion.BuscarSP(false, false).Where(a => a.Nombre.ToLower() == model.Nombre.Trim().ToLower()).Count();
            if (verificarOperacion > 0 || verificarOperacionxID > 0)
            {
                correct = true;
            }
            return correct;
        }
        public bool OperacionEF(Operacion model)
        {
            bool correct = false;
            int verificarOperacionxID = _servicioOperacion.BuscarEF().Where(a => a.IdOperacion == model.IdOperacion && (a.Active == true)).Count();
            int verificarOperacion = _servicioOperacion.BuscarEF().Where(a => a.Nombre.Trim() == model.Nombre.Trim() && (a.Active == true)).Count();

            if (verificarOperacion == 0 || verificarOperacionxID == 1)
            {
                correct = true;
            }
            return correct;
        }

        public bool ExistsInactiveEF(Operacion model)
        {
            bool correct = false;
            int verificarOperacionxID = _servicioOperacion.BuscarEF().Where(a => a.IdOperacion == model.IdOperacion && (a.Active == false)).Count();
            int verificarOperacion = _servicioOperacion.BuscarEF().Where(a => a.Nombre.Trim() == model.Nombre.Trim() && (a.Active == false)).Count();
            if (verificarOperacion > 0 || verificarOperacionxID > 0)
            {
                correct = true;
            }
            return correct;
        }
    }
}
