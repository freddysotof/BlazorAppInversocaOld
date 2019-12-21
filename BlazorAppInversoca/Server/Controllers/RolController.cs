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
    public class RolController : ControllerBase
    {
        private readonly ValidationRol _validarRol;
        private readonly IRol _servicioRol; // Servicio de Rol
        private RolViewModel RolViewModel = new RolViewModel();
        public RolController(IRol Rol)
        {
            _servicioRol = Rol;
            _validarRol = new ValidationRol(_servicioRol);
        }

        //Get: BuscarSP Todos los Rols con StoredProcedure
        [Route("BuscarSP/Todos/{isAll}/Activo/{Activo}")]
        [HttpGet]
        public ActionResult ListSP(bool isAll, bool Activo)
        {
            return new JsonResult(_servicioRol.BuscarSP(isAll, Activo));
        }
        //Get: BuscarSP Todos los Registros de Roels on StoredProcedure
        [Route("BuscarSP/Registro")]
        [HttpGet]
        public ActionResult SearchRecords()
        {
            return new JsonResult(_servicioRol.BuscarRegistroSP());
        }
        //Get: BuscarSP Todos los Registros de Rol por Nombre con StoredProcedure
        [Route("BuscarSP/Registro/Nombre/{nombre}")]
        [HttpGet]
        public ActionResult SearchRecordByName(string nombre)
        {
            nombre = StaticHelper.FirstLetterCapital(nombre);
            return new JsonResult(_servicioRol.BuscarRegistroSP()
                .Where(a => a.Nombre.ToLower() == nombre.ToLower()).SingleOrDefault());
        }
        //Get: BuscarSP Todos los Registros de Rol por Id con StoredProcedure
        [Route("BuscarSP/Registro/Id/{id}")]
        [HttpGet]
        public ActionResult SearchRecordById(int id)
        {
            return new JsonResult(_servicioRol.BuscarRegistroSP()
                .Where(a => a.IdRol == id).SingleOrDefault());
        }
        //Get: BuscarSP Todos los Rols View por Nombre con StoredProcedure
        [Route("BuscarSP/Todos/{isAll}/Activo/{Activo}/Nombre/{nombre}")]
        [HttpGet]
        public ActionResult SearchListByName(bool isAll, bool Activo, string nombre)
        {
            nombre = StaticHelper.FirstLetterCapital(nombre);
            return new JsonResult(_servicioRol.BuscarSP(isAll, Activo)
                .Where(a => a.Nombre.ToLower() == nombre.ToLower()).SingleOrDefault());
        }
        //Get: BuscarSP Todos los Rols View por Id con StoredProcedure
        [Route("BuscarSP/Todos/{isAll}/Activo/{Activo}/Id/{id}")]
        [HttpGet]
        public ActionResult SearchListById(bool isAll, bool Activo, int id)
        {
            return new JsonResult(_servicioRol.BuscarSP(isAll, Activo)
                .Where(a => a.IdRol == id).SingleOrDefault());
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
                var result = _servicioRol.BuscarEF().Where(a => a.IdRol == Convert.ToInt32(value));
                return new JsonResult(result);
            }
            else if (filtro == "Nombre")
            {
                var result = _servicioRol.BuscarEF().Where(a => a.Nombre.Contains(value));
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
                var result = _servicioRol.BuscarSP(isAll, Activo).Where(a => a.IdRol == Convert.ToInt32(value));
                return new JsonResult(result);
            }
            else if (filtro == "Nombre")
            {
                var result = _servicioRol.BuscarSP(isAll, Activo).Where(a => a.Nombre.Contains(value));
                return new JsonResult(result);
            }
            return null;
        }
        //POST: Crear un Rol con Stored Procedure
        [Route("CrearSP")]
        [HttpPost]
        public ActionResult CreateSP([FromBody] RolViewModel model)
        {
            if (!_validarRol.ExistsInactiveSP(model))
            {
                var error = _servicioRol.CrearSP(model);
                bool inserted = false;
                if (error == null)
                {
                    inserted = true;
                }
                return new JsonResult(new ResultViewModel { success = inserted, error = error, token = null });
            }
            else if (_validarRol.ExistsInactiveSP(model))
            {
                return new JsonResult(new ResultViewModel { success = true, error = "exists", token = null });
            }
            return null;
        }

        //POST: Modificar un Rol con Stored Procedure
        [Route("ModificarSP")]
        [HttpPut]
        public ActionResult UpdateSP([FromBody] RolViewModel model)
        {
            if (!_validarRol.ExistsInactiveSP(model))
            {
                var error = _servicioRol.ActualizarSP(model);
                bool inserted = false;
                if (error == null)
                {
                    inserted = true;
                }
                return new JsonResult(new ResultViewModel { success = inserted, error = error, token = null });
            }
            else if (_validarRol.ExistsInactiveSP(model))
            {
                if (model.Active)
                {
                    return new JsonResult(new ResultViewModel { success = true, error = "exists", token = null });
                }
                else
                {
                    model.Active = true;
                    return new JsonResult(new ResultViewModel { success = true, error = _servicioRol.ActualizarSP(model), token = null });
                }
            }
            return null;
        }

        // PUT: Desactivar un Rol con Stored Procedure
        [Route("DesactivarSP")]
        [HttpPut]
        public ActionResult InactiveSP([FromBody] RolViewModel model)
        {
            model.Active = false;
            var error = _servicioRol.ActualizarSP(model);
            bool inserted = false;
            if (error == null)
            {
                inserted = true;
            }
            return new JsonResult(new ResultViewModel { success = inserted, error = error, token = null });
        }
        // DELETE: Eliminar un Rol con Stored Procedure
        [Route("EliminarSP")]
        [HttpPost]
        public ActionResult DeleteSP([FromBody]RolView model)
        {
            var error = _servicioRol.EliminarSP(model);
            bool inserted = false;
            if (error == null)
            {
                inserted = true;
            }
            return new JsonResult(new ResultViewModel { success = inserted, error = error, token = null });
        }
        //GET: BuscarEF Buscar Todos los Rols con Entity Framework
        [Route("BuscarEF")]
        [HttpGet]
        public ActionResult ListEF()
        {
            return new JsonResult(_servicioRol.BuscarEF().Where(a => a.Active == true));
        }
        //POST: Crear un Rol en Entity Framework
        [Route("CrearEF")]
        [HttpPost]
        public ActionResult CreateEF([FromBody] Rol model)
        {
            if (!_validarRol.ExistsInactiveEF(model))
            {
                var error = _servicioRol.CrearEF(model);
                bool inserted = false;
                if (error == null)
                {
                    inserted = true;
                }
                return new JsonResult(new ResultViewModel { success = inserted, error = error, token = null });
            }
            else if (_validarRol.ExistsInactiveEF(model))
            {
                return new JsonResult(new ResultViewModel { success = true, error = "exists", token = null });
            }
            return null;
        }

        //POST: Modificar un Rol en Entity Framework
        [Route("ModificarEF")]
        [HttpPut]
        public ActionResult UpdateEF([FromBody] Rol model)
        {
            if (!_validarRol.ExistsInactiveEF(model))
            {
                var error = _servicioRol.ActualizarEF(model);
                bool inserted = false;
                if (error == null)
                {
                    inserted = true;
                }
                return new JsonResult(new ResultViewModel { success = inserted, error = error, token = null });
            }
            else if (_validarRol.ExistsInactiveEF(model))
            {
                if (model.Active)
                {
                    return new JsonResult(new ResultViewModel { success = true, error = "exists", token = null });
                }
                else
                {
                    model.Active = true;
                    return new JsonResult(new ResultViewModel { success = true, error = _servicioRol.ActualizarEF(model), token = null });
                }
            }
            return null;
        }

        // PUT: Desactivar un Rol en EntityFramework
        [Route("DesactivarEF")]
        [HttpPut]
        public ActionResult InactiveEF([FromBody] Rol model)
        {
            model.Active = false;
            var error = _servicioRol.ActualizarEF(model);
            bool inserted = false;
            if (error == null)
            {
                inserted = true;
            }
            return new JsonResult(new ResultViewModel { success = inserted, error = error, token = null });
        }
        // DELETE: Eliminar un Rol en Entity Framework
        [Route("EliminarEF")]
        [HttpPost]
        public ActionResult DeleteEF([FromBody]Rol model)
        {
            var error = _servicioRol.EliminarEF(model);
            bool inserted = false;
            if (error == null)
            {
                inserted = true;
            }
            return new JsonResult(new ResultViewModel { success = inserted, error = error, token = null });
        }
    }
}
