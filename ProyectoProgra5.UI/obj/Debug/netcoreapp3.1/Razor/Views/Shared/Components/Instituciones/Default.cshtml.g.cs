#pragma checksum "C:\ProyectoFinalProgra5\ProgramacionAvanzadaWeb\ProyectoProgra5.UI\Views\Shared\Components\Instituciones\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "143001333900db1fdbe4ec87d099253ad75423f7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_Instituciones_Default), @"mvc.1.0.view", @"/Views/Shared/Components/Instituciones/Default.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"143001333900db1fdbe4ec87d099253ad75423f7", @"/Views/Shared/Components/Instituciones/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ec354dc7592d85f6184a55140f6f136f5ff651be", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_Instituciones_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Institucione>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n<ul>\r\n");
#nullable restore
#line 5 "C:\ProyectoFinalProgra5\ProgramacionAvanzadaWeb\ProyectoProgra5.UI\Views\Shared\Components\Instituciones\Default.cshtml"
     foreach (var institucione in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("<li>");
#nullable restore
#line 7 "C:\ProyectoFinalProgra5\ProgramacionAvanzadaWeb\ProyectoProgra5.UI\Views\Shared\Components\Instituciones\Default.cshtml"
Write(institucione.NombreInstitucion);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n");
#nullable restore
#line 8 "C:\ProyectoFinalProgra5\ProgramacionAvanzadaWeb\ProyectoProgra5.UI\Views\Shared\Components\Instituciones\Default.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("</ul>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Institucione>> Html { get; private set; }
    }
}
#pragma warning restore 1591
