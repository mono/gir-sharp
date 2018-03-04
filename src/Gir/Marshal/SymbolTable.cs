using System;
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

		public void AddTypes (IEnumerable<ISymbol> symbols, Repository repository = null)
		{
			string nsPrefix = repository != null ? repository.Namespace.Name + "." : string.Empty;

			foreach (var symbol in symbols)
				AddTypeCommon (nsPrefix + symbol.Name, symbol);
		}

		public void AddType (ISymbol symbol, Repository repository = null)
		{
			string nsPrefix = repository != null ? repository.Namespace.Name + "." : string.Empty;
			AddTypeCommon (nsPrefix + symbol.Name, symbol);
		}

		void AddTypeCommon (string key, ISymbol symbol)
		{
			typeMap [key] = symbol;

			// Maybe do not register the type if we didn't pass in the repository, so we don't count things twice.
			statistics.RegisterType(symbol);
		}

		public ISymbol this [string type] => typeMap[type];

		public void ProcessAliases ()
		{
			char [] separator = { '.' };

			var copy = typeMap.ToDictionary (x => x.Key, x => x.Value);
			foreach (var kvp in copy) {
				if (kvp.Value is Alias alias) {
					// This is inside a resolved repository
					string repository = null;
					if (kvp.Key.Contains ('.')) {
						repository = kvp.Key.Split (separator) [0];
					}
					typeMap[kvp.Key] = Dealias (alias, repository);
				}
			}
		}

		ISymbol Dealias (Alias original, string repository = null)
		{
			ISymbol target = original;
			while (target is Alias alias) {
				var toType = alias.Type.Name;
				if (typeMap.TryGetValue (toType, out target))
					continue;

				if (repository != null) {
					// HACK?!: this might be in a included repository but these are prefixed in symbol table
					toType = $"{repository}.{alias.Type.Name}";
					if (typeMap.TryGetValue (toType, out target))
						continue;
				}

				statistics.RegisterError(new AliasRegistrationError(alias));
				return this["none"];
			}

			return target;
		}

		// This might contain duplicate symbols since we register the main repo as fully qualified and non-fully qualified.
		// Perhaps the better fix is for generatables to handle appending the namespace so it's fully qualified?
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
