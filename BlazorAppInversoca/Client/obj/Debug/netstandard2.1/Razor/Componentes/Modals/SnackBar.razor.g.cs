#pragma checksum "C:\Users\fredd\Desktop\VS\BlazorAppInversoca\BlazorAppInversoca\Client\Componentes\Modals\SnackBar.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a39bd689c00f4d9c74d65645598ec1fa01941e50"
// <auto-generated/>
#pragma warning disable 1591
namespace BlazorAppInversoca.Client.Componentes.Modals
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
    public partial class SnackBar : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<MatBlazor.MatSnackbar>(0);
            __builder.AddAttribute(1, "Stacked", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 1 "C:\Users\fredd\Desktop\VS\BlazorAppInversoca\BlazorAppInversoca\Client\Componentes\Modals\SnackBar.razor"
                                             true

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(2, "IsOpen", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 1 "C:\Users\fredd\Desktop\VS\BlazorAppInversoca\BlazorAppInversoca\Client\Componentes\Modals\SnackBar.razor"
                            isOpen

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(3, "IsOpenChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.Boolean>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.Boolean>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => isOpen = __value, isOpen))));
            __builder.AddAttribute(4, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(5, "\r\n    ");
                __builder2.OpenComponent<MatBlazor.MatIconButton>(6);
                __builder2.AddAttribute(7, "OnClick", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 2 "C:\Users\fredd\Desktop\VS\BlazorAppInversoca\BlazorAppInversoca\Client\Componentes\Modals\SnackBar.razor"
                               ()=>Cerrar.InvokeAsync("Cerrando SB")

#line default
#line hidden
#nullable disable
                )));
                __builder2.AddAttribute(8, "Icon", "close");
                __builder2.AddAttribute(9, "Style", "position: absolute; right: 0; color:whitesmoke");
                __builder2.AddAttribute(10, "Class", "btn");
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(11, "\r\n    <br>\r\n    ");
                __builder2.OpenComponent<MatBlazor.MatSnackbarContent>(12);
                __builder2.AddAttribute(13, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.AddMarkupContent(14, "\r\n        ");
                    __builder3.AddContent(15, 
#nullable restore
#line 7 "C:\Users\fredd\Desktop\VS\BlazorAppInversoca\BlazorAppInversoca\Client\Componentes\Modals\SnackBar.razor"
         Titulo

#line default
#line hidden
#nullable disable
                    );
                    __builder3.AddMarkupContent(16, "\r\n    ");
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(17, "\r\n    ");
                __builder2.OpenComponent<MatBlazor.MatSnackbarActions>(18);
                __builder2.AddAttribute(19, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.AddMarkupContent(20, "\r\n    ");
                    __builder3.OpenComponent<MatBlazor.MatButton>(21);
                    __builder3.AddAttribute(22, "Type", "button");
                    __builder3.AddAttribute(23, "OnClick", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 10 "C:\Users\fredd\Desktop\VS\BlazorAppInversoca\BlazorAppInversoca\Client\Componentes\Modals\SnackBar.razor"
                                        ()=>Cerrar.InvokeAsync("Cerrando SB")

#line default
#line hidden
#nullable disable
                    )));
                    __builder3.AddAttribute(24, "Raised", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 10 "C:\Users\fredd\Desktop\VS\BlazorAppInversoca\BlazorAppInversoca\Client\Componentes\Modals\SnackBar.razor"
                                                                                        true

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(25, "Class", "btn");
                    __builder3.AddAttribute(26, "Style", "margin-right: 5px;");
                    __builder3.AddAttribute(27, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder4) => {
                        __builder4.AddContent(28, "Cerrar");
                    }
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(29, "\r\n\r\n    ");
                    __builder3.OpenComponent<MatBlazor.MatButton>(30);
                    __builder3.AddAttribute(31, "OnClick", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 13 "C:\Users\fredd\Desktop\VS\BlazorAppInversoca\BlazorAppInversoca\Client\Componentes\Modals\SnackBar.razor"
                          ()=>Accion.InvokeAsync("Abriendo SB")

#line default
#line hidden
#nullable disable
                    )));
                    __builder3.AddAttribute(32, "Raised", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 13 "C:\Users\fredd\Desktop\VS\BlazorAppInversoca\BlazorAppInversoca\Client\Componentes\Modals\SnackBar.razor"
                                                                          true

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(33, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder4) => {
                        __builder4.AddContent(34, 
#nullable restore
#line 13 "C:\Users\fredd\Desktop\VS\BlazorAppInversoca\BlazorAppInversoca\Client\Componentes\Modals\SnackBar.razor"
                                                                                 AccionLabel

#line default
#line hidden
#nullable disable
                        );
                    }
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(35, "\r\n          \r\n            ");
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(36, "\r\n");
            }
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
#nullable restore
#line 18 "C:\Users\fredd\Desktop\VS\BlazorAppInversoca\BlazorAppInversoca\Client\Componentes\Modals\SnackBar.razor"
      
    [Parameter]
    public bool isOpen { get; set; }
    [Parameter]
    public string Titulo { get; set; }
    [Parameter]
    public string AccionLabel { get; set; }
    [Parameter]
    public EventCallback<string> Accion { get; set; }
    [Parameter]
    public EventCallback<string> Cerrar { get; set; }



#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
