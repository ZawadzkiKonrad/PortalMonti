#pragma checksum "C:\Users\48797\Documents\web\PortalMonti\PortalMonti.Web\Views\Shared\_FriendForIndex.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b7956acc84143ac3f40a5a1ff2fdd754fda8918f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__FriendForIndex), @"mvc.1.0.view", @"/Views/Shared/_FriendForIndex.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b7956acc84143ac3f40a5a1ff2fdd754fda8918f", @"/Views/Shared/_FriendForIndex.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4a0fe791533bd4b79acc47efe78846a612c1da45", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__FriendForIndex : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PortalMonti.Application.ViewModels.Friend.ListFriendForListVm>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<tbody>\r\n");
#nullable restore
#line 4 "C:\Users\48797\Documents\web\PortalMonti\PortalMonti.Web\Views\Shared\_FriendForIndex.cshtml"
     foreach (var item in Model.Friends)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 8 "C:\Users\48797\Documents\web\PortalMonti\PortalMonti.Web\Views\Shared\_FriendForIndex.cshtml"
           Write(Html.DisplayFor(modelItem => item.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 11 "C:\Users\48797\Documents\web\PortalMonti\PortalMonti.Web\Views\Shared\_FriendForIndex.cshtml"
           Write(Html.DisplayFor(modelItem => item.Image));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 14 "C:\Users\48797\Documents\web\PortalMonti\PortalMonti.Web\Views\Shared\_FriendForIndex.cshtml"
           Write(Html.DisplayFor(modelItem => item.Login));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n           \r\n            <td>\r\n                ");
#nullable restore
#line 18 "C:\Users\48797\Documents\web\PortalMonti\PortalMonti.Web\Views\Shared\_FriendForIndex.cshtml"
           Write(Html.ActionLink("Edytuj", "EditPost", new { id = item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                ");
#nullable restore
#line 19 "C:\Users\48797\Documents\web\PortalMonti\PortalMonti.Web\Views\Shared\_FriendForIndex.cshtml"
           Write(Html.ActionLink("ViewPost", "ViewPost", new { id = item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                ");
#nullable restore
#line 20 "C:\Users\48797\Documents\web\PortalMonti\PortalMonti.Web\Views\Shared\_FriendForIndex.cshtml"
           Write(Html.ActionLink("Delete", "Delete", new { id = item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 23 "C:\Users\48797\Documents\web\PortalMonti\PortalMonti.Web\Views\Shared\_FriendForIndex.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<tbody>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PortalMonti.Application.ViewModels.Friend.ListFriendForListVm> Html { get; private set; }
    }
}
#pragma warning restore 1591
