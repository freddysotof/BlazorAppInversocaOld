using Microsoft.EntityFrameworkCore;
using BlazorAppInversoca.DataService.DBContent;
using BlazorAppInversoca.DataService.Interfaces;
using BlazorAppInversoca.Shared.EFModels;
using BlazorAppInversoca.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace BlazorAppInversoca.DataService.Repositorio
{
    public class RolOperacionRepositorio : IRolOperacion
    {
        private readonly BlazorAppInversocaContent _BlazorAppInversocaContent;
        public RolOperacionRepositorio(BlazorAppInversocaContent content)
        {
            this._BlazorAppInversocaContent = content;
        }
        private List<SqlParameter> getParameters(RolOperacionViewModel viewmodel)
        {
            
            List<SqlParameter> model = new List<SqlParameter>()
            {new SqlParameter() {ParameterName = "@IdRol", SqlDbType=SqlDbType.Int, Value= viewmodel.IdRol},
             new SqlParameter() {ParameterName = "@IdOperacion",SqlDbType= SqlDbType.Int, Value= viewmodel.IdOperacion},
             new SqlParameter() {ParameterName = "@Descripcion",SqlDbType= SqlDbType.VarChar, Value= viewmodel.Descripcion.Trim()}
            };
            return model;
        }
        public List<RolOperacion> BuscarEF()
        {
            return this._BlazorAppInversocaContent.RolOperacion.Include(c => c.Operacion).Include(r=>r.Rol).AsNoTracking()
                 .ToList();
        }
        public List<RolOperacionViewModel> BuscarRegistroSP()
        {
            var spRolOp = _BlazorAppInversocaContent.RolOperacionViewModel.FromSqlRaw("exec dbo.roles_operaciones_SelectRecord").ToList();

            if (spRolOp != null)
            {
                foreach (var registro in spRolOp)
                {
                    var spRol = _BlazorAppInversocaContent.RolView.FromSqlRaw("exec dbo.roles_Select {0},{0}", true, true)
                        .ToList().Where(r => r.IdRol == registro.IdRol).SingleOrDefault();
                    var spOperacion = _BlazorAppInversocaContent.OperacionView.FromSqlRaw("exec dbo.operaciones_Select {0},{0}", true, true)
                        .ToList().Where(r => r.IdOperacion == registro.IdOperacion).SingleOrDefault();
                    if (spRol != null) { registro.Rol = spRol; } else { registro.Rol = new RolView(); }
                    if (spOperacion != null) { registro.Operacion = spOperacion; } else { registro.Operacion = new OperacionView(); }
                }
                return spRolOp;
            }
            else
            {
                return null;
            }

        }
        public List<RolOperacionView> BuscarSP(int IdRol=0,int IdOperacion=0)
        {
            var rol = new SqlParameter("@IdRol", IdRol);
            var operacion = new SqlParameter("@IdOperacion", IdOperacion);
            return this._BlazorAppInversocaContent.RolOperacionView.FromSqlRaw("exec dbo.roles_operaciones_Select @IdRol,@IdOperacion", rol, operacion).ToList();
        }
        public string CrearEF(RolOperacion model)
        {
            string str = (string)null;
            try
            {
                RolOperacion relacion = new RolOperacion
                {
                    IdOperacion = model.IdOperacion,
                    Descripcion = model.Descripcion,
                    IdRol = model.IdRol
                };
                this._BlazorAppInversocaContent.RolOperacion.Add(relacion);
                this._BlazorAppInversocaContent.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                var error = Convert.ToString(e.GetBaseException().Message);
                if(error.Contains("PRIMARY KEY constraint"))
                {
                    str = "Ya existe una relacion entre el Rol " + model.Rol.Nombre +
                        " y la Operacion " + model.Operacion.Nombre;
                }
                else if (error.Contains("FOREIGN KEY constraint") && error.Contains("IdOperacion"))
                {
                    str = "La Operacion no Existe";
                }
                else if (error.Contains("FOREIGN KEY constraint") && error.Contains("IdRol"))
                {
                    str = "El Rol no existe";
                }

                else {str = e.GetBaseException().Message;}
            }
            return str;
        }
        public string CrearSP(RolOperacionViewModel model)
        {
            string str = (string)null;
            try
            {
                this._BlazorAppInversocaContent.Database.ExecuteSqlRaw("dbo.roles_operaciones_insert " +
                    "@IdRol,@IdOperacion,@Descripcion ", getParameters(model));
                this._BlazorAppInversocaContent.SaveChanges();
            }
            catch (SqlException e)
            {
                var error = Convert.ToString(e.GetBaseException().Message);
                if (error.Contains("PRIMARY KEY constraint"))
                {
                    str = "Ya existe una relacion entre el Rol " + model.IdRol
                        + " y la Operacion " + model.IdOperacion
                        ;
                }
                else if (error.Contains("FOREIGN KEY constraint") && error.Contains("IdOperacion"))
                {
                    str = "La Operacion no Existe";
                }
                else if (error.Contains("FOREIGN KEY constraint") && error.Contains("IdRol"))
                {
                    str = "El Rol no existe";
                }
                else { str = e.GetBaseException().Message; }
            }
            return str;
        }
        public string ActualizarEF(RolOperacion model)
        {
            string str = (string)null;
            try
            {
                this._BlazorAppInversocaContent.Entry<RolOperacion>(model).State = EntityState.Modified;
                this._BlazorAppInversocaContent.RolOperacion.Update(model);
                this._BlazorAppInversocaContent.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                var error = Convert.ToString(e.GetBaseException().Message);
                if (error.Contains("PRIMARY KEY constraint"))
                {
                    str = "Ya existe una relacion entre el Rol " + model.IdRol +
                        " y la Operacion " + model.IdOperacion;
                }
                else if (error.Contains("FOREIGN KEY constraint") && error.Contains("IdOperacion"))
                {
                    str = "La Operacion no Existe";
                }
                else if (error.Contains("FOREIGN KEY constraint") && error.Contains("IdRol"))
                {
                    str = "El Rol no existe";
                }
                else { str = e.GetBaseException().Message; }
            }
            return str;
        }
        public string ActualizarSP(RolOperacionViewModel model)
        {
            string str = (string)null;
            try
            {
                this._BlazorAppInversocaContent.Database.ExecuteSqlRaw("dbo.roles_operaciones_update " +
                      "@IdRol,@IdOperacion,@Descripcion ", getParameters(model));
                this._BlazorAppInversocaContent.SaveChanges();
            }
            catch (SqlException e)
            {
                var error = Convert.ToString(e.GetBaseException().Message);
                if (error.Contains("PRIMARY KEY constraint"))
                {
                    str = "Ya existe una relacion entre el Rol " + model.IdRol +
                     " y la Operacion " + model.IdOperacion;
                }
                else if (error.Contains("FOREIGN KEY constraint") && error.Contains("IdOperacion"))
                {
                    str = "La Operacion no Existe";
                }
                else if (error.Contains("FOREIGN KEY constraint") && error.Contains("IdRol"))
                {
                    str = "El Rol no existe";
                }
                else { str = e.GetBaseException().Message; }
            }
            return str;
        }
        public string EliminarEF(RolOperacion model)
        {
            var modelReturn = this.BuscarEF().Where(a => a.IdOperacion == model.IdOperacion && 
            a.IdRol == model.IdRol).SingleOrDefault();

            string str = (string)null;
            try
            {
                this._BlazorAppInversocaContent.Remove(modelReturn);
                this._BlazorAppInversocaContent.SaveChanges();
            }
            catch (ArgumentException ex)
            {
                str = "La Relacion entre Rol y Operacion no fue encontrada, es posible que ya haya sido eliminada anteriormente";
            }
        
            catch (DbUpdateException e)
            {
                var error = Convert.ToString(e.GetBaseException().Message);
                str = e.GetBaseException().Message;
            }
            return str;
        }
        public string EliminarSP(RolOperacionView model)
        {
            var rol = new SqlParameter("@IdRol", model.IdRol);
            var operacion = new SqlParameter("@IdOperacion", model.IdOperacion);
            string str = (string)null;
            try
            {
                this._BlazorAppInversocaContent.Database.ExecuteSqlRaw("dbo.roles_operaciones_delete @IdRol,@IdOperacion", rol,operacion);
                this._BlazorAppInversocaContent.SaveChanges();
            }
            catch (ArgumentException ex)
            {
                str = "La Relacion entre Rol y Operacion no fue encontrada, es posible que ya haya sido eliminada anteriormente";
            }
            catch (SqlException e)
            {
                var error = Convert.ToString(e.GetBaseException().Message);
                str = e.GetBaseException().Message;
            }
            return str;
        }
    }
}
