#pragma checksum "D:\files\lessons\02.11 exam\musicShop\02.11 exam\Views\Shared\_CategoryCard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "699b166300b7318065adc0c7a7a34d5f21db49ab"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__CategoryCard), @"mvc.1.0.view", @"/Views/Shared/_CategoryCard.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/_CategoryCard.cshtml", typeof(AspNetCore.Views_Shared__CategoryCard))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"699b166300b7318065adc0c7a7a34d5f21db49ab", @"/Views/Shared/_CategoryCard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9fedabc1957d4d17c6669e586865aa747e1b6229", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__CategoryCard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 33, true);
            WriteLiteral("<div class=\"row\">\r\n    <p>Model: ");
            EndContext();
            BeginContext(34, 17, false);
#line 2 "D:\files\lessons\02.11 exam\musicShop\02.11 exam\Views\Shared\_CategoryCard.cshtml"
         Write(Model.ProductName);

#line default
#line hidden
            EndContext();
            BeginContext(51, 21, true);
            WriteLiteral("</p>\r\n    <p>Price:  ");
            EndContext();
            BeginContext(73, 25, false);
#line 3 "D:\files\lessons\02.11 exam\musicShop\02.11 exam\Views\Shared\_CategoryCard.cshtml"
          Write(Model.Price.ToString("C"));

#line default
#line hidden
            EndContext();
            BeginContext(98, 12, true);
            WriteLiteral("</p>\r\n</div>");
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
