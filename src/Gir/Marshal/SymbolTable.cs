using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Gir
{
	public partial class SymbolTable : IEnumerable<ISymbol>
	{
		// FIXME: Known issue with pointers. We need to figure that one out.
		readonly Dictionary<string, ISymbol> typeMap = new Dictionary<string, ISymbol>();
		Statistics statistics;

		public SymbolTable(Statistics statistics, bool nativeWin64)
		{
			this.statistics = statistics;

			RegisterBuiltIn(nativeWin64);
		}

		public void AddTypes (IEnumerable<ISymbol> symbols)
		{
			foreach (var symbol in symbols)
				AddType(symbol);
		}

		public void AddType (ISymbol symbol)
		{
			typeMap[symbol.CType] = symbol;
			statistics.RegisterType(symbol);
		}

		public ISymbol this[string type] {
			get {
				// Handle pointer trimming
				// The main idea is to figure out the number of pointer symbols trimmed
				// And use that in marshalling.


				return typeMap[type];
			}
		}

		public void ProcessAliases ()
		{
			var copy = typeMap.ToDictionary(x => x.Key, x => x.Value);
			foreach (var kvp in copy) {
				if (kvp.Value is Alias alias) {
					typeMap[kvp.Key] = Dealias(alias);
				}
			}
		}

		ISymbol Dealias (Alias original)
		{
			ISymbol target = original;
			while (target is Alias alias) {
				if (!typeMap.TryGetValue(alias.Type.CType, out target)) {
					statistics.RegisterError(new AliasRegistrationError(alias));
					return this["void"];
				}
			}
			return target;
		}

		public IEnumerator<ISymbol> GetEnumerator()
		{
			return typeMap.Values.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
