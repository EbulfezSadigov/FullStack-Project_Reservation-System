#pragma checksum "C:\Users\test\Desktop\My-Project\My-Project\Views\Home\Room.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bbb643dc3590f2573210984f8ff870fdae167939"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Room), @"mvc.1.0.view", @"/Views/Home/Room.cshtml")]
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
#line 1 "C:\Users\test\Desktop\My-Project\My-Project\Views\_ViewImports.cshtml"
using My_Project;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\test\Desktop\My-Project\My-Project\Views\_ViewImports.cshtml"
using My_Project.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\test\Desktop\My-Project\My-Project\Views\_ViewImports.cshtml"
using My_Project.ViewModel;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bbb643dc3590f2573210984f8ff870fdae167939", @"/Views/Home/Room.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6e10db8d528050e2c661819b125ce0d657a1fb97", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_Room : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<HomeViewModel>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-fluid rounded-3"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-fluid mb-3"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral(@"
<section id=""about-side"" class=""text-center"">
    <div class=""container"">
        <h1 class=""fw-bolder"">Choose Our Rooms</h1>
    </div>
</section>

<section id=""room"">
    <div class=""container"" data-aos=""zoom-in-down"" data-aos-duration=""2000"">
        <div class=""top-text text-center mb-5"">
            <span class=""top"">Our Rooms</span>
        </div>
        <h2 class=""text-center mb-5"">Our Rooms</h2>
        <div class=""swiper mySwiper"">
            <div class=""swiper-wrapper"">
");
#nullable restore
#line 17 "C:\Users\test\Desktop\My-Project\My-Project\Views\Home\Room.cshtml"
                 foreach (Room item in Model.rooms)
                {


#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"swiper-slide text-center mb-5 rounded-3\">\r\n                        <div class=\"img-wrapper\">\r\n                            <div class=\"img-length\">\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "bbb643dc3590f2573210984f8ff870fdae1679394999", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 821, "~/images/", 821, 9, true);
#nullable restore
#line 23 "C:\Users\test\Desktop\My-Project\My-Project\Views\Home\Room.cshtml"
AddHtmlAttributeValue("", 830, item.Image, 830, 11, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n                        <div class=\"text mt-4\">\r\n                            <h4>");
#nullable restore
#line 27 "C:\Users\test\Desktop\My-Project\My-Project\Views\Home\Room.cshtml"
                           Write(item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                            <p class=\"money\"><span class=\"fs-2 text-primary\">$");
#nullable restore
#line 28 "C:\Users\test\Desktop\My-Project\My-Project\Views\Home\Room.cshtml"
                                                                         Write(item.RoomPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>/per night</p>\r\n                        </div>\r\n                        <div class=\"properties\">\r\n");
#nullable restore
#line 31 "C:\Users\test\Desktop\My-Project\My-Project\Views\Home\Room.cshtml"
                             foreach (RoomAmentity item2 in item.RoomAmentities)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <p><i class=\"uil uil-check fs-4\"></i>");
#nullable restore
#line 33 "C:\Users\test\Desktop\My-Project\My-Project\Views\Home\Room.cshtml"
                                                                Write(item2.Amentity.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 34 "C:\Users\test\Desktop\My-Project\My-Project\Views\Home\Room.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <a");
            BeginWriteAttribute("href", " href=\"", 1507, "\"", 1536, 2);
            WriteAttributeValue("", 1514, "/room/details/", 1514, 14, true);
#nullable restore
#line 35 "C:\Users\test\Desktop\My-Project\My-Project\Views\Home\Room.cshtml"
WriteAttributeValue("", 1528, item.Id, 1528, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"mybtn\">More Details</a>\r\n                        </div>\r\n                    </div>\r\n");
#nullable restore
#line 38 "C:\Users\test\Desktop\My-Project\My-Project\Views\Home\Room.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            </div>
            <div class=""swiper-pagination""></div>
        </div>
    </div>
</section>

<section id=""service"">
    <div class=""container"">
        <div class=""top-text text-center mb-5"" data-aos=""zoom-out-down"" data-aos-duration=""1000"" data-aos-offset=""300""
             data-aos-easing=""ease-in-sine"">
            <span class=""top"">Service</span>
        </div>
        <div class=""row"">
            <div class=""col-lg-5 col-12 p-0"">
                <div class=""categories text-lg-start text-center"" data-aos=""fade-right"">
");
#nullable restore
#line 54 "C:\Users\test\Desktop\My-Project\My-Project\Views\Home\Room.cshtml"
                     foreach (Category item in Model.categories)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <span class=\"tabs-toggle\"><i");
            BeginWriteAttribute("class", " class=\"", 2348, "\"", 2375, 3);
            WriteAttributeValue("", 2356, "uil", 2356, 3, true);
#nullable restore
#line 56 "C:\Users\test\Desktop\My-Project\My-Project\Views\Home\Room.cshtml"
WriteAttributeValue(" ", 2359, item.Icon, 2360, 10, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 2370, "me-2", 2371, 5, true);
            EndWriteAttribute();
            WriteLiteral("></i>");
#nullable restore
#line 56 "C:\Users\test\Desktop\My-Project\My-Project\Views\Home\Room.cshtml"
                                                                                Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
#nullable restore
#line 57 "C:\Users\test\Desktop\My-Project\My-Project\Views\Home\Room.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n            </div>\r\n            <div class=\"col-lg-7 col-12 p-0\">\r\n");
#nullable restore
#line 61 "C:\Users\test\Desktop\My-Project\My-Project\Views\Home\Room.cshtml"
                 foreach (Service item in Model.services)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div");
            BeginWriteAttribute("class", " class=\"", 2616, "\"", 2693, 3);
            WriteAttributeValue("", 2624, "services", 2624, 8, true);
#nullable restore
#line 63 "C:\Users\test\Desktop\My-Project\My-Project\Views\Home\Room.cshtml"
WriteAttributeValue(" ", 2632, Model.services.IndexOf(item)==0?"is-active":"", 2633, 49, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 2682, "text-light", 2683, 11, true);
            EndWriteAttribute();
            WriteLiteral(" data-aos=\"fade-left\">\r\n                        <i");
            BeginWriteAttribute("class", " class=\"", 2744, "\"", 2766, 2);
            WriteAttributeValue("", 2752, "uil", 2752, 3, true);
#nullable restore
#line 64 "C:\Users\test\Desktop\My-Project\My-Project\Views\Home\Room.cshtml"
WriteAttributeValue(" ", 2755, item.Icon, 2756, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></i>\r\n                        <h2 class=\"mb-4 fs-1\">");
#nullable restore
#line 65 "C:\Users\test\Desktop\My-Project\My-Project\Views\Home\Room.cshtml"
                                         Write(item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n                        <p class=\"mb-4\">");
#nullable restore
#line 66 "C:\Users\test\Desktop\My-Project\My-Project\Views\Home\Room.cshtml"
                                   Write(item.Text);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                        <span>");
#nullable restore
#line 67 "C:\Users\test\Desktop\My-Project\My-Project\Views\Home\Room.cshtml"
                         Write(item.Subtext);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                    </div>\r\n");
#nullable restore
#line 69 "C:\Users\test\Desktop\My-Project\My-Project\Views\Home\Room.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            </div>
        </div>
    </div>
</section>

<section id=""guest"">
    <div class=""container"" data-aos=""zoom-in-down"" data-aos-duration=""2000"">
        <div class=""top-text text-center mb-5"">
            <span class=""top"">Guests says</span>
        </div>
        <h2 class=""text-center mb-5"">Our Satisfied Guests says</h2>
        <div class=""swiper mySwiper"">
            <div class=""swiper-wrapper"">
");
#nullable restore
#line 83 "C:\Users\test\Desktop\My-Project\My-Project\Views\Home\Room.cshtml"
                 foreach (Guest item in Model.guests)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"swiper-slide text-center mb-5\">\r\n                        <div class=\"img-wrapper\">\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "bbb643dc3590f2573210984f8ff870fdae16793914221", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 3648, "~/images/person/", 3648, 16, true);
#nullable restore
#line 87 "C:\Users\test\Desktop\My-Project\My-Project\Views\Home\Room.cshtml"
AddHtmlAttributeValue("", 3664, item.Image, 3664, 11, false);

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
            WriteLiteral("<br>\r\n                        </div>\r\n                        <div class=\"stars\">\r\n");
#nullable restore
#line 90 "C:\Users\test\Desktop\My-Project\My-Project\Views\Home\Room.cshtml"
                             for (int i = 0; i < item.startCount; i++)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <i class=\"bi bi-star-fill\"></i>\r\n");
#nullable restore
#line 93 "C:\Users\test\Desktop\My-Project\My-Project\Views\Home\Room.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </div>\r\n                        <div class=\"text mt-2\">\r\n                            <p class=\"opacity-75\">\r\n                                ");
#nullable restore
#line 97 "C:\Users\test\Desktop\My-Project\My-Project\Views\Home\Room.cshtml"
                           Write(item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </p>\r\n                        </div>\r\n                        <div class=\"properties mt-5\">\r\n                            <p class=\"fw-semibold\">");
#nullable restore
#line 101 "C:\Users\test\Desktop\My-Project\My-Project\Views\Home\Room.cshtml"
                                              Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            <span>Guest from ");
#nullable restore
#line 102 "C:\Users\test\Desktop\My-Project\My-Project\Views\Home\Room.cshtml"
                                        Write(item.Where);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                        </div>\r\n                    </div>\r\n");
#nullable restore
#line 105 "C:\Users\test\Desktop\My-Project\My-Project\Views\Home\Room.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n            <div class=\"swiper-pagination\"></div>\r\n        </div>\r\n    </div>\r\n</section>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<HomeViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
