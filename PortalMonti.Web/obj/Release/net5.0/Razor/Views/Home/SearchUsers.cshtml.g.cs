#pragma checksum "C:\Users\48797\Documents\web\PortalMonti — kopia (2)backup\PortalMonti.Web\Views\Home\SearchUsers.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c186f3d7224c70d160601b6e0ae57ada3deb6a8a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_SearchUsers), @"mvc.1.0.view", @"/Views/Home/SearchUsers.cshtml")]
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
#line 1 "C:\Users\48797\Documents\web\PortalMonti — kopia (2)backup\PortalMonti.Web\Views\_ViewImports.cshtml"
using PortalMonti.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\48797\Documents\web\PortalMonti — kopia (2)backup\PortalMonti.Web\Views\_ViewImports.cshtml"
using PortalMonti.Web.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\48797\Documents\web\PortalMonti — kopia (2)backup\PortalMonti.Web\Views\Home\SearchUsers.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c186f3d7224c70d160601b6e0ae57ada3deb6a8a", @"/Views/Home/SearchUsers.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4a0fe791533bd4b79acc47efe78846a612c1da45", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_SearchUsers : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<PortalMonti.Domain.Model.AppUser>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/ListUsersStyle.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-rounded"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width:auto"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Identity", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/Account/Register", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\48797\Documents\web\PortalMonti — kopia (2)backup\PortalMonti.Web\Views\Home\SearchUsers.cshtml"
  
    ViewData["Title"] = "ListUsers";

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "c186f3d7224c70d160601b6e0ae57ada3deb6a8a6199", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n<link href=\"https://maxcdn.bootstrapcdn.com/font-awesome/4.3.0/css/font-awesome.min.css\" rel=\"stylesheet\">\r\n\r\n\r\n\r\n");
#nullable restore
#line 11 "C:\Users\48797\Documents\web\PortalMonti — kopia (2)backup\PortalMonti.Web\Views\Home\SearchUsers.cshtml"
 if (Model.Any())
{

    

#line default
#line hidden
#nullable disable
#nullable restore
#line 27 "C:\Users\48797\Documents\web\PortalMonti — kopia (2)backup\PortalMonti.Web\Views\Home\SearchUsers.cshtml"
            
    foreach (var user in Model)
    {
        
        

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"member-entry\">\r\n            <a href=\"#\" class=\"member-img\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "c186f3d7224c70d160601b6e0ae57ada3deb6a8a8053", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1143, "~/upload/", 1143, 9, true);
#nullable restore
#line 35 "C:\Users\48797\Documents\web\PortalMonti — kopia (2)backup\PortalMonti.Web\Views\Home\SearchUsers.cshtml"
AddHtmlAttributeValue("", 1152, user.ImageProfile, 1152, 18, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                <i class=\"fa fa-forward\"></i>\r\n            </a>\r\n            <div class=\"member-details\">\r\n                <h4> <a href=\"#\">");
#nullable restore
#line 39 "C:\Users\48797\Documents\web\PortalMonti — kopia (2)backup\PortalMonti.Web\Views\Home\SearchUsers.cshtml"
                            Write(user.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a> </h4>\r\n                <div class=\"row info-list\">\r\n                    <div class=\"col-sm-4\">\r\n                        <a");
            BeginWriteAttribute("href", " href=\"", 1472, "\"", 1531, 1);
#nullable restore
#line 42 "C:\Users\48797\Documents\web\PortalMonti — kopia (2)backup\PortalMonti.Web\Views\Home\SearchUsers.cshtml"
WriteAttributeValue("", 1479, Url.ActionLink("AddFriend","Home",new{id=user.Id }), 1479, 52, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Dodaj znajomego</a>\r\n                    </div>\r\n                    <div class=\"col-sm-4\">\r\n                        ");
#nullable restore
#line 45 "C:\Users\48797\Documents\web\PortalMonti — kopia (2)backup\PortalMonti.Web\Views\Home\SearchUsers.cshtml"
                   Write(Html.ActionLink("Zobacz Profil", "ViewProfile", "Profile", new { appUserId = user.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n\r\n                    </div>\r\n                    <div class=\"col-sm-4\">\r\n                        ");
#nullable restore
#line 49 "C:\Users\48797\Documents\web\PortalMonti — kopia (2)backup\PortalMonti.Web\Views\Home\SearchUsers.cshtml"
                   Write(Html.ActionLink("Wyślij wiadomość", "ChatPrv", "Home", new { appUserId = user.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                    </div>\r\n\r\n                </div>\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 57 "C:\Users\48797\Documents\web\PortalMonti — kopia (2)backup\PortalMonti.Web\Views\Home\SearchUsers.cshtml"
                  

    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    <br />\r\n    <br>\r\n");
#nullable restore
#line 62 "C:\Users\48797\Documents\web\PortalMonti — kopia (2)backup\PortalMonti.Web\Views\Home\SearchUsers.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""card"">
        <div class=""card-header"">
            No uses created yet
        </div>
        <div class=""card-body"">
            <h5 class=""card-title"">
                Use the button bellow to create a user
            </h5>
            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c186f3d7224c70d160601b6e0ae57ada3deb6a8a12417", async() => {
                WriteLiteral("\r\n                Add new User\r\n            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n            fore\r\n        </div>\r\n\r\n    </div>\r\n");
#nullable restore
#line 82 "C:\Users\48797\Documents\web\PortalMonti — kopia (2)backup\PortalMonti.Web\Views\Home\SearchUsers.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n\r\n\r\n\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<PortalMonti.Domain.Model.AppUser>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591