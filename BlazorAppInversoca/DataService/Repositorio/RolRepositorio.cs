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
    public class RolRepositorio : IRol
    {
        private readonly BlazorAppInversocaContent _BlazorAppInversocaContent;
        public RolRepositorio(BlazorAppInversocaContent content)
        {
            this._BlazorAppInversocaContent = content;
        }
        private List<SqlParameter> getParameters(RolViewModel viewmodel)
        {
            viewmodel.Nombre = StaticHelper.FirstLetterCapital(viewmodel.Nombre);
            List<SqlParameter> model = new List<SqlParameter>()
            {new SqlParameter() {ParameterName = "@IdRol", SqlDbType=SqlDbType.Int, Value= viewmodel.IdRol},
             new SqlParameter() {ParameterName = "@Descripcion",SqlDbType= SqlDbType.Text, Value= viewmodel.Descripcion.Trim()},
             new SqlParameter() {ParameterName = "@Nombre",SqlDbType= SqlDbType.VarChar, Value= viewmodel.Nombre.Trim()},
             new SqlParameter() {ParameterName = "@Active",SqlDbType= SqlDbType.Bit, Value= viewmodel.Active}
            };
            return model;
        }
        public List<Rol> BuscarEF()
        {
            return this._BlazorAppInversocaContent.Rol.Include(c => c.UsuariosActivos).ThenInclude(u=>u.Usuario).Include(r=>r.OperacionesPermitidas)
                .ThenInclude(o=>o.Operacion).AsNoTracking()
                 .ToList();
        }
        public List<RolViewModel> BuscarRegistroSP()
        {
            return _BlazorAppInversocaContent.RolViewModel.FromSqlRaw("exec dbo.roles_SelectRecord").ToList();
        }
        public List<RolView> BuscarSP(bool isAll, bool isActive)
        {
            var todos = new SqlParameter("@IsAll", isAll);
            var active = new SqlParameter("@Activo", isActive);
            return this._BlazorAppInversocaContent.RolView.FromSqlRaw("exec dbo.roles_Select @IsAll,@Activo", todos, active).ToList();
        }
        public string CrearEF(Rol model)
        {
            string str = (string)null;
            try
            {
                Rol rol = new Rol
                {
                    Active = model.Active,
                    Descripcion = model.Descripcion,
                    Nombre = model.Nombre
                };
                this._BlazorAppInversocaContent.Rol.Add(rol);
                this._BlazorAppInversocaContent.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                var error = Convert.ToString(e.GetBaseException().Message);
                if (error.Contains("idx_Rol_Nombre"))
                {
                    str = "El Rol ya Existe";
                }
                else { str = e.GetBaseException().Message; }
            }
            return str;
        }
        public string CrearSP(RolViewModel model)
        {
            string str = (string)null;
            try
            {
                this._BlazorAppInversocaContent.Database.ExecuteSqlRaw("dbo.roles_insert " +
                    "@IdRol,@Nombre,@Active ", getParameters(model));
                this._BlazorAppInversocaContent.SaveChanges();
            }
            catch (SqlException e)
            {
                var error = Convert.ToString(e.GetBaseException().Message);
                if (error.Contains("idx_Rol_Nombre"))
                {
                    str = "El Rol ya Existe";
                }
                else { str = e.GetBaseException().Message; }
            }
            return str;
        }
        public string ActualizarEF(Rol model)
        {
            string str = (string)null;
            try
            {
                this._BlazorAppInversocaContent.Entry<Rol>(model).State = EntityState.Modified;
                this._BlazorAppInversocaContent.Rol.Update(model);
                this._BlazorAppInversocaContent.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                var error = Convert.ToString(e.GetBaseException().Message);
                if (error.Contains("idx_Rol_Nombre"))
                {
                    str = "El Rol ya Existe";
                }
                else { str = e.GetBaseException().Message; }
            }
            return str;
        }
        public string ActualizarSP(RolViewModel model)
        {
            string str = (string)null;
            try
            {
                this._BlazorAppInversocaContent.Database.ExecuteSqlRaw("dbo.roles_update " +
                     "@IdRol,@Nombre,@Active ", getParameters(model));
                this._BlazorAppInversocaContent.SaveChanges();
            }
            catch (SqlException e)
            {
                var error = Convert.ToString(e.GetBaseException().Message);
                if (error.Contains("idx_Rol_Nombre"))
                {
                    str = "El Rol ya Existe";
                }
                else { str = e.GetBaseException().Message; }
            }
            return str;
        }
        public string EliminarEF(Rol model)
        {
            var modelReturn = this.BuscarEF().Where(a => a.IdRol == model.IdRol).SingleOrDefault();

            string str = (string)null;
            try
            {
                this._BlazorAppInversocaContent.Rol.Remove(modelReturn);
                this._BlazorAppInversocaContent.SaveChanges();
            }
            catch (ArgumentException ex)
            {
                str = "El Rol no fue encontrado, es posible que ya haya sido eliminado anteriormente";
            }
            catch (DbUpdateException e)
            {
                var error = Convert.ToString(e.GetBaseException().Message);
                if (error.Contains("DELETE") && error.Contains("REFERENCE constraint"))
                {
                    str = "Debe eliminar los Usuarios que tienen este Rol Asignado";
                }
                else { str = e.GetBaseException().Message; }
            }
            return str;
        }
        public string EliminarSP(RolView model)
        {
            string str = (string)null;
            try
            {
                this._BlazorAppInversocaContent.Database.ExecuteSqlRaw("dbo.roles_delete " +
                    "{0}", model.IdRol);
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
                    str = "Debe eliminar los Usuarios que tienen este Rol Asignado";
                }
                else { str = e.GetBaseException().Message; }
            }
            return str;
        }
    }
}
