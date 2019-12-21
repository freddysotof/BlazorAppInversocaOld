
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
    public class ModuloRepositorio : IModulo
    {
        private readonly BlazorAppInversocaContent _BlazorAppInversocaContent;
        public ModuloRepositorio(BlazorAppInversocaContent content)
        {
            this._BlazorAppInversocaContent = content;
        }
        private List<SqlParameter> getParameters(ModuloViewModel viewmodel)
        {
            viewmodel.Nombre = StaticHelper.FirstLetterCapital(viewmodel.Nombre);
            List<SqlParameter> model = new List<SqlParameter>()
            {new SqlParameter() {ParameterName = "@IdModulo", SqlDbType=SqlDbType.Int, Value= viewmodel.IdModulo},
             new SqlParameter() {ParameterName = "@Nombre",SqlDbType= SqlDbType.VarChar, Value= viewmodel.Nombre.Trim()},
             new SqlParameter() {ParameterName = "@Descripcion",SqlDbType= SqlDbType.Text, Value= viewmodel.Descripcion.Trim()},
             new SqlParameter() {ParameterName = "@Active",SqlDbType= SqlDbType.Bit, Value= viewmodel.Active}
            };
            return model;
        }
        public List<Modulo> BuscarEF()
        {
            return this._BlazorAppInversocaContent.Modulo.Include(o=>o.Operaciones).ThenInclude(ro=>ro.RolesOperaciones).AsNoTracking()
                  .ToList();
        }
        public List<ModuloViewModel> BuscarRegistroSP()
        {
            return _BlazorAppInversocaContent.ModuloViewModel.FromSqlRaw("exec dbo.modulos_SelectRecord").ToList();
        }
        public List<ModuloView> BuscarSP(bool isAll, bool isActive)
        {
            var todos = new SqlParameter("@IsAll", isAll);
            var active = new SqlParameter("@Activo", isActive);
            return this._BlazorAppInversocaContent.ModuloView.FromSqlRaw("exec dbo.modulos_Select @IsAll,@Activo", todos, active).ToList();
        }
        public string CrearEF(Modulo model)
        {
            {
                string str = (string)null;
                try
                {
                    Modulo modulo = new Modulo
                    {
                        Active = model.Active,
                        Descripcion = model.Descripcion,
                        Nombre = model.Nombre,
                    };
                    this._BlazorAppInversocaContent.Modulo.Add(modulo);
                    this._BlazorAppInversocaContent.SaveChanges();
                }
                catch (DbUpdateException e)
                {
                    var error = Convert.ToString(e.GetBaseException().Message);
                    if (error.Contains("idx_Modulo_Nombre")){
                        str = "El Modulo ya Existe";
                    }
                    else if (error.Contains("FOREIGN KEY constraint") && error.Contains("IdPropiedad"))
                    {
                        str = "El Propiedad no Existe";
                    }
                   
                    else { str = e.GetBaseException().Message; }
                }
                return str;
            }
        }
        public string CrearSP(ModuloViewModel model)
        {
            string str = (string)null;
            try
            {
                this._BlazorAppInversocaContent.Database.ExecuteSqlRaw("dbo.modulos_insert " +
                    "@IdModulo,@Nombre,@IdPropiedad,@Active ", getParameters(model));
                this._BlazorAppInversocaContent.SaveChanges();
            }
            catch (SqlException e)
            {
                var error = Convert.ToString(e.GetBaseException().Message);
                if (error.Contains("idx_Modulo_Nombre"))
                {
                    str = "El Modulo ya Existe";
                }
                else if (error.Contains("FOREIGN KEY constraint") && error.Contains("IdPropiedad"))
                {
                    str = "El Propiedad no Existe";
                }
                else { str = e.GetBaseException().Message; }
            }
            return str;
        }
        public string ActualizarEF(Modulo model)
        {
            string str = (string)null;
            try
            {
                this._BlazorAppInversocaContent.Entry<Modulo>(model).State = EntityState.Modified;
                this._BlazorAppInversocaContent.Modulo.Update(model);
                this._BlazorAppInversocaContent.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                var error = Convert.ToString(e.GetBaseException().Message);
                if (error.Contains("idx_Modulo_Nombre"))
                {
                    str = "El Modulo ya Existe";
                }
                else if (error.Contains("FOREIGN KEY constraint") && error.Contains("IdPropiedad"))
                {
                    str = "El Propiedad no Existe";
                }
                else { str = e.GetBaseException().Message; }
            }
            return str;
        }
        public string ActualizarSP(ModuloViewModel model)
        {
            string str = (string)null;
            try
            {
                this._BlazorAppInversocaContent.Database.ExecuteSqlRaw("dbo.modulos_update " +
                    "@IdModulo,@Nombre,@IdPropiedad,@Active ", getParameters(model));
                this._BlazorAppInversocaContent.SaveChanges();
            }
            catch (SqlException e)
            {
                var error = Convert.ToString(e.GetBaseException().Message);
                if (error.Contains("idx_Modulo_Nombre"))
                {
                    str = "El Modulo ya Existe";
                }
                else if (error.Contains("FOREIGN KEY constraint") && error.Contains("IdPropiedad"))
                {
                    str = "El Propiedad no Existe";
                }
                else { str = e.GetBaseException().Message; }
            }
            return str;
        }
        public string EliminarEF(Modulo model)
        {
            var modelReturn = this.BuscarEF().Where(a => a.IdModulo == model.IdModulo).SingleOrDefault();

            string str = (string)null;
            try
            {
                this._BlazorAppInversocaContent.Modulo.Remove(modelReturn);
                this._BlazorAppInversocaContent.SaveChanges();
            }
            catch (ArgumentException ex)
            {
                str = "El Modulo no fue encontrado, es posible que ya haya sido eliminado anteriormente";
            }
            catch (DbUpdateException e)
            {
                var error = Convert.ToString(e.GetBaseException().Message);
                if (error.Contains("DELETE") && error.Contains("REFERENCE constraint"))
                {
                    str = "Debe Eliminar las Operaciones relacionadas que tiene este Modulo";
                }
                else { str = e.GetBaseException().Message; }
            }
            return str;
        }
        public string EliminarSP(ModuloView model)
        {
            string str = (string)null;
            try
            {
                this._BlazorAppInversocaContent.Database.ExecuteSqlRaw("dbo.modulos_delete " +
                    "{0}", model.IdModulo);
                this._BlazorAppInversocaContent.SaveChanges();
            }
            catch (ArgumentException ex)
            {
                str = "El Modulo no fue encontrado, es posible que ya haya sido eliminado anteriormente";
            }
            catch (SqlException e)
            {
                var error = Convert.ToString(e.GetBaseException().Message);
                if (error.Contains("DELETE") && error.Contains("REFERENCE constraint"))
                {
                    str = "Debe Eliminar las Operaciones relacionadas con este modulo";
                }
                else { str = e.GetBaseException().Message; }
            }
            return str;
        }
    }
}
