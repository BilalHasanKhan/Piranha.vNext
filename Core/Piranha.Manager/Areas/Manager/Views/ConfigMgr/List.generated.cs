﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.0
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Piranha.Areas.Manager.Views.ConfigMgr
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    using Piranha;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/Manager/Views/ConfigMgr/List.cshtml")]
    public partial class List : System.Web.Mvc.WebViewPage<IList<Piranha.Manager.Config.ConfigBlock>>
    {
        public List()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Areas\Manager\Views\ConfigMgr\List.cshtml"
  
	ViewBag.Title = @Piranha.Manager.Resources.Config.ListTitle;

	var sections = Model.Where(b => b.Section.ToLower() != "general" && b.Section.ToLower() != "blogging").Select(b => b.Section).Distinct();

            
            #line default
            #line hidden
WriteLiteral("\r\n");

DefineSection("script", () => {

WriteLiteral("\r\n\t<script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(">\r\n\t\tko.applyBindings(new manager.models.config());\r\n\t</script>\r\n");

});

WriteLiteral("\r\n<div");

WriteLiteral(" class=\"container-fluid\"");

WriteLiteral(">\r\n\t<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n\t\t<div");

WriteLiteral(" class=\"col-sm-12\"");

WriteLiteral(">\r\n\t\t\t<ul");

WriteLiteral(" class=\"nav nav-pills\"");

WriteLiteral(">\r\n\t\t\t\t<li");

WriteLiteral(" data-bind=\"css: { active: active() == \'general\' }\"");

WriteLiteral("><a");

WriteLiteral(" href=\"#\"");

WriteLiteral(" data-bind=\"click: function() { setActive(\'general\'); }\"");

WriteLiteral(">");

            
            #line 17 "..\..\Areas\Manager\Views\ConfigMgr\List.cshtml"
                                                                                                                                      Write(Piranha.Manager.Resources.Config.General);

            
            #line default
            #line hidden
WriteLiteral("</a></li>\r\n\t\t\t\t<li");

WriteLiteral(" data-bind=\"css: { active: active() == \'blogging\' }\"");

WriteLiteral("><a");

WriteLiteral(" href=\"#\"");

WriteLiteral(" data-bind=\"click: function() { setActive(\'blogging\'); }\"");

WriteLiteral(">");

            
            #line 18 "..\..\Areas\Manager\Views\ConfigMgr\List.cshtml"
                                                                                                                                        Write(Piranha.Manager.Resources.Config.Blogging);

            
            #line default
            #line hidden
WriteLiteral("</a></li>\r\n");

            
            #line 19 "..\..\Areas\Manager\Views\ConfigMgr\List.cshtml"
				
            
            #line default
            #line hidden
            
            #line 19 "..\..\Areas\Manager\Views\ConfigMgr\List.cshtml"
                 foreach (var section in sections) {

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t\t<li");

WriteLiteral(" data-bind=\"css: { active: active() == \'");

            
            #line 20 "..\..\Areas\Manager\Views\ConfigMgr\List.cshtml"
                                                           Write(section.ToLower());

            
            #line default
            #line hidden
WriteLiteral("\' }\"");

WriteLiteral("><a");

WriteLiteral(" href=\"#\"");

WriteLiteral(" data-bind=\"click: function() { setActive(\'");

            
            #line 20 "..\..\Areas\Manager\Views\ConfigMgr\List.cshtml"
                                                                                                                                          Write(section.ToLower());

            
            #line default
            #line hidden
WriteLiteral("\'); }\"");

WriteLiteral(">");

            
            #line 20 "..\..\Areas\Manager\Views\ConfigMgr\List.cshtml"
                                                                                                                                                                     Write(section);

            
            #line default
            #line hidden
WriteLiteral("</a></li>\r\n");

            
            #line 21 "..\..\Areas\Manager\Views\ConfigMgr\List.cshtml"
				}

            
            #line default
            #line hidden
WriteLiteral("\t\t\t</ul>\r\n\t\t\t<br />\r\n\t\t</div>\r\n\t</div>\r\n\t<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n\t\t<div");

WriteLiteral(" class=\"col-sm-12\"");

WriteLiteral(">\r\n\t\t\t<form");

WriteLiteral(" role=\"form\"");

WriteLiteral(" class=\"form\"");

WriteLiteral(">\r\n\t\t\t\t<!-- General settings -->\r\n\t\t\t\t<div");

WriteLiteral(" data-bind=\"if: active() == \'general\'\"");

WriteLiteral(">\r\n\t\t\t\t\t<!-- Site -->\r\n\t\t\t\t\t<div");

WriteLiteral(" id=\"pnlSite\"");

WriteLiteral(" class=\"panel panel-white\"");

WriteLiteral(">\r\n\t\t\t\t\t\t<div");

WriteLiteral(" class=\"notification\"");

WriteLiteral(">\r\n\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\"icon\"");

WriteLiteral("><span");

WriteLiteral(" class=\"glyphicon glyphicon-ok-circle\"");

WriteLiteral("></span></div>\r\n\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t<div");

WriteLiteral(" class=\"panel-body\"");

WriteLiteral(">\r\n\t\t\t\t\t\t\t<!-- Save -->\r\n\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\"btn-group pull-right\"");

WriteLiteral(">\r\n\t\t\t\t\t\t\t\t<button");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-labeled btn-success\"");

WriteLiteral(" data-bind=\"click: saveSite\"");

WriteLiteral(">\r\n\t\t\t\t\t\t\t\t\t<span");

WriteLiteral(" class=\"btn-label\"");

WriteLiteral(">\r\n\t\t\t\t\t\t\t\t\t\t<i");

WriteLiteral(" class=\"glyphicon glyphicon-ok\"");

WriteLiteral("></i>\r\n\t\t\t\t\t\t\t\t\t</span>\r\n");

WriteLiteral("\t\t\t\t\t\t\t\t\t");

            
            #line 43 "..\..\Areas\Manager\Views\ConfigMgr\List.cshtml"
                               Write(Piranha.Manager.Resources.Global.Save);

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t\t\t\t</button>\r\n\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\r\n\t\t\t\t\t\t\t<h3>");

            
            #line 47 "..\..\Areas\Manager\Views\ConfigMgr\List.cshtml"
                           Write(Piranha.Manager.Resources.Config.Site);

            
            #line default
            #line hidden
WriteLiteral("</h3>\r\n\r\n\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n\t\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\"col-sm-6\"");

WriteLiteral(">\r\n\t\t\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n\t\t\t\t\t\t\t\t\t\t<label>");

            
            #line 52 "..\..\Areas\Manager\Views\ConfigMgr\List.cshtml"
                                          Write(Piranha.Manager.Resources.Config.SiteTitle);

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n\t\t\t\t\t\t\t\t\t\t<input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" data-bind=\"value: siteTitle\"");

WriteLiteral(" />\r\n\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n\t\t\t\t\t\t\t\t\t\t<label>");

            
            #line 56 "..\..\Areas\Manager\Views\ConfigMgr\List.cshtml"
                                          Write(Piranha.Manager.Resources.Config.SiteArchivePageSize);

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n\t\t\t\t\t\t\t\t\t\t<input");

WriteLiteral(" type=\"number\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" data-bind=\"value: siteArchivePageSize\"");

WriteLiteral(" />\r\n\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\"col-sm-6\"");

WriteLiteral(">\r\n\t\t\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n\t\t\t\t\t\t\t\t\t\t<label>");

            
            #line 62 "..\..\Areas\Manager\Views\ConfigMgr\List.cshtml"
                                          Write(Piranha.Manager.Resources.Config.SiteDescription);

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n\t\t\t\t\t\t\t\t\t\t<textarea");

WriteLiteral(" rows=\"3\"");

WriteLiteral(" class=\"form-control count-me\"");

WriteLiteral(" style=\"height:97px\"");

WriteLiteral(" data-bind=\"value: siteDescription\"");

WriteLiteral("></textarea>\r\n\t\t\t\t\t\t\t\t\t\t<p><span");

WriteLiteral(" data-bind=\"text: siteDescription().Length\"");

WriteLiteral("></span>/255 ");

            
            #line 64 "..\..\Areas\Manager\Views\ConfigMgr\List.cshtml"
                                                                                                   Write(Piranha.Manager.Resources.Global.Characters);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t</div>\r\n\t\t\t\t\t</div>\r\n" +
"\r\n\t\t\t\t\t<!-- Cache -->\r\n\t\t\t\t\t<div");

WriteLiteral(" id=\"pnlCache\"");

WriteLiteral(" class=\"panel panel-white\"");

WriteLiteral(">\r\n\t\t\t\t\t\t<div");

WriteLiteral(" class=\"notification\"");

WriteLiteral(">\r\n\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\"icon\"");

WriteLiteral("><span");

WriteLiteral(" class=\"glyphicon glyphicon-ok-circle\"");

WriteLiteral("></span></div>\r\n\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t<div");

WriteLiteral(" class=\"panel-body\"");

WriteLiteral(">\r\n\t\t\t\t\t\t\t<!-- Save -->\r\n\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\"btn-group pull-right\"");

WriteLiteral(">\r\n\t\t\t\t\t\t\t\t<button");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-labeled btn-success\"");

WriteLiteral(" data-bind=\"click: saveCache\"");

WriteLiteral(">\r\n\t\t\t\t\t\t\t\t\t<span");

WriteLiteral(" class=\"btn-label\"");

WriteLiteral(">\r\n\t\t\t\t\t\t\t\t\t\t<i");

WriteLiteral(" class=\"glyphicon glyphicon-ok\"");

WriteLiteral("></i>\r\n\t\t\t\t\t\t\t\t\t</span>\r\n");

WriteLiteral("\t\t\t\t\t\t\t\t\t");

            
            #line 83 "..\..\Areas\Manager\Views\ConfigMgr\List.cshtml"
                               Write(Piranha.Manager.Resources.Global.Save);

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t\t\t\t</button>\r\n\t\t\t\t\t\t\t</div>\r\n\r\n\t\t\t\t\t\t\t<h3>");

            
            #line 87 "..\..\Areas\Manager\Views\ConfigMgr\List.cshtml"
                           Write(Piranha.Manager.Resources.Config.Cache);

            
            #line default
            #line hidden
WriteLiteral("</h3>\r\n\r\n\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n\t\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\"col-sm-6\"");

WriteLiteral(">\r\n\t\t\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n\t\t\t\t\t\t\t\t\t\t<label>");

            
            #line 92 "..\..\Areas\Manager\Views\ConfigMgr\List.cshtml"
                                          Write(Piranha.Manager.Resources.Config.CacheExpires);

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n\t\t\t\t\t\t\t\t\t\t<input");

WriteLiteral(" type=\"number\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" data-bind=\"value: cacheExpires\"");

WriteLiteral(" />\r\n\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\"col-sm-6\"");

WriteLiteral(">\r\n\t\t\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n\t\t\t\t\t\t\t\t\t\t<label>");

            
            #line 98 "..\..\Areas\Manager\Views\ConfigMgr\List.cshtml"
                                          Write(Piranha.Manager.Resources.Config.CacheMaxAge);

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n\t\t\t\t\t\t\t\t\t\t<input");

WriteLiteral(" type=\"number\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" data-bind=\"value: cacheMaxAge\"");

WriteLiteral(" />\r\n\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t</div>\r\n\t\t\t\t\t</div>\r\n\r" +
"\n\t\t\t\t\t<!-- Params -->\r\n");

            
            #line 107 "..\..\Areas\Manager\Views\ConfigMgr\List.cshtml"
					
            
            #line default
            #line hidden
            
            #line 107 "..\..\Areas\Manager\Views\ConfigMgr\List.cshtml"
                     foreach (var block in Model.Where(b => b.Section.ToLower() == "general")) {
						
            
            #line default
            #line hidden
            
            #line 108 "..\..\Areas\Manager\Views\ConfigMgr\List.cshtml"
                   Write(Html.EditorFor(m => block));

            
            #line default
            #line hidden
            
            #line 108 "..\..\Areas\Manager\Views\ConfigMgr\List.cshtml"
                                                   
					}

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t</div>\r\n\r\n\t\t\t\t<!-- Blog settings -->\r\n\t\t\t\t<div");

WriteLiteral(" data-bind=\"if: active() == \'blogging\'\"");

WriteLiteral(">\r\n\t\t\t\t\t<!-- Comments -->\r\n\t\t\t\t\t<div");

WriteLiteral(" id=\"pnlComments\"");

WriteLiteral(" class=\"panel panel-white\"");

WriteLiteral(">\r\n\t\t\t\t\t\t<div");

WriteLiteral(" class=\"notification\"");

WriteLiteral(">\r\n\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\"icon\"");

WriteLiteral("><span");

WriteLiteral(" class=\"glyphicon glyphicon-ok-circle\"");

WriteLiteral("></span></div>\r\n\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t<div");

WriteLiteral(" class=\"panel-body\"");

WriteLiteral(">\r\n\t\t\t\t\t\t\t<!-- Save -->\r\n\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\"btn-group pull-right\"");

WriteLiteral(">\r\n\t\t\t\t\t\t\t\t<button");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-labeled btn-success\"");

WriteLiteral(" data-bind=\"click: saveComments\"");

WriteLiteral(">\r\n\t\t\t\t\t\t\t\t\t<span");

WriteLiteral(" class=\"btn-label\"");

WriteLiteral(">\r\n\t\t\t\t\t\t\t\t\t\t<i");

WriteLiteral(" class=\"glyphicon glyphicon-ok\"");

WriteLiteral("></i>\r\n\t\t\t\t\t\t\t\t\t</span>\r\n");

WriteLiteral("\t\t\t\t\t\t\t\t\t");

            
            #line 126 "..\..\Areas\Manager\Views\ConfigMgr\List.cshtml"
                               Write(Piranha.Manager.Resources.Global.Save);

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t\t\t\t</button>\r\n\t\t\t\t\t\t\t</div>\r\n\r\n\t\t\t\t\t\t\t<h3>");

            
            #line 130 "..\..\Areas\Manager\Views\ConfigMgr\List.cshtml"
                           Write(Piranha.Manager.Resources.Config.Comments);

            
            #line default
            #line hidden
WriteLiteral("</h3>\r\n\r\n\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n\t\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\"col-sm-12\"");

WriteLiteral(">\r\n\t\t\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n\t\t\t\t\t\t\t\t\t\t<label>");

            
            #line 135 "..\..\Areas\Manager\Views\ConfigMgr\List.cshtml"
                                          Write(Piranha.Manager.Resources.Config.Moderators);

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n\t\t\t\t\t\t\t\t\t\t<input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" data-bind=\"value: commentModerators\"");

WriteLiteral(" />\r\n\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\"col-sm-6\"");

WriteLiteral(">\r\n\t\t\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\"checkbox\"");

WriteLiteral(">\r\n\t\t\t\t\t\t\t\t\t\t<label>\r\n\t\t\t\t\t\t\t\t\t\t\t<input");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" data-bind=\"checked: commentModerateAnonymous\"");

WriteLiteral(" /> <strong>");

            
            #line 142 "..\..\Areas\Manager\Views\ConfigMgr\List.cshtml"
                                                                                                                       Write(Piranha.Manager.Resources.Config.ModerateAnonymous);

            
            #line default
            #line hidden
WriteLiteral("</strong>\r\n\t\t\t\t\t\t\t\t\t\t</label>\r\n\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\"checkbox\"");

WriteLiteral(">\r\n\t\t\t\t\t\t\t\t\t\t<label>\r\n\t\t\t\t\t\t\t\t\t\t\t<input");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" data-bind=\"checked: commentNotifyAuthor\"");

WriteLiteral(" /> <strong>");

            
            #line 147 "..\..\Areas\Manager\Views\ConfigMgr\List.cshtml"
                                                                                                                  Write(Piranha.Manager.Resources.Config.NotifyAuthors);

            
            #line default
            #line hidden
WriteLiteral("</strong>\r\n\t\t\t\t\t\t\t\t\t\t</label>\r\n\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\"col-sm-6\"");

WriteLiteral(">\r\n\t\t\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\"checkbox\"");

WriteLiteral(">\r\n\t\t\t\t\t\t\t\t\t\t<label>\r\n\t\t\t\t\t\t\t\t\t\t\t<input");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" data-bind=\"checked: commentModerateAuthorized\"");

WriteLiteral(" /> <strong>");

            
            #line 154 "..\..\Areas\Manager\Views\ConfigMgr\List.cshtml"
                                                                                                                        Write(Piranha.Manager.Resources.Config.ModerateAuthorized);

            
            #line default
            #line hidden
WriteLiteral("</strong>\r\n\t\t\t\t\t\t\t\t\t\t</label>\r\n\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\"checkbox\"");

WriteLiteral(">\r\n\t\t\t\t\t\t\t\t\t\t<label>\r\n\t\t\t\t\t\t\t\t\t\t\t<input");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" data-bind=\"checked: commentNotifyModerators\"");

WriteLiteral(" /> <strong>");

            
            #line 159 "..\..\Areas\Manager\Views\ConfigMgr\List.cshtml"
                                                                                                                      Write(Piranha.Manager.Resources.Config.NotifyModerators);

            
            #line default
            #line hidden
WriteLiteral("</strong>\r\n\t\t\t\t\t\t\t\t\t\t</label>\r\n\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t</div>\r\n\t\t" +
"\t\t\t\t</div>\r\n\t\t\t\t\t</div>\r\n\r\n\t\t\t\t\t<!-- Params -->\r\n");

            
            #line 168 "..\..\Areas\Manager\Views\ConfigMgr\List.cshtml"
					
            
            #line default
            #line hidden
            
            #line 168 "..\..\Areas\Manager\Views\ConfigMgr\List.cshtml"
                     foreach (var block in Model.Where(b => b.Section.ToLower() == "blogging")) {
						
            
            #line default
            #line hidden
            
            #line 169 "..\..\Areas\Manager\Views\ConfigMgr\List.cshtml"
                   Write(Html.EditorFor(m => block));

            
            #line default
            #line hidden
            
            #line 169 "..\..\Areas\Manager\Views\ConfigMgr\List.cshtml"
                                                   
					}

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t</div>\r\n\r\n\t\t\t\t<!-- Custom sections -->\r\n");

            
            #line 174 "..\..\Areas\Manager\Views\ConfigMgr\List.cshtml"
				
            
            #line default
            #line hidden
            
            #line 174 "..\..\Areas\Manager\Views\ConfigMgr\List.cshtml"
                 foreach (var section in sections) {

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t\t<div");

WriteLiteral(" data-bind=\"if: active() == \'");

            
            #line 175 "..\..\Areas\Manager\Views\ConfigMgr\List.cshtml"
                                                 Write(section.ToLower());

            
            #line default
            #line hidden
WriteLiteral("\'\"");

WriteLiteral(">\r\n\t\t\t\t\t\t<!-- Blocks -->\r\n");

            
            #line 177 "..\..\Areas\Manager\Views\ConfigMgr\List.cshtml"
						
            
            #line default
            #line hidden
            
            #line 177 "..\..\Areas\Manager\Views\ConfigMgr\List.cshtml"
                         foreach (var block in Model.Where(b => b.Section.ToLower() == section.ToLower())) {
							
            
            #line default
            #line hidden
            
            #line 178 "..\..\Areas\Manager\Views\ConfigMgr\List.cshtml"
                       Write(Html.EditorFor(m => block));

            
            #line default
            #line hidden
            
            #line 178 "..\..\Areas\Manager\Views\ConfigMgr\List.cshtml"
                                                       
						}						

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t\t</div>\r\n");

            
            #line 181 "..\..\Areas\Manager\Views\ConfigMgr\List.cshtml"
				}

            
            #line default
            #line hidden
WriteLiteral("\t\t\t</form>\r\n\t\t</div>\r\n\t</div>\r\n</div>\r\n");

        }
    }
}
#pragma warning restore 1591