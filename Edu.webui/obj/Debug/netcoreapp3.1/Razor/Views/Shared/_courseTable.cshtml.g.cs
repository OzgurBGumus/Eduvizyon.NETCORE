#pragma checksum "D:\work\C.Sharp\.Net-Core-Mvc\EduRepo\Edu.webui\Views\Shared\_courseTable.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cd3a43d9fae326857a71db5953871393f60b1c74"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__courseTable), @"mvc.1.0.view", @"/Views/Shared/_courseTable.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cd3a43d9fae326857a71db5953871393f60b1c74", @"/Views/Shared/_courseTable.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"01a2c627c7f20b1339703d710ec4c677e9e3b1bd", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__courseTable : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Course>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CourseDelete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral(@"<table id=""CourseTable"" class=""table table-bordered"" style=""width:100%"">
    <thead>
        <tr>
            <td style=""width:30px;"">Id</td>
            <td>Name</td>
            <td style=""width:80px;"">Start Date</td>
            <td style=""width:80px;"">End Date</td>
            <td style=""width:100px;"">Level</td>
            <td style=""width:50px;"">Price</td>
            <td style=""width:50px;"">Discount</td>
            <td style=""width:125px;""></td>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 16 "D:\work\C.Sharp\.Net-Core-Mvc\EduRepo\Edu.webui\Views\Shared\_courseTable.cshtml"
         foreach (var course in @Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr");
            BeginWriteAttribute("class", " class=\"", 599, "\"", 638, 1);
#nullable restore
#line 18 "D:\work\C.Sharp\.Net-Core-Mvc\EduRepo\Edu.webui\Views\Shared\_courseTable.cshtml"
WriteAttributeValue("", 607, course.Active?"":"bg-danger", 607, 31, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                <td>");
#nullable restore
#line 19 "D:\work\C.Sharp\.Net-Core-Mvc\EduRepo\Edu.webui\Views\Shared\_courseTable.cshtml"
               Write(course.CourseId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 20 "D:\work\C.Sharp\.Net-Core-Mvc\EduRepo\Edu.webui\Views\Shared\_courseTable.cshtml"
               Write(course.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 21 "D:\work\C.Sharp\.Net-Core-Mvc\EduRepo\Edu.webui\Views\Shared\_courseTable.cshtml"
               Write(course.StartDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 22 "D:\work\C.Sharp\.Net-Core-Mvc\EduRepo\Edu.webui\Views\Shared\_courseTable.cshtml"
               Write(course.EndDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 23 "D:\work\C.Sharp\.Net-Core-Mvc\EduRepo\Edu.webui\Views\Shared\_courseTable.cshtml"
               Write(course.Level);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 24 "D:\work\C.Sharp\.Net-Core-Mvc\EduRepo\Edu.webui\Views\Shared\_courseTable.cshtml"
               Write(course.PriceCourse);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 25 "D:\work\C.Sharp\.Net-Core-Mvc\EduRepo\Edu.webui\Views\Shared\_courseTable.cshtml"
               Write(course.Discount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>\r\n");
#nullable restore
#line 27 "D:\work\C.Sharp\.Net-Core-Mvc\EduRepo\Edu.webui\Views\Shared\_courseTable.cshtml"
                     if(User.IsInRole("Owner") || User.IsInRole("Manager"))
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cd3a43d9fae326857a71db5953871393f60b1c748581", async() => {
                WriteLiteral("\r\n                            <input type=\"hidden\" name=\"courseId\",");
                BeginWriteAttribute("value", " value=\"", 1246, "\"", 1270, 1);
#nullable restore
#line 30 "D:\work\C.Sharp\.Net-Core-Mvc\EduRepo\Edu.webui\Views\Shared\_courseTable.cshtml"
WriteAttributeValue("", 1254, course.CourseId, 1254, 16, false);

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
#line 33 "D:\work\C.Sharp\.Net-Core-Mvc\EduRepo\Edu.webui\Views\Shared\_courseTable.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <a");
            BeginWriteAttribute("href", " href=\"", 1435, "\"", 1476, 2);
            WriteAttributeValue("", 1442, "/admin/CourseEdit/", 1442, 18, true);
#nullable restore
#line 34 "D:\work\C.Sharp\.Net-Core-Mvc\EduRepo\Edu.webui\Views\Shared\_courseTable.cshtml"
WriteAttributeValue("", 1460, course.CourseId, 1460, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-xs btn-primary\">Edit</a>\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 37 "D:\work\C.Sharp\.Net-Core-Mvc\EduRepo\Edu.webui\Views\Shared\_courseTable.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Course>> Html { get; private set; }
    }
}
#pragma warning restore 1591
