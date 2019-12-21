using BlazorAppInversoca.DataService.Interfaces;
using BlazorAppInversoca.Shared.EFModels;
using BlazorAppInversoca.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorAppInversoca.Server.Helpers
{
    public class ValidationUsuario
    {
        private readonly IUsuario _servicioUsuario;

        public ValidationUsuario(IUsuario Usuario)
        {
            _servicioUsuario = Usuario;

        }
        public bool CredentialsEF(Usuario model)
        {
            bool correct = false;
            int verificarCredenciales = _servicioUsuario.BuscarEF().Where(a => a.Nombre.Trim() == model.Nombre.Trim() &&
            a.Contrasena.Trim() == model.Contrasena.Trim() && (a.Active == true)).Count();
            if (verificarCredenciales == 1)
            {
                correct = true;
            }
            return correct;
        }
        public bool CredentialsSP(UsuarioViewModel model)
        {
            bool correct = false;
            int verificarCredenciales = _servicioUsuario.BuscarRegistroSP().Where(a => a.Nombre.Trim() == model.Nombre.Trim() &&
            a.Contrasena.Trim() == model.Contrasena.Trim() && (a.Active == true)).Count();
            if (verificarCredenciales == 1)
            {
                correct = true;
            }
            return correct;
        }

        public bool UsuarioSP(UsuarioViewModel model)
        {
            bool correct = false;
            int verificarUsuarioxID = _servicioUsuario.BuscarSP(false, true).Where(a => a.IdUsuario == model.IdUsuario && a.Nombre.ToLower() == model.Nombre.Trim().ToLower() &&
            a.Correo.ToLower() == model.Correo.Trim().ToLower()).Count();
            int verificarUsuario = _servicioUsuario.BuscarSP(false, true).Where(a => a.Nombre.ToLower() == model.Nombre.Trim().ToLower() &&
            a.Correo.ToLower() == model.Correo.Trim().ToLower()).Count();
            if ((verificarUsuario == 0 && verificarUsuarioxID == 1) || (verificarUsuario == 1 && verificarUsuarioxID == 1) || (verificarUsuario == 0 && verificarUsuarioxID == 0))
            {
                correct = true;
            }
            return correct;
        }

        public bool ExistsInactiveSP(UsuarioViewModel model)
        {
            bool correct = false;
            int verificarUsuarioxID = _servicioUsuario.BuscarSP(false, false).Where(a => a.IdUsuario == model.IdUsuario).Count();
            int verificarUsuario = _servicioUsuario.BuscarSP(false, false).Where(a => a.Nombre.ToLower() == model.Nombre.Trim().ToLower() &&
            a.Correo.ToLower() == model.Correo.Trim().ToLower()).Count();
            if (verificarUsuario > 0 || verificarUsuarioxID > 0)
            {
                correct = true;
            }
            return correct;
        }
        public bool UsuarioEF(Usuario model)
        {
            bool correct = false;
            int verificarUsuarioxID = _servicioUsuario.BuscarEF().Where(a => a.IdUsuario == model.IdUsuario && (a.Active == true)).Count();
            int verificarUsuario = _servicioUsuario.BuscarEF().Where(a => a.Nombre.Trim() == model.Nombre.Trim() &&
            a.Correo.ToLower() == model.Correo.Trim().ToLower() && (a.Active == true)).Count();

            if (verificarUsuario == 0 || verificarUsuarioxID == 1)
            {
                correct = true;
            }
            return correct;
        }

        public bool ExistsInactiveEF(Usuario model)
        {
            bool correct = false;
            int verificarUsuarioxID = _servicioUsuario.BuscarEF().Where(a => a.IdUsuario == model.IdUsuario && (a.Active == false)).Count();
            int verificarUsuario = _servicioUsuario.BuscarEF().Where(a => a.Nombre.Trim() == model.Nombre.Trim() &&
            (a.Correo.ToLower() == model.Correo.Trim().ToLower()) &&  (a.Active == false)).Count();
            if (verificarUsuario > 0 || verificarUsuarioxID > 0)
            {
                correct = true;
            }
            return correct;
        }
    }
}
