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
    public class ServicioRolOperacion
    {
        private readonly HttpClient _http;
        private readonly string urlApi = "https://localhost:51663";
        private readonly LocalStorage _LocalStorage;
        private readonly RolOperacionViewModel RolOperacionViewModel;
        public ServicioRolOperacion(HttpClient httpserv, LocalStorage _localstrg)
        {
            _LocalStorage = _localstrg;
            _http = httpserv;
        }
        //Metodos de Busquedas
        public async Task<List<RolOperacion>> BuscarEF()
        {
            //ValidarToken
            var result = await _http.GetJsonAsync<List<RolOperacion>>($"{urlApi}/api/RolOperacion/BuscarEF");
            return result;
        }
        public async Task<List<RolOperacionView>> BuscarSP()
        {
            //ValidarToken
            var result = await _http.GetJsonAsync<List<RolOperacionView>>($"{urlApi}/api/RolOperacion/BuscarSP");
            return result;
        }
        public async Task<RolOperacionView> BuscarSP_x_Rol_Operacion(int IdRol=0,int IdOperacion=0)
        {
            //ValidarToken
            var result = await _http.GetJsonAsync<RolOperacionView>($"{urlApi}/api/RolOperacion/BuscarSP/Rol/{IdRol}/Operacion/{IdOperacion}");
            return result;
        }
        public async Task<List<RolOperacionView>> BuscarSP_x_Rol(int IdRol)
        {
            //ValidarToken
            var result = await _http.GetJsonAsync<List<RolOperacionView>>($"{urlApi}/api/RolOperacion/BuscarSP/Rol/{IdRol}");
            return result;
        }
        public async Task<List<RolOperacionView>> BuscarSP_x_Operacion(int IdOperacion)
        {
            //ValidarToken
            var result = await _http.GetJsonAsync<List<RolOperacionView>>($"{urlApi}/api/RolOperacion/BuscarSP/Operacion/{IdOperacion}");
            return result;
        }
        public async Task<List<RolOperacionViewModel>> BuscarSP_Registros()
        {
            //ValidarToken
            var result = await _http.GetJsonAsync<List<RolOperacionViewModel>>($"{urlApi}/api/RolOperacion/BuscarSP/Registro");
            return result;
        }
        public async Task<List<RolOperacionViewModel>> BuscarSP_Registro_x_Rol(int IdRol = 0)
        {
            //ValidarToken
            var result = await _http.GetJsonAsync<List<RolOperacionViewModel>>($"{urlApi}/api/RolOperacion/BuscarSP/Registro/Rol/{IdRol}");
            return result;
        }
        public async Task<List<RolOperacionViewModel>> BuscarSP_Registro_x_Operacion(int IdOperacion = 0)
        {
            //ValidarToken
            var result = await _http.GetJsonAsync<List<RolOperacionViewModel>>($"{urlApi}/api/RolOperacion/BuscarSP/Registro/Operacion/{IdOperacion}");
            return result;
        }
        public async Task<RolOperacionViewModel> BuscarSP_Registro_x_Rol_Operacion(int IdRol,int IdOperacion)
        {
            //ValidarToken
            var result = await _http.GetJsonAsync<RolOperacionViewModel>($"{urlApi}/api/RolOperacion/BuscarSP/Registro/Rol/{IdRol}/Operacion/{IdRol}");
            return result;
        }
        // Filtrar Registros
        public async Task<List<RolOperacion>> FiltrarEF(string filtro, string value)
        {
            //ValidarToken
            var result = await _http.GetJsonAsync<List<RolOperacion>>($"{urlApi}/api/RolOperacion/FiltrarEF/{filtro}/{value}");
            return result;
        }
        public async Task<List<RolOperacionView>> FiltrarSP(bool isAll, bool isActive, string filtro, string value)
        {
            //ValidarToken
            var result = await _http.GetJsonAsync<List<RolOperacionView>>($"{urlApi}/api/RolOperacion/FiltrarSP/{filtro}/{value}");
            return result;
        }
        // Metodos para Crear Registros
        public async Task<ResultViewModel> RegistrarEF(RolOperacion model)
        {
            //ValidarToken
            var result = await _http.PostJsonAsync<ResultViewModel>($"{urlApi}/api/RolOperacion/CrearEF", model);
            return result;
        }
        public async Task<ResultViewModel> RegistrarSP(RolOperacionViewModel model)
        {
            //ValidarToken
            var result = await _http.PostJsonAsync<ResultViewModel>($"{urlApi}/api/RolOperacion/CrearSP", model);
            return result;
        }

        // Metodos para Modificar o Editar Registros
        public async Task<ResultViewModel> ModificarEF(RolOperacion model)
        {
            //ValidarToken
            var result = await _http.PutJsonAsync<ResultViewModel>($"{urlApi}/api/RolOperacion/ModificarEF", model);
            return result;
        }
        public async Task<ResultViewModel> ModificarSP(RolOperacionViewModel model)
        {
            //ValidarToken
            var result = await _http.PutJsonAsync<ResultViewModel>($"{urlApi}/api/RolOperacion/ModificarSP", model);
            return result;
        }
      
        // Metodos Para Eliminar Registros
        public async Task<ResultViewModel> EliminarEF(RolOperacion model)
        {
            //ValidarToken
            var result = await _http.PostJsonAsync<ResultViewModel>($"{urlApi}/api/RolOperacion/EliminarEF", model);
            return result;
        }
        public async Task<ResultViewModel> EliminarSP(RolOperacionView model)
        {
            //ValidarToken
            var result = await _http.PostJsonAsync<ResultViewModel>($"{urlApi}/api/RolOperacion/EliminarSP", model);
            return result;
        }
    }
}
