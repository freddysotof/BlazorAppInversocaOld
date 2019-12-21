using BlazorAppInversoca.DataService.Interfaces;
using BlazorAppInversoca.Shared.EFModels;
using BlazorAppInversoca.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorAppInversoca.Server.Helpers
{
    public class ValidationRol
    {
        private readonly IRol _servicioRol;

        public ValidationRol(IRol Rol)
        {
            _servicioRol = Rol;

        }
        public bool RolSP(RolViewModel model)
        {
            bool correct = false;
            int verificarRolxID = _servicioRol.BuscarSP(false, true).Where(a => a.IdRol == model.IdRol && a.Nombre.ToLower() == model.Nombre.Trim().ToLower()).Count();
            int verificarRol = _servicioRol.BuscarSP(false, true).Where(a => a.Nombre.ToLower() == model.Nombre.Trim().ToLower()).Count();
            if ((verificarRol == 0 && verificarRolxID == 1) || (verificarRol == 1 && verificarRolxID == 1) || (verificarRol == 0 && verificarRolxID == 0))
            {
                correct = true;
            }
            return correct;
        }

        public bool ExistsInactiveSP(RolViewModel model)
        {
            bool correct = false;
            int verificarRolxID = _servicioRol.BuscarSP(false, false).Where(a => a.IdRol == model.IdRol).Count();
            int verificarRol = _servicioRol.BuscarSP(false, false).Where(a => a.Nombre.ToLower() == model.Nombre.Trim().ToLower()).Count();
            if (verificarRol > 0 || verificarRolxID > 0)
            {
                correct = true;
            }
            return correct;
        }
        public bool RolEF(Rol model)
        {
            bool correct = false;
            int verificarRolxID = _servicioRol.BuscarEF().Where(a => a.IdRol == model.IdRol && (a.Active == true)).Count();
            int verificarRol = _servicioRol.BuscarEF().Where(a => a.Nombre.Trim() == model.Nombre.Trim() && (a.Active == true)).Count();

            if (verificarRol == 0 || verificarRolxID == 1)
            {
                correct = true;
            }
            return correct;
        }

        public bool ExistsInactiveEF(Rol model)
        {
            bool correct = false;
            int verificarRolxID = _servicioRol.BuscarEF().Where(a => a.IdRol == model.IdRol && (a.Active == false)).Count();
            int verificarRol = _servicioRol.BuscarEF().Where(a => a.Nombre.Trim() == model.Nombre.Trim() && (a.Active == false)).Count();
            if (verificarRol > 0 || verificarRolxID > 0)
            {
                correct = true;
            }
            return correct;
        }
    }
}
