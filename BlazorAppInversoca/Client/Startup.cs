using Blazor.Extensions.Storage;
using BlazorAppInversoca.Client.Servicios;
using MatBlazor;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;

namespace BlazorAppInversoca.Client
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<HttpClient>();
            services.AddTransient<ServicioPropiedad>();
            services.AddTransient<ServicioModulo>();
            services.AddTransient<ServicioOperacion>();
            services.AddTransient<ServicioRol>();
            services.AddTransient<ServicioUsuario>();
            services.AddTransient<ServicioRolOperacion>();
            services.AddTransient<ServicioUsuarioRol>();
            //services.AddSingleton<Validations>();
            //services.AddSingleton<ContactosValidations>();
            // Add auth services
            services.AddAuthorizationCore();
            services.AddScoped<AuthenticationStateProvider, ServiceAutenticacionProveedor>();
            //
            services.AddStorage();
            services.AddMatToaster(config =>
            {
                config.Position = MatToastPosition.TopCenter;
                config.PreventDuplicates = true;
                config.NewestOnTop = true;
                config.ShowCloseButton = true;
                config.MaximumOpacity = 95;
                config.VisibleStateDuration = 3000;
            });
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
