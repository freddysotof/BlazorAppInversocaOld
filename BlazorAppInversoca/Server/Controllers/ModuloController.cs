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
    public class ModuloController : ControllerBase
    {
        private readonly ValidationModulo _validarModulo;
        private readonly IModulo _servicioModulo; // Servicio de Modulo
        private ModuloViewModel ModuloViewModel = new ModuloViewModel();
        public ModuloController(IModulo Modulo)
        {
            _servicioModulo = Modulo;
            _validarModulo = new ValidationModulo(_servicioModulo);
        }

        //Get: BuscarSP Todos los Modulos con StoredProcedure
        [Route("BuscarSP/Todos/{isAll}/Activo/{Activo}")]
        [HttpGet]
        public ActionResult ListSP(bool isAll, bool Activo)
        {
            return new JsonResult(_servicioModulo.BuscarSP(isAll, Activo));
        }
        //Get: BuscarSP Todos los Registros de Modulo por Nombre con StoredProcedure
        [Route("BuscarSP/Registro/Nombre/{nombre}")]
        [HttpGet]
        public ActionResult SearchRecordByName(string nombre)
        {
            nombre = StaticHelper.FirstLetterCapital(nombre);
            return new JsonResult(_servicioModulo.BuscarRegistroSP()
                .Where(a => a.Nombre.ToLower() == nombre.ToLower()).SingleOrDefault());
        }
        //Get: BuscarSP Todos los Registros de Modulo on StoredProcedure
        [Route("BuscarSP/Registro")]
        [HttpGet]
        public ActionResult SearchRecords()
        {
            return new JsonResult(_servicioModulo.BuscarRegistroSP());
        }
        //Get: BuscarSP Todos los Registros de Modulo por Id con StoredProcedure
        [Route("BuscarSP/Registro/Id/{id}")]
        [HttpGet]
        public ActionResult SearchRecordById(int id)
        {
            return new JsonResult(_servicioModulo.BuscarRegistroSP()
                .Where(a => a.IdModulo == id).SingleOrDefault());
        }
        //Get: BuscarSP Todos los Modulos View por Nombre con StoredProcedure
        [Route("BuscarSP/Todos/{isAll}/Activo/{Activo}/Nombre/{nombre}")]
        [HttpGet]
        public ActionResult SearchListByName(bool isAll, bool Activo, string nombre)
        {
            nombre = StaticHelper.FirstLetterCapital(nombre);
            return new JsonResult(_servicioModulo.BuscarSP(isAll, Activo)
                .Where(a => a.Nombre.ToLower() == nombre.ToLower()).SingleOrDefault());
        }
        //Get: BuscarSP Todos los Modulos View por Id con StoredProcedure
        [Route("BuscarSP/Todos/{isAll}/Activo/{Activo}/Id/{id}")]
        [HttpGet]
        public ActionResult SearchListById(bool isAll, bool Activo, int id)
        {
            return new JsonResult(_servicioModulo.BuscarSP(isAll, Activo)
                .Where(a => a.IdModulo == id).SingleOrDefault());
        }

        //Get: Buscar Todos los Modulo que contenga el filtro
        [Route("FiltrarEF/{filtro}/{value}")]
        [HttpGet]
        public ActionResult FilterEF(string filtro="", string value="")

        {
            filtro = StaticHelper.FirstLetterCapital(filtro);
            value = StaticHelper.FirstLetterCapital(value);
            if (filtro == "Id")
            {
                var result = _servicioModulo.BuscarEF().Where(a => a.IdModulo == Convert.ToInt32(value));
                return new JsonResult(result);
            }
            else if (filtro == "Nombre")
            {
                var result = _servicioModulo.BuscarEF().Where(a => a.Nombre.Contains(value));
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
                var result = _servicioModulo.BuscarSP(isAll, Activo).Where(a => a.IdModulo == Convert.ToInt32(value));
                return new JsonResult(result);
            }
            else if (filtro == "Nombre")
            {
                var result = _servicioModulo.BuscarSP(isAll, Activo).Where(a => a.Nombre.Contains(value));
                return new JsonResult(result);
            }
            return null;
        }



        //POST: Crear un Modulo con Stored Procedure
        [Route("CrearSP")]
        [HttpPost]
        public ActionResult CreateSP([FromBody] ModuloViewModel model)
        {
            if (!_validarModulo.ExistsInactiveSP(model))
            {
                var error = _servicioModulo.CrearSP(model);
                bool inserted = false;
                if (error == null)
                {
                    inserted = true;
                }
                return new JsonResult(new ResultViewModel { success = inserted, error = error, token = null });
            }
            else if (_validarModulo.ExistsInactiveSP(model))
            {
                return new JsonResult(new ResultViewModel { success = true, error = "exists", token = null });
            }
            return null;
        }

        //POST: Modificar un Modulo con Stored Procedure
        [Route("ModificarSP")]
        [HttpPut]
        public ActionResult UpdateSP([FromBody] ModuloViewModel model)
        {
            if (!_validarModulo.ExistsInactiveSP(model))
            {
                var error = _servicioModulo.ActualizarSP(model);
                bool inserted = false;
                if (error == null)
                {
                    inserted = true;
                }
                return new JsonResult(new ResultViewModel { success = inserted, error = error, token = null });
            }
            else if (_validarModulo.ExistsInactiveSP(model))
            {
                if (model.Active)
                {
                    return new JsonResult(new ResultViewModel { success = true, error = "exists", token = null });
                }
                else
                {
                    model.Active = true;
                    return new JsonResult(new ResultViewModel { success = true, error = _servicioModulo.ActualizarSP(model), token = null });
                }
            }
            return null;
        }

        // PUT: Desactivar un Modulo con Stored Procedure
        [Route("DesactivarSP")]
        [HttpPut]
        public ActionResult InactiveSP([FromBody] ModuloViewModel model)
        {
            model.Active = false;
            var error = _servicioModulo.ActualizarSP(model);
            bool inserted = false;
            if (error == null)
            {
                inserted = true;
            }
            return new JsonResult(new ResultViewModel { success = inserted, error = error, token = null });
        }
        // DELETE: Eliminar un Modulo con Stored Procedure
        [Route("EliminarSP")]
        [HttpPost]
        public ActionResult DeleteSP([FromBody]ModuloView model)
        {
            var error = _servicioModulo.EliminarSP(model);
            bool inserted = false;
            if (error == null)
            {
                inserted = true;
            }
            return new JsonResult(new ResultViewModel { success = inserted, error = error, token = null });
        }

        //GET: BuscarEF Buscar Todos los Modulos con Entity Framework
        [Route("BuscarEF")]
        [HttpGet]
        public ActionResult ListEF()
        {
            return new JsonResult(_servicioModulo.BuscarEF().Where(a => a.Active == true));
        }
        //POST: Crear un Modulo en Entity Framework
        [Route("CrearEF")]
        [HttpPost]
        public ActionResult CreateEF([FromBody] Modulo model)
        {
            if (!_validarModulo.ExistsInactiveEF(model))
            {
                var error = _servicioModulo.CrearEF(model);
                bool inserted = false;
                if(error == null)
                {
                    inserted = true;
                }
                return new JsonResult(new ResultViewModel { success = inserted, error = error, token = null });
            }
            else if (_validarModulo.ExistsInactiveEF(model))
            {
                return new JsonResult(new ResultViewModel { success = true, error = "exists", token = null });
            }
            return null;
        }

        //POST: Modificar un Modulo en Entity Framework
        [Route("ModificarEF")]
        [HttpPut]
        public ActionResult UpdateEF([FromBody] Modulo model)
        {
            if (!_validarModulo.ExistsInactiveEF(model))
            {
                var error = _servicioModulo.ActualizarEF(model);
                bool inserted = false;
                if (error == null)
                {
                    inserted = true;
                }
                return new JsonResult(new ResultViewModel { success = inserted, error = error, token = null });
            }
            else if (_validarModulo.ExistsInactiveEF(model))
            {
                if (model.Active)
                {
                    return new JsonResult(new ResultViewModel { success = true, error = "exists", token = null });
                }
                else
                {
                    model.Active = true;
                    return new JsonResult(new ResultViewModel { success = true, error = _servicioModulo.ActualizarEF(model), token = null });
                }
            }
            return null;
        }

        // PUT: Desactivar un Modulo en EntityFramework
        [Route("DesactivarEF")]
        [HttpPut]
        public ActionResult InactiveEF([FromBody] Modulo model)
        {
            model.Active = false;
            var error = _servicioModulo.ActualizarEF(model);
            bool inserted = false;
            if (error == null)
            {
                inserted = true;
            }
            return new JsonResult(new ResultViewModel { success = inserted, error = error, token = null });
        }
        // DELETE: Eliminar un Modulo en Entity Framework
        [Route("EliminarEF")]
        [HttpPost]
        public ActionResult DeleteEF([FromBody]Modulo model)
        {
            var error = _servicioModulo.EliminarEF(model);
            bool inserted = false;
            if (error == null)
            {
                inserted = true;
            }
            return new JsonResult(new ResultViewModel { success = inserted, error = error, token = null });
        }
    }
}
