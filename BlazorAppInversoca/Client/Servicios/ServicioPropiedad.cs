using Microsoft.AspNetCore.Components;
using BlazorAppInversoca.Shared.EFModels;
using BlazorAppInversoca.Shared.Token___Result_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BlazorAppInversoca.Shared.ViewModels;
using Blazor.Extensions.Storage;

namespace BlazorAppInversoca.Client.Servicios
{
    public class ServicioPropiedad
    {
        private readonly HttpClient _http;
        private readonly string urlApi = "https://localhost:51663";
        private readonly LocalStorage _LocalStorage;
        private PropiedadViewModel PropiedadViewModel;
        public ServicioPropiedad(HttpClient httpserv,LocalStorage _localstrg)
        {
            _LocalStorage = _localstrg;
            _http = httpserv;
        }

        //Metodos de Busquedas
        public async Task<List<Propiedad>> BuscarEF()
        {
            //ValidarToken
            var result = await _http.GetJsonAsync<List<Propiedad>>($"{urlApi}/api/Propiedad/BuscarEF");
            return result;
        }
        public async Task<List<PropiedadView>> BuscarSP(bool isAll = true,bool isActive=true)
        {
            //ValidarToken
            var result = await _http.GetJsonAsync<List<PropiedadView>>($"{urlApi}/api/Propiedad/BuscarSP/Todos/{isAll}/Activo/{isActive}");
            return result;
        }
        public async Task<PropiedadView> BuscarSP_x_Id(bool isAll = true, bool isActive = true,int Id = 0)
        {
            //ValidarToken
            var result = await _http.GetJsonAsync<PropiedadView>($"{urlApi}/api/Propiedad/BuscarSP/Todos/{isAll}/Activo/{isActive}/Id/{Id}");
            return result;
        }
        public async Task<PropiedadView> BuscarSP_x_Nombre(bool isAll = true, bool isActive = true, string nombre = "")
        {
            //ValidarToken
            var result = await _http.GetJsonAsync<PropiedadView>($"{urlApi}/api/Propiedad/BuscarSP/Todos/{isAll}/Activo/{isActive}/Nombre/{nombre}");
            return result;
        }
        public async Task<List<PropiedadViewModel>> BuscarSP_Registros()
        {
            //ValidarToken
            var result = await _http.GetJsonAsync<List<PropiedadViewModel>>($"{urlApi}/api/Propiedad/BuscarSP/Registro");
            return result;
        }
        public async Task<PropiedadViewModel> BuscarSP_Registro_x_Id(int Id = 0)
        {
            //ValidarToken
            var result = await _http.GetJsonAsync<PropiedadViewModel>($"{urlApi}/api/Propiedad/BuscarSP/Registro/Id/{Id}");
            return result;
        }
        public async Task<PropiedadViewModel> BuscarSP_Registro_x_Nombre(string nombre="")
        {
            //ValidarToken
            var result = await _http.GetJsonAsync<PropiedadViewModel>($"{urlApi}/api/Propiedad/BuscarSP/Registro/Nombre/{nombre}");
            return result;
        }
        // Filtrar Registros
        public async Task<List<Propiedad>> FiltrarEF(string filtro, string value)
        {
            //ValidarToken
            var result = await _http.GetJsonAsync<List<Propiedad>>($"{urlApi}/api/Propiedad/FiltrarEF/{filtro}/{value}");
            return result;
        }
        public async Task<List<PropiedadView>> FiltrarSP(bool isAll, bool isActive, string filtro, string value)
        {
            //ValidarToken
            var result = await _http.GetJsonAsync<List<PropiedadView>>($"{urlApi}/api/Propiedad/FiltrarSP/Todos/{isAll}/Activo/{isActive}/{filtro}/{value}");
            return result;
        }
        // Metodos para Crear Registros
        public async Task<ResultViewModel> RegistrarEF(Propiedad model)
        {
            //ValidarToken
            var result = await _http.PostJsonAsync<ResultViewModel>($"{urlApi}/api/Propiedad/CrearEF", model);
            return result;
        }
        public async Task<ResultViewModel> RegistrarSP(PropiedadViewModel model)
        {
            //ValidarToken
            var result = await _http.PostJsonAsync<ResultViewModel>($"{urlApi}/api/Propiedad/CrearSP", model);
            return result;
        }

        // Metodos para Modificar o Editar Registros
        public async Task<ResultViewModel> ModificarEF(Propiedad model)
        {
            //ValidarToken
            var result = await _http.PutJsonAsync<ResultViewModel>($"{urlApi}/api/Propiedad/ModificarEF", model);
            return result;
        }
        public async Task<ResultViewModel> ModificarSP(PropiedadViewModel model)
        {  
            //ValidarToken
            var result = await _http.PutJsonAsync<ResultViewModel>($"{urlApi}/api/Propiedad/ModificarSP", model);
            return result;
        }
        // Metodos para Activar Registros
        public async Task<ResultViewModel> ActivarEF(Propiedad model)
        {
            //ValidarToken
            var result = await _http.PutJsonAsync<ResultViewModel>($"{urlApi}/api/Propiedad/ModificarEF", model);
            return result;
        }
        public async Task<ResultViewModel> ActivarSP(int id = 0, string nombre="")
        {
            //ValidarToken
            if (id == 0) { PropiedadViewModel = await BuscarSP_Registro_x_Nombre(nombre); }
            else { PropiedadViewModel = await BuscarSP_Registro_x_Id(id); }
            var result = await _http.PutJsonAsync<ResultViewModel>($"{urlApi}/api/Propiedad/ModificarSP", PropiedadViewModel);
            return result;
        }
        // Metodos Para Desactivar Registros
        public async Task<ResultViewModel> DesactivarEF(int IdPropiedad)
        {
            //ValidarToken
            var Propiedades = await BuscarEF();
            var Propiedad = Propiedades.Where(a => a.IdPropiedad == IdPropiedad).SingleOrDefault();
            var result = await _http.PutJsonAsync<ResultViewModel>($"{urlApi}/api/Propiedad/DesactivarEF", Propiedad);
            return result;
        }
        public async Task<ResultViewModel> DesactivarSP(int IdCliente)
        {
            //ValidarToken
            PropiedadViewModel = await BuscarSP_Registro_x_Id(IdCliente);
            var result = await _http.PutJsonAsync<ResultViewModel>($"{urlApi}/api/Propiedad/DesactivarSP", PropiedadViewModel);
            return result;
        }
        // Metodos Para Eliminar Registros
        public async Task<ResultViewModel> EliminarEF(Propiedad model)
        {
            //ValidarToken
            var result = await _http.PostJsonAsync<ResultViewModel>($"{urlApi}/api/Propiedad/EliminarEF", model);
            return result;
        }
        public async Task<ResultViewModel> EliminarSP(PropiedadView model)
        {
            //ValidarToken
            var result = await _http.PostJsonAsync<ResultViewModel>($"{urlApi}/api/Propiedad/EliminarSP", model);
            return result;
        }
    }
}
