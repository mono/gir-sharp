﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Gir
{
	public partial class SymbolTable : IEnumerable<ISymbol>
	{
		readonly Dictionary<string, ISymbol> typeMap = new Dictionary<string, ISymbol> ();
		Statistics statistics;

		public SymbolTable (Statistics statistics, bool nativeWin64)
		{
			this.statistics = statistics;

			RegisterBuiltIn (nativeWin64);
		}

		public void AddTypes (IEnumerable<ISymbol> symbols)
		{
			foreach (var symbol in symbols)
				AddType (symbol);
		}

		public void AddType (ISymbol symbol)
		{
			// TODO, not all <class> tags have a CType
			// https://raw.githubusercontent.com/gtk-rs/gir-files/master/Gtk-3.0.gir
			// <class name="EntryIconAccessible"
			//     c: symbol - prefix = "entry_icon_accessible"
			//     parent = "Atk.Object"
			//     glib: type - name = "GtkEntryIconAccessible"
			//     glib: get - type = "gtk_entry_icon_accessible_get_type" >
			//   <implements name = "Atk.Action" />
			//   <implements name = "Atk.Component" />
			// </class>
			if (symbol.CType == null) return;

			typeMap [symbol.CType] = symbol;
			statistics.RegisterType (symbol);
		}

		const string constPrefix = "const ";
		static string TrimConstAndPointer (string type)
		{
			int start = 0;
			if (type.StartsWith (constPrefix, StringComparison.Ordinal)) {
				start = constPrefix.Length;
			}

			// Look for the first pointer symbol
			int end = type.IndexOf ('*', start, type.Length - start);
			if (end == -1) {
				end = type.Length;
			}
			else if (type.IndexOf ("void", start, StringComparison.Ordinal) == 0) {
				// Special case in case of pointers for void*,
				// otherwise we'll get void from the symbol table
				return "gpointer";
			}

			return type.Substring (start, end - start);
		}

		public ISymbol this [string type] {
			get {
				var actualType = TrimConstAndPointer (type);

				return typeMap [actualType];
			}
		}

		public void ProcessAliases ()
		{
			var copy = typeMap.ToDictionary (x => x.Key, x => x.Value);
			foreach (var kvp in copy) {
				if (kvp.Value is Alias alias) {
					typeMap [kvp.Key] = Dealias (alias);
				}
			}
		}

		ISymbol Dealias (Alias original)
		{
			ISymbol target = original;
			while (target is Alias alias) {
				var toType = TrimConstAndPointer (alias.Type.CType);
				if (!typeMap.TryGetValue (toType, out target)) {
					statistics.RegisterError (new AliasRegistrationError (alias));
					return this ["void"];
				}
			}
			return target;
		}

		public IEnumerator<ISymbol> GetEnumerator ()
		{
			return typeMap.Values.GetEnumerator ();
		}

		IEnumerator IEnumerable.GetEnumerator ()
		{
			return GetEnumerator ();
		}
	}
}
