#pragma checksum "C:\Users\4shr4\OneDrive\Desktop\DotNetCoreProjects\AshrafsAdvancedSweetShop\AshrafsAdvancedSweetShop\Views\Candy\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8b09331cc0505d2d1b922224275c47e08611614a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Candy_Details), @"mvc.1.0.view", @"/Views/Candy/Details.cshtml")]
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
#line 1 "C:\Users\4shr4\OneDrive\Desktop\DotNetCoreProjects\AshrafsAdvancedSweetShop\AshrafsAdvancedSweetShop\Views\_ViewImports.cshtml"
using AshrafsAdvancedSweetShop.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\4shr4\OneDrive\Desktop\DotNetCoreProjects\AshrafsAdvancedSweetShop\AshrafsAdvancedSweetShop\Views\_ViewImports.cshtml"
using AshrafsAdvancedSweetShop.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8b09331cc0505d2d1b922224275c47e08611614a", @"/Views/Candy/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5a4d103ac42376cf0bccfb1f4a7308ab1dad7db5", @"/Views/_ViewImports.cshtml")]
    public class Views_Candy_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("@model Candy\r\n\r\n<h1>");
#nullable restore
#line 3 "C:\Users\4shr4\OneDrive\Desktop\DotNetCoreProjects\AshrafsAdvancedSweetShop\AshrafsAdvancedSweetShop\Views\Candy\Details.cshtml"
Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n\r\n<div class=\"thumbnail\">\r\n    <img");
            BeginWriteAttribute("src", " src=\"", 74, "\"", 95, 1);
#nullable restore
#line 6 "C:\Users\4shr4\OneDrive\Desktop\DotNetCoreProjects\AshrafsAdvancedSweetShop\AshrafsAdvancedSweetShop\Views\Candy\Details.cshtml"
WriteAttributeValue("", 80, Model.ImageUrl, 80, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 96, "\"", 113, 1);
#nullable restore
#line 6 "C:\Users\4shr4\OneDrive\Desktop\DotNetCoreProjects\AshrafsAdvancedSweetShop\AshrafsAdvancedSweetShop\Views\Candy\Details.cshtml"
WriteAttributeValue("", 102, Model.Name, 102, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n    <div class=\"caption-full\">\r\n        <h2 class=\"pull-right\">");
#nullable restore
#line 8 "C:\Users\4shr4\OneDrive\Desktop\DotNetCoreProjects\AshrafsAdvancedSweetShop\AshrafsAdvancedSweetShop\Views\Candy\Details.cshtml"
                          Write(Model.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n        <h3><a href=\"#\">");
#nullable restore
#line 9 "C:\Users\4shr4\OneDrive\Desktop\DotNetCoreProjects\AshrafsAdvancedSweetShop\AshrafsAdvancedSweetShop\Views\Candy\Details.cshtml"
                   Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></h3>\r\n        <p>");
#nullable restore
#line 10 "C:\Users\4shr4\OneDrive\Desktop\DotNetCoreProjects\AshrafsAdvancedSweetShop\AshrafsAdvancedSweetShop\Views\Candy\Details.cshtml"
      Write(Model.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    </div>\r\n</div>");
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
