#pragma checksum "C:\Users\fredd\Desktop\VS\BlazorAppInversoca\BlazorAppInversoca\Client\Shared\NavMenu.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fcf59c769624068111a57e12da22b7f1bf0cd8fa"
// <auto-generated/>
#pragma warning disable 1591
namespace BlazorAppInversoca.Client.Shared
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\fredd\Desktop\VS\BlazorAppInversoca\BlazorAppInversoca\Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\fredd\Desktop\VS\BlazorAppInversoca\BlazorAppInversoca\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\fredd\Desktop\VS\BlazorAppInversoca\BlazorAppInversoca\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\fredd\Desktop\VS\BlazorAppInversoca\BlazorAppInversoca\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\fredd\Desktop\VS\BlazorAppInversoca\BlazorAppInversoca\Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\fredd\Desktop\VS\BlazorAppInversoca\BlazorAppInversoca\Client\_Imports.razor"
using BlazorAppInversoca.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\fredd\Desktop\VS\BlazorAppInversoca\BlazorAppInversoca\Client\_Imports.razor"
using BlazorAppInversoca.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\fredd\Desktop\VS\BlazorAppInversoca\BlazorAppInversoca\Client\_Imports.razor"
using BlazorAppInversoca.Shared.Components_Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\fredd\Desktop\VS\BlazorAppInversoca\BlazorAppInversoca\Client\_Imports.razor"
using BlazorAppInversoca.Shared.EFModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\fredd\Desktop\VS\BlazorAppInversoca\BlazorAppInversoca\Client\_Imports.razor"
using BlazorAppInversoca.Shared.Helpers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\fredd\Desktop\VS\BlazorAppInversoca\BlazorAppInversoca\Client\_Imports.razor"
using BlazorAppInversoca.Shared.Token___Result_Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\fredd\Desktop\VS\BlazorAppInversoca\BlazorAppInversoca\Client\_Imports.razor"
using BlazorAppInversoca.Shared.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\fredd\Desktop\VS\BlazorAppInversoca\BlazorAppInversoca\Client\_Imports.razor"
using BlazorAppInversoca.Client.Servicios;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\fredd\Desktop\VS\BlazorAppInversoca\BlazorAppInversoca\Client\_Imports.razor"
using BlazorAppInversoca.Client.Componentes;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Users\fredd\Desktop\VS\BlazorAppInversoca\BlazorAppInversoca\Client\_Imports.razor"
using BlazorAppInversoca.Client.Componentes.Body;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "C:\Users\fredd\Desktop\VS\BlazorAppInversoca\BlazorAppInversoca\Client\_Imports.razor"
using BlazorAppInversoca.Client.Componentes.Buttons;

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "C:\Users\fredd\Desktop\VS\BlazorAppInversoca\BlazorAppInversoca\Client\_Imports.razor"
using BlazorAppInversoca.Client.Componentes.Formularios;

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "C:\Users\fredd\Desktop\VS\BlazorAppInversoca\BlazorAppInversoca\Client\_Imports.razor"
using BlazorAppInversoca.Client.Componentes.Loader;

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "C:\Users\fredd\Desktop\VS\BlazorAppInversoca\BlazorAppInversoca\Client\_Imports.razor"
using BlazorAppInversoca.Client.Componentes.Modals;

#line default
#line hidden
#nullable disable
#nullable restore
#line 20 "C:\Users\fredd\Desktop\VS\BlazorAppInversoca\BlazorAppInversoca\Client\_Imports.razor"
using BlazorAppInversoca.Client.Componentes.Navigator;

#line default
#line hidden
#nullable disable
#nullable restore
#line 21 "C:\Users\fredd\Desktop\VS\BlazorAppInversoca\BlazorAppInversoca\Client\_Imports.razor"
using BlazorAppInversoca.Client.Componentes.Tables;

#line default
#line hidden
#nullable disable
#nullable restore
#line 22 "C:\Users\fredd\Desktop\VS\BlazorAppInversoca\BlazorAppInversoca\Client\_Imports.razor"
using BlazorAppInversoca.Client.Componentes.Themes;

#line default
#line hidden
#nullable disable
#nullable restore
#line 23 "C:\Users\fredd\Desktop\VS\BlazorAppInversoca\BlazorAppInversoca\Client\_Imports.razor"
using MatBlazor;

#line default
#line hidden
#nullable disable
    public partial class NavMenu : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "top-row pl-4 navbar navbar-dark");
            __builder.AddMarkupContent(2, "\r\n    ");
            __builder.AddMarkupContent(3, "<a class=\"navbar-brand\" href>BlazorAppInversoca</a>\r\n    ");
            __builder.OpenElement(4, "button");
            __builder.AddAttribute(5, "class", "navbar-toggler");
            __builder.AddAttribute(6, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 3 "C:\Users\fredd\Desktop\VS\BlazorAppInversoca\BlazorAppInversoca\Client\Shared\NavMenu.razor"
                                             ToggleNavMenu

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(7, "\r\n        <span class=\"navbar-toggler-icon\"></span>\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(8, "\r\n");
            __builder.CloseElement();
            __builder.AddMarkupContent(9, "\r\n\r\n");
            __builder.OpenElement(10, "div");
            __builder.AddAttribute(11, "class", 
#nullable restore
#line 8 "C:\Users\fredd\Desktop\VS\BlazorAppInversoca\BlazorAppInversoca\Client\Shared\NavMenu.razor"
             NavMenuCssClass

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(12, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 8 "C:\Users\fredd\Desktop\VS\BlazorAppInversoca\BlazorAppInversoca\Client\Shared\NavMenu.razor"
                                        ToggleNavMenu

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(13, "\r\n    ");
            __builder.OpenElement(14, "ul");
            __builder.AddAttribute(15, "class", "nav flex-column");
            __builder.AddMarkupContent(16, "\r\n        ");
            __builder.OpenElement(17, "li");
            __builder.AddAttribute(18, "class", "nav-item px-3");
            __builder.AddMarkupContent(19, "\r\n            ");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Routing.NavLink>(20);
            __builder.AddAttribute(21, "class", "nav-link");
            __builder.AddAttribute(22, "href", "");
            __builder.AddAttribute(23, "Match", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.Routing.NavLinkMatch>(
#nullable restore
#line 11 "C:\Users\fredd\Desktop\VS\BlazorAppInversoca\BlazorAppInversoca\Client\Shared\NavMenu.razor"
                                                     NavLinkMatch.All

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(24, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(25, "\r\n                <span class=\"oi oi-home\" aria-hidden=\"true\"></span> Home\r\n            ");
            }
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(26, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(27, "\r\n        ");
            __builder.OpenElement(28, "li");
            __builder.AddAttribute(29, "class", "nav-item px-3");
            __builder.AddMarkupContent(30, "\r\n            ");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Routing.NavLink>(31);
            __builder.AddAttribute(32, "class", "nav-link");
            __builder.AddAttribute(33, "href", "counter");
            __builder.AddAttribute(34, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(35, "\r\n                <span class=\"oi oi-plus\" aria-hidden=\"true\"></span> Counter\r\n            ");
            }
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(36, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(37, "\r\n        ");
            __builder.OpenElement(38, "li");
            __builder.AddAttribute(39, "class", "nav-item px-3");
            __builder.AddMarkupContent(40, "\r\n            ");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Routing.NavLink>(41);
            __builder.AddAttribute(42, "class", "nav-link");
            __builder.AddAttribute(43, "href", "fetchdata");
            __builder.AddAttribute(44, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(45, "\r\n                <span class=\"oi oi-list-rich\" aria-hidden=\"true\"></span> Fetch data\r\n            ");
            }
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(46, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(47, "\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(48, "\r\n");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 28 "C:\Users\fredd\Desktop\VS\BlazorAppInversoca\BlazorAppInversoca\Client\Shared\NavMenu.razor"
       
    private bool collapseNavMenu = true;

    private string NavMenuCssClass => collapseNavMenu ? "collapse" : null;

    private void ToggleNavMenu()
    {
        collapseNavMenu = !collapseNavMenu;
    }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
