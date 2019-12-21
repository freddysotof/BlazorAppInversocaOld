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
    public class ServicioRol
    {
        private readonly HttpClient _http;
        private readonly string urlApi = "https://localhost:51663";
        private readonly LocalStorage _LocalStorage;
        private RolViewModel rolViewModel;
        public ServicioRol(HttpClient httpserv, LocalStorage _localstrg)
        {
            _LocalStorage = _localstrg;
            _http = httpserv;
        }
        //Metodos de Busquedas
        public async Task<List<Rol>> BuscarEF()
        {
            //ValidarToken
            var result = await _http.GetJsonAsync<List<Rol>>($"{urlApi}/api/Rol/BuscarEF");
            return result;
        }
        public async Task<List<RolView>> BuscarSP(bool isAll = true, bool isActive = true)
        {
            //ValidarToken
            var result = await _http.GetJsonAsync<List<RolView>>($"{urlApi}/api/Rol/BuscarSP/Todos/{isAll}/Activo/{isActive}");
            return result;
        }
        public async Task<RolView> BuscarSP_x_Id(bool isAll = true, bool isActive = true, int Id = 0)
        {
            //ValidarToken
            var result = await _http.GetJsonAsync<RolView>($"{urlApi}/api/Rol/BuscarSP/Todos/{isAll}/Activo/{isActive}/Id/{Id}");
            return result;
        }
        public async Task<RolView> BuscarSP_x_Nombre(bool isAll = true, bool isActive = true, string nombre = "")
        {
            //ValidarToken
            var result = await _http.GetJsonAsync<RolView>($"{urlApi}/api/Rol/BuscarSP/Todos/{isAll}/Activo/{isActive}/Nombre/{nombre}");
            return result;
        }
        public async Task<List<RolViewModel>> BuscarSP_Registros()
        {
            //ValidarToken
            var result = await _http.GetJsonAsync<List<RolViewModel>>($"{urlApi}/api/Rol/BuscarSP/Registro");
            return result;
        }
        public async Task<RolViewModel> BuscarSP_Registro_x_Id(int Id = 0)
        {
            //ValidarToken
            var result = await _http.GetJsonAsync<RolViewModel>($"{urlApi}/api/Rol/BuscarSP/Registro/Id/{Id}");
            return result;
        }
        public async Task<RolViewModel> BuscarSP_Registro_x_Nombre(string nombre = "")
        {
            //ValidarToken
            var result = await _http.GetJsonAsync<RolViewModel>($"{urlApi}/api/Rol/BuscarSP/Registro/Nombre/{nombre}");
            return result;
        }
        // Filtrar Registros
        public async Task<List<Rol>> FiltrarEF(string filtro, string value)
        {
            //ValidarToken
            var result = await _http.GetJsonAsync<List<Rol>>($"{urlApi}/api/Rol/FiltrarEF/{filtro}/{value}");
            return result;
        }
        public async Task<List<RolView>> FiltrarSP(bool isAll, bool isActive, string filtro, string value)
        {
            //ValidarToken
            var result = await _http.GetJsonAsync<List<RolView>>($"{urlApi}/api/Rol/FiltrarSP/Todos/{isAll}/Activo/{isActive}/{filtro}/{value}");
            return result;
        }
        // Metodos para Crear Registros
        public async Task<ResultViewModel> RegistrarEF(Rol model)
        {
            //ValidarToken
            var result = await _http.PostJsonAsync<ResultViewModel>($"{urlApi}/api/Rol/CrearEF", model);
            return result;
        }
        public async Task<ResultViewModel> RegistrarSP(RolViewModel model)
        {
            //ValidarToken
            var result = await _http.PostJsonAsync<ResultViewModel>($"{urlApi}/api/Rol/CrearSP", model);
            return result;
        }

        // Metodos para Modificar o Editar Registros
        public async Task<ResultViewModel> ModificarEF(Rol model)
        {
            //ValidarToken
            var result = await _http.PutJsonAsync<ResultViewModel>($"{urlApi}/api/Rol/ModificarEF", model);
            return result;
        }
        public async Task<ResultViewModel> ModificarSP(RolViewModel model)
        {
            //ValidarToken
            var result = await _http.PutJsonAsync<ResultViewModel>($"{urlApi}/api/Rol/ModificarSP", model);
            return result;
        }
        // Metodos para Activar Registros
        public async Task<ResultViewModel> ActivarEF(Rol model)
        {
            //ValidarToken
            var result = await _http.PutJsonAsync<ResultViewModel>($"{urlApi}/api/Rol/ModificarEF", model);
            return result;
        }
        public async Task<ResultViewModel> ActivarSP(int id = 0, string nombre = "")
        {
            //ValidarToken
            if (id == 0) { rolViewModel = await BuscarSP_Registro_x_Nombre(nombre); }
            else { rolViewModel = await BuscarSP_Registro_x_Id(id); }
            var result = await _http.PutJsonAsync<ResultViewModel>($"{urlApi}/api/Rol/ModificarSP", rolViewModel);
            return result;
        }
        // Metodos Para Desactivar Registros
        public async Task<ResultViewModel> DesactivarEF(int IdRol)
        {
            //ValidarToken
            var Rols = await BuscarEF();
            var Rol = Rols.Where(a => a.IdRol == IdRol).SingleOrDefault();
            var result = await _http.PutJsonAsync<ResultViewModel>($"{urlApi}/api/Rol/DesactivarEF", Rol);
            return result;
        }
        public async Task<ResultViewModel> DesactivarSP(int IdCliente)
        {
            //ValidarToken
            rolViewModel = await BuscarSP_Registro_x_Id(IdCliente);
            var result = await _http.PutJsonAsync<ResultViewModel>($"{urlApi}/api/Rol/DesactivarSP", rolViewModel);
            return result;
        }
        // Metodos Para Eliminar Registros
        public async Task<ResultViewModel> EliminarEF(Rol model)
        {
            //ValidarToken
            var result = await _http.PostJsonAsync<ResultViewModel>($"{urlApi}/api/Rol/EliminarEF", model);
            return result;
        }
        public async Task<ResultViewModel> EliminarSP(RolView model)
        {
            //ValidarToken
            var result = await _http.PostJsonAsync<ResultViewModel>($"{urlApi}/api/Rol/EliminarSP", model);
            return result;
        }
    }
}
