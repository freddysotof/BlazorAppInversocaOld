
using Microsoft.EntityFrameworkCore;
using BlazorAppInversoca.DataService.DBContent;
using BlazorAppInversoca.DataService.Interfaces;
using BlazorAppInversoca.Shared.EFModels;
using BlazorAppInversoca.Shared.Helpers;
using BlazorAppInversoca.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace BlazorAppInversoca.DataService.Repositorio
{
    public class OperacionRepositorio : IOperacion
    {
        private readonly BlazorAppInversocaContent _BlazorAppInversocaContent;
        public OperacionRepositorio(BlazorAppInversocaContent content)
        {
            this._BlazorAppInversocaContent = content;
        }
        private List<SqlParameter> getParameters(OperacionViewModel viewmodel)
        {
            viewmodel.Nombre = StaticHelper.FirstLetterCapital(viewmodel.Nombre);
            List<SqlParameter> model = new List<SqlParameter>()
            {new SqlParameter() {ParameterName = "@IdOperacion", SqlDbType=SqlDbType.Int, Value= viewmodel.IdOperacion},
             new SqlParameter() {ParameterName = "@Nombre",SqlDbType= SqlDbType.VarChar, Value= viewmodel.Nombre.Trim()},
             new SqlParameter() {ParameterName = "@Descripcion",SqlDbType= SqlDbType.Text, Value= viewmodel.Descripcion.Trim()},
             new SqlParameter() {ParameterName = "@IdModulo",SqlDbType= SqlDbType.Int, Value= viewmodel.IdModulo},
             new SqlParameter() {ParameterName = "@Active",SqlDbType= SqlDbType.Bit, Value= viewmodel.Active}
            };
            return model;
        }
        public List<Operacion> BuscarEF()
        {
            return this._BlazorAppInversocaContent.Operacion.Include(c => c.RolesOperaciones).Include(m=>m.Modulo).AsNoTracking()
                 .ToList();
        }
        public List<OperacionViewModel> BuscarRegistroSP()
        {
            return _BlazorAppInversocaContent.OperacionViewModel.FromSqlRaw("exec dbo.operaciones_SelectRecord").ToList();
        }
        public List<OperacionView> BuscarSP(bool isAll, bool isActive)
        {
            var todos = new SqlParameter("@IsAll", isAll);
            var active = new SqlParameter("@Activo", isActive);
            return this._BlazorAppInversocaContent.OperacionView.FromSqlRaw("exec dbo.operaciones_Select @IsAll,@Activo", todos, active).ToList();
        }
        public string CrearEF(Operacion model)
        {
            string str = (string)null;
            try
            {
                Operacion operacion = new Operacion
                {
                    Active = model.Active,
                    IdModulo = model.IdModulo,
                    Descripcion = model.Descripcion,
                    Nombre = model.Nombre
                };
                this._BlazorAppInversocaContent.Operacion.Add(operacion);
                this._BlazorAppInversocaContent.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                var error = Convert.ToString(e.GetBaseException().Message);
                if (error.Contains("idx_Operacion_Nombre"))
                {
                    str = "La Operacion ya Existe";
                }
                else if (error.Contains("FOREIGN KEY constraint") && error.Contains("IdPropiedad"))
                {
                    str = "El Modulo no Existe";
                }
                else { str = e.GetBaseException().Message; }
            }
            return str;
        }

        public string CrearSP(OperacionViewModel model)
        {
            string str = (string)null;
            try
            {
                this._BlazorAppInversocaContent.Database.ExecuteSqlRaw("dbo.operaciones_insert " +
                    "@IdOperacion,@Nombre,@IdModulo,@Active ", getParameters(model));
                this._BlazorAppInversocaContent.SaveChanges();
            }
            catch (SqlException e)
            {
                var error = Convert.ToString(e.GetBaseException().Message);
                if (error.Contains("idx_Operacion_Nombre"))
                {
                    str = "La Operacion ya Existe";
                }
                else if (error.Contains("FOREIGN KEY constraint") && error.Contains("IdPropiedad"))
                {
                    str = "El Modulo no Existe";
                }
                else { str = e.GetBaseException().Message; }
            }
            return str;
        }
        public string ActualizarEF(Operacion model)
        {
            string str = (string)null;
            try
            {
                this._BlazorAppInversocaContent.Entry<Operacion>(model).State = EntityState.Modified;
                this._BlazorAppInversocaContent.Operacion.Update(model);
                this._BlazorAppInversocaContent.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                var error = Convert.ToString(e.GetBaseException().Message);
                if (error.Contains("idx_Operacion_Nombre"))
                {
                    str = "La Operacion ya Existe";
                }
                else if (error.Contains("FOREIGN KEY constraint") && error.Contains("IdPropiedad"))
                {
                    str = "El Modulo no Existe";
                }
                else { str = e.GetBaseException().Message; }
            }
            return str;
        }

        public string ActualizarSP(OperacionViewModel model)
        {
            string str = (string)null;
            try
            {
                this._BlazorAppInversocaContent.Database.ExecuteSqlRaw("dbo.operaciones_update " +
                     "@IdOperacion,@Nombre,@IdModulo,@Active ", getParameters(model));
                this._BlazorAppInversocaContent.SaveChanges();
            }
            catch (SqlException e)
            {
                var error = Convert.ToString(e.GetBaseException().Message);
                if (error.Contains("idx_Operacion_Nombre"))
                {
                    str = "La Operacion ya Existe";
                }
                else if (error.Contains("FOREIGN KEY constraint") && error.Contains("IdPropiedad"))
                {
                    str = "El Modulo no Existe";
                }
                else { str = e.GetBaseException().Message; }
            }
            return str;
        }
        public string EliminarEF(Operacion model)
        {
            var modelReturn = this.BuscarEF().Where(a => a.IdOperacion == model.IdOperacion).SingleOrDefault();

            string str = (string)null;
            try
            {
                this._BlazorAppInversocaContent.Remove(modelReturn);
                this._BlazorAppInversocaContent.SaveChanges();
            }
            catch (ArgumentException ex)
            {
                str = "La Operacion no fue encontrada, es posible que ya haya sido eliminada anteriormente";
            }
            catch (DbUpdateException e)
            {
                var error = Convert.ToString(e.GetBaseException().Message);
                if (error.Contains("DELETE") && error.Contains("REFERENCE constraint"))
                {
                    str = "Debe Eliminar los roles que tienen permiso para realizar esta Operacion";
                }
                else { str = e.GetBaseException().Message; }
            }
            return str;
        }
        public string EliminarSP(OperacionView model)
        {
            string str = (string)null;
            try
            {
                this._BlazorAppInversocaContent.Database.ExecuteSqlRaw("dbo.operaciones_delete " +
                    "{0}", model.IdOperacion);
                this._BlazorAppInversocaContent.SaveChanges();
            }
            catch (ArgumentException ex)
            {
                str = "La Operacion no fue encontrada, es posible que ya haya sido eliminada anteriormente";
            }
            catch (SqlException e)
            {
                var error = Convert.ToString(e.GetBaseException().Message);
                if (error.Contains("DELETE") && error.Contains("REFERENCE constraint"))
                {
                    str = "Debe Eliminar los roles que tienen permiso para realizar esta Operacion";
                }
                else { str = e.GetBaseException().Message; }
            }
            return str;
        }
    }
}
