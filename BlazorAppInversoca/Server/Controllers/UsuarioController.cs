using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlazorAppInversoca.DataService.Interfaces;
using BlazorAppInversoca.Server.Helpers;
using BlazorAppInversoca.Shared.EFModels;
using BlazorAppInversoca.Shared.Helpers;
using BlazorAppInversoca.Shared.Token___Result_Models;
using BlazorAppInversoca.Shared.ViewModels;

namespace BlazorAppInversoca.Server.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly ValidationUsuario _validarUsuario;
        private readonly IUsuario _servicioUsuario; // Servicio de Usuario
        private UsuarioViewModel UsuarioViewModel = new UsuarioViewModel();
        public UsuarioController(IUsuario Usuario)
        {
            _servicioUsuario = Usuario;
            _validarUsuario = new ValidationUsuario(_servicioUsuario);
        }
        //GET: Verificar si el usuario esta logeado
        [AllowAnonymous]
        [HttpGet("VerificarUsuario")]
        public UserInfo GetUser()
        {
            return null;
            //return User.Identity.IsAuthenticated
            //    ? new UserInfo { UserName = User.Identity.Name, IsAuthenticated = true }
            //    : LoggedOutUser;
        }
        //POST: cerrar Sesion con Authentication
        [HttpGet("Logout")]
        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("~/");
        }
        //POST: Iniciar Sesion con Entity Framework
        [AllowAnonymous]
        [Route("IniciarSesionSP")]
        [HttpPost]
        public ActionResult LoginSP([FromBody] UsuarioViewModel model)
        {
            if (_validarUsuario.CredentialsSP(model))
            {
                return null;
                //var tokenGenerator = Token.TokenGenerator.GenerateTokenJwt(model.UserName.Trim());
                ////var tokenGenerator = Token.TokenGenerator.GenerateTokenJwt("Jorge");
                //return new JsonResult(new ResultViewModel { success = true, error = null, token = tokenGenerator });
            }
            else
            {
                return new JsonResult(new ResultViewModel { success = false, error = "Usuario y/o contraseña incorrectos", token = null });
            }
        }
       

        //Get: BuscarSP Todos los Usuarios con StoredProcedure
        [Route("BuscarSP/Todos/{isAll}/Activo/{Activo}")]
        [HttpGet]
        public ActionResult ListSP(bool isAll, bool Activo)
        {
            return new JsonResult(_servicioUsuario.BuscarSP(isAll, Activo));
        }
        //Get: BuscarSP Todos los Registros de Usuarios on StoredProcedure
        [Route("BuscarSP/Registro")]
        [HttpGet]
        public ActionResult SearchRecords()
        {
            return new JsonResult(_servicioUsuario.BuscarRegistroSP());
        }
        //Get: BuscarSP Todos los Registros de Usuario por Nombre con StoredProcedure
        [Route("BuscarSP/Registro/Nombre/{nombre}")]
        [HttpGet]
        public ActionResult SearchRecordByName(string nombre)
        {
            nombre = StaticHelper.FirstLetterCapital(nombre);
            return new JsonResult(_servicioUsuario.BuscarRegistroSP()
                .Where(a => a.Nombre.ToLower() == nombre.ToLower()).SingleOrDefault());
        }
        //Get: BuscarSP Todos los Registros de Usuario por Id con StoredProcedure
        [Route("BuscarSP/Registro/Id/{id}")]
        [HttpGet]
        public ActionResult SearchRecordById(int id)
        {
            return new JsonResult(_servicioUsuario.BuscarRegistroSP()
                .Where(a => a.IdUsuario == id).SingleOrDefault());
        }
        //Get: BuscarSP Todos los Usuarios View por Nombre con StoredProcedure
        [Route("BuscarSP/Todos/{isAll}/Activo/{Activo}/Nombre/{nombre}")]
        [HttpGet]
        public ActionResult SearchListByName(bool isAll, bool Activo, string nombre)
        {
            nombre = StaticHelper.FirstLetterCapital(nombre);
            return new JsonResult(_servicioUsuario.BuscarSP(isAll, Activo)
                .Where(a => a.Nombre.ToLower() == nombre.ToLower()).SingleOrDefault());
        }
        //Get: BuscarSP Todos los Usuarios View por Id con StoredProcedure
        [Route("BuscarSP/Todos/{isAll}/Activo/{Activo}/Id/{id}")]
        [HttpGet]
        public ActionResult SearchListById(bool isAll, bool Activo, int id)
        {
            return new JsonResult(_servicioUsuario.BuscarSP(isAll, Activo)
                .Where(a => a.IdUsuario == id).SingleOrDefault());
        }
        //Get: Buscar Todos los Modulo que contenga el filtro
        [Route("FiltrarEF/{filtro}/{value}")]
        [HttpGet]
        public ActionResult FilterEF(string filtro = "", string value = "")

        {
            filtro = StaticHelper.FirstLetterCapital(filtro);
            value = StaticHelper.FirstLetterCapital(value);
            if (filtro == "Id")
            {
                var result = _servicioUsuario.BuscarEF().Where(a => a.IdUsuario == Convert.ToInt32(value));
                return new JsonResult(result);
            }
            else if (filtro == "Nombre")
            {
                var result = _servicioUsuario.BuscarEF().Where(a => a.Nombre.Contains(value));
                return new JsonResult(result);
            }
            else if (filtro == "Correo")
            {
                var result = _servicioUsuario.BuscarEF().Where(a => a.Correo.Contains(value));
                return new JsonResult(result);
            }
            return null;
        }
        //Get: BuscarSP Todos los Moduloes que contenga el filtro con StoredProcedure
        [Route("FiltrarSP/Todos/{isAll}/Activo/{Activo}/{filtro}/{value}")]
        [HttpGet]
        public ActionResult FilterSP(bool isAll, bool Activo, string filtro, string value)
        {
            filtro = StaticHelper.FirstLetterCapital(filtro);
            value = StaticHelper.FirstLetterCapital(value);
            if (filtro == "Id")
            {
                var result = _servicioUsuario.BuscarSP(isAll, Activo).Where(a => a.IdUsuario == Convert.ToInt32(value));
                return new JsonResult(result);
            }
            else if (filtro == "Nombre")
            {
                var result = _servicioUsuario.BuscarSP(isAll, Activo).Where(a => a.Nombre.Contains(value));
                return new JsonResult(result);
            }
            else if(filtro == "Correo")
            {
                var result = _servicioUsuario.BuscarSP(isAll, Activo).Where(a => a.Correo.Contains(value));
                return new JsonResult(result);
            }
            return null;
        }
        //POST: Crear un Usuario con Stored Procedure
        [Route("CrearSP")]
        [HttpPost]
        public ActionResult CreateSP([FromBody] UsuarioViewModel model)
        {
            if (!_validarUsuario.ExistsInactiveSP(model))
            {
                var error = _servicioUsuario.CrearSP(model);
                bool inserted = false;
                if (error == null)
                {
                    inserted = true;
                }
                return new JsonResult(new ResultViewModel { success = inserted, error = error, token = null });
            }
            else if (_validarUsuario.ExistsInactiveSP(model))
            {
                return new JsonResult(new ResultViewModel { success = true, error = "exists", token = null });
            }
            return null;
        }

        //POST: Modificar un Usuario con Stored Procedure
        [Route("ModificarSP")]
        [HttpPut]
        public ActionResult UpdateSP([FromBody] UsuarioViewModel model)
        {
            if (!_validarUsuario.ExistsInactiveSP(model))
            {
                var error = _servicioUsuario.ActualizarSP(model);
                bool inserted = false;
                if (error == null)
                {
                    inserted = true;
                }
                return new JsonResult(new ResultViewModel { success = inserted, error = error, token = null });
            }
            else if (_validarUsuario.ExistsInactiveSP(model))
            {
                if (model.Active)
                {
                    return new JsonResult(new ResultViewModel { success = true, error = "exists", token = null });
                }
                else
                {
                    model.Active = true;
                    return new JsonResult(new ResultViewModel { success = true, error = _servicioUsuario.ActualizarSP(model), token = null });
                }
            }
            return null;
        }

        // PUT: Desactivar un Usuario con Stored Procedure
        [Route("DesactivarSP")]
        [HttpPut]
        public ActionResult InactiveSP([FromBody] UsuarioViewModel model)
        {
            model.Active = false;
            var error = _servicioUsuario.ActualizarSP(model);
            bool inserted = false;
            if (error == null)
            {
                inserted = true;
            }
            return new JsonResult(new ResultViewModel { success = inserted, error = error, token = null });
        }
        // DELETE: Eliminar un Usuario con Stored Procedure
        [Route("EliminarSP")]
        [HttpPost]
        public ActionResult DeleteSP([FromBody]UsuarioView model)
        {
            var error = _servicioUsuario.EliminarSP(model);
            bool inserted = false;
            if (error == null)
            {
                inserted = true;
            }
            return new JsonResult(new ResultViewModel { success = inserted, error = error, token = null });
        }
        //POST: Iniciar Sesion con Entity Framework
        [AllowAnonymous]
        [Route("IniciarSesionEF")]
        [HttpPost]
        public ActionResult LoginEF([FromBody] Usuario model)
        {
            if (_validarUsuario.CredentialsEF(model))
            {
                return null;
                //var tokenGenerator = Token.TokenGenerator.GenerateTokenJwt(model.UserName.Trim());
                ////var tokenGenerator = Token.TokenGenerator.GenerateTokenJwt("Jorge");
                //return new JsonResult(new ResultViewModel { success = true, error = null, token = tokenGenerator });
            }
            else
            {
                return new JsonResult(new ResultViewModel { success = false, error = "Usuario y/o contraseña incorrectos", token = null });
            }
        }
        //GET: BuscarEF Buscar Todos los Usuarios con Entity Framework
        [Route("BuscarEF")]
        [HttpGet]
        public ActionResult ListEF()
        {
            return new JsonResult(_servicioUsuario.BuscarEF().Where(a => a.Active == true));
        }
        //POST: Crear un Usuario en Entity Framework
        [Route("CrearEF")]
        [HttpPost]
        public ActionResult CreateEF([FromBody] Usuario model)
        {
            if (_validarUsuario.UsuarioEF(model) && !_validarUsuario.ExistsInactiveEF(model))
            {
                var error = _servicioUsuario.CrearEF(model);
                bool inserted = false;
                if (error == null)
                {
                    inserted = true;
                }
                return new JsonResult(new ResultViewModel { success = inserted, error = error, token = null });
            }
            else if (_validarUsuario.ExistsInactiveEF(model))
            {
                return new JsonResult(new ResultViewModel { success = true, error = "exists", token = null });
            }
            return null;
        }

        //POST: Modificar un Usuario en Entity Framework
        [Route("ModificarEF")]
        [HttpPut]
        public ActionResult UpdateEF([FromBody] Usuario model)
        {
            if (_validarUsuario.UsuarioEF(model) && !_validarUsuario.ExistsInactiveEF(model))
            {
                var error = _servicioUsuario.ActualizarEF(model);
                bool inserted = false;
                if (error == null)
                {
                    inserted = true;
                }
                return new JsonResult(new ResultViewModel { success = inserted, error = error, token = null });
            }
            else if (_validarUsuario.ExistsInactiveEF(model))
            {
                if (model.Active)
                {
                    return new JsonResult(new ResultViewModel { success = true, error = "exists", token = null });
                }
                else
                {
                    model.Active = true;
                    return new JsonResult(new ResultViewModel { success = true, error = _servicioUsuario.ActualizarEF(model), token = null });
                }
            }
            return null;
        }

        // PUT: Desactivar un Usuario en EntityFramework
        [Route("DesactivarEF")]
        [HttpPut]
        public ActionResult InactiveEF([FromBody] Usuario model)
        {
            model.Active = false;
            var error = _servicioUsuario.ActualizarEF(model);
            bool inserted = false;
            if (error == null)
            {
                inserted = true;
            }
            return new JsonResult(new ResultViewModel { success = inserted, error = error, token = null });
        }
        // DELETE: Eliminar un Usuario en Entity Framework
        [Route("EliminarEF")]
        [HttpPost]
        public ActionResult DeleteEF([FromBody]Usuario model)
        {
            var error = _servicioUsuario.EliminarEF(model);
            bool inserted = false;
            if (error == null)
            {
                inserted = true;
            }
            return new JsonResult(new ResultViewModel { success = inserted, error = error, token = null });
        }
    }
}
