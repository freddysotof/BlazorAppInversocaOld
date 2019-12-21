using BlazorAppInversoca.DataService.Interfaces;
using BlazorAppInversoca.Shared.EFModels;
using BlazorAppInversoca.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorAppInversoca.Server.Helpers
{
    public class ValidationRolOperacion
    {
        private readonly IRolOperacion _servicioRolOperacion;

        public ValidationRolOperacion(IRolOperacion RolOperacion)
        {
            _servicioRolOperacion = RolOperacion;

        }
        public bool RolOperacionSP(RolOperacionViewModel model)
        {
            bool correct = false;
            int verificarRolOperacionxID = _servicioRolOperacion.BuscarSP(0,0).Where(a => a.IdRol == model.IdRol && a.IdOperacion == model.IdOperacion).Count();
            if (verificarRolOperacionxID == 1 ||  verificarRolOperacionxID == 0)
            {
                correct = true;
            }
            return correct;
        }

        //public bool ExistsInactiveSP(RolOperacionViewModel model)
        //{
        //    bool correct = false;
        //    int verificarRolOperacionxID = _servicioRolOperacion.BuscarSP(false, false).Where(a => a.IdRolOperacion == model.IdRolOperacion).Count();
        //    int verificarRolOperacion = _servicioRolOperacion.BuscarSP(false, false).Where(a => a.Nombre.ToLower() == model.Nombre.Trim().ToLower()).Count();
        //    if (verificarRolOperacion > 0 || verificarRolOperacionxID > 0)
        //    {
        //        correct = true;
        //    }
        //    return correct;
        //}
        public bool RolOperacionEF(RolOperacion model)
        {
            bool correct = false;
            int verificarRolOperacionxID = _servicioRolOperacion.BuscarEF().Where(a => a.IdRol == model.IdRol && a.IdOperacion == model.IdOperacion).Count();
           
            if (verificarRolOperacionxID == 1 || verificarRolOperacionxID == 0)
            {
                correct = true;
            }
            return correct;
        }

        //public bool ExistsInactiveEF(RolOperacion model)
        //{
        //    bool correct = false;
        //    int verificarRolOperacionxID = _servicioRolOperacion.BuscarEF().Where(a => a.IdRolOperacion == model.IdRolOperacion && (a.Active == false)).Count();
        //    int verificarRolOperacion = _servicioRolOperacion.BuscarEF().Where(a => a.Nombre.Trim() == model.Nombre.Trim() && (a.Active == false)).Count();
        //    if (verificarRolOperacion == 1 || verificarRolOperacionxID == 1)
        //    {
        //        correct = true;
        //    }
        //    return correct;
        //}
    }
}
