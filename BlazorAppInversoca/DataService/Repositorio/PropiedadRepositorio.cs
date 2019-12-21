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
    public class PropiedadRepositorio : IPropiedad
    {
        private readonly BlazorAppInversocaContent _BlazorAppInversocaContent;
        public PropiedadRepositorio(BlazorAppInversocaContent content)
        {
            this._BlazorAppInversocaContent = content;
        }
        private List<SqlParameter> getParameters(PropiedadViewModel viewmodel)
        {
            viewmodel.Nombre = StaticHelper.FirstLetterCapital(viewmodel.Nombre);
            List<SqlParameter> model = new List<SqlParameter>()
            {new SqlParameter() {ParameterName = "@IdPropiedad", SqlDbType=SqlDbType.Int, Value= viewmodel.IdPropiedad},
             new SqlParameter() {ParameterName = "@Nombre",SqlDbType= SqlDbType.VarChar, Value= viewmodel.Nombre.Trim()},
             new SqlParameter() {ParameterName = "@Descripcion",SqlDbType= SqlDbType.Text, Value= viewmodel.Descripcion.Trim()},
             new SqlParameter() {ParameterName = "@Active",SqlDbType= SqlDbType.Bit, Value= viewmodel.Active}
            };
            return model;
        }
        public List<Propiedad> BuscarEF()
        {
            return this._BlazorAppInversocaContent.Propiedad.ToList();
        }
        public List<PropiedadViewModel> BuscarRegistroSP()
        {
            return _BlazorAppInversocaContent.PropiedadViewModel.FromSqlRaw("exec dbo.Propiedades_SelectRecord").ToList();
        }
        public List<PropiedadView> BuscarSP(bool isAll, bool isActive)
        {
            var todos = new SqlParameter("@IsAll", isAll);
            var active = new SqlParameter("@Activo", isActive);
            return this._BlazorAppInversocaContent.PropiedadView.FromSqlRaw("exec dbo.Propiedades_Select @IsAll,@Activo", todos, active).ToList();
        }
        public string CrearEF(Propiedad model)
        {
            string str = (string)null;
            try
            {
                Propiedad Propiedad = new Propiedad
                {
                    Active = model.Active,
                    Nombre = model.Nombre,
                    Descripcion = model.Descripcion
                };
                this._BlazorAppInversocaContent.Propiedad.Add(Propiedad);
                this._BlazorAppInversocaContent.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                var error = Convert.ToString(e.GetBaseException().Message);
                if (error.Contains("idx_Propiedad_Nombre"))
                {
                    str = "El Propiedad ya Existe";
                }
                else { str = e.GetBaseException().Message; }
            }
            return str;
        }

        public string CrearSP(PropiedadViewModel model)
        {
            string str = (string)null;
            try
            {
                this._BlazorAppInversocaContent.Database.ExecuteSqlRaw("dbo.Propiedades_insert " +
                    "@IdPropiedad,@Nombre,@Descripcion,@Active ", getParameters(model));
                this._BlazorAppInversocaContent.SaveChanges();
            }
            catch (SqlException e)
            {
                var error = Convert.ToString(e.GetBaseException().Message);
                if (error.Contains("idx_Propiedad_Nombre"))
                {
                    str = "El Propiedad ya Existe";
                }
                else { str = e.GetBaseException().Message; }
            }
            return str;
        }
        public string ActualizarEF(Propiedad model)
        {
            string str = (string)null;
            try
            {
                this._BlazorAppInversocaContent.Entry<Propiedad>(model).State = EntityState.Modified;
                this._BlazorAppInversocaContent.Propiedad.Update(model);
                this._BlazorAppInversocaContent.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                var error = Convert.ToString(e.GetBaseException().Message);
                if (error.Contains("idx_Propiedad_Nombre"))
                {
                    str = "El Propiedad ya Existe";
                }
                else { str = e.GetBaseException().Message; }
            }
            return str;
        }

        public string ActualizarSP(PropiedadViewModel model)
        {
            string str = (string)null;
            try
            {
                this._BlazorAppInversocaContent.Database.ExecuteSqlRaw("dbo.Propiedades_update " +
                     "@IdPropiedad,@Nombre,@Descripcion,@Active ", getParameters(model));
                this._BlazorAppInversocaContent.SaveChanges();
            }
            catch (SqlException e)
            {
                var error = Convert.ToString(e.GetBaseException().Message);
                if (error.Contains("idx_Propiedad_Nombre"))
                {
                    str = "El Propiedad ya Existe";
                }
                else { str = e.GetBaseException().Message; }
            }
            return str;
        }
        public string EliminarEF(Propiedad model)
        {
            var modelReturn = this.BuscarEF().Where(a => a.IdPropiedad == model.IdPropiedad).SingleOrDefault();

            string str = (string)null;
            try
            {
                this._BlazorAppInversocaContent.Remove(modelReturn);
                this._BlazorAppInversocaContent.SaveChanges();
            }
            catch(ArgumentException e)
            {
                str = "El Propiedad no fue encontrado, es posible que ya haya sido eliminado anteriormente";
            }
            catch (DbUpdateException e)
            {
                var error = Convert.ToString(e.GetBaseException().Message);
                if (error.Contains("DELETE") && error.Contains("REFERENCE constraint"))
                {
                    //str = e.GetBaseException().Message;
                    str = "debe eliminar los modulos que contienen este Propiedad para poder ser eliminado para poder completar esta operacion";
                }
                else { str = e.GetBaseException().Message; }
            }
            return str;
        }

        public string EliminarSP(PropiedadView model)
        {
            string str = (string)null;
            try
            {
                this._BlazorAppInversocaContent.Database.ExecuteSqlRaw("dbo.Propiedades_delete " +
                    "{0}", model.IdPropiedad);
                this._BlazorAppInversocaContent.SaveChanges();
            }
            catch (ArgumentException ex)
            {
                str = "El Propiedad no fue encontrado, es posible que ya haya sido eliminado anteriormente";
            }
            catch (SqlException e)
            {
                var error = Convert.ToString(e.GetBaseException().Message);
                if (error.Contains("DELETE") && error.Contains("REFERENCE constraint"))
                {
                    str = "Debe eliminar los Modulos que contienen este Propiedad para poder ser eliminado para poder completar esta operacion";
                }
                else { str = e.GetBaseException().Message; }
            }
            return str;
        }
    }
}
