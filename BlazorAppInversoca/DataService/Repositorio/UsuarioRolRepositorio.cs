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
    public class UsuarioRolRepositorio : IUsuarioRol
    {
        private readonly BlazorAppInversocaContent _BlazorAppInversocaContent;
        public UsuarioRolRepositorio(BlazorAppInversocaContent content)
        {
            this._BlazorAppInversocaContent = content;
        }
        private List<SqlParameter> getParameters(UsuarioRolViewModel viewmodel)
        {

            List<SqlParameter> model = new List<SqlParameter>()
            {new SqlParameter() {ParameterName = "@IdUsuario", SqlDbType=SqlDbType.Int, Value= viewmodel.IdUsuario},
             new SqlParameter() {ParameterName = "@IdRol",SqlDbType= SqlDbType.Int, Value= viewmodel.IdRol},
             new SqlParameter() {ParameterName = "@Descripcion",SqlDbType= SqlDbType.VarChar, Value= viewmodel.Descripcion.Trim()}
            };
            return model;
        }
        public List<UsuarioRol> BuscarEF()
        {
            return this._BlazorAppInversocaContent.UsuarioRol.Include(c => c.Usuario).Include(r => r.Rol).AsNoTracking()
                 .ToList();
        }
        public List<UsuarioRolViewModel> BuscarRegistroSP()
        { 
            var spURol = _BlazorAppInversocaContent.UsuarioRolViewModel.FromSqlRaw("exec dbo.usuarios_roles_SelectRecord").ToList();

            if (spURol != null)
            {
                foreach (var registro in spURol)
                {
                    var spRol = _BlazorAppInversocaContent.RolView.FromSqlRaw("exec dbo.roles_Select {0},{0}", true, true)
                        .ToList().Where(r => r.IdRol == registro.IdRol).SingleOrDefault();
                    var spUsuario = _BlazorAppInversocaContent.UsuarioView.FromSqlRaw("exec dbo.usuarios_Select {0},{0}", true, true)
                        .ToList().Where(r => r.IdUsuario == registro.IdUsuario).SingleOrDefault();
                    if (spRol != null) { registro.Rol = spRol; } else { registro.Rol = new RolView(); }
                    if (spUsuario != null) { registro.Usuario = spUsuario; } else { registro.Usuario = new UsuarioView(); }
                }
                return spURol;
            }
            else
            {
                return null;
            }
        }
        public List<UsuarioRolView> BuscarSP(int IdUsuario = 0, int IdRol = 0)
        {
            var usuario = new SqlParameter("@IdUsuario", IdUsuario);
            var rol = new SqlParameter("@IdRol", IdRol);
            return this._BlazorAppInversocaContent.UsuarioRolView.FromSqlRaw("exec dbo.usuarios_roles_Select @IdUsuario,@IdRol", usuario, rol).ToList();
        }
        public string CrearEF(UsuarioRol model)
        {
            {
                string str = (string)null;
                try
                {
                    UsuarioRol permisos = new UsuarioRol
                    {
                        IdUsuario = model.IdUsuario,
                        IdRol = model.IdRol
                    };
                    this._BlazorAppInversocaContent.UsuarioRol.Add(permisos);
                    this._BlazorAppInversocaContent.SaveChanges();
                }
                catch (DbUpdateException e)
                {
                    var error = Convert.ToString(e.GetBaseException().Message);
                    if (error.Contains("PRIMARY KEY constraint"))
                    {
                        str = "Ya existe una relacion entre el Usuario " + model.Usuario.Nombre +
                            " y el Rol " + model.Rol.Nombre;
                    }else if (error.Contains("FOREIGN KEY constraint") && error.Contains("IdUsuario"))
                    {
                        str = "El Usuario no Existe";
                    }
                    else if (error.Contains("FOREIGN KEY constraint") && error.Contains("IdRol"))
                    {
                        str = "El Rol no existe";
                    }
                    else { str = e.GetBaseException().Message; }
                    }
                return str;
            }
        }

        public string CrearSP(UsuarioRolViewModel model)
        {
            string str = (string)null;
            try
            {
                this._BlazorAppInversocaContent.Database.ExecuteSqlRaw("dbo.usuarios_roles_insert " +
                    "@IdUsuario,@IdRol,@Descripcion ", getParameters(model));
                this._BlazorAppInversocaContent.SaveChanges();
            }
            catch (SqlException e)
            {
                var error = Convert.ToString(e.GetBaseException().Message);
                if (error.Contains("PRIMARY KEY constraint"))
                {
                    str = "Ya existe una relacion entre el Usuario " + model.IdUsuario +
                        " el Rol " + model.IdRol;
                }else if(error.Contains("FOREIGN KEY constraint") && error.Contains("IdUsuario")){
                    str = "El Usuario no Existe";
                }else if (error.Contains("FOREIGN KEY constraint") && error.Contains("IdRol"))
                {
                    str = "El Rol no existe";
                }
                else { str = e.GetBaseException().Message; }
            }
            return str;
        }
        public string ActualizarEF(UsuarioRol model)
        {
            string str = (string)null;
            try
            {
                this._BlazorAppInversocaContent.Entry<UsuarioRol>(model).State = EntityState.Modified;
                this._BlazorAppInversocaContent.UsuarioRol.Update(model);
                this._BlazorAppInversocaContent.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                var error = Convert.ToString(e.GetBaseException().Message);
                if (error.Contains("PRIMARY KEY constraint"))
                {
                    str = "Ya existe una relacion entre el Usuario " + model.IdUsuario +
                       " el Rol " + model.IdRol;
                }
                else if (error.Contains("FOREIGN KEY constraint") && error.Contains("IdUsuario"))
                {
                    str = "El Usuario no Existe";
                }
                else if (error.Contains("FOREIGN KEY constraint") && error.Contains("IdRol"))
                {
                    str = "El Rol no existe";
                }
                else { str = e.GetBaseException().Message; }
            }
            return str;
        }

        public string ActualizarSP(UsuarioRolViewModel model)
        {
            string str = (string)null;
            try
            {
                this._BlazorAppInversocaContent.Database.ExecuteSqlRaw("dbo.usuarios_roles_update " +
                     "@IdUsuario,@IdRol,@Descripcion ", getParameters(model));
                this._BlazorAppInversocaContent.SaveChanges();
            }
            catch (SqlException e)
            {
                var error = Convert.ToString(e.GetBaseException().Message);
                if (error.Contains("PRIMARY KEY constraint"))
                {
                    str = "Ya existe una relacion entre el Usuario " + model.Usuario.Nombre +
                        " el Rol " + model.Rol.Nombre;
                }
                else if (error.Contains("FOREIGN KEY constraint") && error.Contains("IdUsuario"))
                {
                    str = "El Usuario no Existe";
                }
                else if (error.Contains("FOREIGN KEY constraint") && error.Contains("IdRol"))
                {
                    str = "El Rol no existe";
                }
                else { str = e.GetBaseException().Message; }
            }
            return str;
        }
        public string EliminarEF(UsuarioRol model)
        {
            var modelReturn = this.BuscarEF().Where(a => a.IdUsuario == model.IdUsuario &&
            a.IdRol == model.IdRol).SingleOrDefault();

            string str = (string)null;
            try
            {
                this._BlazorAppInversocaContent.Remove(modelReturn);
                this._BlazorAppInversocaContent.SaveChanges();
            }
            catch (ArgumentException ex)
            {
                str = "La Relacion entre Usuario y Rol no fue encontrada, es posible que ya haya sido eliminada anteriormente";
            }
            catch (DbUpdateException e)
            {
                var error = Convert.ToString(e.GetBaseException().Message);
                str = e.GetBaseException().Message;
            }
            return str;
        }
        public string EliminarSP(UsuarioRolView model)
        {
            var usuario = new SqlParameter("@IdUsuario", model.IdUsuario);
            var rol = new SqlParameter("@IdRol", model.IdRol);
            string str = (string)null;
            try
            {
                this._BlazorAppInversocaContent.Database.ExecuteSqlRaw("dbo.usuarios_roles_delete @IdUsuario,@IdRol",usuario,rol);
                this._BlazorAppInversocaContent.SaveChanges();
            }
            catch (ArgumentException ex)
            {
                str = "La Relacion entre Usuario y Rol no fue encontrada, es posible que ya haya sido eliminada anteriormente";
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
