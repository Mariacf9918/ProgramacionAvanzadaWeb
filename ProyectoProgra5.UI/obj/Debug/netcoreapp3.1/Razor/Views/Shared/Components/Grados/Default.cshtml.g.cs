#pragma checksum "C:\ProyectoFinalProgra5\ProgramacionAvanzadaWeb\ProyectoProgra5.UI\Views\Shared\Components\Grados\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6ab8d06b81bd5f07341ff034c9dd481a963afc6f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_Grados_Default), @"mvc.1.0.view", @"/Views/Shared/Components/Grados/Default.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\ProyectoFinalProgra5\ProgramacionAvanzadaWeb\ProyectoProgra5.UI\Views\_ViewImports.cshtml"
using ProyectoProgra5.UI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\ProyectoFinalProgra5\ProgramacionAvanzadaWeb\ProyectoProgra5.UI\Views\_ViewImports.cshtml"
using ProyectoProgra5.UI.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6ab8d06b81bd5f07341ff034c9dd481a963afc6f", @"/Views/Shared/Components/Grados/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ec354dc7592d85f6184a55140f6f136f5ff651be", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_Grados_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Grado>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<ul>\r\n");
#nullable restore
#line 4 "C:\ProyectoFinalProgra5\ProgramacionAvanzadaWeb\ProyectoProgra5.UI\Views\Shared\Components\Grados\Default.cshtml"
     foreach (var grado in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("<li>");
#nullable restore
#line 6 "C:\ProyectoFinalProgra5\ProgramacionAvanzadaWeb\ProyectoProgra5.UI\Views\Shared\Components\Grados\Default.cshtml"
Write(grado.Descripcion);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n");
#nullable restore
#line 7 "C:\ProyectoFinalProgra5\ProgramacionAvanzadaWeb\ProyectoProgra5.UI\Views\Shared\Components\Grados\Default.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("</ul>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Grado>> Html { get; private set; }
    }
}
#pragma warning restore 1591
