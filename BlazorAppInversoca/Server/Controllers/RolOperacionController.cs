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
    public class RolOperacionController : ControllerBase
    {
        private readonly ValidationRolOperacion _validarRolOperacion;
        private readonly IRolOperacion _servicioRolOperacion; // Servicio de RolOperacion
        private RolOperacionViewModel RolOperacionViewModel = new RolOperacionViewModel();
        public RolOperacionController(IRolOperacion RolOperacion)
        {
            _servicioRolOperacion = RolOperacion;
            _validarRolOperacion = new ValidationRolOperacion(_servicioRolOperacion);
        }

        //Get: BuscarSP Todos los RolOperacions con StoredProcedure
        [Route("BuscarSP")]
        [HttpGet]
        public ActionResult ListSP()
        {
            return new JsonResult(_servicioRolOperacion.BuscarSP());
        }
        //Get: BuscarSP Todos los Registros de RolOperacion con StoredProcedure
        [Route("BuscarSP/Registro")]
        [HttpGet]
        public ActionResult SearchRecords()
        {
            return new JsonResult(_servicioRolOperacion.BuscarRegistroSP());
        }
        //Get: BuscarSP un Registros de RolOperacion  con StoredProcedure
        [Route("BuscarSP/Registro/Rol/{IdRol}/Operacion/{IdOperacion}")]
        [HttpGet]
        public ActionResult SearchRecord(int IdRol,int IdOperacion)
        {
            return new JsonResult(_servicioRolOperacion.BuscarRegistroSP()
                .Where(a => a.IdRol == IdRol && a.IdOperacion == IdOperacion).SingleOrDefault());
        }
        //Get: BuscarSP Todos los Registros de RolOperacion por Rol con StoredProcedure
        [Route("BuscarSP/Registro/Rol/{IdRol}")]
        [HttpGet]
        public ActionResult SearchRecordByRol(int IdRol)
        {
            return new JsonResult(_servicioRolOperacion.BuscarRegistroSP()
                .Where(a => a.IdRol == IdRol));
        }
        //Get: BuscarSP Todos los Registros de RolOperacion por Operacion con StoredProcedure
        [Route("BuscarSP/Registro/Operacion/{IdOperacion}")]
        [HttpGet]
        public ActionResult SearchRecordByOperacion(int IdOperacion)
        {
            return new JsonResult(_servicioRolOperacion.BuscarRegistroSP()
                .Where(a => a.IdOperacion == IdOperacion));
        }
        //Get: BuscarSP Todos los RolOperacions View por Rol con StoredProcedure
        [Route("BuscarSP/Rol/{IdRol}")]
        [HttpGet]
        public ActionResult SearchListByRol(int IdRol = 0)
        {
            return new JsonResult(_servicioRolOperacion.BuscarSP()
                .Where(a => a.IdRol == IdRol));
        }
        //Get: BuscarSP Todos los RolOperacions View por Operacion con StoredProcedure
        [Route("BuscarSP/Operacion/{IdOperacion}")]
        [HttpGet]
        public ActionResult SearchListByOperacion(int IdOperacion = 0)
        {
            return new JsonResult(_servicioRolOperacion.BuscarSP()
                .Where(a => a.IdOperacion == IdOperacion));
        }
        //Get: BuscarSP Todos los RolOperacions View por Ambos
        [Route("BuscarSP/Rol/{IdRol}/Operacion/{IdOperacion}")]
        [HttpGet]
        public ActionResult SearchListByRolOperacion(int IdRol=0,int IdOperacion = 0)
        {
            return new JsonResult(_servicioRolOperacion.BuscarSP(IdRol,IdOperacion)
                .SingleOrDefault());
        }
        //Get: Buscar Todos los Modulo que contenga el filtro
        [Route("FiltrarEF/{filtro}/{value}")]
        [HttpGet]
        public ActionResult FilterEF(string filtro = "", string value = "")

        {
            filtro = StaticHelper.FirstLetterCapital(filtro);
            value = StaticHelper.FirstLetterCapital(value);
            if (filtro == "Rol")
            {
                var result = _servicioRolOperacion.BuscarEF().Where(a => a.Rol.Nombre.Contains(value));
                return new JsonResult(result);
            }
            else if (filtro == "Operación")
            {
                var result = _servicioRolOperacion.BuscarEF().Where(a => a.Operacion.Nombre.Contains(value));
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
            if (filtro == "Rol")
            {
                var result = _servicioRolOperacion.BuscarSP().Where(a => a.NombreRol.Contains(value));
                return new JsonResult(result);
            }
            else if (filtro == "Operación")
            {
                var result = _servicioRolOperacion.BuscarSP().Where(a => a.NombreOperacion.Contains(value));
                return new JsonResult(result);
            }
            return null;
        }
        //POST: Crear un RolOperacion con Stored Procedure
        [Route("CrearSP")]
        [HttpPost]
        public ActionResult CreateSP([FromBody] RolOperacionViewModel model)
        {
            var error = _servicioRolOperacion.CrearSP(model);
            bool inserted = false;
            if (error == null)
            {
                inserted = true;
            }
            return new JsonResult(new ResultViewModel { success = inserted, error = error, token = null });
        }

        //POST: Modificar un RolOperacion con Stored Procedure
        [Route("ModificarSP")]
        [HttpPut]
        public ActionResult UpdateSP([FromBody] RolOperacionViewModel model)
        {    
            var error = _servicioRolOperacion.ActualizarSP(model);
            bool inserted = false;
            if (error == null)
            {
                inserted = true;
            }
            return new JsonResult(new ResultViewModel { success = inserted, error = error, token = null });
        }


        // DELETE: Eliminar un RolOperacion con Stored Procedure
        [Route("EliminarSP")]
        [HttpPost]
        public ActionResult DeleteSP([FromBody]RolOperacionView model)
        {
            var error = _servicioRolOperacion.EliminarSP(model);
            bool inserted = false;
            if (error == null)
            {
                inserted = true;
            }
            return new JsonResult(new ResultViewModel { success = inserted, error = error, token = null });
        }
        //GET: BuscarEF Buscar Todos los RolOperacions con Entity Framework
        [Route("BuscarEF")]
        [HttpGet]
        public ActionResult ListEF()
        {
            return new JsonResult(_servicioRolOperacion.BuscarEF());
        }
        //POST: Crear un RolOperacion en Entity Framework
        [Route("CrearEF")]
        [HttpPost]
        public ActionResult CreateEF([FromBody] RolOperacion model)
        {
            var error = _servicioRolOperacion.CrearEF(model);
            bool inserted = false;
            if (error == null)
            {
                inserted = true;
            }
            return new JsonResult(new ResultViewModel { success = inserted, error = error, token = null });  
        }

        //POST: Modificar un RolOperacion en Entity Framework
        [Route("ModificarEF")]
        [HttpPut]
        public ActionResult UpdateEF([FromBody] RolOperacion model)
        {
            var error = _servicioRolOperacion.CrearEF(model);
            bool inserted = false;
            if (error == null)
            {
                inserted = true;
            }
            return new JsonResult(new ResultViewModel { success = inserted, error = error, token = null });
        }
        // DELETE: Eliminar un RolOperacion en Entity Framework
        [Route("EliminarEF")]
        [HttpPost]
        public ActionResult DeleteEF([FromBody]RolOperacion model)
        {
            var error = _servicioRolOperacion.EliminarEF(model);
            bool inserted = false;
            if (error == null)
            {
                inserted = true;
            }
            return new JsonResult(new ResultViewModel { success = inserted, error = error, token = null });
        }
        //// PUT: Desactivar un RolOperacion en EntityFramework
        //[Route("DesactivarEF")]
        //[HttpPut]
        //public ActionResult InactiveEF([FromBody] RolOperacion model)
        //{
        //    model.Active = false;
        //    return new JsonResult(new ResultViewModel { success = true, error = _servicioRolOperacion.ActualizarEF(model), token = null });
        //}
        //// PUT: Desactivar un RolOperacion con Stored Procedure
        //[Route("DesactivarSP")]
        //[HttpPut]
        //public ActionResult InactiveSP([FromBody] RolOperacionViewModel model)
        //{
        //    model.Active = false;
        //    return new JsonResult(new ResultViewModel { success = true, error = _servicioRolOperacion.ActualizarSP(model), token = null });
        //}
        ////Get: BuscarSP Todos los RolOperaciones que contenga el filtro con StoredProcedure
        //[Route("FiltrarSP/Todos/{isAll}/Activo/{Activo}/{filtro}/{value}")]
        //[HttpGet]
        //public ActionResult FilterSP(bool isAll, bool Activo, string filtro, string value)
        //{
        //    filtro = StaticHelper.FirstLetterCapital(filtro);
        //    value = StaticHelper.FirstLetterCapital(value);
        //    if (filtro == "ID")
        //    {
        //        var result = _servicioRolOperacion.BuscarSP(isAll, Activo).Where(a => a.IdRolOperacion == Convert.ToInt32(value));
        //        return new JsonResult(result);
        //    }
        //    else if (filtro == "Nombre")
        //    {
        //        var result = _servicioRolOperacion.BuscarSP(isAll, Activo).Where(a => a.Nombre.Contains(value));
        //        return new JsonResult(result);
        //    }
        //    else if (filtro == "Compañia")
        //    {
        //        //var result = _servicioRolOperacion.BuscarSP(isAll, Activo).Where(a => a.NombreMercado.Contains(value));
        //        //return new JsonResult(result);
        //    }

        //    return null;
        //}
    }
}
