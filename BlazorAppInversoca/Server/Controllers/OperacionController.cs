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
    public class OperacionController : ControllerBase
    {
        private readonly ValidationOperacion _validarOperacion;
        private readonly IOperacion _servicioOperacion; // Servicio de Operacion
        private OperacionViewModel OperacionViewModel = new OperacionViewModel();
        public OperacionController(IOperacion Operacion)
        {
            _servicioOperacion = Operacion;
            _validarOperacion = new ValidationOperacion(_servicioOperacion);
        }

        //Get: BuscarSP Todos los Operacions con StoredProcedure
        [Route("BuscarSP/Todos/{isAll}/Activo/{Activo}")]
        [HttpGet]
        public ActionResult ListSP(bool isAll, bool Activo)
        {
            return new JsonResult(_servicioOperacion.BuscarSP(isAll, Activo));
        }
        //Get: BuscarSP Todos los Registros de Operacion on StoredProcedure
        [Route("BuscarSP/Registro")]
        [HttpGet]
        public ActionResult SearchRecords()
        {
            return new JsonResult(_servicioOperacion.BuscarRegistroSP());
        }
        //Get: BuscarSP Todos los Registros de Operacion por Nombre con StoredProcedure
        [Route("BuscarSP/Registro/Nombre/{nombre}")]
        [HttpGet]
        public ActionResult SearchRecordByName(string nombre)
        {
            nombre = StaticHelper.FirstLetterCapital(nombre);
            return new JsonResult(_servicioOperacion.BuscarRegistroSP()
                .Where(a => a.Nombre.ToLower() == nombre.ToLower()).SingleOrDefault());
        }
        //Get: BuscarSP Todos los Registros de Operacion por Id con StoredProcedure
        [Route("BuscarSP/Registro/Id/{id}")]
        [HttpGet]
        public ActionResult SearchRecordById(int id)
        {
            return new JsonResult(_servicioOperacion.BuscarRegistroSP()
                .Where(a => a.IdOperacion == id).SingleOrDefault());
        }
        //Get: BuscarSP Todos los Operacions View por Nombre con StoredProcedure
        [Route("BuscarSP/Todos/{isAll}/Activo/{Activo}/Nombre/{nombre}")]
        [HttpGet]
        public ActionResult SearchListByName(bool isAll, bool Activo, string nombre)
        {
            nombre = StaticHelper.FirstLetterCapital(nombre);
            return new JsonResult(_servicioOperacion.BuscarSP(isAll, Activo)
                .Where(a => a.Nombre.ToLower() == nombre.ToLower()).SingleOrDefault());
        }
        //Get: BuscarSP Todos los Operacions View por Id con StoredProcedure
        [Route("BuscarSP/Todos/{isAll}/Activo/{Activo}/Id/{id}")]
        [HttpGet]
        public ActionResult SearchListById(bool isAll, bool Activo, int id)
        {
            return new JsonResult(_servicioOperacion.BuscarSP(isAll, Activo)
                .Where(a => a.IdOperacion == id).SingleOrDefault());
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
                var result = _servicioOperacion.BuscarEF().Where(a => a.IdOperacion == Convert.ToInt32(value));
                return new JsonResult(result);
            }
            else if (filtro == "Nombre")
            {
                var result = _servicioOperacion.BuscarEF().Where(a => a.Nombre.Contains(value));
                return new JsonResult(result);
            }
            else if (filtro == "Modulo")
            {
                var result = _servicioOperacion.BuscarEF().Where(a => a.Modulo.Nombre.Contains(value));
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
                var result = _servicioOperacion.BuscarSP(isAll, Activo).Where(a => a.IdOperacion == Convert.ToInt32(value));
                return new JsonResult(result);
            }
            else if (filtro == "Nombre")
            {
                var result = _servicioOperacion.BuscarSP(isAll, Activo).Where(a => a.Nombre.Contains(value));
                return new JsonResult(result);
            }
            else if (filtro == "Modulo")
            {
                var result = _servicioOperacion.BuscarSP(isAll, Activo).Where(a => a.Modulo.Contains(value));
                return new JsonResult(result);
            }
            return null;
        }
        //POST: Crear un Operacion con Stored Procedure
        [Route("CrearSP")]
        [HttpPost]
        public ActionResult CreateSP([FromBody] OperacionViewModel model)
        {
            if (!_validarOperacion.ExistsInactiveSP(model))
            {
                var error = _servicioOperacion.CrearSP(model);
                bool inserted = false;
                if (error == null)
                {
                    inserted = true;
                }
                return new JsonResult(new ResultViewModel { success = inserted, error = error, token = null });
            }
            else if (_validarOperacion.ExistsInactiveSP(model))
            {
                return new JsonResult(new ResultViewModel { success = true, error = "exists", token = null });
            }
            return null;
        }

        //POST: Modificar un Operacion con Stored Procedure
        [Route("ModificarSP")]
        [HttpPut]
        public ActionResult UpdateSP([FromBody] OperacionViewModel model)
        {
            if (!_validarOperacion.ExistsInactiveSP(model))
            {
                var error = _servicioOperacion.ActualizarSP(model);
                bool inserted = false;
                if (error == null)
                {
                    inserted = true;
                }
                return new JsonResult(new ResultViewModel { success = inserted, error = error, token = null });
            }
            else if (_validarOperacion.ExistsInactiveSP(model))
            {
                if (model.Active)
                {
                    return new JsonResult(new ResultViewModel { success = true, error = "exists", token = null });
                }
                else
                {
                    model.Active = true;
                    return new JsonResult(new ResultViewModel { success = true, error = _servicioOperacion.ActualizarSP(model), token = null });
                }
            }
            return null;
        }

        // PUT: Desactivar un Operacion con Stored Procedure
        [Route("DesactivarSP")]
        [HttpPut]
        public ActionResult InactiveSP([FromBody] OperacionViewModel model)
        {
            model.Active = false;
            var error = _servicioOperacion.ActualizarSP(model);
            bool inserted = false;
            if (error == null)
            {
                inserted = true;
            }
            return new JsonResult(new ResultViewModel { success = inserted, error = error, token = null });
        }
        // DELETE: Eliminar un Operacion con Stored Procedure
        [Route("EliminarSP")]
        [HttpPost]
        public ActionResult DeleteSP([FromBody]OperacionView model)
        {
            var error = _servicioOperacion.EliminarSP(model);
            bool inserted = false;
            if (error == null)
            {
                inserted = true;
            }
            return new JsonResult(new ResultViewModel { success = inserted, error = error, token = null });
        }
        //GET: BuscarEF Buscar Todos los Operacions con Entity Framework
        [Route("BuscarEF")]
        [HttpGet]
        public ActionResult ListEF()
        {
            return new JsonResult(_servicioOperacion.BuscarEF().Where(a => a.Active == true));
        }
        //POST: Crear un Operacion en Entity Framework
        [Route("CrearEF")]
        [HttpPost]
        public ActionResult CreateEF([FromBody] Operacion model)
        {
            if (!_validarOperacion.ExistsInactiveEF(model))
            {
                var error = _servicioOperacion.CrearEF(model);
                bool inserted = false;
                if (error == null)
                {
                    inserted = true;
                }
                return new JsonResult(new ResultViewModel { success = inserted, error = error, token = null });
            }
            else if (_validarOperacion.ExistsInactiveEF(model))
            {
                return new JsonResult(new ResultViewModel { success = true, error = "exists", token = null });
            }
            return null;
        }

        //POST: Modificar un Operacion en Entity Framework
        [Route("ModificarEF")]
        [HttpPut]
        public ActionResult UpdateEF([FromBody] Operacion model)
        {
            if (!_validarOperacion.ExistsInactiveEF(model))
            {
                var error = _servicioOperacion.ActualizarEF(model);
                bool inserted = false;
                if (error == null)
                {
                    inserted = true;
                }
                return new JsonResult(new ResultViewModel { success = inserted, error = error, token = null });
            }
            else if (_validarOperacion.ExistsInactiveEF(model))
            {
                if (model.Active)
                {
                    return new JsonResult(new ResultViewModel { success = true, error = "exists", token = null });
                }
                else
                {
                    model.Active = true;
                    return new JsonResult(new ResultViewModel { success = true, error = _servicioOperacion.ActualizarEF(model), token = null });
                }
            }
            return null;
        }

        // PUT: Desactivar un Operacion en EntityFramework
        [Route("DesactivarEF")]
        [HttpPut]
        public ActionResult InactiveEF([FromBody] Operacion model)
        {
            model.Active = false;
            var error = _servicioOperacion.ActualizarEF(model);
            bool inserted = false;
            if (error == null)
            {
                inserted = true;
            }
            return new JsonResult(new ResultViewModel { success = inserted, error = error, token = null });
        }
        // DELETE: Eliminar un Operacion en Entity Framework
        [Route("EliminarEF")]
        [HttpPost]
        public ActionResult DeleteEF([FromBody]Operacion model)
        {
            var error = _servicioOperacion.EliminarEF(model);
            bool inserted = false;
            if (error == null)
            {
                inserted = true;
            }
            return new JsonResult(new ResultViewModel { success = inserted, error = error, token = null });
        }
    }
}
