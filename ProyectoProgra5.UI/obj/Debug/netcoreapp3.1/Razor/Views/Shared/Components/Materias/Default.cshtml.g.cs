#pragma checksum "C:\Users\oscar\ProgramacionAvanzadaWeb\ProyectoProgra5.UI\Views\Shared\Components\Materias\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5a4ae57816cb3691c2c50cd2f68b1ced5dda7492"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_Materias_Default), @"mvc.1.0.view", @"/Views/Shared/Components/Materias/Default.cshtml")]
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
#line 1 "C:\Users\oscar\ProgramacionAvanzadaWeb\ProyectoProgra5.UI\Views\_ViewImports.cshtml"
using ProyectoProgra5.UI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\oscar\ProgramacionAvanzadaWeb\ProyectoProgra5.UI\Views\_ViewImports.cshtml"
using ProyectoProgra5.UI.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5a4ae57816cb3691c2c50cd2f68b1ced5dda7492", @"/Views/Shared/Components/Materias/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ec354dc7592d85f6184a55140f6f136f5ff651be", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_Materias_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Materia>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n<ul>\r\n");
#nullable restore
#line 5 "C:\Users\oscar\ProgramacionAvanzadaWeb\ProyectoProgra5.UI\Views\Shared\Components\Materias\Default.cshtml"
     foreach (var materia in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("<li>");
#nullable restore
#line 7 "C:\Users\oscar\ProgramacionAvanzadaWeb\ProyectoProgra5.UI\Views\Shared\Components\Materias\Default.cshtml"
Write(materia.Descripcion);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n");
#nullable restore
#line 8 "C:\Users\oscar\ProgramacionAvanzadaWeb\ProyectoProgra5.UI\Views\Shared\Components\Materias\Default.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Materia>> Html { get; private set; }
    }
}
#pragma warning restore 1591
