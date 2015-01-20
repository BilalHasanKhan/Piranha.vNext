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
using System.IO;

namespace Piranha.Log
{
	/// <summary>
	/// Log provider for writing application logs to file.
	/// </summary>
	public class FileLog : ILog
	{
		#region Members
		private const string msg = "{0} [{1}] {2}";
		private readonly string path = Path.Combine("App_Data", "Logs");
		private readonly object mutex = new object();
		private readonly string filePath;
		private readonly bool disabled;
		#endregion

		/// <summary>
		/// Default constructor.
		/// </summary>
		public FileLog() {
			if (AppDomain.CurrentDomain != null && !String.IsNullOrWhiteSpace(AppDomain.CurrentDomain.BaseDirectory)) {
				var mapped = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);

				// Ensure log directory
				if (!Directory.Exists(mapped))
					Directory.CreateDirectory(mapped);

				// Store mapped file path
				filePath = Path.Combine(mapped, "Log.txt");
			} else {
				disabled = true;
			}
		}

		/// <summary>
		/// Writes the given message to the log.
		/// </summary>
		/// <param name="level">The level</param>
		/// <param name="message">The log message</param>
		/// <param name="exception">The optional exception</param>
		public void Log(LogLevel level, string message, Exception exception = null) {
			if (!disabled) {
				if (level == LogLevel.INFO || level == LogLevel.WARNING) {
#if DEBUG
					// Only log info & warning message in Debug.
					Write(level, message, exception);
#endif
				} else {
					// Always log errors.
					Write(level, message, exception);
				}
			}
		}

		#region Private methods
		/// <summary>
		/// Writes the given message to the log.
		/// </summary>
		/// <param name="level">The level</param>
		/// <param name="message">The log message</param>
		/// <param name="exception">The optional exception</param>
		private void Write(LogLevel level, string message, Exception exception = null) {
			lock (mutex) {
				using (var writer = new StreamWriter(filePath, true)) {
					writer.WriteLine(String.Format(msg, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
						level.ToString(), message));
					if (exception != null)
						writer.WriteLine(exception.Message);
					writer.Flush();
					writer.Close();
				}
			}
		}
		#endregion
	}
}
