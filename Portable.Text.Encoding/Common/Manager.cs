/*
 * Manager.cs - Implementation of the "I18N.Common.Manager" class.
 *
 * Copyright (c) 2002  Southern Storm Software, Pty Ltd
 *
 * Permission is hereby granted, free of charge, to any person obtaining
 * a copy of this software and associated documentation files (the "Software"),
 * to deal in the Software without restriction, including without limitation
 * the rights to use, copy, modify, merge, publish, distribute, sublicense,
 * and/or sell copies of the Software, and to permit persons to whom the
 * Software is furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS
 * OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
 * THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR
 * OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
 * ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
 * OTHER DEALINGS IN THE SOFTWARE.
 */

using System;
using System.Text;
using System.Globalization;
using System.Collections.Generic;
using System.Reflection;

namespace Portable.Text {
	// This class provides the primary entry point into the I18N
	// library.  Users of the library start by getting the value
	// of the "PrimaryManager" property.  They then invoke methods
	// on the manager to obtain further I18N information.
	class Manager
	{
		// The primary I18N manager.
		private static Manager manager;
		// Internal state.
		readonly Dictionary<string, object> handlers;
		// List of all handler classes.
		Dictionary<string, object> active;
		// Currently active handlers.
		Dictionary<string, object> assemblies;
		// Currently loaded region assemblies.
		static readonly object lockobj = new object ();

		// Constructor.
		Manager ()
		{
			handlers = new Dictionary<string, object> (StringComparer.OrdinalIgnoreCase);
			active = new Dictionary<string, object> (16);
			assemblies = new Dictionary<string, object> (8);
			LoadClassList ();
		}

		// Get the primary I18N manager instance.
		public static Manager PrimaryManager {
			get {
				lock (lockobj) {
					if (manager == null) {
						manager = new Manager ();
					}
					return manager;
				}
			}
		}
		// Normalize a name.
		// FIXME: This means, we accept invalid names such as "euc_jp"
		static string Normalize (String name)
		{
			return name.ToLower (CultureInfo.InvariantCulture).Replace ('-', '_');
		}
		// Get an encoding object for a specific code page.
		// Returns NULL if the code page is not available.
		public Encoding GetEncoding (int codePage)
		{
			return Instantiate ("CP" + codePage) as Encoding;
		}
		// Get an encoding object for a specific Web encoding.
		// Returns NULL if the encoding is not available.
		public Encoding GetEncoding (String name)
		{
			// Validate the parameter.
			if (name == null) {
				return null;
			}

			string orgName = name;

			// Normalize the encoding name.
			name = Normalize (name);

			// Try to find a class called "ENCname".
			Encoding e = Instantiate ("ENC" + name) as Encoding;
			if (e == null)
				e = Instantiate (name) as Encoding;

			if (e == null) {
				// Try windows aliases
				string alias = Handlers.GetAlias (name);
				if (alias != null) {
					e = Instantiate ("ENC" + alias) as Encoding;
					if (e == null)
						e = Instantiate (alias) as Encoding;
				}
			}
			if (e == null)
				return null;

			// e.g. Neither euc_jp nor shift-jis not allowed (Normalize() badness)
			if (orgName.IndexOf ('_') > 0 && e.WebName.IndexOf ('-') > 0)
				return null;
			if (orgName.IndexOf ('-') > 0 && e.WebName.IndexOf ('_') > 0)
				return null;
			return e;
		}
		// List of hex digits for use by "GetCulture".
		private const String hex = "0123456789abcdef";
		// Get a specific culture by identifier.  Returns NULL
		// if the culture information is not available.
		public CultureInfo GetCulture (int culture, bool useUserOverride)
		{
			// Create the hex version of the culture identifier.
			StringBuilder builder = new StringBuilder ();
			builder.Append (hex [(culture >> 12) & 0x0F]);
			builder.Append (hex [(culture >> 8) & 0x0F]);
			builder.Append (hex [(culture >> 4) & 0x0F]);
			builder.Append (hex [culture & 0x0F]);
			String name = builder.ToString ();

			// Try looking for an override culture handler.
			if (useUserOverride) {
				Object obj = Instantiate ("CIDO" + name);
				if (obj != null) {
					return (obj as CultureInfo);
				}
			}

			// Look for the generic non-override culture.
			return (Instantiate ("CID" + name) as CultureInfo);
		}
		// Get a specific culture by name.  Returns NULL if the
		// culture informaion is not available.
		public CultureInfo GetCulture (String name, bool useUserOverride)
		{
			// Validate the parameter.
			if (name == null) {
				return null;
			}

			// Normalize the culture name.
			name = Normalize (name);

			// Try looking for an override culture handler.
			if (useUserOverride) {
				Object obj = Instantiate ("CNO" + name);
				if (obj != null) {
					return (obj as CultureInfo);
				}
			}

			// Look for the generic non-override culture.
			return (Instantiate ("CN" + name) as CultureInfo);
		}
		// Instantiate a handler class.  Returns null if it is not
		// possible to instantiate the class.
		internal object Instantiate (string name)
		{
			Assembly assembly;
			object handler;
			string region;
			Type type;

			lock (this) {
				// See if we already have an active handler by this name.
				handler = active [name];
				if (handler != null) {
					return handler;
				}

				// Determine which region assembly handles the class.
				region = (String)(handlers [name]);
				if (region == null) {
					// The class does not exist in any region assembly.
					return null;
				}

				// Find the region-specific assembly and load it.
				assembly = (Assembly)(assemblies [region]);
				if (assembly == null) {
					try {
						// we use the same strong name as I18N.dll except the assembly name
						AssemblyName myName = typeof(Manager).GetTypeInfo ().Assembly.GetName ();
						myName.Name = region;
						assembly = Assembly.Load (myName);
					} catch {
						assembly = null;
					}
					if (assembly == null) {
						return null;
					}
					assemblies [region] = assembly;
				}

				// Look for the class within the region-specific assembly.
				type = assembly.GetType (region + "." + name, false, true);
				if (type == null) {
					return null;
				}

				// Invoke the constructor, which we assume is public
				// and has zero arguments.
				try {
					handler = Activator.CreateInstance (type);
				} catch {
					// The constructor was not present/inaccessable.
					return null;
				}

				// Add the handler to the active handlers cache.
				active.Add (name, handler);

				// Return the handler to the caller.
				return handler;
			}
		}
		// Load the list of classes that are present in all region assemblies.
		private void LoadClassList ()
		{
			// The file does not exist, or the runtime engine
			// refuses to implement the necessary semantics.
			// Fall back to an internal list, which must be
			// kept up to date manually.
			LoadInternalClasses ();
		}
		// Load the list of classes from the internal list.
		private void LoadInternalClasses ()
		{
			int posn;
			foreach (string line in Handlers.List) {
				// Split the line into namespace and name.  We assume
				// that the line has the form "I18N.<Region>.<Name>".
				posn = line.LastIndexOf ('.');
				if (posn != -1) {
					// Add the namespace to the "handlers" hash,
					// attached to the name of the handler class.
					string name = line.Substring (posn + 1);
					if (!handlers.ContainsKey (name)) {
						handlers.Add (name, line.Substring (0, posn));
					}
				}
			}
		}
	};
	// class Manager
};
 // namespace I18N.Common
