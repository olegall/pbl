#pragma checksum "D:\Work\PBLService\PBLService\PblUi\Views\Light\Many.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "feb394ef9ecf962059b916596a1f02af007fe04b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Light_Many), @"mvc.1.0.view", @"/Views/Light/Many.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"feb394ef9ecf962059b916596a1f02af007fe04b", @"/Views/Light/Many.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bb6f3cef756b97b9905f407bd194e296d47c3a92", @"/Views/_ViewImports.cshtml")]
    public class Views_Light_Many : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PblUi.Models.LightVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "ShowUpdateMany", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "DeleteMany", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\Work\PBLService\PBLService\PblUi\Views\Light\Many.cshtml"
  
    ViewData["Title"] = "Конфигурирование множества ламп";
    string controller = "Light";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("<div class=\"text-center\">\r\n    <h1 class=\"display-4\">Редактирование ламп</h1>\r\n</div>\r\n<hr>\r\n<link rel=\"stylesheet\" href=\"https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css\">\r\n\r\n<div class=\"container\">\r\n");
#nullable restore
#line 14 "D:\Work\PBLService\PBLService\PblUi\Views\Light\Many.cshtml"
     using (Html.BeginForm("ShowUpdateMany", @controller, FormMethod.Post, new { @class = "update-form" }))
    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""row"">
        <div style=""width: 14px;""></div>
        <label class=""controller-caption col"">Адрес контроллера</label>
        <label class=""col"">Адрес</label>
        <label class=""col"">Номер</label>
        <label class=""col"">Цвет</label>
    </div>
");
#nullable restore
#line 23 "D:\Work\PBLService\PBLService\PblUi\Views\Light\Many.cshtml"
         foreach (var l in Model.Lights)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"row\">\r\n                <input type=\"hidden\" name=\"id\"");
            BeginWriteAttribute("value", " value=\"", 876, "\"", 884, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                <input type=\"checkbox\" name=\"checked\" value=\"false\"");
            BeginWriteAttribute("id", " id=\"", 955, "\"", 965, 1);
#nullable restore
#line 27 "D:\Work\PBLService\PBLService\PblUi\Views\Light\Many.cshtml"
WriteAttributeValue("", 960, l.Id, 960, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                \r\n");
#nullable restore
#line 29 "D:\Work\PBLService\PBLService\PblUi\Views\Light\Many.cshtml"
                 foreach (PblDAL.Models.Controller c in Model.Controllers)
                {
                    if (c.Id == l.ControllerId)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <input type=\"hidden\" name=\"controllerId\"");
            BeginWriteAttribute("value", " value=\"", 1218, "\"", 1241, 1);
#nullable restore
#line 33 "D:\Work\PBLService\PBLService\PblUi\Views\Light\Many.cshtml"
WriteAttributeValue("", 1226, l.ControllerId, 1226, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                        <p class=\"controller-caption col\">");
#nullable restore
#line 34 "D:\Work\PBLService\PBLService\PblUi\Views\Light\Many.cshtml"
                                                     Write(c.Address);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 35 "D:\Work\PBLService\PBLService\PblUi\Views\Light\Many.cshtml"
                        break;
                    }
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                <p class=\"col\">");
#nullable restore
#line 38 "D:\Work\PBLService\PBLService\PblUi\Views\Light\Many.cshtml"
                          Write(string.Format("0x{0:x2}", l.Address));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                <p class=\"col\">");
#nullable restore
#line 39 "D:\Work\PBLService\PBLService\PblUi\Views\Light\Many.cshtml"
                          Write(l.Num);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n\r\n");
#nullable restore
#line 41 "D:\Work\PBLService\PBLService\PblUi\Views\Light\Many.cshtml"
                 foreach (PblDAL.Models.Color col in Model.Colors)
                {
                    if (col.Id == l.ColorId)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <p class=\"col\">");
#nullable restore
#line 45 "D:\Work\PBLService\PBLService\PblUi\Views\Light\Many.cshtml"
                                  Write(col.ColorName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 46 "D:\Work\PBLService\PBLService\PblUi\Views\Light\Many.cshtml"
                        break;
                    }
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n");
#nullable restore
#line 50 "D:\Work\PBLService\PBLService\PblUi\Views\Light\Many.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        <hr>\r\n        <div class=\"row\">\r\n            <select class=\"form-control col-sm-2 choose-action\" name=\"num\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "feb394ef9ecf962059b916596a1f02af007fe04b8649", async() => {
                WriteLiteral("Редактировать");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "feb394ef9ecf962059b916596a1f02af007fe04b10142", async() => {
                WriteLiteral("Удалить");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </select>\r\n            <button type=\"submit\" class=\"btn btn-info add-btn col-sm-1 action-btn glyphicon glyphicon-arrow-right\" disabled></button>\r\n        </div>\r\n");
#nullable restore
#line 59 "D:\Work\PBLService\PBLService\PblUi\Views\Light\Many.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    <br><br>\r\n    <div class=\"text-center\">\r\n        <h1 class=\"display-4\">Добавить лампы</h1>\r\n    </div>\r\n    <hr>\r\n");
#nullable restore
#line 65 "D:\Work\PBLService\PBLService\PblUi\Views\Light\Many.cshtml"
     using (Html.BeginForm("CreateMany", @controller, FormMethod.Post, new { @class = "row create-form" }))
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <p class=\"col-sm-1 caption\">Контр-р</p>\r\n        <select class=\"form-control col-sm\" name=\"controllerId\">\r\n");
#nullable restore
#line 69 "D:\Work\PBLService\PBLService\PblUi\Views\Light\Many.cshtml"
             foreach (PblDAL.Models.Controller c in Model.Controllers)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "feb394ef9ecf962059b916596a1f02af007fe04b12486", async() => {
#nullable restore
#line 71 "D:\Work\PBLService\PBLService\PblUi\Views\Light\Many.cshtml"
                                 Write(c.Address);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 71 "D:\Work\PBLService\PBLService\PblUi\Views\Light\Many.cshtml"
                   WriteLiteral(c.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 72 "D:\Work\PBLService\PBLService\PblUi\Views\Light\Many.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </select>\r\n");
            WriteLiteral("        <p class=\"col-sm-1 caption\">Адр Min</p>\r\n        <select class=\"form-control col-sm addr\" name=\"addressMin\">\r\n");
#nullable restore
#line 77 "D:\Work\PBLService\PBLService\PblUi\Views\Light\Many.cshtml"
             foreach (int addr in Model.Addrs)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "feb394ef9ecf962059b916596a1f02af007fe04b14838", async() => {
#nullable restore
#line 79 "D:\Work\PBLService\PBLService\PblUi\Views\Light\Many.cshtml"
                                 Write(string.Format("0x{0:x2}", @addr));

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 79 "D:\Work\PBLService\PBLService\PblUi\Views\Light\Many.cshtml"
                   WriteLiteral(addr);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 80 "D:\Work\PBLService\PBLService\PblUi\Views\Light\Many.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </select>\r\n");
            WriteLiteral("        <p class=\"col-sm-1 caption\">Адр Max</p>\r\n        <select class=\"form-control col-sm addr\" name=\"addressMax\">\r\n");
#nullable restore
#line 85 "D:\Work\PBLService\PBLService\PblUi\Views\Light\Many.cshtml"
             foreach (int addr in Model.Addrs)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "feb394ef9ecf962059b916596a1f02af007fe04b17213", async() => {
#nullable restore
#line 87 "D:\Work\PBLService\PBLService\PblUi\Views\Light\Many.cshtml"
                                 Write(string.Format("0x{0:x2}", @addr));

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 87 "D:\Work\PBLService\PBLService\PblUi\Views\Light\Many.cshtml"
                   WriteLiteral(addr);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 88 "D:\Work\PBLService\PBLService\PblUi\Views\Light\Many.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </select>\r\n");
            WriteLiteral("        <p class=\"col-sm-1 caption\">Цвет</p>\r\n        <select class=\"form-control col-sm\" name=\"colorId\">\r\n");
#nullable restore
#line 93 "D:\Work\PBLService\PBLService\PblUi\Views\Light\Many.cshtml"
             foreach (PblDAL.Models.Color col in Model.Colors)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "feb394ef9ecf962059b916596a1f02af007fe04b19593", async() => {
#nullable restore
#line 95 "D:\Work\PBLService\PBLService\PblUi\Views\Light\Many.cshtml"
                                   Write(col.ColorName);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 95 "D:\Work\PBLService\PBLService\PblUi\Views\Light\Many.cshtml"
                   WriteLiteral(col.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 96 "D:\Work\PBLService\PBLService\PblUi\Views\Light\Many.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </select>\r\n        <button type=\"submit\" class=\"btn btn-info btn-sm add-btn\">Заполнить</button>\r\n");
#nullable restore
#line 99 "D:\Work\PBLService\PBLService\PblUi\Views\Light\Many.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>
<script src=""https://code.jquery.com/jquery-3.4.1.js""></script>

<script>
    let checkboxes = $('input[type=""checkbox""]');
    $(document).ready(function () {
        clearCheckboxes();
    });

    checkboxes.click(function () {
        let hiddenId = $(this).parent().find('input[name=""id""]');
        if ($(this).prop('checked')) {
            let id = $(this).attr('id');
            hiddenId.attr('value', id);
        } else {
            hiddenId.attr('value', '');
        }
        toggleActionBtn();
    });

    function clearCheckboxes() {
        checkboxes.prop('checked', false);
    }

    function toggleActionBtn() {
        let isAnyCheckboxChecked = checkboxes.toArray()
                                             .some(x => x.checked === true);
        $('.action-btn').prop('disabled', !isAnyCheckboxChecked);
    }

    $('.choose-action').change(function () {
        let action = $(this).find(':selected').val();
        $('.update-form').attr('action', '/");
#nullable restore
#line 132 "D:\Work\PBLService\PBLService\PblUi\Views\Light\Many.cshtml"
                                      Write(controller);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"/'+action);
    });
</script>

<style>
    .save-btn, .add-btn, .delete-btn {
        height: 30px;
        margin-left: 10px;
    }

    .save-btn {
       margin-right: 10px;
    }

    .action-btn {
        padding: 0;
    }

    .controller-caption {
        margin-left: 20px;
    }

    .create-form .caption {
        text-align: right;
        margin-top: 6px;
    }
    .update-form {
        width: 98%;
    }

    .row {
        height: 35px;
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PblUi.Models.LightVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
