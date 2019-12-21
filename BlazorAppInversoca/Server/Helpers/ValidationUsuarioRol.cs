using BlazorAppInversoca.DataService.Interfaces;
using BlazorAppInversoca.Shared.EFModels;
using BlazorAppInversoca.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorAppInversoca.Server.Helpers
{
    public class ValidationUsuarioRol
    {
        private readonly IUsuarioRol _servicioUsuarioRol;

        public ValidationUsuarioRol(IUsuarioRol UsuarioRol)
        {
            _servicioUsuarioRol = UsuarioRol;

        }
        public bool UsuarioRolSP(UsuarioRolViewModel model)
        {
            bool correct = false;
            int verificarUsuarioRolxID = _servicioUsuarioRol.BuscarSP(0,0).Where(a => a.IdUsuario == model.IdUsuario && a.IdRol == model.IdRol).Count();
            if (verificarUsuarioRolxID == 1 || verificarUsuarioRolxID == 0)
            {
                correct = true;
            }
            return correct;
        }

        //public bool ExistsInactiveSP(UsuarioRolViewModel model)
        //{
        //    bool correct = false;
        //    int verificarUsuarioRolxID = _servicioUsuarioRol.BuscarSP(false, false).Where(a => a.IdUsuarioRol == model.IdUsuarioRol).Count();
        //    int verificarUsuarioRol = _servicioUsuarioRol.BuscarSP(false, false).Where(a => a.Nombre.ToLower() == model.Nombre.Trim().ToLower()).Count();
        //    if (verificarUsuarioRol > 0 || verificarUsuarioRolxID > 0)
        //    {
        //        correct = true;
        //    }
        //    return correct;
        //}
        public bool UsuarioRolEF(UsuarioRol model)
        {
            bool correct = false;
            int verificarUsuarioRolxID = _servicioUsuarioRol.BuscarEF().Where(a => a.IdUsuario == model.IdUsuario && a.IdRol == model.IdRol).Count();

            if (verificarUsuarioRolxID == 1 || verificarUsuarioRolxID == 0)
            {
                correct = true;
            }
            return correct;
        }

        //public bool ExistsInactiveEF(UsuarioRol model)
        //{
        //    bool correct = false;
        //    int verificarUsuarioRolxID = _servicioUsuarioRol.BuscarEF().Where(a => a.IdUsuarioRol == model.IdUsuarioRol && (a.Active == false)).Count();
        //    int verificarUsuarioRol = _servicioUsuarioRol.BuscarEF().Where(a => a.Nombre.Trim() == model.Nombre.Trim() && (a.Active == false)).Count();
        //    if (verificarUsuarioRol == 1 || verificarUsuarioRolxID == 1)
        //    {
        //        correct = true;
        //    }
        //    return correct;
        //}
    }
}
