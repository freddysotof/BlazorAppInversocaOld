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
    public class ServicioUsuario
    {
        private readonly HttpClient _http;
        private readonly string urlApi = "https://localhost:51663";
        private readonly LocalStorage _LocalStorage;
        private UsuarioViewModel usuarioViewModel;
        public ServicioUsuario(HttpClient httpserv, LocalStorage _localstrg)
        {
            _LocalStorage = _localstrg;
            _http = httpserv;
        }
        //Metodos de Busquedas
        public async Task<List<Usuario>> BuscarEF()
        {
            //ValidarToken
            var result = await _http.GetJsonAsync<List<Usuario>>($"{urlApi}/api/Usuario/BuscarEF");
            return result;
        }
        public async Task<List<UsuarioView>> BuscarSP(bool isAll = true, bool isActive = true)
        {
            //ValidarToken
            var result = await _http.GetJsonAsync<List<UsuarioView>>($"{urlApi}/api/Usuario/BuscarSP/Todos/{isAll}/Activo/{isActive}");
            return result;
        }
        public async Task<UsuarioView> BuscarSP_x_Id(bool isAll = true, bool isActive = true, int Id = 0)
        {
            //ValidarToken
            var result = await _http.GetJsonAsync<UsuarioView>($"{urlApi}/api/Usuario/BuscarSP/Todos/{isAll}/Activo/{isActive}/Id/{Id}");
            return result;
        }
        public async Task<UsuarioView> BuscarSP_x_Nombre(bool isAll = true, bool isActive = true, string nombre = "")
        {
            //ValidarToken
            var result = await _http.GetJsonAsync<UsuarioView>($"{urlApi}/api/Usuario/BuscarSP/Todos/{isAll}/Activo/{isActive}/Nombre/{nombre}");
            return result;
        }
        public async Task<List<UsuarioViewModel>> BuscarSP_Registros()
        {
            //ValidarToken
            var result = await _http.GetJsonAsync<List<UsuarioViewModel>>($"{urlApi}/api/Usuario/BuscarSP/Registro");
            return result;
        }
        public async Task<UsuarioViewModel> BuscarSP_Registro_x_Id(int Id = 0)
        {
            //ValidarToken
            var result = await _http.GetJsonAsync<UsuarioViewModel>($"{urlApi}/api/Usuario/BuscarSP/Registro/Id/{Id}");
            return result;
        }
        public async Task<UsuarioViewModel> BuscarSP_Registro_x_Nombre(string nombre = "")
        {
            //ValidarToken
            var result = await _http.GetJsonAsync<UsuarioViewModel>($"{urlApi}/api/Usuario/BuscarSP/Registro/Nombre/{nombre}");
            return result;
        }
        // Filtrar Registros
        public async Task<List<Usuario>> FiltrarEF(string filtro, string value)
        {
            //ValidarToken
            var result = await _http.GetJsonAsync<List<Usuario>>($"{urlApi}/api/Usuario/FiltrarEF/{filtro}/{value}");
            return result;
        }
        public async Task<List<UsuarioView>> FiltrarSP(bool isAll, bool isActive, string filtro, string value)
        {
            //ValidarToken
            var result = await _http.GetJsonAsync<List<UsuarioView>>($"{urlApi}/api/Usuario/FiltrarSP/Todos/{isAll}/Activo/{isActive}/{filtro}/{value}");
            return result;
        }
        // Metodos para Crear Registros
        public async Task<ResultViewModel> RegistrarEF(Usuario model)
        {
            //ValidarToken
            var result = await _http.PostJsonAsync<ResultViewModel>($"{urlApi}/api/Usuario/CrearEF", model);
            return result;
        }
        public async Task<ResultViewModel> RegistrarSP(UsuarioViewModel model)
        {
            //ValidarToken
            var result = await _http.PostJsonAsync<ResultViewModel>($"{urlApi}/api/Usuario/CrearSP", model);
            return result;
        }

        // Metodos para Modificar o Editar Registros
        public async Task<ResultViewModel> ModificarEF(Usuario model)
        {
            //ValidarToken
            var result = await _http.PutJsonAsync<ResultViewModel>($"{urlApi}/api/Usuario/ModificarEF", model);
            return result;
        }
        public async Task<ResultViewModel> ModificarSP(UsuarioViewModel model)
        {
            //ValidarToken
            var result = await _http.PutJsonAsync<ResultViewModel>($"{urlApi}/api/Usuario/ModificarSP", model);
            return result;
        }
        // Metodos para Activar Registros
        public async Task<ResultViewModel> ActivarEF(Usuario model)
        {
            //ValidarToken
            var result = await _http.PutJsonAsync<ResultViewModel>($"{urlApi}/api/Usuario/ModificarEF", model);
            return result;
        }
        public async Task<ResultViewModel> ActivarSP(int id = 0, string nombre = "")
        {
            //ValidarToken
            if (id == 0) { usuarioViewModel = await BuscarSP_Registro_x_Nombre(nombre); }
            else { usuarioViewModel = await BuscarSP_Registro_x_Id(id); }
            var result = await _http.PutJsonAsync<ResultViewModel>($"{urlApi}/api/Rol/ModificarSP", usuarioViewModel);
            return result;
        }
        // Metodos Para Desactivar Registros
        public async Task<ResultViewModel> DesactivarEF(int IdUsuario)
        {
            //ValidarToken
            var Usuarios = await BuscarEF();
            var Usuario = Usuarios.Where(a => a.IdUsuario == IdUsuario).SingleOrDefault();
            var result = await _http.PutJsonAsync<ResultViewModel>($"{urlApi}/api/Usuario/DesactivarEF", Usuario);
            return result;
        }
        public async Task<ResultViewModel> DesactivarSP(int IdCliente)
        {
            //ValidarToken
            usuarioViewModel = await BuscarSP_Registro_x_Id(IdCliente);
            var result = await _http.PutJsonAsync<ResultViewModel>($"{urlApi}/api/Usuario/DesactivarSP", usuarioViewModel);
            return result;
        }
        // Metodos Para Eliminar Registros
        public async Task<ResultViewModel> EliminarEF(Usuario model)
        {
            //ValidarToken
            var result = await _http.PostJsonAsync<ResultViewModel>($"{urlApi}/api/Usuario/EliminarEF", model);
            return result;
        }
        public async Task<ResultViewModel> EliminarSP(UsuarioView model)
        {
            //ValidarToken
            var result = await _http.PostJsonAsync<ResultViewModel>($"{urlApi}/api/Usuario/EliminarSP", model);
            return result;
        }
    }
}
