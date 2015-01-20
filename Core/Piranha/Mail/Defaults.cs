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

namespace Piranha.Mail
{
	/// <summary>
	/// The default mail messages available.
	/// </summary>
	public static class Defaults
	{
		/// <summary>
		/// Default mail for new comments.
		/// </summary>
		public const string NewComment =
			"<html>\n" +
			"<head>\n" +
			"	<style type=\"text/css\">\n" +
			"		body {{ background: #eee; color: #444; padding: 20px; font-family: Arial }}\n" +
			"		h1 {{ font-size: 24px; margin-left: 90px; padding-top: 15px; margin-bottom: 0; }}\n" +
			"		a {{ color: #1f7da4; text-decoration: none; }}\n" +
			"		p {{ background: #fff; padding: 20px; border-radius: 3px; }}\n" +
			"		p.meta {{ background: #eee; padding: 0; margin: 8px 0 30px 90px; color: #666; font-size: 0.9em; }}\n" +
			"		.gravatar {{ border-radius: 40px; float: left; }}\n" +
			"	</style>\n" +
			"	<title>New comment</title>\n" +
			"</head>\n" +
			"<body>\n" +
			"	<div class=\"comment\">\n" +
			"		<img class=\"gravatar\" src=\"{0}\">\n" +
			"		<h1>New comment on <a href=\"{1}\">{2}</a></h1>\n" +
			"		<p class=\"meta\">\n" +
			"			by <strong>{3}</strong> {4}\n" +
			"		</p>\n" +
			"		<p>{5}</p>\n" +
			"	</div>\n" +
			"</body>\n" +
			"</html>";
	}
}
