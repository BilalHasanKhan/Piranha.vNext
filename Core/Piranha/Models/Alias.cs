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
using FluentValidation;

namespace Piranha.Models
{
	/// <summary>
	/// Aliases are used to redirect old URL's to new ones.
	/// </summary>
	public sealed class Alias : Model, Data.IModel, Data.IChanges
	{
		#region Properties
		/// <summary>
		/// Gets/sets the unique id.
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// Gets/sets the old url.
		/// </summary>
		public string OldUrl { get; set; }

		/// <summary>
		/// Gets/sets the new url.
		/// </summary>
		public string NewUrl { get; set; }

		/// <summary>
		/// Gets/sets if this is a permanent redirect.
		/// </summary>
		public bool IsPermanent { get; set; }

		/// <summary>
		/// Gets/sets when the model was initially created.
		/// </summary>
		public DateTime Created { get; set; }

		/// <summary>
		/// Gets/sets when the model was last updated.
		/// </summary>
		public DateTime Updated { get; set; }
		#endregion

		#region Events
		/// <summary>
		/// Called before the model is saved by the DbContext.
		/// </summary>
		/// <param name="db">The current db context</param>
		public override void OnSave() {
			// ensure to call the base class OnSave which will validate the model
			base.OnSave();

			// Remove from model cache
			App.ModelCache.Remove<Models.Alias>(this.Id);
		}

		/// <summary>
		/// Called before the model is deleted by the DbContext.
		/// </summary>
		/// <param name="db">The current db context</param>
		public override void OnDelete() {
			// Remove from model cache
			App.ModelCache.Remove<Models.Alias>(this.Id);
		}
		#endregion

		/// <summary>
		/// Method to validate model
		/// </summary>
		/// <returns>Returns the result of validation</returns>
		protected override FluentValidation.Results.ValidationResult Validate()
		{
			var validator = new AliasValidator();
			return validator.Validate(this);
		}

		#region Validator
		private class AliasValidator : FluentValidation.AbstractValidator<Alias>
		{
			public AliasValidator()
			{
				RuleFor(m => m.NewUrl).NotEmpty();
				RuleFor(m => m.NewUrl).Length(0, 255);
				RuleFor(m => m.OldUrl).NotEmpty();
				RuleFor(m => m.NewUrl).Length(0, 255);
				
				// check unique OldUrl
				RuleFor(m => m.OldUrl).Must((model, oldUrl) => { return IsOldUrlUnique(oldUrl, model.Id); }).WithMessage("OldUrl alias already exists");
			}

			/// <summary>
			/// Function to validate if OldUrl is unique
			/// </summary>
			/// <param name="url"></param>
			/// <param name="api"></param>
			/// <returns></returns>
			private bool IsOldUrlUnique(string url, Guid id) {
				using (var api = new Api()) 
				{ 
					var recordCount = api.Aliases.Get(where: m => m.OldUrl == url && m.Id != id).Count();
					return recordCount == 0;
				}
			}
		}
		#endregion
	}
}
