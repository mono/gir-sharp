using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Gir
{
	public partial class SymbolTable : IEnumerable<ISymbol>
	{
		readonly Dictionary<string, ISymbol> typeMap = new Dictionary<string, ISymbol>();
		Statistics statistics;

		public SymbolTable(Statistics statistics)
		{
			this.statistics = statistics;

			RegisterPrimitives();
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

		public void ProcessAliases ()
		{
			var copy = typeMap.ToDictionary(x => x.Key, x => x.Value);
			foreach (var kvp in copy) {
				var target = kvp.Value;
				if (target is Alias alias) {
					typeMap[kvp.Key] = Dealias(alias);
				}
			}
		}

		ISymbol Dealias (Alias original)
		{
			ISymbol target = original;
			while (target is Alias alias) {
				if (!typeMap.TryGetValue(alias.Type.CType, out target)) {
					statistics.RegisterError(new RegistrationError(alias));
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

		public ISymbol this[string type]
		{
			get {
				// Handle alias.
				return typeMap[type];
			}
		}

		class RegistrationError : Error
		{
			Alias alias;

			public RegistrationError (Alias alias)
			{
				this.alias = alias;
			}

			public override string Message => string.Format ("Alias {0} pointing to non-registered {1}, setting to 'void'", alias.CType, alias.Type.CType);
		}
	}
}
