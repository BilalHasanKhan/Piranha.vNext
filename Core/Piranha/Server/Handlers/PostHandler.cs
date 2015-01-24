﻿/*
 * Copyright (c) 2014-2015 Håkan Edling
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 * 
 * http://github.com/piranhacms/piranha.vnext
 * 
 */

using System;
using System.Linq;

namespace Piranha.Server.Handlers
{
	/// <summary>
	/// Handler for routing requests for posts.
	/// </summary>
	public class PostHandler : IHandler
	{
		/// <summary>
		/// Tries to handle an incoming request.
		/// </summary>
		/// <param name="api">The current api</param>
		/// <param name="request">The incoming route request</param>
		/// <returns>The result</returns>
		public IResponse Handle(Api api, IRequest request) {
			var type = api.PostTypes.GetSingle(request.Segments[0]);
			var route = "";

			if (type != null) {
				// First try to resolve a unique permalink
				if (request.Segments.Length > 1) {
					var post = Client.Models.PostModel.GetBySlug(request.Segments[1], type.Id);

					if (post != null) {
						route = !String.IsNullOrWhiteSpace(post.Route) ? post.Route : (!String.IsNullOrWhiteSpace(type.Route) ? type.Route : "post");

						if (request.Segments.Length > 2 && request.Segments[2] == "comment") {
							var response = request.RewriteResponse();

							response.Route = !String.IsNullOrWhiteSpace(type.CommentRoute) ? type.CommentRoute : "comment/add";
							response.Params = request.Params;

							return response;
						} else {
							route = !String.IsNullOrWhiteSpace(post.Route) ? post.Route : (!String.IsNullOrWhiteSpace(type.Route) ? type.Route : "post");

							// Append extra url segments
							for (var n = 2; n < request.Segments.Length; n++) {
								route += "/" + request.Segments[n];
							}

							// Set current
							App.Env.SetCurrent(new Client.Models.Current() {
								Id = post.Id,
								Title = post.Title,
								Keywords = post.Keywords,
								Description = post.Description,
								VirtualPath = "~/" + type.Slug + "/" + post.Slug,
								Type = Client.Models.CurrentType.Post
							});

							var response = request.RewriteResponse();

							response.Route = route;
							response.Params = request.Params.Concat(new Param[] { 
								new Param() { Key = "id", Value = post.Id.ToString() }
							}).ToArray();

							return response;
						}
					}
				}

				// Check if we should continue
				if (request.Segments.Length > 1 && request.Segments[1] != "page" && !IsNumber(request.Segments[1]))
					return null;

				// Secondly try to resolve an archive request
				if (type.EnableArchive) {
					route = !String.IsNullOrWhiteSpace(type.ArchiveRoute) ? type.ArchiveRoute : "archive";

					int? page = null;
					int? year = null;
					int? month = null;
					bool foundPage = false;

					for (var n = 1; n < request.Segments.Length; n++) {
						if (request.Segments[n] == "page") {
							foundPage = true;
							continue;
						}

						if (foundPage) {
							try {
								page = Convert.ToInt32(request.Segments[n]);

							} catch { }
							break;
						}

						if (!year.HasValue) {
							try {
								year = Convert.ToInt32(request.Segments[n]);

								if (year.Value > DateTime.Now.Year)
									year = DateTime.Now.Year;
							} catch { }
						} else {
							try {
								month = Math.Max(Math.Min(Convert.ToInt32(request.Segments[n]), 12), 1);
							} catch { }
						}
					}

					// Set current
					App.Env.SetCurrent(new Client.Models.Current() {
						Id = type.Id,
						Title = type.ArchiveTitle,
						Keywords = type.MetaKeywords,
						Description = type.MetaDescription,
						VirtualPath = "~/" + type.Slug + (year.HasValue ? "/" + year + (month.HasValue ? "/" + month : "") : ""),
						Type = Client.Models.CurrentType.Archive
					});

					var response = request.RewriteResponse();

					response.Route = route;
					response.Params = request.Params.Concat(new Param[] { 
						new Param() { Key = "id", Value = type.Id.ToString() },
						new Param() { Key = "year", Value = year.ToString() },
						new Param() { Key = "month", Value = month.ToString() },
						new Param() { Key = "page", Value = page.ToString() }
					}).ToArray();

					return response;
				}
			}
			return null;
		}

		#region Private methods
		/// <summary>
		/// Checks if the given given string is a number.
		/// </summary>
		/// <param name="str">The string</param>
		/// <returns>If the given string is a numerical value</returns>
		private bool IsNumber(string str) {
			try {
				var num = Convert.ToInt32(str);
			} catch {
				return false;
			}
			return true;
		}
		#endregion
	}
}
