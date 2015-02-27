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

namespace Piranha.Extend.Components
{
	/// <summary>
	/// Boolean extension.
	/// </summary>
	[Component(Name="Date", Type=ComponentType.TemplateField)]
	public class Date : Component<DateTime>, IComponent
	{
		/// <summary>
		/// Default constructor.
		/// </summary>
		public Date() : base(v => v) { }
	}
}