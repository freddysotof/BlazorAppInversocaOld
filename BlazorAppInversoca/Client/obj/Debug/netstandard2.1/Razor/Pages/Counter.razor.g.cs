#pragma checksum "C:\Users\fredd\Desktop\VS\BlazorAppInversoca\BlazorAppInversoca\Client\Pages\Counter.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9d392e124d0d523bbcceed40d7ea1a94eee4d522"
// <auto-generated/>
#pragma warning disable 1591
namespace BlazorAppInversoca.Client.Pages
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
    [Microsoft.AspNetCore.Components.RouteAttribute("/counter")]
    public partial class Counter : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h1>Counter</h1>\r\n\r\n");
            __builder.OpenElement(1, "p");
            __builder.AddContent(2, "Current count: ");
            __builder.AddContent(3, 
#nullable restore
#line 5 "C:\Users\fredd\Desktop\VS\BlazorAppInversoca\BlazorAppInversoca\Client\Pages\Counter.razor"
                   currentCount

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(4, "\r\n\r\n");
            __builder.OpenElement(5, "button");
            __builder.AddAttribute(6, "class", "btn btn-primary");
            __builder.AddAttribute(7, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 7 "C:\Users\fredd\Desktop\VS\BlazorAppInversoca\BlazorAppInversoca\Client\Pages\Counter.razor"
                                          IncrementCount

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(8, "Click me");
            __builder.CloseElement();
            __builder.AddMarkupContent(9, "\r\n");
            __builder.OpenComponent<MatBlazor.MatButton>(10);
            __builder.AddAttribute(11, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddContent(12, " Hola");
            }
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
#nullable restore
#line 9 "C:\Users\fredd\Desktop\VS\BlazorAppInversoca\BlazorAppInversoca\Client\Pages\Counter.razor"
       
    private int currentCount = 0;

    private void IncrementCount()
    {
        currentCount++;
    }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
