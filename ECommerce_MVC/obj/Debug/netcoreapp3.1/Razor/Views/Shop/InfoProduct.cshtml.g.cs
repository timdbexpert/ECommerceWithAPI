#pragma checksum "C:\Users\User\source\repos\E-Commerce\ECommerce_MVC\Views\Shop\InfoProduct.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3bfe8d3e31692ec90f37d3b6721cb32062f52be8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shop_InfoProduct), @"mvc.1.0.view", @"/Views/Shop/InfoProduct.cshtml")]
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
#line 1 "C:\Users\User\source\repos\E-Commerce\ECommerce_MVC\Views\_ViewImports.cshtml"
using ECommerce_MVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\User\source\repos\E-Commerce\ECommerce_MVC\Views\_ViewImports.cshtml"
using ECommerce_MVC.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3bfe8d3e31692ec90f37d3b6721cb32062f52be8", @"/Views/Shop/InfoProduct.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a716b95fecd9c5784b96748e9d359f71e3b137b6", @"/Views/_ViewImports.cshtml")]
    public class Views_Shop_InfoProduct : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ECommerce_MVC.Models.FiltersViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onmouseover", new global::Microsoft.AspNetCore.Html.HtmlString("myFunction(this)"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-fluid"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("imgBox"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\User\source\repos\E-Commerce\ECommerce_MVC\Views\Shop\InfoProduct.cshtml"
  
    ViewData["Title"] = "InfoProduct";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"container pt-4\">\r\n    <div class=\"row\">\r\n        <div class=\"col-lg-9 col-md-9 col-sm-12\">\r\n            <div class=\"product\" style=\"float: left; padding-bottom:4em\">\r\n\r\n                <div class=\"product-small-img\">\r\n");
#nullable restore
#line 14 "C:\Users\User\source\repos\E-Commerce\ECommerce_MVC\Views\Shop\InfoProduct.cshtml"
                     foreach (var item in Model.Pictures)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "3bfe8d3e31692ec90f37d3b6721cb32062f52be85381", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 490, "~/images/", 490, 9, true);
#nullable restore
#line 16 "C:\Users\User\source\repos\E-Commerce\ECommerce_MVC\Views\Shop\InfoProduct.cshtml"
AddHtmlAttributeValue("", 499, item.Name, 499, 10, false);

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
            WriteLiteral("\r\n");
#nullable restore
#line 17 "C:\Users\User\source\repos\E-Commerce\ECommerce_MVC\Views\Shop\InfoProduct.cshtml"

                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n                <div class=\"img-container\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "3bfe8d3e31692ec90f37d3b6721cb32062f52be87342", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 707, "~/images/", 707, 9, true);
#nullable restore
#line 22 "C:\Users\User\source\repos\E-Commerce\ECommerce_MVC\Views\Shop\InfoProduct.cshtml"
AddHtmlAttributeValue("", 716, Model.Product.MainImage, 716, 24, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </div>\r\n\r\n            </div>\r\n            <h5 style=\"font-family: Arial, Helvetica, sans-serif;\"> ");
#nullable restore
#line 26 "C:\Users\User\source\repos\E-Commerce\ECommerce_MVC\Views\Shop\InfoProduct.cshtml"
                                                               Write(Model.Product.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n            <hr>\r\n            <div class=\"product-info\">\r\n                <dl>\r\n                    <dt style=\"display: inline;\"> Price</dt>\r\n                    <dd style=\"display: inline;\">");
#nullable restore
#line 31 "C:\Users\User\source\repos\E-Commerce\ECommerce_MVC\Views\Shop\InfoProduct.cshtml"
                                            Write(Model.Product.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(" $</dd>\r\n                \r\n                </dl>\r\n            </div>\r\n\r\n        </div>\r\n        <div class=\"col-lg-3 col-md-3 col-sm-12\">\r\n            <div class=\"information\">\r\n                <h5 style=\"color: rgb(196, 67, 67)\" class=\"pb-2\">");
#nullable restore
#line 39 "C:\Users\User\source\repos\E-Commerce\ECommerce_MVC\Views\Shop\InfoProduct.cshtml"
                                                            Write(Model.Product.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(" $</h5>\r\n                <span>This item does not ship to<strong> Azerbaijan.</strong> Please check other sellers who may ship internationally.</span>\r\n\r\n");
            WriteLiteral("                <div class=\"information\">\r\n                    <button style=\"outline: none;\"><i class=\" mdi mdi-play-box\"></i>Buy Now</button>\r\n                    <button style=\"outline: none;\" class=\"addtoCart\" data-id=\"");
#nullable restore
#line 45 "C:\Users\User\source\repos\E-Commerce\ECommerce_MVC\Views\Shop\InfoProduct.cshtml"
                                                                         Write(Model.Product.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"""><i class="" mdi mdi-cart-arrow-down""></i>Add to Cart</button>
                </div>

            </div>
        </div>
        <table style=""border: 1px solid #e9e9e9; border-collapse: collapse; width: 100%; padding-top:3em"" >
            <tbody style=""box-sizing: border-box;"">
                <tr>
                    <td>Brand</td>
                    <td>");
#nullable restore
#line 54 "C:\Users\User\source\repos\E-Commerce\ECommerce_MVC\Views\Shop\InfoProduct.cshtml"
                   Write(Model.Brands.Where(x => x.Id == Model.Product.BrandId).Select(x => x.Name).FirstOrDefault());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n                <tr>\r\n                    <td>Name</td>\r\n                    <td>");
#nullable restore
#line 58 "C:\Users\User\source\repos\E-Commerce\ECommerce_MVC\Views\Shop\InfoProduct.cshtml"
                   Write(Model.Product.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n");
#nullable restore
#line 60 "C:\Users\User\source\repos\E-Commerce\ECommerce_MVC\Views\Shop\InfoProduct.cshtml"
                 if (Model.Product.ProsessorId != 1)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>Prosessor</td>\r\n                        <td>");
#nullable restore
#line 64 "C:\Users\User\source\repos\E-Commerce\ECommerce_MVC\Views\Shop\InfoProduct.cshtml"
                       Write(Model.Prosessors.Where(x => x.Id == Model.Product.ProsessorId).Select(x => x.Name).FirstOrDefault());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n");
#nullable restore
#line 66 "C:\Users\User\source\repos\E-Commerce\ECommerce_MVC\Views\Shop\InfoProduct.cshtml"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 67 "C:\Users\User\source\repos\E-Commerce\ECommerce_MVC\Views\Shop\InfoProduct.cshtml"
                 if (Model.Product.HardDriveId != 1 && Model.Product.SSDId != 1)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>SSD</td>\r\n                        <td>");
#nullable restore
#line 71 "C:\Users\User\source\repos\E-Commerce\ECommerce_MVC\Views\Shop\InfoProduct.cshtml"
                       Write(Model.SSDs.Where(x => x.Id == Model.Product.SSDId).Select(x => x.Name).FirstOrDefault());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td>Hard Drive</td>\r\n                        <td>");
#nullable restore
#line 75 "C:\Users\User\source\repos\E-Commerce\ECommerce_MVC\Views\Shop\InfoProduct.cshtml"
                       Write(Model.HardDrives.Where(x => x.Id == Model.Product.HardDriveId).Select(x => x.Name).FirstOrDefault());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n");
#nullable restore
#line 77 "C:\Users\User\source\repos\E-Commerce\ECommerce_MVC\Views\Shop\InfoProduct.cshtml"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 78 "C:\Users\User\source\repos\E-Commerce\ECommerce_MVC\Views\Shop\InfoProduct.cshtml"
                 if (Model.Product.RAMId != 1)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>RAM</td>\r\n                        <td>");
#nullable restore
#line 82 "C:\Users\User\source\repos\E-Commerce\ECommerce_MVC\Views\Shop\InfoProduct.cshtml"
                       Write(Model.RAMs.Where(x => x.Id == Model.Product.RAMId).Select(x => x.Name).FirstOrDefault());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n");
#nullable restore
#line 84 "C:\Users\User\source\repos\E-Commerce\ECommerce_MVC\Views\Shop\InfoProduct.cshtml"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 85 "C:\Users\User\source\repos\E-Commerce\ECommerce_MVC\Views\Shop\InfoProduct.cshtml"
                 if (Model.Product.Operation_SystemId != 1)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>Operation System</td>\r\n                        <td>");
#nullable restore
#line 89 "C:\Users\User\source\repos\E-Commerce\ECommerce_MVC\Views\Shop\InfoProduct.cshtml"
                       Write(Model.Operation_Systems.Where(x => x.Id == Model.Product.Operation_SystemId).Select(x => x.Name).FirstOrDefault());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n");
#nullable restore
#line 91 "C:\Users\User\source\repos\E-Commerce\ECommerce_MVC\Views\Shop\InfoProduct.cshtml"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 92 "C:\Users\User\source\repos\E-Commerce\ECommerce_MVC\Views\Shop\InfoProduct.cshtml"
                 if (Model.Product.StorageId != 1)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>Storage</td>\r\n                        <td>");
#nullable restore
#line 96 "C:\Users\User\source\repos\E-Commerce\ECommerce_MVC\Views\Shop\InfoProduct.cshtml"
                       Write(Model.Storages.Where(x => x.Id == Model.Product.StorageId).Select(x => x.Name).FirstOrDefault());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n");
#nullable restore
#line 98 "C:\Users\User\source\repos\E-Commerce\ECommerce_MVC\Views\Shop\InfoProduct.cshtml"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 99 "C:\Users\User\source\repos\E-Commerce\ECommerce_MVC\Views\Shop\InfoProduct.cshtml"
                 if (Model.Product.Style_JoinId != 1)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>Style Join</td>\r\n                        <td>");
#nullable restore
#line 103 "C:\Users\User\source\repos\E-Commerce\ECommerce_MVC\Views\Shop\InfoProduct.cshtml"
                       Write(Model.Storages.Where(x => x.Id == Model.Product.Style_JoinId).Select(x => x.Name).FirstOrDefault());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n");
#nullable restore
#line 105 "C:\Users\User\source\repos\E-Commerce\ECommerce_MVC\Views\Shop\InfoProduct.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>Color</td>\r\n                    <td>");
#nullable restore
#line 108 "C:\Users\User\source\repos\E-Commerce\ECommerce_MVC\Views\Shop\InfoProduct.cshtml"
                   Write(Model.Colors.Where(x => x.Id == Model.Product.ColorId).Select(x => x.Name).FirstOrDefault());

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</td>
                </tr>
            </tbody>
        </table>
    </div>
</div>




<script src=""https://cdn.jsdelivr.net/npm/js-cookie@beta/dist/js.cookie.min.js""></script>
    <script type=""module"" src=""https://cdn.jsdelivr.net/npm/js-cookie@beta/dist/js.cookie.min.mjs""></script>


<script>
    function myFunction(smallimg) {
        var fullImg = document.getElementById(""imgBox"");
        fullImg.src = smallimg.src;
    }

    

        $("".addtoCart"").click(function () {
            var products = [];
            var productids;

           // if (products.length == 0) {
            productids = Cookies.get('ProductCart');
            if (productids != undefined && productids != """" && productids != null) {
                var ids = productids.split('-');

                    if (ids.length == 1) {
                        products.push(ids);
                    };

                    if (ids.length >1)
                    {
                        for (f of ids) {");
            WriteLiteral(@"
                            products.push(f);
                        }
                    }
                    
            }

            var productID = $(this).attr('data-id');
            if (productID != undefined) {
                   products.push(productID);
                   Cookies.set('ProductCart', products.join('-'), { expires: 30, path: '/' });
            }
         

            // $.cookie('CartProducts', productID);

            alert(""Product added to Cart."");
            console.log(products);
            updateCartProduct();
        });
</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ECommerce_MVC.Models.FiltersViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
