#pragma checksum "D:\work\C.Sharp\.Net-Core-Mvc\EduRepo\Edu.webui\Views\Admin\TimeList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3deecc3a16f01cf97b799164b7b01c6300429279"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_TimeList), @"mvc.1.0.view", @"/Views/Admin/TimeList.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3deecc3a16f01cf97b799164b7b01c6300429279", @"/Views/Admin/TimeList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"01a2c627c7f20b1339703d710ec4c677e9e3b1bd", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_TimeList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\work\C.Sharp\.Net-Core-Mvc\EduRepo\Edu.webui\Views\Admin\TimeList.cshtml"
  
    List<Time> times = ViewBag.Times;

#line default
#line hidden
#nullable disable
            DefineSection("Style", async() => {
                WriteLiteral(@"
    <link rel=""stylesheet"" href=""https://cdn.datatables.net/1.10.21/css/dataTables.bootstrap4.min.css"">
    <link rel=""stylesheet"" href=""https://cdn.datatables.net/rowreorder/1.2.7/css/rowReorder.dataTables.min.css"">
    <link rel=""stylesheet"" href=""https://cdn.datatables.net/responsive/2.2.5/css/responsive.dataTables.min.css"">
");
            }
            );
            DefineSection("Script", async() => {
                WriteLiteral(@"
    <script src=""//cdn.datatables.net/1.10.21/js/jquery.dataTables.min.js""></script>
    <script src=""https://cdn.datatables.net/1.10.21/js/dataTables.bootstrap4.min.js""></script>
    <script src=""https://cdn.datatables.net/rowreorder/1.2.7/js/dataTables.rowReorder.min.js""></script>
    <script src=""https://cdn.datatables.net/responsive/2.2.5/js/dataTables.responsive.min.js""></script>
    <script>
        $(document).ready( function () {
            $('#TimeTable').DataTable({
                rowReorder: {
                    selector: 'td:nth-child(2)'
                },
                responsive: true
            });
        });
    </script>
");
            }
            );
            WriteLiteral("<div class=\"row\">\r\n    <div class=\"col-md-12\">\r\n        <h1 class=\"h3\" style=\"display: inline; margin-right:15px;\">Time List</h1>\r\n");
#nullable restore
#line 28 "D:\work\C.Sharp\.Net-Core-Mvc\EduRepo\Edu.webui\Views\Admin\TimeList.cshtml"
         if(User.IsInRole("Owner"))
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <a href=\"/Admin/TimeCreate\"class=\"btn btn-primary btn-sm\">Create Time</a>\r\n");
#nullable restore
#line 31 "D:\work\C.Sharp\.Net-Core-Mvc\EduRepo\Edu.webui\Views\Admin\TimeList.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        \r\n        <hr>\r\n        <div class=\"mt-4\">\r\n            ");
#nullable restore
#line 35 "D:\work\C.Sharp\.Net-Core-Mvc\EduRepo\Edu.webui\Views\Admin\TimeList.cshtml"
       Write(await Html.PartialAsync("_timeTable", @times));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
