#pragma checksum "D:\files\lessons\02.11 exam\musicShop\02.11 exam\Views\Shared\CategoriesList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7c60aa1461cca703238b021b1d3a2e92158cf2e5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_CategoriesList), @"mvc.1.0.view", @"/Views/Shared/CategoriesList.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/CategoriesList.cshtml", typeof(AspNetCore.Views_Shared_CategoriesList))]
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
#line 1 "D:\files\lessons\02.11 exam\musicShop\02.11 exam\Views\_ViewImports.cshtml"
using _02._11_exam;

#line default
#line hidden
#line 2 "D:\files\lessons\02.11 exam\musicShop\02.11 exam\Views\_ViewImports.cshtml"
using _02._11_exam.Models;

#line default
#line hidden
#line 3 "D:\files\lessons\02.11 exam\musicShop\02.11 exam\Views\_ViewImports.cshtml"
using _02._11_exam.Data.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7c60aa1461cca703238b021b1d3a2e92158cf2e5", @"/Views/Shared/CategoriesList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9fedabc1957d4d17c6669e586865aa747e1b6229", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_CategoriesList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "D:\files\lessons\02.11 exam\musicShop\02.11 exam\Views\Shared\CategoriesList.cshtml"
  
    Layout = "_Layout";

#line default
#line hidden
            BeginContext(32, 27, true);
            WriteLiteral("\r\n<!DOCTYPE html>\r\n<html>\r\n");
            EndContext();
            BeginContext(59, 109, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f9a743d5d0cc453a9590ed8968170f7e", async() => {
                BeginContext(65, 96, true);
                WriteLiteral("\r\n    <meta name=\"viewport\" content=\"width=device-width\" />\r\n    <title>CategoriesList</title>\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(168, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(170, 317, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7dbec58c18f94c1eb8584a34b4ec7179", async() => {
                BeginContext(176, 10, true);
                WriteLiteral("\r\n    <h1>");
                EndContext();
                BeginContext(187, 13, false);
#line 12 "D:\files\lessons\02.11 exam\musicShop\02.11 exam\Views\Shared\CategoriesList.cshtml"
   Write(ViewBag.Title);

#line default
#line hidden
                EndContext();
                BeginContext(200, 7, true);
                WriteLiteral("</h1>\r\n");
                EndContext();
                BeginContext(248, 33, true);
                WriteLiteral("    <div class=\"row mt-5 mb-2\">\r\n");
                EndContext();
#line 15 "D:\files\lessons\02.11 exam\musicShop\02.11 exam\Views\Shared\CategoriesList.cshtml"
          
            foreach (Category category in Model.GetCategories)
            {
                

#line default
#line hidden
                BeginContext(389, 50, false);
#line 18 "D:\files\lessons\02.11 exam\musicShop\02.11 exam\Views\Shared\CategoriesList.cshtml"
           Write(await Html.PartialAsync("_CategoryCard", category));

#line default
#line hidden
                EndContext();
#line 18 "D:\files\lessons\02.11 exam\musicShop\02.11 exam\Views\Shared\CategoriesList.cshtml"
                                                                   ;
            }
        

#line default
#line hidden
                BeginContext(468, 12, true);
                WriteLiteral("    </div>\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(487, 9, true);
            WriteLiteral("\r\n</html>");
            EndContext();
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
