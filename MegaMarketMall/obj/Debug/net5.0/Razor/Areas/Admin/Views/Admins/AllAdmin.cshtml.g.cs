#pragma checksum "/home/aitemir/csharp_cmd/RealProjects/MegaMarketMall/MegaMarketMall/Areas/Admin/Views/Admins/AllAdmin.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8bc94acf3473d665efbaccde958478612f0cc402"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Admins_AllAdmin), @"mvc.1.0.view", @"/Areas/Admin/Views/Admins/AllAdmin.cshtml")]
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
#line 1 "/home/aitemir/csharp_cmd/RealProjects/MegaMarketMall/MegaMarketMall/Areas/Admin/Views/_ViewImports.cshtml"
using MegaMarketMall;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/home/aitemir/csharp_cmd/RealProjects/MegaMarketMall/MegaMarketMall/Areas/Admin/Views/_ViewImports.cshtml"
using MegaMarketMall.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "/home/aitemir/csharp_cmd/RealProjects/MegaMarketMall/MegaMarketMall/Areas/Admin/Views/Admins/AllAdmin.cshtml"
using Microsoft.IdentityModel.Tokens;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/home/aitemir/csharp_cmd/RealProjects/MegaMarketMall/MegaMarketMall/Areas/Admin/Views/Admins/AllAdmin.cshtml"
using System.Security.Cryptography;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8bc94acf3473d665efbaccde958478612f0cc402", @"/Areas/Admin/Views/Admins/AllAdmin.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4ad3888fea7312ef4ea66c00e8668f2541035383", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Admins_AllAdmin : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<System.Collections.Generic.List<MegaMarketMall.Models.Users.Admin>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 5 "/home/aitemir/csharp_cmd/RealProjects/MegaMarketMall/MegaMarketMall/Areas/Admin/Views/Admins/AllAdmin.cshtml"
  
    ViewBag.Title = "List of Admins";
    Layout = "_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral("<a");
            BeginWriteAttribute("href", " href=\'", 218, "\'", 248, 1);
#nullable restore
#line 9 "/home/aitemir/csharp_cmd/RealProjects/MegaMarketMall/MegaMarketMall/Areas/Admin/Views/Admins/AllAdmin.cshtml"
WriteAttributeValue("", 225, Url.Action("Register"), 225, 23, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><button class=\"btn btn-primary\">Add new Admin</button></a>\n");
#nullable restore
#line 10 "/home/aitemir/csharp_cmd/RealProjects/MegaMarketMall/MegaMarketMall/Areas/Admin/Views/Admins/AllAdmin.cshtml"
 if (@Model.IsNullOrEmpty())
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h1>There is no admin, <a");
            BeginWriteAttribute("href", " href=\'", 369, "\'", 399, 1);
#nullable restore
#line 12 "/home/aitemir/csharp_cmd/RealProjects/MegaMarketMall/MegaMarketMall/Areas/Admin/Views/Admins/AllAdmin.cshtml"
WriteAttributeValue("", 376, Url.Action("Register"), 376, 23, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">add the new one!!!</a></h1>\n");
#nullable restore
#line 13 "/home/aitemir/csharp_cmd/RealProjects/MegaMarketMall/MegaMarketMall/Areas/Admin/Views/Admins/AllAdmin.cshtml"
}

else
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "/home/aitemir/csharp_cmd/RealProjects/MegaMarketMall/MegaMarketMall/Areas/Admin/Views/Admins/AllAdmin.cshtml"
     foreach (var @admin in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"card\" style=\"width: 18rem;\">\n            <div class=\"card-body\">\n                <h5 class=\"card-title\">");
#nullable restore
#line 21 "/home/aitemir/csharp_cmd/RealProjects/MegaMarketMall/MegaMarketMall/Areas/Admin/Views/Admins/AllAdmin.cshtml"
                                  Write(admin.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\n                <h6 class=\"card-subtitle mb-2 text-muted\">admin id => ");
#nullable restore
#line 22 "/home/aitemir/csharp_cmd/RealProjects/MegaMarketMall/MegaMarketMall/Areas/Admin/Views/Admins/AllAdmin.cshtml"
                                                                 Write(admin.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\n");
            WriteLiteral("                <a href=\"#\" class=\"card-link\">Change</a>\n                <a");
            BeginWriteAttribute("href", " href=\'", 924, "\'", 984, 1);
#nullable restore
#line 25 "/home/aitemir/csharp_cmd/RealProjects/MegaMarketMall/MegaMarketMall/Areas/Admin/Views/Admins/AllAdmin.cshtml"
WriteAttributeValue("", 931, Url.Action("Delete", "Admins", new {Id = @admin.Id}), 931, 53, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"card-link\">Delete</a>\n            </div>\n        </div>\n");
#nullable restore
#line 28 "/home/aitemir/csharp_cmd/RealProjects/MegaMarketMall/MegaMarketMall/Areas/Admin/Views/Admins/AllAdmin.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 28 "/home/aitemir/csharp_cmd/RealProjects/MegaMarketMall/MegaMarketMall/Areas/Admin/Views/Admins/AllAdmin.cshtml"
     
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<System.Collections.Generic.List<MegaMarketMall.Models.Users.Admin>> Html { get; private set; }
    }
}
#pragma warning restore 1591
