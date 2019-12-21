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
    public class ServicioModulo
    {
        private readonly HttpClient _http;
        private readonly string urlApi = "https://localhost:51663";
        private readonly LocalStorage _LocalStorage;
        private ModuloViewModel moduloViewModel;
        public ServicioModulo(HttpClient httpserv, LocalStorage _localstrg)
        {
            _LocalStorage = _localstrg;
            _http = httpserv;
        }
        //Metodos de Busquedas
        public async Task<List<Modulo>> BuscarEF()
        {
            //ValidarToken
            var result = await _http.GetJsonAsync<List<Modulo>>($"{urlApi}/api/Modulo/BuscarEF");
            return result;
        }
        public async Task<List<ModuloView>> BuscarSP(bool isAll = true, bool isActive = true)
        {
            //ValidarToken
            var result = await _http.GetJsonAsync<List<ModuloView>>($"{urlApi}/api/Modulo/BuscarSP/Todos/{isAll}/Activo/{isActive}");
            return result;
        }
        public async Task<ModuloView> BuscarSP_x_Id(bool isAll = true, bool isActive = true, int Id = 0)
        {
            //ValidarToken
            var result = await _http.GetJsonAsync<ModuloView>($"{urlApi}/api/Modulo/BuscarSP/Todos/{isAll}/Activo/{isActive}/Id/{Id}");
            return result;
        }
        public async Task<ModuloView> BuscarSP_x_Nombre(bool isAll = true, bool isActive = true, string nombre = "")
        {
            //ValidarToken
            var result = await _http.GetJsonAsync<ModuloView>($"{urlApi}/api/Modulo/BuscarSP/Todos/{isAll}/Activo/{isActive}/Nombre/{nombre}");
            return result;
        }
        public async Task<List<ModuloViewModel>> BuscarSP_Registros()
        {
            //ValidarToken
            var result = await _http.GetJsonAsync<List<ModuloViewModel>>($"{urlApi}/api/Modulo/BuscarSP/Registro");
            return result;
        }
        public async Task<ModuloViewModel> BuscarSP_Registro_x_Id(int Id = 0)
        {
            //ValidarToken
            var result = await _http.GetJsonAsync<ModuloViewModel>($"{urlApi}/api/Modulo/BuscarSP/Registro/Id/{Id}");
            return result;
        }
        public async Task<ModuloViewModel> BuscarSP_Registro_x_Nombre(string nombre = "")
        {
            //ValidarToken
            var result = await _http.GetJsonAsync<ModuloViewModel>($"{urlApi}/api/Modulo/BuscarSP/Registro/Nombre/{nombre}");
            return result;
        }
        // Filtrar Registros
        public async Task<List<Modulo>> FiltrarEF(string filtro, string value)
        {
            //ValidarToken
            var result = await _http.GetJsonAsync<List<Modulo>>($"{urlApi}/api/Modulo/FiltrarEF/{filtro}/{value}");
            return result;
        }
        public async Task<List<ModuloView>> FiltrarSP(bool isAll, bool isActive, string filtro, string value)
        {
            //ValidarToken
            var result = await _http.GetJsonAsync<List<ModuloView>>($"{urlApi}/api/Modulo/FiltrarSP/Todos/{isAll}/Activo/{isActive}/{filtro}/{value}");
            return result;
        }
        // Metodos para Crear Registros
        public async Task<ResultViewModel> RegistrarEF(Modulo model)
        {
            //ValidarToken
            var result = await _http.PostJsonAsync<ResultViewModel>($"{urlApi}/api/Modulo/CrearEF", model);
            return result;
        }
        public async Task<ResultViewModel> RegistrarSP(ModuloViewModel model)
        {
            //ValidarToken
            var result = await _http.PostJsonAsync<ResultViewModel>($"{urlApi}/api/Modulo/CrearSP", model);
            return result;
        }

        // Metodos para Modificar o Editar Registros
        public async Task<ResultViewModel> ModificarEF(Modulo model)
        {
            //ValidarToken
            var result = await _http.PutJsonAsync<ResultViewModel>($"{urlApi}/api/Modulo/ModificarEF", model);
            return result;
        }
        public async Task<ResultViewModel> ModificarSP(ModuloViewModel model)
        {
            //ValidarToken
            var result = await _http.PutJsonAsync<ResultViewModel>($"{urlApi}/api/Modulo/ModificarSP", model);
            return result;
        }
        // Metodos para Activar Registros
        public async Task<ResultViewModel> ActivarEF(Modulo model)
        {
            //ValidarToken
            var result = await _http.PutJsonAsync<ResultViewModel>($"{urlApi}/api/Modulo/ModificarEF", model);
            return result;
        }
        public async Task<ResultViewModel> ActivarSP(int id = 0, string nombre = "")
        {
            //ValidarToken
            if (id == 0) { moduloViewModel = await BuscarSP_Registro_x_Nombre(nombre); }
            else { moduloViewModel = await BuscarSP_Registro_x_Id(id); }
            var result = await _http.PutJsonAsync<ResultViewModel>($"{urlApi}/api/Modulo/ModificarSP", moduloViewModel);
            return result;
        }
        // Metodos Para Desactivar Registros
        public async Task<ResultViewModel> DesactivarEF(int IdModulo)
        {
            //ValidarToken
            var Modulos = await BuscarEF();
            var Modulo = Modulos.Where(a => a.IdModulo == IdModulo).SingleOrDefault();
            var result = await _http.PutJsonAsync<ResultViewModel>($"{urlApi}/api/Modulo/DesactivarEF", Modulo);
            return result;
        }
        public async Task<ResultViewModel> DesactivarSP(int IdCliente)
        {
            //ValidarToken
            moduloViewModel = await BuscarSP_Registro_x_Id(IdCliente);
            var result = await _http.PutJsonAsync<ResultViewModel>($"{urlApi}/api/Modulo/DesactivarSP", moduloViewModel);
            return result;
        }
        // Metodos Para Eliminar Registros
        public async Task<ResultViewModel> EliminarEF(Modulo model)
        {
            //ValidarToken
            var result = await _http.PostJsonAsync<ResultViewModel>($"{urlApi}/api/Modulo/EliminarEF", model);
            return result;
        }
        public async Task<ResultViewModel> EliminarSP(ModuloView model)
        {
            //ValidarToken
            var result = await _http.PostJsonAsync<ResultViewModel>($"{urlApi}/api/Modulo/EliminarSP", model);
            return result;
        }
    }
}
