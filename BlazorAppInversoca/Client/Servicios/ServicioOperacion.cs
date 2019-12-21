using Blazor.Extensions.Storage;
using BlazorAppInversoca.Shared.EFModels;
using BlazorAppInversoca.Shared.Token___Result_Models;
using BlazorAppInversoca.Shared.ViewModels;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorAppInversoca.Client.Servicios
{
    public class ServicioOperacion
    {
        private readonly HttpClient _http;
        private readonly string urlApi = "https://localhost:51663";
        private readonly LocalStorage _LocalStorage;
        private OperacionViewModel operacionViewModel;
        public ServicioOperacion(HttpClient httpserv, LocalStorage _localstrg)
        {
            _LocalStorage = _localstrg;
            _http = httpserv;
        }
        //Metodos de Busquedas
        public async Task<List<Operacion>> BuscarEF()
        {
            //ValidarToken
            var result = await _http.GetJsonAsync<List<Operacion>>($"{urlApi}/api/Operacion/BuscarEF");
            return result;
        }
        public async Task<List<OperacionView>> BuscarSP(bool isAll = true, bool isActive = true)
        {
            //ValidarToken
            var result = await _http.GetJsonAsync<List<OperacionView>>($"{urlApi}/api/Operacion/BuscarSP/Todos/{isAll}/Activo/{isActive}");
            return result;
        }
        public async Task<OperacionView> BuscarSP_x_Id(bool isAll = true, bool isActive = true, int Id = 0)
        {
            //ValidarToken
            var result = await _http.GetJsonAsync<OperacionView>($"{urlApi}/api/Operacion/BuscarSP/Todos/{isAll}/Activo/{isActive}/Id/{Id}");
            return result;
        }
        public async Task<OperacionView> BuscarSP_x_Nombre(bool isAll = true, bool isActive = true, string nombre = "")
        {
            //ValidarToken
            var result = await _http.GetJsonAsync<OperacionView>($"{urlApi}/api/Operacion/BuscarSP/Todos/{isAll}/Activo/{isActive}/Nombre/{nombre}");
            return result;
        }
        public async Task<List<OperacionViewModel>> BuscarSP_Registros()
        {
            //ValidarToken
            var result = await _http.GetJsonAsync<List<OperacionViewModel>>($"{urlApi}/api/Operacion/BuscarSP/Registro");
            return result;
        }
        public async Task<OperacionViewModel> BuscarSP_Registro_x_Id(int Id = 0)
        {
            //ValidarToken
            var result = await _http.GetJsonAsync<OperacionViewModel>($"{urlApi}/api/Operacion/BuscarSP/Registro/Id/{Id}");
            return result;
        }
        public async Task<OperacionViewModel> BuscarSP_Registro_x_Nombre(string nombre = "")
        {
            //ValidarToken
            var result = await _http.GetJsonAsync<OperacionViewModel>($"{urlApi}/api/Operacion/BuscarSP/Registro/Nombre/{nombre}");
            return result;
        }
        // Filtrar Registros
        public async Task<List<Operacion>> FiltrarEF(string filtro, string value)
        {
            //ValidarToken
            var result = await _http.GetJsonAsync<List<Operacion>>($"{urlApi}/api/Operacion/FiltrarEF/{filtro}/{value}");
            return result;
        }
        public async Task<List<OperacionView>> FiltrarSP(bool isAll, bool isActive, string filtro, string value)
        {
            //ValidarToken
            var result = await _http.GetJsonAsync<List<OperacionView>>($"{urlApi}/api/Operacion/FiltrarSP/Todos/{isAll}/Activo/{isActive}/{filtro}/{value}");
            return result;
        }
        // Metodos para Crear Registros
        public async Task<ResultViewModel> RegistrarEF(Operacion model)
        {
            //ValidarToken
            var result = await _http.PostJsonAsync<ResultViewModel>($"{urlApi}/api/Operacion/CrearEF", model);
            return result;
        }
        public async Task<ResultViewModel> RegistrarSP(OperacionViewModel model)
        {
            //ValidarToken
            var result = await _http.PostJsonAsync<ResultViewModel>($"{urlApi}/api/Operacion/CrearSP", model);
            return result;
        }

        // Metodos para Modificar o Editar Registros
        public async Task<ResultViewModel> ModificarEF(Operacion model)
        {
            //ValidarToken
            var result = await _http.PutJsonAsync<ResultViewModel>($"{urlApi}/api/Operacion/ModificarEF", model);
            return result;
        }
        public async Task<ResultViewModel> ModificarSP(OperacionViewModel model)
        {
            //ValidarToken
            var result = await _http.PutJsonAsync<ResultViewModel>($"{urlApi}/api/Operacion/ModificarSP", model);
            return result;
        }
        // Metodos para Activar Registros
        public async Task<ResultViewModel> ActivarEF(Operacion model)
        {
            //ValidarToken
            var result = await _http.PutJsonAsync<ResultViewModel>($"{urlApi}/api/Operacion/ModificarEF", model);
            return result;
        }
        public async Task<ResultViewModel> ActivarSP(int id = 0, string nombre = "")
        {
            //ValidarToken
            if (id == 0) { operacionViewModel = await BuscarSP_Registro_x_Nombre(nombre); }
            else { operacionViewModel = await BuscarSP_Registro_x_Id(id); }
            var result = await _http.PutJsonAsync<ResultViewModel>($"{urlApi}/api/Operacion/ModificarSP", operacionViewModel);
            return result;
        }
        // Metodos Para Desactivar Registros
        public async Task<ResultViewModel> DesactivarEF(int IdOperacion)
        {
            //ValidarToken
            var Operacions = await BuscarEF();
            var Operacion = Operacions.Where(a => a.IdOperacion == IdOperacion).SingleOrDefault();
            var result = await _http.PutJsonAsync<ResultViewModel>($"{urlApi}/api/Operacion/DesactivarEF", Operacion);
            return result;
        }
        public async Task<ResultViewModel> DesactivarSP(int IdCliente)
        {
            //ValidarToken
            operacionViewModel = await BuscarSP_Registro_x_Id(IdCliente);
            var result = await _http.PutJsonAsync<ResultViewModel>($"{urlApi}/api/Operacion/DesactivarSP", operacionViewModel);
            return result;
        }
        // Metodos Para Eliminar Registros
        public async Task<ResultViewModel> EliminarEF(Operacion model)
        {
            //ValidarToken
            var result = await _http.PostJsonAsync<ResultViewModel>($"{urlApi}/api/Operacion/EliminarEF", model);
            return result;
        }
        public async Task<ResultViewModel> EliminarSP(OperacionView model)
        {
            //ValidarToken
            var result = await _http.PostJsonAsync<ResultViewModel>($"{urlApi}/api/Operacion/EliminarSP", model);
            return result;
        }
    }
}
