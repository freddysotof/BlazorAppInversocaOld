using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class UsuarioRolController : ControllerBase
    {
        private readonly ValidationUsuarioRol _validarUsuarioRol;
        private readonly IUsuarioRol _servicioUsuarioRol; // Servicio de UsuarioRol
        private UsuarioRolViewModel UsuarioRolViewModel = new UsuarioRolViewModel();
        public UsuarioRolController(IUsuarioRol UsuarioRol)
        {
            _servicioUsuarioRol = UsuarioRol;
            _validarUsuarioRol = new ValidationUsuarioRol(_servicioUsuarioRol);
        }

        //Get: BuscarSP Todos los UsuarioRols con StoredProcedure
        [Route("BuscarSP")]
        [HttpGet]
        public ActionResult ListSP()
        {
            return new JsonResult(_servicioUsuarioRol.BuscarSP());
        }
      
        //Get: BuscarSP Todos los Registros de RolOperacion con StoredProcedure
        [Route("BuscarSP/Registro")]
        [HttpGet]
        public ActionResult SearchRecords()
        {
            return new JsonResult(_servicioUsuarioRol.BuscarRegistroSP());
        }
        //Get: BuscarSP un Registro de Usuario Rol por Nombre con StoredProcedure
        [Route("BuscarSP/Registro/Usuario/{IdUsuario}/Rol/{IdRol}")]
        [HttpGet]
        public ActionResult SearchRecord(int IdUsuario, int IdRol)
        {
            return new JsonResult(_servicioUsuarioRol.BuscarRegistroSP()
                .Where(a => a.IdUsuario == IdUsuario && a.IdRol == IdRol).SingleOrDefault());
        }
        //Get: BuscarSP Todos los Registros de UsuarioRol por Nombre con StoredProcedure
        [Route("BuscarSP/Registro/Rol/{IdRol}")]
        [HttpGet]
        public ActionResult SearchRecordByRol(int IdRol)
        {
            return new JsonResult(_servicioUsuarioRol.BuscarRegistroSP()
                .Where(a => a.IdRol == IdRol));
        }
        //Get: BuscarSP Todos los Registros de UsuarioRol por Id con StoredProcedure
        [Route("BuscarSP/Registro/Usuario/{IdUsuario}")]
        [HttpGet]
        public ActionResult SearchRecordByUsuario(int IdUsuario)
        {
            return new JsonResult(_servicioUsuarioRol.BuscarRegistroSP()
                .Where(a => a.IdUsuario == IdUsuario));
        }
        //Get: BuscarSP Todos los UsuarioRols View por Nombre con StoredProcedure
        [Route("BuscarSP/Rol/{IdRol}")]
        [HttpGet]
        public ActionResult SearchListByRol( int IdRol = 0)
        {
            return new JsonResult(_servicioUsuarioRol.BuscarSP()
                .Where(a => a.IdRol == IdRol));
        }
        //Get: BuscarSP Todos los UsuarioRols View por Usuario con Stored Proeedure
        [Route("BuscarSP/Usuario/{IdUsuario}")]
        [HttpGet]
        public ActionResult SearchListByUsuario(int IdUsuario=0)
        {
            return new JsonResult(_servicioUsuarioRol.BuscarSP()
                .Where(a => a.IdUsuario == IdUsuario)) ;
        }
        //Get: BuscarSP Una Relacion Especifica
        [Route("BuscarSP/Usuario/{IdUsuario}/Rol/{IdRol}")]
        [HttpGet]
        public ActionResult ListSPUsuarioRol(int IdUsuario = 0, int IdRol = 0)
        {
            return new JsonResult(_servicioUsuarioRol.BuscarSP(IdUsuario, IdRol).SingleOrDefault());
        }
        //Get: Buscar Todos los Modulo que contenga el filtro
        [Route("FiltrarEF/{filtro}/{value}")]
        [HttpGet]
        public ActionResult FilterEF(string filtro = "", string value = "")

        {
            filtro = StaticHelper.FirstLetterCapital(filtro);
            value = StaticHelper.FirstLetterCapital(value);
            if (filtro == "Usuario")
            {
                var result = _servicioUsuarioRol.BuscarEF().Where(a => a.Usuario.Nombre.Contains(value));
                return new JsonResult(result);
            }
            else if (filtro == "Rol")
            {
                var result = _servicioUsuarioRol.BuscarEF().Where(a => a.Rol.Nombre.Contains(value));
                return new JsonResult(result);
            }
            return null;
        }
        //Get: BuscarSP Todos los Moduloes que contenga el filtro con StoredProcedure
        [Route("FiltrarSP/{filtro}/{value}")]
        [HttpGet]
        public ActionResult FilterSP(bool isAll, bool Activo, string filtro, string value)
        {
            filtro = StaticHelper.FirstLetterCapital(filtro);
            value = StaticHelper.FirstLetterCapital(value);
            if (filtro == "Usuario")
            {
                var result = _servicioUsuarioRol.BuscarSP().Where(a => a.NombreUsuario.Contains(value));
                return new JsonResult(result);
            }
            else if (filtro == "Rol")
            {
                var result = _servicioUsuarioRol.BuscarSP().Where(a => a.NombreRol.Contains(value));
                return new JsonResult(result);
            }
            return null;
        }
        //POST: Crear un UsuarioRol con Stored Procedure
        [Route("CrearSP")]
        [HttpPost]
        public ActionResult CreateSP([FromBody] UsuarioRolViewModel model)
        {
            var error = _servicioUsuarioRol.CrearSP(model);
            bool inserted = false;
            if (error == null)
            {
                inserted = true;
            }
            return new JsonResult(new ResultViewModel { success = inserted, error = error, token = null });
        }

        //POST: Modificar un UsuarioRol con Stored Procedure
        [Route("ModificarSP")]
        [HttpPut]
        public ActionResult UpdateSP([FromBody] UsuarioRolViewModel model)
        {
            var error = _servicioUsuarioRol.ActualizarSP(model);
            bool inserted = false;
            if (error == null)
            {
                inserted = true;
            }
            return new JsonResult(new ResultViewModel { success = inserted, error = error, token = null });
        }


        // DELETE: Eliminar un UsuarioRol con Stored Procedure
        [Route("EliminarSP")]
        [HttpPost]
        public ActionResult DeleteSP([FromBody]UsuarioRolView model)
        {
            var error = _servicioUsuarioRol.EliminarSP(model);
            bool inserted = false;
            if (error == null)
            {
                inserted = true;
            }
            return new JsonResult(new ResultViewModel { success = inserted, error = error, token = null });
        }
        //GET: BuscarEF Buscar Todos los UsuarioRols con Entity Framework
        [Route("BuscarEF")]
        [HttpGet]
        public ActionResult ListEF()
        {
            return new JsonResult(_servicioUsuarioRol.BuscarEF());
        }
        //POST: Crear un UsuarioRol en Entity Framework
        [Route("CrearEF")]
        [HttpPost]
        public ActionResult CreateEF([FromBody] UsuarioRol model)
        {
            var error = _servicioUsuarioRol.CrearEF(model);
            bool inserted = false;
            if (error == null)
            {
                inserted = true;
            }
            return new JsonResult(new ResultViewModel { success = inserted, error = error, token = null });
        }

        //POST: Modificar un UsuarioRol en Entity Framework
        [Route("ModificarEF")]
        [HttpPut]
        public ActionResult UpdateEF([FromBody] UsuarioRol model)
        {
            var error = _servicioUsuarioRol.ActualizarEF(model);
            bool inserted = false;
            if (error == null)
            {
                inserted = true;
            }
            return new JsonResult(new ResultViewModel { success = inserted, error = error, token = null });
        }
        // DELETE: Eliminar un UsuarioRol en Entity Framework
        [Route("EliminarEF")]
        [HttpPost]
        public ActionResult DeleteEF([FromBody]UsuarioRol model)
        {
            var error = _servicioUsuarioRol.EliminarEF(model);
            bool inserted = false;
            if (error == null)
            {
                inserted = true;
            }
            return new JsonResult(new ResultViewModel { success = inserted, error = error, token = null });
        }
        //// PUT: Desactivar un UsuarioRol en EntityFramework
        //[Route("DesactivarEF")]
        //[HttpPut]
        //public ActionResult InactiveEF([FromBody] UsuarioRol model)
        //{
        //    model.Active = false;
        //    return new JsonResult(new ResultViewModel { success = true, error = _servicioUsuarioRol.ActualizarEF(model), token = null });
        //}
        //// PUT: Desactivar un UsuarioRol con Stored Procedure
        //[Route("DesactivarSP")]
        //[HttpPut]
        //public ActionResult InactiveSP([FromBody] UsuarioRolViewModel model)
        //{
        //    model.Active = false;
        //    return new JsonResult(new ResultViewModel { success = true, error = _servicioUsuarioRol.ActualizarSP(model), token = null });
        //}
        ////Get: BuscarSP Todos los UsuarioRoles que contenga el filtro con StoredProcedure
        //[Route("FiltrarSP/Todos/{isAll}/Activo/{Activo}/{filtro}/{value}")]
        //[HttpGet]
        //public ActionResult FilterSP(bool isAll, bool Activo, string filtro, string value)
        //{
        //    filtro = StaticHelper.FirstLetterCapital(filtro);
        //    value = StaticHelper.FirstLetterCapital(value);
        //    if (filtro == "ID")
        //    {
        //        var result = _servicioUsuarioRol.BuscarSP(isAll, Activo).Where(a => a.IdUsuarioRol == Convert.ToInt32(value));
        //        return new JsonResult(result);
        //    }
        //    else if (filtro == "Nombre")
        //    {
        //        var result = _servicioUsuarioRol.BuscarSP(isAll, Activo).Where(a => a.Nombre.Contains(value));
        //        return new JsonResult(result);
        //    }
        //    else if (filtro == "Compañia")
        //    {
        //        //var result = _servicioUsuarioRol.BuscarSP(isAll, Activo).Where(a => a.NombreMercado.Contains(value));
        //        //return new JsonResult(result);
        //    }

        //    return null;
        //}
    }
    }
