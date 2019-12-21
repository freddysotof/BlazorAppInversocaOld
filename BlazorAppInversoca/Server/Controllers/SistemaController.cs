using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorAppInversoca.DataService.Interfaces;
using BlazorAppInversoca.Server.Helpers;
using BlazorAppInversoca.Shared.EFModels;
using BlazorAppInversoca.Shared.Helpers;
using BlazorAppInversoca.Shared.Token___Result_Models;
using BlazorAppInversoca.Shared.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace BlazorAppInversoca.Server.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class PropiedadController : ControllerBase
    {
        private readonly ValidationPropiedad _validarPropiedad;
        private readonly IPropiedad _servicioPropiedad; // Servicio de Propiedad
        private PropiedadViewModel PropiedadViewModel = new PropiedadViewModel();
        public PropiedadController(IPropiedad Propiedad)
        {
            _servicioPropiedad = Propiedad;
            _validarPropiedad = new ValidationPropiedad(_servicioPropiedad);
        }

        //Get: BuscarSP Todos los Propiedades con StoredProcedure
        [Route("BuscarSP/Todos/{isAll}/Activo/{Activo}")]
        [HttpGet]
        public ActionResult ListSP(bool isAll, bool Activo)
        {
            return new JsonResult(_servicioPropiedad.BuscarSP(isAll, Activo));
        }
        //Get: BuscarSP Todos los Registros de Propiedad por Nombre con StoredProcedure
        [Route("BuscarSP/Registro/Nombre/{nombre}")]
        [HttpGet]
        public ActionResult SearchRecordByName(string nombre)
        {
            nombre = StaticHelper.FirstLetterCapital(nombre);
            return new JsonResult(_servicioPropiedad.BuscarRegistroSP()
                .Where(a => a.Nombre.ToLower() == nombre.ToLower()).SingleOrDefault());
        }
        //Get: BuscarSP Todos los Registros de Propiedades on StoredProcedure
        [Route("BuscarSP/Registro")]
        [HttpGet]
        public ActionResult SearchRecords()
        {
            return new JsonResult(_servicioPropiedad.BuscarRegistroSP());
        }
        //Get: BuscarSP Todos los Registros de Propiedad por Id con StoredProcedure
        [Route("BuscarSP/Registro/Id/{id}")]
        [HttpGet]
        public ActionResult SearchRecordById(int id)
        {
            return new JsonResult(_servicioPropiedad.BuscarRegistroSP()
                .Where(a => a.IdPropiedad == id).SingleOrDefault());
        }
        //Get: BuscarSP Todos los Propiedades View por Nombre con StoredProcedure
        [Route("BuscarSP/Todos/{isAll}/Activo/{Activo}/Nombre/{nombre}")]
        [HttpGet]
        public ActionResult SearchListByName(bool isAll, bool Activo, string nombre)
        {
            nombre = StaticHelper.FirstLetterCapital(nombre);
            return new JsonResult(_servicioPropiedad.BuscarSP(isAll, Activo)
                .Where(a => a.Nombre.ToLower() == nombre.ToLower()).SingleOrDefault());
        }
        //Get: BuscarSP Todos los Propiedades View por Id con StoredProcedure
        [Route("BuscarSP/Todos/{isAll}/Activo/{Activo}/Id/{id}")]
        [HttpGet]
        public ActionResult SearchListById(bool isAll, bool Activo, int id)
        {
            return new JsonResult(_servicioPropiedad.BuscarSP(isAll, Activo)
                .Where(a => a.IdPropiedad == id).SingleOrDefault());
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
                var result = _servicioPropiedad.BuscarEF().Where(a => a.IdPropiedad == Convert.ToInt32(value));
                return new JsonResult(result);
            }
            else if (filtro == "Nombre")
            {
                var result = _servicioPropiedad.BuscarEF().Where(a => a.Nombre.Contains(value));
                return new JsonResult(result);
            }
            else if(filtro == "Compañía")
            {
                //var result = _servicioPropiedad.BuscarEF().Where(a => a..Contains(value));
                //return new JsonResult(result);
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
                var result = _servicioPropiedad.BuscarSP(isAll, Activo).Where(a => a.IdPropiedad == Convert.ToInt32(value));
                return new JsonResult(result);
            }
            else if (filtro == "Nombre")
            {
                var result = _servicioPropiedad.BuscarSP(isAll, Activo).Where(a => a.Nombre.Contains(value));
                return new JsonResult(result);
            }
            else if (filtro == "Compañía")
            {
                //var result = _servicioPropiedad.BuscarEF().Where(a => a.C.Contains(value));
                //return new JsonResult(result);
            }
            return null;
        }

        //POST: Crear un Propiedad con Stored Procedure
        [Route("CrearSP")]
        [HttpPost]
        public ActionResult CreateSP([FromBody] PropiedadViewModel model)
        {
            if (!_validarPropiedad.ExistsInactiveSP(model))
            {
                var error = _servicioPropiedad.CrearSP(model);
                bool inserted = false;
                if (error == null)
                {
                    inserted = true;
                }
                return new JsonResult(new ResultViewModel { success = inserted, error = error, token = null });
            }
            else if (_validarPropiedad.ExistsInactiveSP(model))
            {
                return new JsonResult(new ResultViewModel { success = true, error = "exists", token = null });
            }
            return null;
        }

        //POST: Modificar un Propiedad con Stored Procedure
        [Route("ModificarSP")]
        [HttpPut]
        public ActionResult UpdateSP([FromBody] PropiedadViewModel model)
        {
            if (!_validarPropiedad.ExistsInactiveSP(model))
            {
                var error = _servicioPropiedad.ActualizarSP(model);
                bool inserted = false;
                if (error == null)
                {
                    inserted = true;
                }
                return new JsonResult(new ResultViewModel { success = inserted, error = error, token = null });
            }
            else if (_validarPropiedad.ExistsInactiveSP(model))
            {
                if (model.Active)
                {
                    return new JsonResult(new ResultViewModel { success = true, error = "exists", token = null });
                }
                else
                {
                    model.Active = true;
                    return new JsonResult(new ResultViewModel { success = true, error = _servicioPropiedad.ActualizarSP(model), token = null });
                }
            }
            return null;
        }

        // PUT: Desactivar un Propiedad con Stored Procedure
        [Route("DesactivarSP")]
        [HttpPut]
        public ActionResult InactiveSP([FromBody] PropiedadViewModel model)
        {
            model.Active = false;
            var error = _servicioPropiedad.ActualizarSP(model);
            bool inserted = false;
            if (error == null)
            {
                inserted = true;
            }
            return new JsonResult(new ResultViewModel { success = inserted, error = error, token = null });
        }
        // DELETE: Eliminar un Propiedad con Stored Procedure
        [Route("EliminarSP")]
        [HttpPost]
        public ActionResult DeleteSP([FromBody]PropiedadView model)
        {
            var error = _servicioPropiedad.EliminarSP(model);
            bool inserted = false;
            if (error == null)
            {
                inserted = true;
            }
            return new JsonResult(new ResultViewModel { success = inserted, error = error, token = null });
        }
        //GET: BuscarEF Buscar Todos los Propiedades con Entity Framework
        [Route("BuscarEF")]
        [HttpGet]
        public ActionResult ListEF()
        {
            return new JsonResult(_servicioPropiedad.BuscarEF().Where(a => a.Active == true));
        }
        //POST: Crear un Propiedad en Entity Framework
        [Route("CrearEF")]
        [HttpPost]
        public ActionResult CreateEF([FromBody] Propiedad model)
        {
            if (!_validarPropiedad.ExistsInactiveEF(model))
            {
                var error = _servicioPropiedad.CrearEF(model);
                bool inserted = false;
                if (error == null)
                {
                    inserted = true;
                }
                return new JsonResult(new ResultViewModel { success = inserted, error = error, token = null });
            }
            else if (_validarPropiedad.ExistsInactiveEF(model))
            {
                return new JsonResult(new ResultViewModel { success = true, error = "exists", token = null });
            }
            return null;
        }

        //POST: Modificar un Propiedad en Entity Framework
        [Route("ModificarEF")]
        [HttpPut]
        public ActionResult UpdateEF([FromBody] Propiedad model)
        {
            if (!_validarPropiedad.ExistsInactiveEF(model))
            {
                var error = _servicioPropiedad.ActualizarEF(model);
                bool inserted = false;
                if (error == null)
                {
                    inserted = true;
                }
                return new JsonResult(new ResultViewModel { success = inserted, error = error, token = null });
            }
            else if (_validarPropiedad.ExistsInactiveEF(model))
            {
                if (model.Active)
                {
                    return new JsonResult(new ResultViewModel { success = true, error = "exists", token = null });
                }
                else
                {
                    model.Active = true;
                    return new JsonResult(new ResultViewModel { success = true, error = _servicioPropiedad.ActualizarEF(model), token = null });
                }
            }
            return null;
        }

        // PUT: Desactivar un Propiedad en EntityFramework
        [Route("DesactivarEF")]
        [HttpPut]
        public ActionResult InactiveEF([FromBody] Propiedad model)
        {
            model.Active = false;
            var error = _servicioPropiedad.ActualizarEF(model);
            bool inserted = false;
            if (error == null)
            {
                inserted = true;
            }
            return new JsonResult(new ResultViewModel { success = inserted, error = error, token = null });
        }
        // DELETE: Eliminar un Propiedad en Entity Framework
        [Route("EliminarEF")]
        [HttpPost]
        public ActionResult DeleteEF([FromBody]Propiedad model)
        {
            var error = _servicioPropiedad.EliminarEF(model);
            bool inserted = false;
            if (error == null)
            {
                inserted = true;
            }
            return new JsonResult(new ResultViewModel { success = inserted, error = error, token = null });
        }
    }
}
