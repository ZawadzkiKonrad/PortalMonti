#pragma checksum "C:\Users\48797\Documents\web\PortalMonti\PortalMonti.Web\Views\Shared\Components\NotificationsList\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5a62dcb99a12b4f65ca001e7399a173a17a27131"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_NotificationsList_Default), @"mvc.1.0.view", @"/Views/Shared/Components/NotificationsList/Default.cshtml")]
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
#line 1 "C:\Users\48797\Documents\web\PortalMonti\PortalMonti.Web\Views\_ViewImports.cshtml"
using PortalMonti.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\48797\Documents\web\PortalMonti\PortalMonti.Web\Views\_ViewImports.cshtml"
using PortalMonti.Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5a62dcb99a12b4f65ca001e7399a173a17a27131", @"/Views/Shared/Components/NotificationsList/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4a0fe791533bd4b79acc47efe78846a612c1da45", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_NotificationsList_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<PortalMonti.Domain.Model.Notification>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 4 "C:\Users\48797\Documents\web\PortalMonti\PortalMonti.Web\Views\Shared\Components\NotificationsList\Default.cshtml"
     foreach (var noti in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li>\r\n            <a class=\"dropdown-item\"");
            BeginWriteAttribute("href", " href=\"", 154, "\"", 222, 1);
#nullable restore
#line 7 "C:\Users\48797\Documents\web\PortalMonti\PortalMonti.Web\Views\Shared\Components\NotificationsList\Default.cshtml"
WriteAttributeValue("", 161, Url.Action("ChatPrv", "Home",new {appUserId=noti.AuthorId }), 161, 61, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 7 "C:\Users\48797\Documents\web\PortalMonti\PortalMonti.Web\Views\Shared\Components\NotificationsList\Default.cshtml"
                                                                                                     Write(noti.Text);

#line default
#line hidden
#nullable disable
            WriteLiteral(" od : ");
#nullable restore
#line 7 "C:\Users\48797\Documents\web\PortalMonti\PortalMonti.Web\Views\Shared\Components\NotificationsList\Default.cshtml"
                                                                                                                     Write(noti.AuthorName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n\r\n        </li>\r\n");
#nullable restore
#line 10 "C:\Users\48797\Documents\web\PortalMonti\PortalMonti.Web\Views\Shared\Components\NotificationsList\Default.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
            WriteLiteral("\r\n\r\n<script>\r\n\r\n</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<PortalMonti.Domain.Model.Notification>> Html { get; private set; }
    }
}
#pragma warning restore 1591
