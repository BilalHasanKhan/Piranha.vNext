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
using System.Collections.Generic;

namespace Piranha.Server
{
	/// <summary>
	/// The handlers used by the Piranha routing.
	/// </summary>
	public sealed class HandlerCollection
	{
		#region Members
		/// <summary>
		/// The private collection of handlers.
		/// </summary>
		private readonly Dictionary<string, IHandler> handlers;
		#endregion

		#region Properties
		/// <summary>
		/// Gets/sets the registered alias handler.
		/// </summary>
		public IHandler Aliases { get; set; }

		/// <summary>
		/// Gets/sets the registered page handler.
		/// </summary>
		public IHandler Pages { get; set; }

		/// <summary>
		/// Gets/sets the registered post handler.
		/// </summary>
		public IHandler Posts { get; set; }

		/// <summary>
		/// Gets/sets the handler with the given key.
		/// </summary>
		/// <param name="key">The handler key</param>
		/// <returns>The registered handler, null if not found</returns>
		public IHandler this[string key] {
			get {
				IHandler handler;

				if (handlers.TryGetValue(key, out handler))
					return handler;
				return null;
			}
			set { handlers[key] = value; }
		}
		#endregion

		/// <summary>
		/// Default internal constructor.
		/// </summary>
		internal HandlerCollection() {
			handlers = new Dictionary<string, IHandler>();
		}

		/// <summary>
		/// Adds a new or replaces the registered handler with the given
		/// key.
		/// </summary>
		/// <param name="key">The handler key</param>
		/// <param name="handler">The request handler</param>
		public void Add(string key, IHandler handler) {
			handlers[key] = handler;
		}

		/// <summary>
		/// Removes the handler with the given key.
		/// </summary>
		/// <param name="key">The handler key</param>
		public void Remove(string key) {
			handlers.Remove(key);
		}
	}
}
