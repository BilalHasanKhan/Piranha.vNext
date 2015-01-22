﻿/*
 * Copyright (c) 2014 Håkan Edling
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 * 
 * http://github.com/piranhacms/piranha.vnext
 * 
 */

using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;

namespace PiranhaCMS
{
	/// <summary>
	/// Main entry point for the MVC application.
	/// </summary>
	public class MvcApplication : System.Web.HttpApplication
	{
		/// <summary>
		/// Starts the MVC application.
		/// </summary>
		protected void Application_Start() {
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			AreaRegistration.RegisterAllAreas();

			// Initialize the application instance with the ASP.NET runtime
			Piranha.App.Init(c => {
				c.Cache = new Piranha.AspNet.Cache.HttpCache();
				c.Env = new Piranha.AspNet.Env();
				c.Mail = new Piranha.AspNet.Mail.SmtpMail();
				c.Security = new Piranha.AspNet.Security.SimpleSecurity("admin", "password");
				c.Store = new Piranha.EntityFramework.Store();
			});

			#region Seed test data
			//
			// Let's get some default data going
			//
			using (var api = new Piranha.Api()) {
				// Only seed if we don't have any authors
				if (api.Authors.Get().Count() == 0) {
					var author = api.Authors.GetSingle(@where: a => a.Name == "Håkan Edling");
					if (author == null) {
						author = new Piranha.Models.Author() {
							Name = "Håkan Edling",
							Email = "info@piranhacms.org"
						};
						api.Authors.Add(author);
						api.SaveChanges();
					}

					// Post type
					var type = api.PostTypes.GetSingle(@where: t => t.Slug == "blog");
					if (type == null) {
						type = new Piranha.Models.PostType() {
							Name = "Blog post",
							EnableArchive = true,
							ArchiveTitle = "Blog",
							Slug = "blog",
							MetaKeywords = "Piranha CMS, .NET, MVC, CMS, Blog",
							MetaDescription = "Read the latest toughts and rambles about your favourite framework."
						};
						api.PostTypes.Add(type);
						api.SaveChanges();
					}

					// Page type
					var pageType = api.PageTypes.GetSingle(@where: t => t.Slug == "standard");
					if (pageType == null) {
						pageType = new Piranha.Models.PageType() {
							Name = "Standard"
						};
						api.PageTypes.Add(pageType);
						api.SaveChanges();
					}

					// Categories
					var cat = api.Categories.GetSingle(@where: c => c.Slug == "development");
					if (cat == null) {
						cat = new Piranha.Models.Category() {
							Title = "Development"
						};
						api.Categories.Add(cat);
						api.SaveChanges();
					}

					// Posts
					var post = api.Posts.GetSingle(@where: p => p.Slug == "my-first-post");
					if (post == null) {
						post = new Piranha.Models.Post() {
							AuthorId = author.Id,
							TypeId = type.Id,
							Title = "My first post",
							Keywords = "Piranha CMS, Blog, First",
							Description = "The first post of the blog",
							Excerpt = "Maecenas faucibus mollis interdum. Duis mollis, est non commodo luctus, nisi erat porttitor ligula, eget lacinia odio sem nec elit. Morbi leo risus, porta ac consectetur ac, vestibulum at eros.",
							Body = "<p>Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Etiam porta sem malesuada magna mollis euismod. Aenean eu leo quam. Pellentesque ornare sem lacinia quam venenatis vestibulum. Morbi leo risus, porta ac consectetur ac, vestibulum at eros. Nullam quis risus eget urna mollis ornare vel eu leo.</p>" +
								   "<p>Curabitur blandit tempus porttitor. Cras mattis consectetur purus sit amet fermentum. Aenean lacinia bibendum nulla sed consectetur. Sed posuere consectetur est at lobortis. Morbi leo risus, porta ac consectetur ac, vestibulum at eros. Vestibulum id ligula porta felis euismod semper.</p>",
							Published = DateTime.Now
						};

						post.Categories.Add(cat);

						api.Posts.Add(post);
						api.SaveChanges();

						api.Comments.Add(new Piranha.Models.Comment() {
							PostId = post.Id,
							Author = "Håkan Edling",
							Email = "hakan@tidyui.com",
							IsApproved = true,
							WebSite = "http://piranhacms.org",
							Body = "I hope you enjoy this new version of Piranha CMS. Remember to give me your feedback at the GitHub repo."
						});
						api.SaveChanges();
					}

					// Pages
					var page = api.Pages.GetSingle(@where: p => p.Slug == "welcome-to-piranha-cms");
					if (page == null) {
						// Get startpage body from resource file
						string body;
						using (var reader = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + @"\App_Data\Import\startcontent.html")) {
							body = reader.ReadToEnd();
						}

						// Create page
						page = new Piranha.Models.Page() {
							AuthorId = author.Id,
							TypeId = pageType.Id,
							Title = "Welcome to Piranha vNext",
							IsHidden = true,
							Keywords = "Piranha CMS, CMS, ASP.NET MVC, ASP.NET WebPages, Entity Framework",
							Description = "Piranha is the fun, fast and lightweight .NET framework for developing cms-based web applications with an extra bite. It's built on ASP.NET MVC 5, Web Pages 3 & Entity Framework 6",
							Body = body,
							Published = DateTime.Now
						};
						api.Pages.Add(page);
						api.SaveChanges();
					}
				}
			}
			#endregion

			#region Seed new content model
			using (var api = new Piranha.Api()) {
				if (api.Content.Get().Count() == 0) {
					// Get the first author & category
					var author = api.Authors.Get().First();
					var cat = api.Categories.Get().First();

					// Template
					var template = api.Templates.GetSingle(where: t => t.Name == "Post");
					if (template == null) {
						template = new Piranha.Models.Template() {
							Name = "Post",
							Type = Piranha.Models.ContentType.Post
						};
						api.Templates.Add(template);
						api.SaveChanges();
					}

					// Content
					var content = api.Content.GetSingle(where: c => c.Slug == "my-first-content");
					if (content == null) {
						content = new Piranha.Models.Content() {
							AuthorId = author.Id,
							TemplateId = template.Id,
							Type = Piranha.Models.ContentType.Post,
							Title = "My first content",
							MetaKeywords = "Piranha CMS, Blog, First",
							MetaDescription = "The first post of the blog",
							Published = DateTime.Now
						};
						content.Categories.Add(cat);
						content.Rows.Add(new Piranha.Models.ContentRow() {
							SortOrder = 1
						});
						content.Rows[0].Blocks.Add(new Piranha.Models.ContentBlock() {
							SortOrder = 1,
							Size = 9
						});
						content.Rows[0].Blocks[0].Body = new Piranha.Extend.Blocks.Html() {
							Body = "<p>Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Etiam porta sem malesuada magna mollis euismod. Aenean eu leo quam. Pellentesque ornare sem lacinia quam venenatis vestibulum. Morbi leo risus, porta ac consectetur ac, vestibulum at eros. Nullam quis risus eget urna mollis ornare vel eu leo.</p>" + 
								"<p>Curabitur blandit tempus porttitor. Cras mattis consectetur purus sit amet fermentum. Aenean lacinia bibendum nulla sed consectetur. Sed posuere consectetur est at lobortis. Morbi leo risus, porta ac consectetur ac, vestibulum at eros. Vestibulum id ligula porta felis euismod semper.</p>"
						};
						content.Rows[0].Blocks.Add(new Piranha.Models.ContentBlock() {
							SortOrder = 2,
							Size = 3
						});
						content.Rows[0].Blocks[1].Body = new Piranha.Extend.Blocks.Html() {
							Body = "<p>Sidebar ipsum. Aside porta sem malesuada magna mollis euismod. Aenean eu leo quam.</p>"
						};
						api.Content.Add(content);
						api.SaveChanges();
					}
				}
			}
			#endregion
		}
	}
}
