using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;
using Blazor.Extensions.Storage;
using BlazorAppInversoca.Shared.EFModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorAppInversoca.Client.Servicios
{
    public class ServiceAutenticacionProveedor : AuthenticationStateProvider
    {
        private readonly HttpClient _http;
        private readonly string urlApi = "http://localhost:51663";
        private readonly LocalStorage _LocalStorage;

        public ServiceAutenticacionProveedor(HttpClient httpClient, LocalStorage localStorage)
        {
            _LocalStorage = localStorage;
            _http = httpClient;
        }
        //public async Task ValidateToken()
        //{
        //    string token = await _LocalStorage.GetItem<string>("token");
        //    _http.DefaultRequestHeaders.Authorization =
        //    new AuthenticationHeaderValue("Bearer", token);

        //}
        public async Task Logout()
        {
            //ValidarToken
            var userInfo = await _http.GetJsonAsync<UserInfo>($"{urlApi}/api/Usuario/Logout");
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            //ValidarToken
            var userInfo = await _http.GetJsonAsync<UserInfo>($"{urlApi}/api/Usuario/VerificarUsuario");

            var identity = userInfo.IsAuthenticated
                ? new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, userInfo.UserName) }, "serverauth")
                : new ClaimsIdentity();

            return new AuthenticationState(new ClaimsPrincipal(identity));
        }
    }
}
