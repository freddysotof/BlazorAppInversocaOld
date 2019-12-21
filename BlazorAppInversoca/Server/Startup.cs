using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using BlazorAppInversoca.DataService.DBContent;
using BlazorAppInversoca.DataService.Interfaces;
using BlazorAppInversoca.DataService.Repositorio;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Text;


namespace BlazorAppInversoca.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews().AddNewtonsoftJson(opt =>
            opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
            services.AddMvc();
            services.AddResponseCompression(opts =>
            {
                opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
                    new[] { "application/octet-stream" });
            });
            services.AddDbContext<BlazorAppInversocaContent>(options =>
           options.UseSqlServer(
           Configuration.GetConnectionString("DefaultConnection"))
           .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
            services.AddControllers();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                 .AddJwtBearer(options =>
                  options.TokenValidationParameters = new TokenValidationParameters
                  {
                      ValidateIssuer = true,
                      ValidateAudience = true,
                      ValidateLifetime = true,
                      ValidateIssuerSigningKey = true,
                      ValidIssuer = "https://localhost:51663/",
                      ValidAudience = "https://localhost:51663/",
                      IssuerSigningKey = new SymmetricSecurityKey(
                      Encoding.UTF8.GetBytes("clave-secreta-api")),
                      ClockSkew = TimeSpan.Zero
                  });
            services.AddTransient<IPropiedad, PropiedadRepositorio>();
            services.AddTransient<IOperacion, OperacionRepositorio>();
            services.AddTransient<IUsuarioRol, UsuarioRolRepositorio>();
            services.AddTransient<IRol, RolRepositorio>();
            services.AddTransient<IUsuario, UsuarioRepositorio>();
            services.AddTransient<IRolOperacion, RolOperacionRepositorio>();
            services.AddTransient<IModulo, ModuloRepositorio>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseResponseCompression();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBlazorDebugging();
            }

            app.UseStaticFiles();
            app.UseClientSideBlazorFiles<Client.Startup>();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapFallbackToClientSideBlazor<Client.Startup>("index.html");
            });
        }
    }
}
