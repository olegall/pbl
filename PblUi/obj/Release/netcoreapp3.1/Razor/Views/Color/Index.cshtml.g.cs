#pragma checksum "D:\Work\PBLService\PBLService\PblUi\Views\Color\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "feb3490b5a2e0b55ddd2d048ee74e05c258d2253"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Color_Index), @"mvc.1.0.view", @"/Views/Color/Index.cshtml")]
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
#line 1 "D:\Work\PBLService\PBLService\PblUi\Views\_ViewImports.cshtml"
using PblUi;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Work\PBLService\PBLService\PblUi\Views\_ViewImports.cshtml"
using PblUi.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"feb3490b5a2e0b55ddd2d048ee74e05c258d2253", @"/Views/Color/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bb6f3cef756b97b9905f407bd194e296d47c3a92", @"/Views/_ViewImports.cshtml")]
    public class Views_Color_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<PblDAL.Models.Color>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\Work\PBLService\PBLService\PblUi\Views\Color\Index.cshtml"
  
    ViewData["Title"] = "Home Page";
    string contrName = "Color";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral(@"<div class=""text-center"">
    <h1 class=""display-4"">Цвета ламп</h1>
</div>

<link rel=""stylesheet"" href=""https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css"">
<table class=""table"">
    <thead>
        <tr>
            <th>Цвет</th>
            <th></th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 20 "D:\Work\PBLService\PBLService\PblUi\Views\Color\Index.cshtml"
         foreach (var m in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n");
#nullable restore
#line 24 "D:\Work\PBLService\PBLService\PblUi\Views\Color\Index.cshtml"
                     using (Html.BeginForm("Update", contrName, FormMethod.Post, new { enctype = "multipart/form-data" }))
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <input type=\"hidden\" name=\"Id\"");
            BeginWriteAttribute("value", " value=\"", 733, "\"", 746, 1);
#nullable restore
#line 26 "D:\Work\PBLService\PBLService\PblUi\Views\Color\Index.cshtml"
WriteAttributeValue("", 741, m.Id, 741, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                        <input class=\"form-control ip\" type=\"text\" name=\"colorName\"");
            BeginWriteAttribute("value", " value=\"", 835, "\"", 855, 1);
#nullable restore
#line 27 "D:\Work\PBLService\PBLService\PblUi\Views\Color\Index.cshtml"
WriteAttributeValue("", 843, m.ColorName, 843, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                        <button class=\"btn btn-default btn-sm glyphicon glyphicon-floppy-disk save\" type=\"submit\"></button>\r\n");
#nullable restore
#line 29 "D:\Work\PBLService\PBLService\PblUi\Views\Color\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </td>\r\n                <td>\r\n                    <button type=\"submit\" class=\"btn btn-default btn-sm glyphicon glyphicon-remove\"");
            BeginWriteAttribute("onclick", " \r\n                                          onclick=\"", 1151, "\"", 1247, 5);
            WriteAttributeValue("", 1205, "location.href=\'", 1205, 15, true);
#nullable restore
#line 33 "D:\Work\PBLService\PBLService\PblUi\Views\Color\Index.cshtml"
WriteAttributeValue("", 1220, contrName, 1220, 10, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1230, "/Delete?id=", 1230, 11, true);
#nullable restore
#line 33 "D:\Work\PBLService\PBLService\PblUi\Views\Color\Index.cshtml"
WriteAttributeValue("", 1241, m.Id, 1241, 5, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1246, "\'", 1246, 1, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                    </button>\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 37 "D:\Work\PBLService\PBLService\PblUi\Views\Color\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n<button type=\"submit\" class=\"btn btn-default btn-sm create\"");
            BeginWriteAttribute("onclick", " \r\n                      onclick=\"", 1418, "\"", 1485, 3);
            WriteAttributeValue("", 1452, "location.href=\'", 1452, 15, true);
#nullable restore
#line 41 "D:\Work\PBLService\PBLService\PblUi\Views\Color\Index.cshtml"
WriteAttributeValue("", 1467, contrName, 1467, 10, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1477, "/Create\'", 1477, 8, true);
            EndWriteAttribute();
            WriteLiteral(@">
    Добавить
</button>

<style>
    .ip {
        width: 135px;
        background: #f3f3f3;
        border: none;
        display: inline-block;
        margin-right: 10px;
    }

    .table {
        width: 250px;
        margin: 0 auto;
        margin-bottom: 10px;
    }

    .create {
        display: block;
        margin: 0 auto;
        width: 200px;
    }

    .glyphicon-remove {
        margin-top: 3px;
    }
</style>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<PblDAL.Models.Color>> Html { get; private set; }
    }
}
#pragma warning restore 1591
