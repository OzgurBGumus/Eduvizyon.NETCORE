#pragma checksum "D:\work\C.Sharp\.Net-Core-Mvc\EduRepo\Edu.webui\Views\Shared\_stateTable.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "216146bde8b7cd391075730eb972a585af673412"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__stateTable), @"mvc.1.0.view", @"/Views/Shared/_stateTable.cshtml")]
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
#line 2 "D:\work\C.Sharp\.Net-Core-Mvc\EduRepo\Edu.webui\Views\_ViewImports.cshtml"
using Edu.webui.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\work\C.Sharp\.Net-Core-Mvc\EduRepo\Edu.webui\Views\_ViewImports.cshtml"
using Edu.entity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\work\C.Sharp\.Net-Core-Mvc\EduRepo\Edu.webui\Views\_ViewImports.cshtml"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\work\C.Sharp\.Net-Core-Mvc\EduRepo\Edu.webui\Views\_ViewImports.cshtml"
using Edu.webui.Extensions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\work\C.Sharp\.Net-Core-Mvc\EduRepo\Edu.webui\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\work\C.Sharp\.Net-Core-Mvc\EduRepo\Edu.webui\Views\_ViewImports.cshtml"
using Edu.webui.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"216146bde8b7cd391075730eb972a585af673412", @"/Views/Shared/_stateTable.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"01a2c627c7f20b1339703d710ec4c677e9e3b1bd", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__stateTable : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<State>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "StateDelete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "POST", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("display: inline;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<table id=""StateTable"" class=""table table-bordered"" style=""width:100%"">
    <thead>
        <tr>
            <td style=""width:60px;"">Id</td>
            <td>Name</td>
            <td style=""width:110px;"">Active</td>
            <td style=""width:260px;""></td>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 12 "D:\work\C.Sharp\.Net-Core-Mvc\EduRepo\Edu.webui\Views\Shared\_stateTable.cshtml"
         foreach (var state in @Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr");
            BeginWriteAttribute("class", " class=\"", 394, "\"", 433, 1);
#nullable restore
#line 14 "D:\work\C.Sharp\.Net-Core-Mvc\EduRepo\Edu.webui\Views\Shared\_stateTable.cshtml"
WriteAttributeValue("", 402, @state.Active?"":"bg-danger", 402, 31, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                <td>");
#nullable restore
#line 15 "D:\work\C.Sharp\.Net-Core-Mvc\EduRepo\Edu.webui\Views\Shared\_stateTable.cshtml"
               Write(state.StateId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 16 "D:\work\C.Sharp\.Net-Core-Mvc\EduRepo\Edu.webui\Views\Shared\_stateTable.cshtml"
               Write(state.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 17 "D:\work\C.Sharp\.Net-Core-Mvc\EduRepo\Edu.webui\Views\Shared\_stateTable.cshtml"
               Write(state.Active);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>\r\n");
#nullable restore
#line 19 "D:\work\C.Sharp\.Net-Core-Mvc\EduRepo\Edu.webui\Views\Shared\_stateTable.cshtml"
                     if(User.IsInRole("Owner") || User.IsInRole("Manager"))
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "216146bde8b7cd391075730eb972a585af6734127302", async() => {
                WriteLiteral("\r\n                            <input type=\"hidden\" name=\"stateId\",");
                BeginWriteAttribute("value", " value=\"", 861, "\"", 883, 1);
#nullable restore
#line 22 "D:\work\C.Sharp\.Net-Core-Mvc\EduRepo\Edu.webui\Views\Shared\_stateTable.cshtml"
WriteAttributeValue("", 869, state.StateId, 869, 14, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                            <button class=\"btn btn-xs btn-danger\">Delete</button>\r\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 25 "D:\work\C.Sharp\.Net-Core-Mvc\EduRepo\Edu.webui\Views\Shared\_stateTable.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <a");
            BeginWriteAttribute("href", " href=\"", 1048, "\"", 1086, 2);
            WriteAttributeValue("", 1055, "/admin/StateEdit/", 1055, 17, true);
#nullable restore
#line 26 "D:\work\C.Sharp\.Net-Core-Mvc\EduRepo\Edu.webui\Views\Shared\_stateTable.cshtml"
WriteAttributeValue("", 1072, state.StateId, 1072, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-xs btn-primary\">Edit</a>\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 29 "D:\work\C.Sharp\.Net-Core-Mvc\EduRepo\Edu.webui\Views\Shared\_stateTable.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<State>> Html { get; private set; }
    }
}
#pragma warning restore 1591
