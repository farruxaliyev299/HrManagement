#pragma checksum "D:\.NET\HR_Management\HR_Management\Views\Chat\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "216b35ccb590a396d81399550f888f1205d83295"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Chat_Index), @"mvc.1.0.view", @"/Views/Chat/Index.cshtml")]
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
#line 1 "D:\.NET\HR_Management\HR_Management\Views\_ViewImports.cshtml"
using HR_Management;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\.NET\HR_Management\HR_Management\Views\_ViewImports.cshtml"
using HR_Management.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\.NET\HR_Management\HR_Management\Views\_ViewImports.cshtml"
using HR_Management.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\.NET\HR_Management\HR_Management\Views\_ViewImports.cshtml"
using HR_Management.ViewModels.Authentication;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"216b35ccb590a396d81399550f888f1205d83295", @"/Views/Chat/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"06e9ff844df84e1ca927f096d6adb896ea008787", @"/Views/_ViewImports.cshtml")]
    public class Views_Chat_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<EmployeeUser>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("rounded-circle mr-1"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("40"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("height", new global::Microsoft.AspNetCore.Html.HtmlString("40"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/js/chat.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 2 "D:\.NET\HR_Management\HR_Management\Views\Chat\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<!--Index start-->
<section class=""pr-chat"">
    <div class=""dashboard-wrapper"">
        <div class=""dashboard-header"">
            <div class=""left-header"">
                <button class=""navbar-toggler"">
                    <svg xmlns=""http://www.w3.org/2000/svg"" xmlns:xlink=""http://www.w3.org/1999/xlink""
                         width=""34px"" height=""34px"" viewBox=""0 0 24 24"" version=""1.1"">
                        <g stroke=""none"" stroke-width=""1"" fill=""#d0d3d6"" fill-rule=""evenodd"">
                            <rect x=""0"" y=""0"" width=""24"" height=""24""></rect>
                            <rect fill=""#3445e5"" x=""4"" y=""4"" width=""7"" height=""7"" rx=""1.5""></rect>
                            <path d=""M5.5,13 L9.5,13 C10.3284271,13 11,13.6715729 11,14.5 L11,18.5 C11,19.3284271 10.3284271,20 9.5,20 L5.5,20 C4.67157288,20 4,19.3284271 4,18.5 L4,14.5 C4,13.6715729 4.67157288,13 5.5,13 Z M14.5,4 L18.5,4 C19.3284271,4 20,4.67157288 20,5.5 L20,9.5 C20,10.3284271 19.3284271,11 18.5,11 L14.5,11 C13.6715729,11 13");
            WriteLiteral(@",10.3284271 13,9.5 L13,5.5 C13,4.67157288 13.6715729,4 14.5,4 Z M14.5,13 L18.5,13 C19.3284271,13 20,13.6715729 20,14.5 L20,18.5 C20,19.3284271 19.3284271,20 18.5,20 L14.5,20 C13.6715729,20 13,19.3284271 13,18.5 L13,14.5 C13,13.6715729 13.6715729,13 14.5,13 Z""
                                  fill=""#3445e5"" opacity=""0.3""></path>
                        </g>
                    </svg>
                </button>
                <h3>Chat</h3>
            </div>
        </div>
        <div class=""dashboard-content"">
            <div class=""card"">
                <div class=""row g-0"">
                    <div class=""col-12 col-lg-5 col-xl-3 border-right"">
                        <div class=""px-4 d-none d-md-block"">
                            <div class=""d-flex align-items-center"">
                                <div class=""flex-grow-1"">
                                    <input type=""text"" class=""form-control my-3"" placeholder=""Search..."" />
                                </div>
               ");
            WriteLiteral("             </div>\r\n                        </div>\r\n                        <!--Employees-->\r\n");
#nullable restore
#line 37 "D:\.NET\HR_Management\HR_Management\Views\Chat\Index.cshtml"
                         foreach (var emp in Model)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <a");
            BeginWriteAttribute("id", " id=\"", 2321, "\"", 2333, 1);
#nullable restore
#line 39 "D:\.NET\HR_Management\HR_Management\Views\Chat\Index.cshtml"
WriteAttributeValue("", 2326, emp.Id, 2326, 7, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"list-group-item list-group-item-action border-0\">\r\n");
            WriteLiteral("                                <div class=\"d-flex align-items-start\">\r\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "216b35ccb590a396d81399550f888f1205d832958100", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 2598, "~/assets/images/userPhotos/", 2598, 27, true);
#nullable restore
#line 42 "D:\.NET\HR_Management\HR_Management\Views\Chat\Index.cshtml"
AddHtmlAttributeValue("", 2625, emp.ProfilePhoto, 2625, 17, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                    <div class=\"d-flex gap-1 flex-grow-1 ml-3\">\r\n                                        <span class=\"contact-name\">");
#nullable restore
#line 45 "D:\.NET\HR_Management\HR_Management\Views\Chat\Index.cshtml"
                                                              Write(emp.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                        <div class=\"d-flex align-items-center small\">\r\n                                            <span");
            BeginWriteAttribute("class", " class=\"", 3043, "\"", 3122, 4);
            WriteAttributeValue("", 3051, "fas", 3051, 3, true);
            WriteAttributeValue(" ", 3054, "fa-circle", 3055, 10, true);
#nullable restore
#line 47 "D:\.NET\HR_Management\HR_Management\Views\Chat\Index.cshtml"
WriteAttributeValue(" ", 3064, emp.ConnectionId == null?"chat-offline":"chat-online", 3065, 56, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 3121, "", 3122, 1, true);
            EndWriteAttribute();
            WriteLiteral("></span> \r\n");
            WriteLiteral("                                        </div>\r\n                                    </div>\r\n                                </div>\r\n                            </a>\r\n");
#nullable restore
#line 53 "D:\.NET\HR_Management\HR_Management\Views\Chat\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral(@"                        <hr class=""d-block d-lg-none mt-1 mb-0"" />
                    </div>
                    <div class=""col-12 col-lg-7 col-xl-9"">
                        <div class=""py-2 px-4 border-bottom d-none d-lg-block"">
                            <div class=""d-flex align-items-center py-1"">
                                <div class=""position-relative"">
                                    <img src=""https://bootdey.com/img/Content/avatar/avatar3.png""
                                         class=""rounded-circle mr-1"" alt=""Sharon Lessman"" width=""40""
                                         height=""40"" />
                                </div>
                                <div class=""flex-grow-1 pl-3"">
                                    <strong>Sharon Lessman</strong>
                                </div>
                                <div>
                                    <button class=""btn btn-primary btn-lg mr-1 px-3"">
                                        <svg xmlns=");
            WriteLiteral(@"""http://www.w3.org/2000/svg"" width=""24"" height=""24""
                                             viewBox=""0 0 24 24"" fill=""none"" stroke=""currentColor""
                                             stroke-width=""2"" stroke-linecap=""round"" stroke-linejoin=""round""
                                             class=""feather feather-phone feather-lg"">
                                            <path d=""M22 16.92v3a2 2 0 0 1-2.18 2 19.79 19.79 0 0 1-8.63-3.07 19.5 19.5 0 0 1-6-6 19.79 19.79 0 0 1-3.07-8.67A2 2 0 0 1 4.11 2h3a2 2 0 0 1 2 1.72 12.84 12.84 0 0 0 .7 2.81 2 2 0 0 1-.45 2.11L8.09 9.91a16 16 0 0 0 6 6l1.27-1.27a2 2 0 0 1 2.11-.45 12.84 12.84 0 0 0 2.81.7A2 2 0 0 1 22 16.92z"">
                                            </path>
                                        </svg>
                                    </button>
                                    <button class=""btn btn-primary btn-lg mr-1 px-3 d-none d-md-inline-block"">
                                        <svg xmlns=""http://www.w3.org/2");
            WriteLiteral(@"000/svg"" width=""24"" height=""24""
                                             viewBox=""0 0 24 24"" fill=""none"" stroke=""currentColor""
                                             stroke-width=""2"" stroke-linecap=""round"" stroke-linejoin=""round""
                                             class=""feather feather-video feather-lg"">
                                            <polygon points=""23 7 16 12 23 17 23 7""></polygon>
                                            <rect x=""1"" y=""5"" width=""15"" height=""14"" rx=""2"" ry=""2""></rect>
                                        </svg>
                                    </button>
                                    <button class=""btn btn-primary btn-lg px-3"">
                                        <svg xmlns=""http://www.w3.org/2000/svg"" width=""24"" height=""24""
                                             viewBox=""0 0 24 24"" fill=""none"" stroke=""currentColor""
                                             stroke-width=""2"" stroke-linecap=""round"" stroke-linejoin=""round""");
            WriteLiteral(@"
                                             class=""feather feather-more-horizontal feather-lg"">
                                            <circle cx=""12"" cy=""12"" r=""1""></circle>
                                            <circle cx=""19"" cy=""12"" r=""1""></circle>
                                            <circle cx=""5"" cy=""12"" r=""1""></circle>
                                        </svg>
                                    </button>
                                </div>
                            </div>
                        </div>
                        <div class=""position-relative"">
                            <div class=""chat-messages p-4"">
                                <div class=""chat-message-right pb-4"">
                                    <div>
                                        <img src=""https://bootdey.com/img/Content/avatar/avatar1.png""
                                             class=""rounded-circle mr-1"" alt=""Chris Wood"" width=""40""
                              ");
            WriteLiteral(@"               height=""40"" />
                                        <div class=""text-muted small text-nowrap mt-2"">
                                            2:33 am
                                        </div>
                                    </div>
                                    <div class=""flex-shrink-1 bg-light rounded py-2 px-3 mr-3"">
                                        <div class=""font-weight-bold mb-1"">You</div>
                                        Lorem ipsum dolor sit amet, vis erat denique in,
                                        dicunt prodesset te vix.
                                    </div>
                                </div>
                                <div class=""chat-message-left pb-4"">
                                    <div>
                                        <img src=""https://bootdey.com/img/Content/avatar/avatar3.png""
                                             class=""rounded-circle mr-1"" alt=""Sharon Lessman"" width=""40""
              ");
            WriteLiteral(@"                               height=""40"" />
                                        <div class=""text-muted small text-nowrap mt-2"">
                                            2:34 am
                                        </div>
                                    </div>
                                    <div class=""flex-shrink-1 bg-light rounded py-2 px-3 ml-3"">
                                        <div class=""font-weight-bold mb-1"">
                                            Sharon Lessman
                                        </div>
                                        Sit meis deleniti eu, pri vidit meliore docendi ut, an
                                        eum erat animal commodo.
                                    </div>
                                </div>
                                <div class=""chat-message-right mb-4"">
                                    <div>
                                        <img src=""https://bootdey.com/img/Content/avatar/avatar1.png""");
            WriteLiteral(@"
                                             class=""rounded-circle mr-1"" alt=""Chris Wood"" width=""40""
                                             height=""40"" />
                                        <div class=""text-muted small text-nowrap mt-2"">
                                            2:35 am
                                        </div>
                                    </div>
                                    <div class=""flex-shrink-1 bg-light rounded py-2 px-3 mr-3"">
                                        <div class=""font-weight-bold mb-1"">You</div>
                                        Cum ea graeci tractatos.
                                    </div>
                                </div>
                                <div class=""chat-message-left pb-4"">
                                    <div>
                                        <img src=""https://bootdey.com/img/Content/avatar/avatar3.png""
                                             class=""rounded-circle mr-1"" alt");
            WriteLiteral(@"=""Sharon Lessman"" width=""40""
                                             height=""40"" />
                                        <div class=""text-muted small text-nowrap mt-2"">
                                            2:36 am
                                        </div>
                                    </div>
                                    <div class=""flex-shrink-1 bg-light rounded py-2 px-3 ml-3"">
                                        <div class=""font-weight-bold mb-1"">
                                            Sharon Lessman
                                        </div>
                                        Sed pulvinar, massa vitae interdum pulvinar, risus
                                        lectus porttitor magna, vitae commodo lectus mauris et
                                        velit. Proin ultricies placerat imperdiet. Morbi
                                        varius quam ac venenatis tempus.
                                    </div>
                     ");
            WriteLiteral(@"           </div>
                                <div class=""chat-message-left pb-4"">
                                    <div>
                                        <img src=""https://bootdey.com/img/Content/avatar/avatar3.png""
                                             class=""rounded-circle mr-1"" alt=""Sharon Lessman"" width=""40""
                                             height=""40"" />
                                        <div class=""text-muted small text-nowrap mt-2"">
                                            2:37 am
                                        </div>
                                    </div>
                                    <div class=""flex-shrink-1 bg-light rounded py-2 px-3 ml-3"">
                                        <div class=""font-weight-bold mb-1"">
                                            Sharon Lessman
                                        </div>
                                        Cras pulvinar, sapien id vehicula aliquet, diam velit
           ");
            WriteLiteral(@"                             elementum orci.
                                    </div>
                                </div>
                                <div class=""chat-message-right mb-4"">
                                    <div>
                                        <img src=""https://bootdey.com/img/Content/avatar/avatar1.png""
                                             class=""rounded-circle mr-1"" alt=""Chris Wood"" width=""40""
                                             height=""40"" />
                                        <div class=""text-muted small text-nowrap mt-2"">
                                            2:38 am
                                        </div>
                                    </div>
                                    <div class=""flex-shrink-1 bg-light rounded py-2 px-3 mr-3"">
                                        <div class=""font-weight-bold mb-1"">You</div>
                                        Lorem ipsum dolor sit amet, vis erat denique in,
       ");
            WriteLiteral(@"                                 dicunt prodesset te vix.
                                    </div>
                                </div>
                                <div class=""chat-message-left pb-4"">
                                    <div>
                                        <img src=""https://bootdey.com/img/Content/avatar/avatar3.png""
                                             class=""rounded-circle mr-1"" alt=""Sharon Lessman"" width=""40""
                                             height=""40"" />
                                        <div class=""text-muted small text-nowrap mt-2"">
                                            2:39 am
                                        </div>
                                    </div>
                                    <div class=""flex-shrink-1 bg-light rounded py-2 px-3 ml-3"">
                                        <div class=""font-weight-bold mb-1"">
                                            Sharon Lessman
                              ");
            WriteLiteral(@"          </div>
                                        Sit meis deleniti eu, pri vidit meliore docendi ut, an
                                        eum erat animal commodo.
                                    </div>
                                </div>
                                <div class=""chat-message-right mb-4"">
                                    <div>
                                        <img src=""https://bootdey.com/img/Content/avatar/avatar1.png""
                                             class=""rounded-circle mr-1"" alt=""Chris Wood"" width=""40""
                                             height=""40"" />
                                        <div class=""text-muted small text-nowrap mt-2"">
                                            2:40 am
                                        </div>
                                    </div>
                                    <div class=""flex-shrink-1 bg-light rounded py-2 px-3 mr-3"">
                                        <div clas");
            WriteLiteral(@"s=""font-weight-bold mb-1"">You</div>
                                        Cum ea graeci tractatos.
                                    </div>
                                </div>
                                <div class=""chat-message-right mb-4"">
                                    <div>
                                        <img src=""https://bootdey.com/img/Content/avatar/avatar1.png""
                                             class=""rounded-circle mr-1"" alt=""Chris Wood"" width=""40""
                                             height=""40"" />
                                        <div class=""text-muted small text-nowrap mt-2"">
                                            2:41 am
                                        </div>
                                    </div>
                                    <div class=""flex-shrink-1 bg-light rounded py-2 px-3 mr-3"">
                                        <div class=""font-weight-bold mb-1"">You</div>
                                        ");
            WriteLiteral(@"Morbi finibus, lorem id placerat ullamcorper, nunc
                                        enim ultrices massa, id dignissim metus urna eget
                                        purus.
                                    </div>
                                </div>
                                <div class=""chat-message-left pb-4"">
                                    <div>
                                        <img src=""https://bootdey.com/img/Content/avatar/avatar3.png""
                                             class=""rounded-circle mr-1"" alt=""Sharon Lessman"" width=""40""
                                             height=""40"" />
                                        <div class=""text-muted small text-nowrap mt-2"">
                                            2:42 am
                                        </div>
                                    </div>
                                    <div class=""flex-shrink-1 bg-light rounded py-2 px-3 ml-3"">
                                   ");
            WriteLiteral(@"     <div class=""font-weight-bold mb-1"">
                                            Sharon Lessman
                                        </div>
                                        Sed pulvinar, massa vitae interdum pulvinar, risus
                                        lectus porttitor magna, vitae commodo lectus mauris et
                                        velit. Proin ultricies placerat imperdiet. Morbi
                                        varius quam ac venenatis tempus.
                                    </div>
                                </div>
                                <div class=""chat-message-right mb-4"">
                                    <div>
                                        <img src=""https://bootdey.com/img/Content/avatar/avatar1.png""
                                             class=""rounded-circle mr-1"" alt=""Chris Wood"" width=""40""
                                             height=""40"" />
                                        <div class=""text-m");
            WriteLiteral(@"uted small text-nowrap mt-2"">
                                            2:43 am
                                        </div>
                                    </div>
                                    <div class=""flex-shrink-1 bg-light rounded py-2 px-3 mr-3"">
                                        <div class=""font-weight-bold mb-1"">You</div>
                                        Lorem ipsum dolor sit amet, vis erat denique in,
                                        dicunt prodesset te vix.
                                    </div>
                                </div>
                                <div class=""chat-message-left pb-4"">
                                    <div>
                                        <img src=""https://bootdey.com/img/Content/avatar/avatar3.png""
                                             class=""rounded-circle mr-1"" alt=""Sharon Lessman"" width=""40""
                                             height=""40"" />
                                        <d");
            WriteLiteral(@"iv class=""text-muted small text-nowrap mt-2"">
                                            2:44 am
                                        </div>
                                    </div>
                                    <div class=""flex-shrink-1 bg-light rounded py-2 px-3 ml-3"">
                                        <div class=""font-weight-bold mb-1"">
                                            Sharon Lessman
                                        </div>
                                        Sit meis deleniti eu, pri vidit meliore docendi ut, an
                                        eum erat animal commodo.
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class=""flex-grow-0 py-3 px-4 border-top"">
                            <div class=""input-group"">
                                <input type=""text"" class=""form-control"" placeholder=""Type your message"" />
 ");
            WriteLiteral(@"                               <button class=""btn btn-primary"">Send</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
<!--Index end-->
");
            DefineSection("CssChat", async() => {
                WriteLiteral("\r\n<link rel=\"stylesheet\" href=\"https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css\" />\r\n");
            }
            );
            DefineSection("ScriptChat", async() => {
                WriteLiteral("\r\n");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "216b35ccb590a396d81399550f888f1205d8329530349", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<EmployeeUser>> Html { get; private set; }
    }
}
#pragma warning restore 1591
