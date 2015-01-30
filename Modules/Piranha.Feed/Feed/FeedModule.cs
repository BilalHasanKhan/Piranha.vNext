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
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Piranha.Extend;
using Piranha.Client.Models;
using Piranha.Server;

namespace Piranha.Feed
{
	/// <summary>
	/// Main entry point for the feed module.
	/// </summary>
	public class FeedModule : IModule
	{
		#region Members
		private const string LINK_TAG = "<link rel=\"{0}\" type=\"{1}\" title=\"{2}\" href=\"{3}\">\n";
		#endregion

		/// <summary>
		/// Initializes the module. This method should be used for
		/// ensuring runtime resources and registering hooks.
		/// </summary>
		public void Init() {
			using (var api = new Api()) {
				// Ensure configuration params
				var param = api.Params.GetSingle(where: p => p.Name == "feed_pagesize");
				if (param == null) {
					param = new Models.Param() { 
						Name = "feed_pagesize",
						Value = "10"
					};
					api.Params.Add(param);
				}
				param = api.Params.GetSingle(where: p => p.Name == "feed_sitefeedtitle");
				if (param == null) {
					param = new Models.Param() { 
						Name = "feed_sitefeedtitle",
						Value = "{SiteTitle} > Feed"
					};
					api.Params.Add(param);
				}
				param = api.Params.GetSingle(where: p => p.Name == "feed_archivefeedtitle");
				if (param == null) {
					param = new Models.Param() { 
						Name = "feed_archivefeedtitle",
						Value = "{SiteTitle} > {PostType} Archive Feed"
					};
					api.Params.Add(param);
				}
				param = api.Params.GetSingle(where: p => p.Name == "feed_commentfeedtitle");
				if (param == null) {
					param = new Models.Param() { 
						Name = "feed_commentfeedtitle",
						Value = "{SiteTitle} > Comments Feed"
					};
					api.Params.Add(param);
				}
				param = api.Params.GetSingle(where: p => p.Name == "feed_postfeedtitle");
				if (param == null) {
					param = new Models.Param() { 
						Name = "feed_postfeedtitle",
						Value = "{SiteTitle} > {PostTitle} Comments Feed"
					};
					api.Params.Add(param);
				}

				// Save changes
				api.SaveChanges();
			}

			// Add configuration to the manager
			Manager.Config.Blocks.Add(new Manager.Config.ConfigBlock("Blogging", "Feed", new List<Manager.Config.ConfigRow>() {
				new Manager.Config.ConfigRow(new List<Manager.Config.ConfigColumn>() {
					new Manager.Config.ConfigColumn(new List<Manager.Config.ConfigItem>() {
						new Manager.Config.ConfigString() {
							Name = "Site title", Param = "feed_sitefeedtitle", Value = Config.Feed.SiteFeedTitle
						},
						new Manager.Config.ConfigString() {
							Name = "Archive title", Param = "feed_archivefeedtitle", Value = Config.Feed.ArchiveFeedTitle
						},
						new Manager.Config.ConfigInteger() {
							Name = "Page size", Param = "feed_pagesize", Value = Config.Feed.PageSize.ToString()
						}
					}),
					new Manager.Config.ConfigColumn(new List<Manager.Config.ConfigItem>() {
						new Manager.Config.ConfigString() {
							Name = "Comment title", Param = "feed_commentfeedtitle", Value = Config.Feed.CommentFeedTitle
						},
						new Manager.Config.ConfigString() {
							Name = "Post title", Param = "feed_postfeedtitle", Value = Config.Feed.PostFeedTitle
						}
					})
				})
			}));

			// Add the feed handler
			App.Handlers.Add("feed", new FeedHandler());

			// Add UI rendering
			Hooks.UI.Head.Render += (sb) => {
				var ui = new Client.Helpers.UIHelper();

				// Get current
				var current = App.Env.GetCurrent();

				// Render base feeds
				var sTitle = HttpUtility.HtmlEncode(Config.Feed.SiteFeedTitle
					.Replace("{SiteTitle}", Config.Site.Title));

				var cTitle = HttpUtility.HtmlEncode(Config.Feed.CommentFeedTitle
					.Replace("{SiteTitle}", Config.Site.Title));

				sb.Append(String.Format(LINK_TAG, "alternate", "application/rss+xml", sTitle,
					App.Env.AbsoluteUrl("~/feed")));
				sb.Append(String.Format(LINK_TAG, "alternate", "application/rss+xml", cTitle,
					App.Env.AbsoluteUrl("~/feed/comments")));

				if (current.Type == CurrentType.Archive) {
					using (var api = new Api()) {
						var title = HttpUtility.HtmlEncode(Config.Feed.ArchiveFeedTitle
							.Replace("{SiteTitle}", Config.Site.Title)
							.Replace("{PostType}", Config.Site.ArchiveTitle));

						sb.Append(String.Format(LINK_TAG, "alternate", "application/rss+xml", title,
							App.Env.AbsoluteUrl("~/" + Config.Permalinks.PostArchiveSlug)));
					}
				} else if (current.Type == CurrentType.Post) {
					var content = Client.Models.ContentModel.GetById(current.Id);

					var title = HttpUtility.HtmlEncode(Config.Feed.PostFeedTitle
						.Replace("{SiteTitle}", Config.Site.Title)
						.Replace("{PostTitle}", content.Title));

					sb.Append(String.Format(LINK_TAG, "alternate", "application/rss+xml", title,
						App.Env.AbsoluteUrl(ui.Permalink(content))));
				}
			};
		}
	}
}