#pragma checksum "C:\Users\fredd\Desktop\VS\BlazorAppInversoca\BlazorAppInversoca\Client\Componentes\Formularios\OperacionForm.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2ef35204ef436341109289e8863213b3c9e41fae"
// <auto-generated/>
#pragma warning disable 1591
namespace BlazorAppInversoca.Client.Componentes.Formularios
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
    public partial class OperacionForm : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "row");
            __builder.AddMarkupContent(2, "\r\n    ");
            __builder.OpenElement(3, "div");
            __builder.AddAttribute(4, "class", "col-xs-12 col-md-5 offset-1");
            __builder.AddMarkupContent(5, "\r\n        ");
            __builder.OpenComponent<MatBlazor.MatStringField>(6);
            __builder.AddAttribute(7, "Label", "Nombre de la Operacion");
            __builder.AddAttribute(8, "Outlined", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 4 "C:\Users\fredd\Desktop\VS\BlazorAppInversoca\BlazorAppInversoca\Client\Componentes\Formularios\OperacionForm.razor"
                                                                                            true

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(9, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 4 "C:\Users\fredd\Desktop\VS\BlazorAppInversoca\BlazorAppInversoca\Client\Componentes\Formularios\OperacionForm.razor"
                                     model.Nombre

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(10, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => model.Nombre = __value, model.Nombre))));
            __builder.AddAttribute(11, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => model.Nombre));
            __builder.CloseComponent();
            __builder.AddMarkupContent(12, "\r\n        ");
            __Blazor.BlazorAppInversoca.Client.Componentes.Formularios.OperacionForm.TypeInference.CreateValidationMessage_0(__builder, 13, 14, 
#nullable restore
#line 5 "C:\Users\fredd\Desktop\VS\BlazorAppInversoca\BlazorAppInversoca\Client\Componentes\Formularios\OperacionForm.razor"
                                  () => model.Nombre

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(15, "\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(16, "\r\n    ");
            __builder.OpenElement(17, "div");
            __builder.AddAttribute(18, "class", "col-xs-12 col-md-5 offset-1");
            __builder.AddMarkupContent(19, "\r\n");
#nullable restore
#line 8 "C:\Users\fredd\Desktop\VS\BlazorAppInversoca\BlazorAppInversoca\Client\Componentes\Formularios\OperacionForm.razor"
         if (!isModuloReadOnly)
        {

#line default
#line hidden
#nullable disable
            __builder.AddContent(20, "            ");
            __builder.OpenComponent<MatBlazor.MatSelect<int>>(21);
            __builder.AddAttribute(22, "Enhanced", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 10 "C:\Users\fredd\Desktop\VS\BlazorAppInversoca\BlazorAppInversoca\Client\Componentes\Formularios\OperacionForm.razor"
                                  true

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(23, "Label", "Elegir Modulo");
            __builder.AddAttribute(24, "Outlined", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 10 "C:\Users\fredd\Desktop\VS\BlazorAppInversoca\BlazorAppInversoca\Client\Componentes\Formularios\OperacionForm.razor"
                                                                        true

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(25, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<int>(
#nullable restore
#line 10 "C:\Users\fredd\Desktop\VS\BlazorAppInversoca\BlazorAppInversoca\Client\Componentes\Formularios\OperacionForm.razor"
                                                                                                        model.IdModulo

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(26, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<int>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<int>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => model.IdModulo = __value, model.IdModulo))));
            __builder.AddAttribute(27, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<int>>>(() => model.IdModulo));
            __builder.AddAttribute(28, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(29, "\r\n");
#nullable restore
#line 11 "C:\Users\fredd\Desktop\VS\BlazorAppInversoca\BlazorAppInversoca\Client\Componentes\Formularios\OperacionForm.razor"
                 foreach (var modulo in ModulosView)
                {

#line default
#line hidden
#nullable disable
                __builder2.AddContent(30, "                    ");
                __builder2.OpenComponent<MatBlazor.MatOption<int>>(31);
                __builder2.AddAttribute(32, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<int>(
#nullable restore
#line 13 "C:\Users\fredd\Desktop\VS\BlazorAppInversoca\BlazorAppInversoca\Client\Componentes\Formularios\OperacionForm.razor"
                                                    modulo.IdModulo

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(33, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.AddContent(34, 
#nullable restore
#line 13 "C:\Users\fredd\Desktop\VS\BlazorAppInversoca\BlazorAppInversoca\Client\Componentes\Formularios\OperacionForm.razor"
                                                                      modulo.Nombre

#line default
#line hidden
#nullable disable
                    );
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(35, "\r\n");
#nullable restore
#line 14 "C:\Users\fredd\Desktop\VS\BlazorAppInversoca\BlazorAppInversoca\Client\Componentes\Formularios\OperacionForm.razor"
                }

#line default
#line hidden
#nullable disable
                __builder2.AddContent(36, "            ");
            }
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(37, "\r\n");
#nullable restore
#line 16 "C:\Users\fredd\Desktop\VS\BlazorAppInversoca\BlazorAppInversoca\Client\Componentes\Formularios\OperacionForm.razor"
        }
        else
        {

#line default
#line hidden
#nullable disable
            __builder.AddContent(38, "            ");
            __builder.OpenComponent<MatBlazor.MatStringField>(39);
            __builder.AddAttribute(40, "Label", "Modulo");
            __builder.AddAttribute(41, "Dense", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 19 "C:\Users\fredd\Desktop\VS\BlazorAppInversoca\BlazorAppInversoca\Client\Componentes\Formularios\OperacionForm.razor"
                                                                              true

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(42, "ReadOnly", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 19 "C:\Users\fredd\Desktop\VS\BlazorAppInversoca\BlazorAppInversoca\Client\Componentes\Formularios\OperacionForm.razor"
                                                                                              isModuloReadOnly

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(43, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 19 "C:\Users\fredd\Desktop\VS\BlazorAppInversoca\BlazorAppInversoca\Client\Componentes\Formularios\OperacionForm.razor"
                                         modulo.Nombre

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(44, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => modulo.Nombre = __value, modulo.Nombre))));
            __builder.AddAttribute(45, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => modulo.Nombre));
            __builder.CloseComponent();
            __builder.AddMarkupContent(46, "\r\n");
#nullable restore
#line 20 "C:\Users\fredd\Desktop\VS\BlazorAppInversoca\BlazorAppInversoca\Client\Componentes\Formularios\OperacionForm.razor"
        }

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(47, "\r\n\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(48, "\r\n   \r\n");
            __builder.CloseElement();
            __builder.AddMarkupContent(49, "\r\n");
            __builder.OpenElement(50, "div");
            __builder.AddAttribute(51, "class", "row");
            __builder.AddMarkupContent(52, "\r\n    ");
            __builder.OpenElement(53, "div");
            __builder.AddAttribute(54, "class", "col-xs-12 col-md-5 offset-1");
            __builder.AddMarkupContent(55, "\r\n        ");
            __builder.OpenComponent<MatBlazor.MatStringField>(56);
            __builder.AddAttribute(57, "Label", "Informacion Adicional");
            __builder.AddAttribute(58, "Outlined", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 28 "C:\Users\fredd\Desktop\VS\BlazorAppInversoca\BlazorAppInversoca\Client\Componentes\Formularios\OperacionForm.razor"
                                                                                           true

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(59, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 28 "C:\Users\fredd\Desktop\VS\BlazorAppInversoca\BlazorAppInversoca\Client\Componentes\Formularios\OperacionForm.razor"
                                     model.Nombre

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(60, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => model.Nombre = __value, model.Nombre))));
            __builder.AddAttribute(61, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => model.Nombre));
            __builder.CloseComponent();
            __builder.AddMarkupContent(62, "\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(63, "\r\n    ");
            __builder.OpenElement(64, "div");
            __builder.AddAttribute(65, "class", "col-xs-12 col-md-5 offset-1");
            __builder.AddMarkupContent(66, "\r\n        ");
            __builder.OpenComponent<MatBlazor.MatStringField>(67);
            __builder.AddAttribute(68, "Label", "Informacion Adicional");
            __builder.AddAttribute(69, "Outlined", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 31 "C:\Users\fredd\Desktop\VS\BlazorAppInversoca\BlazorAppInversoca\Client\Componentes\Formularios\OperacionForm.razor"
                                                                                           true

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(70, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 31 "C:\Users\fredd\Desktop\VS\BlazorAppInversoca\BlazorAppInversoca\Client\Componentes\Formularios\OperacionForm.razor"
                                     model.Nombre

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(71, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => model.Nombre = __value, model.Nombre))));
            __builder.AddAttribute(72, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => model.Nombre));
            __builder.CloseComponent();
            __builder.AddMarkupContent(73, "\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(74, "\r\n");
            __builder.CloseElement();
            __builder.AddMarkupContent(75, "\r\n");
            __builder.OpenElement(76, "div");
            __builder.AddAttribute(77, "class", "row");
            __builder.AddAttribute(78, "style", "margin-left:28px");
            __builder.AddMarkupContent(79, "\r\n    ");
            __builder.OpenElement(80, "div");
            __builder.AddAttribute(81, "class", "col-md-12 col-xs-12 text-center");
            __builder.AddMarkupContent(82, "\r\n        ");
            __builder.OpenComponent<BlazorAppInversoca.Client.Componentes.Themes.Theme>(83);
            __builder.AddAttribute(84, "themeColor", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<BlazorAppInversoca.Client.Componentes.Themes.Theme.ThemeColor>(
#nullable restore
#line 36 "C:\Users\fredd\Desktop\VS\BlazorAppInversoca\BlazorAppInversoca\Client\Componentes\Formularios\OperacionForm.razor"
                           Theme.ThemeColor.nuevo

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(85, "Body", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(86, "\r\n                ");
                __builder2.OpenComponent<MatBlazor.MatButton>(87);
                __builder2.AddAttribute(88, "Disabled", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 38 "C:\Users\fredd\Desktop\VS\BlazorAppInversoca\BlazorAppInversoca\Client\Componentes\Formularios\OperacionForm.razor"
                                       btnSave.isEnabled ? false : true

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(89, "Class", "btn-lg");
                __builder2.AddAttribute(90, "Raised", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 39 "C:\Users\fredd\Desktop\VS\BlazorAppInversoca\BlazorAppInversoca\Client\Componentes\Formularios\OperacionForm.razor"
                                                  true

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(91, "Type", "Submit");
                __builder2.AddAttribute(92, "Icon", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 39 "C:\Users\fredd\Desktop\VS\BlazorAppInversoca\BlazorAppInversoca\Client\Componentes\Formularios\OperacionForm.razor"
                                                                             btnSave.icon

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(93, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.AddContent(94, 
#nullable restore
#line 39 "C:\Users\fredd\Desktop\VS\BlazorAppInversoca\BlazorAppInversoca\Client\Componentes\Formularios\OperacionForm.razor"
                                                                                            btnSave.name

#line default
#line hidden
#nullable disable
                    );
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(95, "\r\n            ");
            }
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(96, "\r\n\r\n        ");
            __builder.OpenComponent<BlazorAppInversoca.Client.Componentes.Themes.Theme>(97);
            __builder.AddAttribute(98, "themeColor", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<BlazorAppInversoca.Client.Componentes.Themes.Theme.ThemeColor>(
#nullable restore
#line 43 "C:\Users\fredd\Desktop\VS\BlazorAppInversoca\BlazorAppInversoca\Client\Componentes\Formularios\OperacionForm.razor"
                           Theme.ThemeColor.cancel

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(99, "Body", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(100, "\r\n                ");
                __builder2.OpenComponent<MatBlazor.MatButton>(101);
                __builder2.AddAttribute(102, "Disabled", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 45 "C:\Users\fredd\Desktop\VS\BlazorAppInversoca\BlazorAppInversoca\Client\Componentes\Formularios\OperacionForm.razor"
                                       btnCancel.isEnabled ? false : true

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(103, "OnClick", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 45 "C:\Users\fredd\Desktop\VS\BlazorAppInversoca\BlazorAppInversoca\Client\Componentes\Formularios\OperacionForm.razor"
                                                                                        ()=>CancelOp.InvokeAsync("cancelar")

#line default
#line hidden
#nullable disable
                )));
                __builder2.AddAttribute(104, "Class", "btn-lg");
                __builder2.AddAttribute(105, "Raised", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 46 "C:\Users\fredd\Desktop\VS\BlazorAppInversoca\BlazorAppInversoca\Client\Componentes\Formularios\OperacionForm.razor"
                                   true

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(106, "Type", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 46 "C:\Users\fredd\Desktop\VS\BlazorAppInversoca\BlazorAppInversoca\Client\Componentes\Formularios\OperacionForm.razor"
                                                btnCancel.attribute.Trim()

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(107, "Icon", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 46 "C:\Users\fredd\Desktop\VS\BlazorAppInversoca\BlazorAppInversoca\Client\Componentes\Formularios\OperacionForm.razor"
                                                                                   btnCancel.icon

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(108, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.AddContent(109, 
#nullable restore
#line 46 "C:\Users\fredd\Desktop\VS\BlazorAppInversoca\BlazorAppInversoca\Client\Componentes\Formularios\OperacionForm.razor"
                                                                                                    btnCancel.name

#line default
#line hidden
#nullable disable
                    );
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(110, "\r\n            ");
            }
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(111, "\r\n       \r\n             ");
            __builder.OpenComponent<BlazorAppInversoca.Client.Componentes.Themes.Theme>(112);
            __builder.AddAttribute(113, "themeColor", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<BlazorAppInversoca.Client.Componentes.Themes.Theme.ThemeColor>(
#nullable restore
#line 50 "C:\Users\fredd\Desktop\VS\BlazorAppInversoca\BlazorAppInversoca\Client\Componentes\Formularios\OperacionForm.razor"
                                Theme.ThemeColor.danger

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(114, "Body", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(115, "\r\n                    ");
                __builder2.OpenComponent<MatBlazor.MatButton>(116);
                __builder2.AddAttribute(117, "Disabled", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 52 "C:\Users\fredd\Desktop\VS\BlazorAppInversoca\BlazorAppInversoca\Client\Componentes\Formularios\OperacionForm.razor"
                                           isNew ? true : false

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(118, "OnClick", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 52 "C:\Users\fredd\Desktop\VS\BlazorAppInversoca\BlazorAppInversoca\Client\Componentes\Formularios\OperacionForm.razor"
                                                                             ()=>DeleteOp.InvokeAsync("eliminar")

#line default
#line hidden
#nullable disable
                )));
                __builder2.AddAttribute(119, "Class", "btn-lg");
                __builder2.AddAttribute(120, "Raised", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 53 "C:\Users\fredd\Desktop\VS\BlazorAppInversoca\BlazorAppInversoca\Client\Componentes\Formularios\OperacionForm.razor"
                             true

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(121, "Type", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 53 "C:\Users\fredd\Desktop\VS\BlazorAppInversoca\BlazorAppInversoca\Client\Componentes\Formularios\OperacionForm.razor"
                                          btnDelete.attribute.Trim()

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(122, "Icon", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 53 "C:\Users\fredd\Desktop\VS\BlazorAppInversoca\BlazorAppInversoca\Client\Componentes\Formularios\OperacionForm.razor"
                                                                             btnDelete.icon

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(123, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.AddContent(124, 
#nullable restore
#line 53 "C:\Users\fredd\Desktop\VS\BlazorAppInversoca\BlazorAppInversoca\Client\Componentes\Formularios\OperacionForm.razor"
                                                                                               btnDelete.name

#line default
#line hidden
#nullable disable
                    );
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(125, "\r\n                ");
            }
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(126, "\r\n\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(127, "\r\n");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 60 "C:\Users\fredd\Desktop\VS\BlazorAppInversoca\BlazorAppInversoca\Client\Componentes\Formularios\OperacionForm.razor"
 
    [Parameter]
    public OperacionViewModel model { get; set; }
    [Parameter]
    public bool isModuloReadOnly { get; set; } = false;
    [Parameter]
    public bool isNew { get; set; }
    [Parameter]
    public ModuloViewModel modulo { get; set; }
    [Parameter]
    public EventCallback CancelOp { get; set; }
    [Parameter]
    public EventCallback DeleteOp { get; set; }
    ModuloView mod = new ModuloView();
    List<ModuloView> ModulosView = new List<ModuloView>();

    // Modelo de Botones
    ButtonModelView btnSave = StaticComponents.btnSave();
    ButtonModelView btnCancel = StaticComponents.btnCancel;
    ButtonModelView btnDelete = StaticComponents.btnDelete();
    protected override async Task OnInitializedAsync()
    {

        model = new OperacionViewModel();
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ServicioModulo _servicioModulo { get; set; }
    }
}
namespace __Blazor.BlazorAppInversoca.Client.Componentes.Formularios.OperacionForm
{
    #line hidden
    internal static class TypeInference
    {
        public static void CreateValidationMessage_0<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg0)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "For", __arg0);
        __builder.CloseComponent();
        }
    }
}
#pragma warning restore 1591
