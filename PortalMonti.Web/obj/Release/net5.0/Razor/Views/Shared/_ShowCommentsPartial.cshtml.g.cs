#pragma checksum "C:\Users\48797\Documents\web\PortalMonti — kopia (2)backup\PortalMonti.Web\Views\Shared\_ShowCommentsPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "af0865f950cbbfc89729ac1c1ad209956be64e8a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__ShowCommentsPartial), @"mvc.1.0.view", @"/Views/Shared/_ShowCommentsPartial.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"af0865f950cbbfc89729ac1c1ad209956be64e8a", @"/Views/Shared/_ShowCommentsPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4a0fe791533bd4b79acc47efe78846a612c1da45", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared__ShowCommentsPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<PortalMonti.Application.ViewModels.Comment.CommentVm>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("be-ava-comment"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("    <!--<div id=\"addpost2\"--> ");
            WriteLiteral(" <!--class=\"be-comment-block\">-->\r\n        <h5>Komentarze</h5>\r\n");
#nullable restore
#line 8 "C:\Users\48797\Documents\web\PortalMonti — kopia (2)backup\PortalMonti.Web\Views\Shared\_ShowCommentsPartial.cshtml"
         foreach (var post in Model)
        {
            


#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"be-comment\"style=\"text-wrap:avoid\">\r\n                    <div class=\"be-img-comment\">\r\n                        <a href=\"blog-detail-2.html\">\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "af0865f950cbbfc89729ac1c1ad209956be64e8a4674", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 646, "~/upload/", 646, 9, true);
#nullable restore
#line 15 "C:\Users\48797\Documents\web\PortalMonti — kopia (2)backup\PortalMonti.Web\Views\Shared\_ShowCommentsPartial.cshtml"
AddHtmlAttributeValue("", 655, post.ProfileImage, 655, 18, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        </a>\r\n                    </div>\r\n                    <div class=\"be-comment-content\">\r\n\r\n                        <span class=\"be-comment-name\">\r\n                            <a href=\"blog-detail-2.html\">");
#nullable restore
#line 21 "C:\Users\48797\Documents\web\PortalMonti — kopia (2)backup\PortalMonti.Web\Views\Shared\_ShowCommentsPartial.cshtml"
                                                    Write(post.Author);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                        </span>\r\n                        <span class=\"be-comment-time\">\r\n                            <i class=\"fa fa-clock-o\"></i>\r\n                            ");
#nullable restore
#line 25 "C:\Users\48797\Documents\web\PortalMonti — kopia (2)backup\PortalMonti.Web\Views\Shared\_ShowCommentsPartial.cshtml"
                       Write(post.Date);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </span>\r\n\r\n                        <p class=\"be-comment-text\">\r\n                            ");
#nullable restore
#line 29 "C:\Users\48797\Documents\web\PortalMonti — kopia (2)backup\PortalMonti.Web\Views\Shared\_ShowCommentsPartial.cshtml"
                       Write(post.Text);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </p>\r\n                    </div>\r\n                </div>\r\n");
#nullable restore
#line 33 "C:\Users\48797\Documents\web\PortalMonti — kopia (2)backup\PortalMonti.Web\Views\Shared\_ShowCommentsPartial.cshtml"
            
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        <div");
            BeginWriteAttribute("post-id", " post-id=\"", 1389, "\"", 1420, 1);
#nullable restore
#line 36 "C:\Users\48797\Documents\web\PortalMonti — kopia (2)backup\PortalMonti.Web\Views\Shared\_ShowCommentsPartial.cshtml"
WriteAttributeValue("", 1399, Model.First().PostId, 1399, 21, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n            ");
#nullable restore
#line 37 "C:\Users\48797\Documents\web\PortalMonti — kopia (2)backup\PortalMonti.Web\Views\Shared\_ShowCommentsPartial.cshtml"
       Write(await Html.PartialAsync("_AddCommentPartial", new PortalMonti.Application.ViewModels.Comment.NewCommentVm()
   { PostId = Model.First().PostId }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div> \r\n\r\n\r\n  ");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<PortalMonti.Application.ViewModels.Comment.CommentVm>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
