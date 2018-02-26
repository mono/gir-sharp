using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Gir
{
	public class SymbolTable : IEnumerable<ISymbol>
	{
		readonly Dictionary<string, ISymbol> typeMap = new Dictionary<string, ISymbol>();

		public SymbolTable()
		{
			// Add primitives
			AddType(new Primitive("void", "void", String.Empty));
			AddType(new Primitive("gpointer", "IntPtr", "IntPtr.Zero"));
			AddType(new Primitive("gboolean", "bool", "false"));
			AddType(new Primitive("gint", "int", "0"));
			AddType(new Primitive("guint", "uint", "0"));
			AddType(new Primitive("int", "int", "0"));
			AddType(new Primitive("unsigned", "uint", "0"));
			AddType(new Primitive("unsigned int", "uint", "0"));
			AddType(new Primitive("unsigned-int", "uint", "0"));
			AddType(new Primitive("gshort", "short", "0"));
			AddType(new Primitive("gushort", "ushort", "0"));
			AddType(new Primitive("short", "short", "0"));
			AddType(new Primitive("guchar", "byte", "0"));
			AddType(new Primitive("unsigned char", "byte", "0"));
			AddType(new Primitive("unsigned-char", "byte", "0"));
			AddType(new Primitive("guint1", "bool", "false"));
			AddType(new Primitive("uint1", "bool", "false"));
			AddType(new Primitive("gint8", "sbyte", "0"));
			AddType(new Primitive("guint8", "byte", "0"));
			AddType(new Primitive("gint16", "short", "0"));
			AddType(new Primitive("guint16", "ushort", "0"));
			AddType(new Primitive("gint32", "int", "0"));
			AddType(new Primitive("guint32", "uint", "0"));
			AddType(new Primitive("gint64", "long", "0"));
			AddType(new Primitive("guint64", "ulong", "0"));
			AddType(new Primitive("long long", "long", "0"));
			AddType(new Primitive("gfloat", "float", "0.0"));
			AddType(new Primitive("float", "float", "0.0"));
			AddType(new Primitive("gdouble", "double", "0.0"));
			AddType(new Primitive("double", "double", "0.0"));
			AddType(new Primitive("goffset", "long", "0"));
			AddType(new Primitive("GQuark", "int", "0"));
		}

		public void AddType (ISymbol symbol)
		{
			typeMap[symbol.CType] = symbol;
		}

		public void ProcessAliases ()
		{
			var copy = typeMap.ToDictionary(x => x.Key, x => x.Value);
			foreach (var kvp in copy) {
				if (kvp.Value is Alias alias) {
					if (!typeMap.TryGetValue (alias.Type.CType, out var aliasedTo)) {
						// FIXME: This should never happen, don't throw for now.
						Console.Error.WriteLine("Alias {0} pointing to non-registered {1}", alias.CType, alias.Type.CType);
						continue;
					}
					typeMap[kvp.Key] = typeMap[alias.Type.CType];
				}
			}
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
	}
}
