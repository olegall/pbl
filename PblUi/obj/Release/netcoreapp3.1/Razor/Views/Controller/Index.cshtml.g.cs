#pragma checksum "D:\Work\PBLService\PBLService\PblUi\Views\Controller\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e656368d4e110d34f4c7a181a3cc38e6edf7a093"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Controller_Index), @"mvc.1.0.view", @"/Views/Controller/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e656368d4e110d34f4c7a181a3cc38e6edf7a093", @"/Views/Controller/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bb6f3cef756b97b9905f407bd194e296d47c3a92", @"/Views/_ViewImports.cshtml")]
    public class Views_Controller_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<PblDAL.Models.Controller>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\Work\PBLService\PBLService\PblUi\Views\Controller\Index.cshtml"
  
    ViewData["Title"] = "Home Page";
    string controller = "Controller";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral(@"<div class=""text-center"">
    <h1 class=""display-4"">Контроллеры</h1>
</div>

<link rel=""stylesheet"" href=""https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css"">
<table class=""table"">
    <thead>
        <tr>
            <th>Адрес - IP / URL &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Адрес slave &nbsp; &nbsp; Порт</th>
            <th></th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 20 "D:\Work\PBLService\PBLService\PblUi\Views\Controller\Index.cshtml"
         foreach (var m in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n");
#nullable restore
#line 24 "D:\Work\PBLService\PBLService\PblUi\Views\Controller\Index.cshtml"
                     using (Html.BeginForm("Update", controller, FormMethod.Post, new { enctype = "multipart/form-data" }))
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <input type=\"hidden\" name=\"Id\"");
            BeginWriteAttribute("value", " value=\"", 824, "\"", 837, 1);
#nullable restore
#line 26 "D:\Work\PBLService\PBLService\PblUi\Views\Controller\Index.cshtml"
WriteAttributeValue("", 832, m.Id, 832, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                        <input class=\"form-control address\" type=\"text\" name=\"Address\"");
            BeginWriteAttribute("value", " value=\"", 929, "\"", 947, 1);
#nullable restore
#line 27 "D:\Work\PBLService\PBLService\PblUi\Views\Controller\Index.cshtml"
WriteAttributeValue("", 937, m.Address, 937, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                        <input class=\"form-control slave\" type=\"text\" name=\"SlaveAddress\"");
            BeginWriteAttribute("value", " value=\"", 1040, "\"", 1063, 1);
#nullable restore
#line 28 "D:\Work\PBLService\PBLService\PblUi\Views\Controller\Index.cshtml"
WriteAttributeValue("", 1048, m.SlaveAddress, 1048, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                        <input class=\"form-control port\" type=\"text\" name=\"Port\"");
            BeginWriteAttribute("value", " value=\"", 1147, "\"", 1162, 1);
#nullable restore
#line 29 "D:\Work\PBLService\PBLService\PblUi\Views\Controller\Index.cshtml"
WriteAttributeValue("", 1155, m.Port, 1155, 7, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                        <button class=\"btn btn-default btn-sm glyphicon glyphicon-floppy-disk save\" type=\"submit\"></button>\r\n");
#nullable restore
#line 31 "D:\Work\PBLService\PBLService\PblUi\Views\Controller\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </td>\r\n                <td>\r\n                    <button class=\"btn btn-default btn-sm glyphicon glyphicon-remove\"");
            BeginWriteAttribute("onclick", " \r\n                            onclick=\"", 1444, "\"", 1527, 5);
            WriteAttributeValue("", 1484, "location.href=\'", 1484, 15, true);
#nullable restore
#line 35 "D:\Work\PBLService\PBLService\PblUi\Views\Controller\Index.cshtml"
WriteAttributeValue("", 1499, controller, 1499, 11, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1510, "/Delete?id=", 1510, 11, true);
#nullable restore
#line 35 "D:\Work\PBLService\PBLService\PblUi\Views\Controller\Index.cshtml"
WriteAttributeValue("", 1521, m.Id, 1521, 5, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1526, "\'", 1526, 1, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                    </button>\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 39 "D:\Work\PBLService\PBLService\PblUi\Views\Controller\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n<button type=\"submit\" class=\"btn btn-default btn-sm create\"");
            BeginWriteAttribute("onclick", " \r\n                      onclick=\"", 1698, "\"", 1766, 3);
            WriteAttributeValue("", 1732, "location.href=\'", 1732, 15, true);
#nullable restore
#line 43 "D:\Work\PBLService\PBLService\PblUi\Views\Controller\Index.cshtml"
WriteAttributeValue("", 1747, controller, 1747, 11, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1758, "/Create\'", 1758, 8, true);
            EndWriteAttribute();
            WriteLiteral(@">
    Добавить
</button>

<style>
    .address {
        width: 135px;
        background: #f3f3f3;
        border: none;
        display: inline-block;
        margin-right: 10px;
    }

    .slave, .port {
        display: inline-block;
        width: 100px;
    }

    .table {
        width: 460px;
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<PblDAL.Models.Controller>> Html { get; private set; }
    }
}
#pragma warning restore 1591
