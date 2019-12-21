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
    public class UsuarioRepositorio : IUsuario
    {
        private readonly BlazorAppInversocaContent _BlazorAppInversocaContent;
        public UsuarioRepositorio(BlazorAppInversocaContent content)
        {
            this._BlazorAppInversocaContent = content;
        }
        private List<SqlParameter> getParameters(UsuarioViewModel viewmodel)
        {
            viewmodel.Nombre = StaticHelper.FirstLetterCapital(viewmodel.Nombre);
            List<SqlParameter> model = new List<SqlParameter>()
            {new SqlParameter() {ParameterName = "@IdUsuario", SqlDbType=SqlDbType.Int, Value= viewmodel.IdUsuario},
             new SqlParameter() {ParameterName = "@Nombre",SqlDbType= SqlDbType.VarChar, Value= viewmodel.Nombre.Trim()},
             new SqlParameter() {ParameterName = "@Contrasena",SqlDbType= SqlDbType.VarChar, Value= viewmodel.Contrasena.Trim()},
             new SqlParameter() {ParameterName = "@Correo",SqlDbType= SqlDbType.VarChar, Value= viewmodel.Correo.Trim()},
             new SqlParameter() {ParameterName = "@Active",SqlDbType= SqlDbType.Bit, Value= viewmodel.Active}
            };
            return model;
        }
        public List<Usuario> BuscarEF()
        {
            return this._BlazorAppInversocaContent.Usuario.Include(ur=>ur.RolesAsignados).ThenInclude(r=>r.Rol).AsNoTracking()
                 .ToList();
        }
        public List<UsuarioViewModel> BuscarRegistroSP()
        {
            return _BlazorAppInversocaContent.UsuarioViewModel.FromSqlRaw("exec dbo.usuarios_SelectRecord").ToList();
        }
        public List<UsuarioView> BuscarSP(bool isAll, bool isActive)
        {
            var todos = new SqlParameter("@IsAll", isAll);
            var active = new SqlParameter("@Activo", isActive);
            return this._BlazorAppInversocaContent.UsuarioView.FromSqlRaw("exec dbo.usuarios_Select @IsAll,@Activo", todos, active).ToList();
        }
        public string CrearEF(Usuario model)
        {
            string str = (string)null;
            try
            {
                Usuario usuario = new Usuario
                {
                    Active = model.Active,
                    Contrasena = model.Contrasena,
                    Nombre = model.Nombre,
                    Correo = model.Correo
                };
                this._BlazorAppInversocaContent.Usuario.Add(usuario);
                this._BlazorAppInversocaContent.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                var error = Convert.ToString(e.GetBaseException().Message);
                if (error.Contains("idx_Usuario_Correo"))
                {
                    str = "Este correo ya esta siendo utilizado por otro usuario";
                }
                else { str = e.GetBaseException().Message; }
            }
            return str;
        }
        public string CrearSP(UsuarioViewModel model)
        {
            string str = (string)null;
            try
            {
                this._BlazorAppInversocaContent.Database.ExecuteSqlRaw("dbo.usuarios_insert " +
                    "@IdUsuario,@Nombre,@Contrasena,@Correo,@Active ", getParameters(model));
                this._BlazorAppInversocaContent.SaveChanges();
            }
            catch (SqlException e)
            {
                var error = Convert.ToString(e.GetBaseException().Message);
                if (error.Contains("idx_Usuario_Correo"))
                {
                    str = "Este correo ya esta siendo utilizado por otro usuario";
                }
                else { str = e.GetBaseException().Message; }
            }
            return str;
        }
        public string ActualizarEF(Usuario model)
        {
            string str = (string)null;
            try
            {
                this._BlazorAppInversocaContent.Entry<Usuario>(model).State = EntityState.Modified;
                this._BlazorAppInversocaContent.Usuario.Update(model);
                this._BlazorAppInversocaContent.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                var error = Convert.ToString(e.GetBaseException().Message);
                if (error.Contains("idx_Usuario_Correo"))
                {
                    str = "Este correo ya esta siendo utilizado por otro usuario";
                }
                else { str = e.GetBaseException().Message; }
            }
            return str;
        }
        public string ActualizarSP(UsuarioViewModel model)
        {
            string str = (string)null;
            try
            {
                this._BlazorAppInversocaContent.Database.ExecuteSqlRaw("dbo.usuarios_update " +
                    "@IdUsuario,@Nombre,@Contrasena,@Correo,@Active ", getParameters(model));
                this._BlazorAppInversocaContent.SaveChanges();
            }
            catch (SqlException e)
            {
                var error = Convert.ToString(e.GetBaseException().Message);
                if (error.Contains("idx_Usuario_Correo"))
                {
                    str = "Este correo ya esta siendo utilizado por otro usuario";
                }
                else { str = e.GetBaseException().Message; }
            }
            return str;
        }
        public string EliminarEF(Usuario model)
        {
            var modelReturn = this.BuscarEF().Where(a => a.IdUsuario == model.IdUsuario).SingleOrDefault();

            string str = (string)null;
            try
            {
                this._BlazorAppInversocaContent.Remove(modelReturn);
                this._BlazorAppInversocaContent.SaveChanges();
            }
            catch (ArgumentException ex)
            {
                str = "El Usuario no fue encontrado, es posible que ya haya sido eliminado anteriormente";
            }
            catch (DbUpdateException e)
            {
                var error = Convert.ToString(e.GetBaseException().Message);
                str = e.GetBaseException().Message;
            }
            return str;
        }
        public string EliminarSP(UsuarioView model)
        {
            string str = (string)null;
            try
            {
                this._BlazorAppInversocaContent.Database.ExecuteSqlRaw("dbo.usuarios_delete " +
                    "{0}", model.IdUsuario);
                this._BlazorAppInversocaContent.SaveChanges();
            }
            catch (ArgumentException ex)
            {
                str = "El Usuario no fue encontrado, es posible que ya haya sido eliminado anteriormente";
            }
            catch (SqlException e)
            {
                var error = Convert.ToString(e.GetBaseException().Message);
                if (error.Contains("DELETE") && error.Contains("REFERENCE constraint"))
                {
                 
                    str = "Este Usuario tiene Movimientos, debe eliminar esos movimientos para poder ser eliminado";
                }
                else { str = e.GetBaseException().Message; }
            }
            return str;
        }
    }
}
