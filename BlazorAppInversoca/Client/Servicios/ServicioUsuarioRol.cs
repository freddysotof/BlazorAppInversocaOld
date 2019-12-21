using Blazor.Extensions.Storage;
using Microsoft.AspNetCore.Components;
using BlazorAppInversoca.Shared.EFModels;
using BlazorAppInversoca.Shared.Token___Result_Models;
using BlazorAppInversoca.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorAppInversoca.Client.Servicios
{
    public class ServicioUsuarioRol
    {
        private readonly HttpClient _http;
        private readonly string urlApi = "https://localhost:51663";
        private readonly LocalStorage _LocalStorage;
        private UsuarioRolViewModel UsuarioRolViewModel;
        public ServicioUsuarioRol(HttpClient httpserv, LocalStorage _localstrg)
        {
            _LocalStorage = _localstrg;
            _http = httpserv;
        }
        //Metodos de Busquedas
        public async Task<List<UsuarioRol>> BuscarEF()
        {
            //ValidarToken
            var result = await _http.GetJsonAsync<List<UsuarioRol>>($"{urlApi}/api/UsuarioRol/BuscarEF");
            return result;
        }
        public async Task<List<UsuarioRolView>> BuscarSP()
        {
            //ValidarToken
            var result = await _http.GetJsonAsync<List<UsuarioRolView>>($"{urlApi}/api/UsuarioRol/BuscarSP");
            return result;
        }
        public async Task<UsuarioRolView> BuscarSP_x_Usuario_Rol(int IdUsuario = 0, int IdRol = 0)
        {
            //ValidarToken
            var result = await _http.GetJsonAsync<UsuarioRolView>($"{urlApi}/api/UsuarioRol/BuscarSP/Usuario/{IdUsuario}/Rol/{IdRol}");
            return result;
        }
        public async Task<List<UsuarioRolView>> BuscarSP_x_Rol(int IdRol)
        {
            //ValidarToken
            var result = await _http.GetJsonAsync<List<UsuarioRolView>>($"{urlApi}/api/UsuarioRol/BuscarSP/Rol/{IdRol}");
            return result;
        }
        public async Task<List<UsuarioRolView>> BuscarSP_x_Usuario(int IdUsuario)
        {
            //ValidarToken
            var result = await _http.GetJsonAsync<List<UsuarioRolView>>($"{urlApi}/api/UsuarioRol/BuscarSP/Usuario/{IdUsuario}");
            return result;
        }
        public async Task<List<UsuarioRolViewModel>> BuscarSP_Registros()
        {
            //ValidarToken
            var result = await _http.GetJsonAsync<List<UsuarioRolViewModel>>($"{urlApi}/api/UsuarioRol/BuscarSP/Registro");
            return result;
        }
        public async Task<List<UsuarioRolViewModel>> BuscarSP_Registro_x_Usuario(int IdUsuario = 0)
        {
            //ValidarToken
            var result = await _http.GetJsonAsync<List<UsuarioRolViewModel>>($"{urlApi}/api/UsuarioRol/BuscarSP/Registro/Usuario/{IdUsuario}");
            return result;
        }
        public async Task<List<UsuarioRolViewModel>> BuscarSP_Registro_x_Rol(int IdRol = 0)
        {
            //ValidarToken
            var result = await _http.GetJsonAsync<List<UsuarioRolViewModel>>($"{urlApi}/api/UsuarioRol/BuscarSP/Registro/Rol/{IdRol}");
            return result;
        }
        public async Task<UsuarioRolViewModel> BuscarSP_Registro_x_Usuario_Rol(int IdUsuario, int IdRol)
        {
            //ValidarToken
            var result = await _http.GetJsonAsync<UsuarioRolViewModel>($"{urlApi}/api/UsuarioRol/BuscarSP/Registro/Usuario/{IdUsuario}/Rol/{IdRol}");
            return result;
        }
        // Filtrar Registros
        public async Task<List<UsuarioRol>> FiltrarEF(string filtro, string value)
        {
            //ValidarToken
            var result = await _http.GetJsonAsync<List<UsuarioRol>>($"{urlApi}/api/UsuarioRol/FiltrarEF/{filtro}/{value}");
            return result;
        }
        public async Task<List<UsuarioRolView>> FiltrarSP(bool isAll, bool isActive, string filtro, string value)
        {
            //ValidarToken
            var result = await _http.GetJsonAsync<List<UsuarioRolView>>($"{urlApi}/api/UsuarioRol/FiltrarSP/{filtro}/{value}");
            return result;
        }
        // Metodos para Crear Registros
        public async Task<ResultViewModel> RegistrarEF(UsuarioRol model)
        {
            //ValidarToken
            var result = await _http.PostJsonAsync<ResultViewModel>($"{urlApi}/api/UsuarioRol/CrearEF", model);
            return result;
        }
        public async Task<ResultViewModel> RegistrarSP(UsuarioRolViewModel model)
        {
            //ValidarToken
            var result = await _http.PostJsonAsync<ResultViewModel>($"{urlApi}/api/UsuarioRol/CrearSP", model);
            return result;
        }

        // Metodos para Modificar o Editar Registros
        public async Task<ResultViewModel> ModificarEF(UsuarioRol model)
        {
            //ValidarToken
            var result = await _http.PutJsonAsync<ResultViewModel>($"{urlApi}/api/UsuarioRol/ModificarEF", model);
            return result;
        }
        public async Task<ResultViewModel> ModificarSP(UsuarioRolViewModel model)
        {
            //ValidarToken
            var result = await _http.PutJsonAsync<ResultViewModel>($"{urlApi}/api/UsuarioRol/ModificarSP", model);
            return result;
        }

        // Metodos Para Eliminar Registros
        public async Task<ResultViewModel> EliminarEF(UsuarioRol model)
        {
            //ValidarToken
            var result = await _http.PostJsonAsync<ResultViewModel>($"{urlApi}/api/UsuarioRol/EliminarEF", model);
            return result;
        }
        public async Task<ResultViewModel> EliminarSP(UsuarioRolView model)
        {
            //ValidarToken
            var result = await _http.PostJsonAsync<ResultViewModel>($"{urlApi}/api/UsuarioRol/EliminarSP", model);
            return result;
        }
    }
}
