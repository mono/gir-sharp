﻿using System;
using System.Collections.Generic;

namespace Gir.Symbols
{
	public class SymbolTable
	{
		static SymbolTable table = null;

		Dictionary<string, IGeneratable> types = new Dictionary<string, IGeneratable>();

		public static SymbolTable Table {
			get {
				if (table == null)
					table = new SymbolTable();

				return table;
			}
		}

		public SymbolTable()
		{
			// Simple easily mapped types
			AddType(new Simple("void", "void", String.Empty));
			AddType(new Simple("gpointer", "IntPtr", "IntPtr.Zero"));
			AddType(new Simple("gboolean", "bool", "false"));
			AddType(new Simple("gint", "int", "0"));
			AddType(new Simple("guint", "uint", "0"));
			AddType(new Simple("int", "int", "0"));
			AddType(new Simple("unsigned", "uint", "0"));
			AddType(new Simple("unsigned int", "uint", "0"));
			AddType(new Simple("unsigned-int", "uint", "0"));
			AddType(new Simple("gshort", "short", "0"));
			AddType(new Simple("gushort", "ushort", "0"));
			AddType(new Simple("short", "short", "0"));
			AddType(new Simple("guchar", "byte", "0"));
			AddType(new Simple("unsigned char", "byte", "0"));
			AddType(new Simple("unsigned-char", "byte", "0"));
			AddType(new Simple("guint1", "bool", "false"));
			AddType(new Simple("uint1", "bool", "false"));
			AddType(new Simple("gint8", "sbyte", "0"));
			AddType(new Simple("guint8", "byte", "0"));
			AddType(new Simple("gint16", "short", "0"));
			AddType(new Simple("guint16", "ushort", "0"));
			AddType(new Simple("gint32", "int", "0"));
			AddType(new Simple("guint32", "uint", "0"));
			AddType(new Simple("gint64", "long", "0"));
			AddType(new Simple("guint64", "ulong", "0"));
			AddType(new Simple("long long", "long", "0"));
			AddType(new Simple("gfloat", "float", "0.0"));
			AddType(new Simple("float", "float", "0.0"));
			AddType(new Simple("gdouble", "double", "0.0"));
			AddType(new Simple("double", "double", "0.0"));
			AddType(new Simple("goffset", "long", "0"));
			AddType(new Simple("GQuark", "int", "0"));

			// platform specific integer types.
#if WIN64LONGS
			AddType (new SimpleGen ("long", "int", "0"));
			AddType (new SimpleGen ("glong", "int", "0"));
			AddType (new SimpleGen ("ulong", "uint", "0"));
			AddType (new SimpleGen ("gulong", "uint", "0"));
			AddType (new SimpleGen ("unsigned long", "uint", "0"));
#else
			AddType(new LPGen("long"));
			AddType(new LPGen("glong"));
			AddType(new LPUGen("ulong"));
			AddType(new LPUGen("gulong"));
			AddType(new LPUGen("unsigned long"));
#endif

			AddType(new LPGen("ssize_t"));
			AddType(new LPGen("gssize"));
			AddType(new LPUGen("size_t"));
			AddType(new LPUGen("gsize"));

#if OFF_T_8
			AddType (new AliasGen ("off_t", "long"));
#else
			AddType(new LPGen("off_t"));
#endif

			// string types
			AddType(new ConstStringGen("const-gchar"));
			AddType(new ConstStringGen("const-xmlChar"));
			AddType(new ConstStringGen("const-char"));
			AddType(new ConstFilenameGen("const-gfilename"));
			AddType(new StringMarshalGen("gfilename", "string", "IntPtr", "GLib.Marshaller.StringToFilenamePtr({0})", "GLib.Marshaller.FilenamePtrToStringGFree({0})"));
			AddType(new StringMarshalGen("gchar", "string", "IntPtr", "GLib.Marshaller.StringToPtrGStrdup({0})", "GLib.Marshaller.PtrToStringGFree({0})"));
			AddType(new StringMarshalGen("char", "string", "IntPtr", "GLib.Marshaller.StringToPtrGStrdup({0})", "GLib.Marshaller.PtrToStringGFree({0})"));
			AddType(new Simple("GStrv", "string[]", "null"));

			// manually wrapped types requiring more complex marshaling
			AddType(new ManualGen("GInitiallyUnowned", "GLib.InitiallyUnowned", "GLib.Object.GetObject ({0})"));
			AddType(new ManualGen("GObject", "GLib.Object", "GLib.Object.GetObject ({0})"));
			AddType(new ManualGen("GList", "GLib.List"));
			AddType(new ManualGen("GPtrArray", "GLib.PtrArray"));
			AddType(new ManualGen("GSList", "GLib.SList"));
			AddType(new MarshalGen("gunichar", "char", "uint", "GLib.Marshaller.CharToGUnichar ({0})", "GLib.Marshaller.GUnicharToChar ({0})"));
			AddType(new MarshalGen("time_t", "System.DateTime", "IntPtr", "GLib.Marshaller.DateTimeTotime_t ({0})", "GLib.Marshaller.time_tToDateTime ({0})"));
			AddType(new MarshalGen("GString", "string", "IntPtr", "new GLib.GString ({0}).Handle", "GLib.GString.PtrToString ({0})"));
			AddType(new MarshalGen("GType", "GLib.GType", "IntPtr", "{0}.Val", "new GLib.GType({0})", freeAfterUse: false));
			AddType(new ByRefGen("GValue", "GLib.Value"));
			AddType(new Simple("GDestroyNotify", "GLib.DestroyNotify", "null"));

			// FIXME: These ought to be handled properly.
			AddType(new Simple("GC", "IntPtr", "IntPtr.Zero"));
			AddType(new Simple("GError", "IntPtr", "IntPtr.Zero"));
			AddType(new Simple("GMemChunk", "IntPtr", "IntPtr.Zero"));
			AddType(new Simple("GTimeVal", "IntPtr", "IntPtr.Zero"));
			AddType(new Simple("GClosure", "IntPtr", "IntPtr.Zero"));
			AddType(new Simple("GArray", "IntPtr", "IntPtr.Zero"));
			AddType(new Simple("GByteArray", "IntPtr", "IntPtr.Zero"));
			AddType(new Simple("GData", "IntPtr", "IntPtr.Zero"));
			AddType(new Simple("GIOChannel", "IntPtr", "IntPtr.Zero"));
			AddType(new Simple("GTypeModule", "GLib.Object", "null"));
			AddType(new Simple("GHashTable", "System.IntPtr", "IntPtr.Zero"));
			AddType(new Simple("va_list", "IntPtr", "IntPtr.Zero"));
			AddType(new Simple("GParamSpec", "IntPtr", "IntPtr.Zero"));
			AddType(new Simple("gconstpointer", "IntPtr", "IntPtr.Zero"));
		}

		public void AddType(IGeneratable gen)
		{
			types[gen.Name] = gen;
		}

		public void AddTypes(IGeneratable[] gens)
		{
			foreach (IGeneratable gen in gens)
				types[gen.Name] = gen;
		}

		public int Count {
			get {
				return types.Count;
			}
		}

		public IEnumerable<IGeneratable> Generatables {
			get {
				return types.Values;
			}
		}

		public IGeneratable this[string ctype] {
			get {
				return DeAlias(ctype);
			}
		}

		private bool IsConstString(string type)
		{
			switch (type) {
				case "const-gchar":
				case "const-char":
				case "const-xmlChar":
				case "const-gfilename":
					return true;
				default:
					return false;
			}
		}

		private string Trim(string type)
		{
			// HACK: If we don't detect this here, there is no
			// way of indicating it in the symbol table
			if (type == "void*" || type == "const-void*") return "gpointer";

			string trim_type = type.TrimEnd('*');

			if (IsConstString(trim_type))
				return trim_type;

			if (trim_type.StartsWith("const-")) return trim_type.Substring(6);
			return trim_type;
		}

		private IGeneratable DeAlias(string type)
		{
			type = Trim(type);
			IGeneratable gen;
			while (types.TryGetValue(type, out gen) && gen is AliasGen) {
				IGeneratable igen = gen as AliasGen;
				IGeneratable temp;
				if (types.TryGetValue(igen.Name, out temp))
					types[type] = temp;
				type = igen.Name;
			}

			types.TryGetValue(type, out gen);
			return gen;
		}

		public string FromNativeReturn(string c_type, string val)
		{
			IGeneratable gen = this[c_type];
			if (gen == null)
				return "";
			return gen.FromNativeReturn(val);
		}

		public string ToNativeReturn(string c_type, string val)
		{
			IGeneratable gen = this[c_type];
			if (gen == null)
				return "";
			return gen.ToNativeReturn(val);
		}

		public string FromNative(string c_type, string val)
		{
			IGeneratable gen = this[c_type];
			if (gen == null)
				return "";
			return gen.FromNative(val);
		}

		public string GetCSType(string c_type)
		{
			IGeneratable gen = this[c_type];
			if (gen == null)
				return "";
			return gen.QualifiedName;
		}

		public string GetName(string c_type)
		{
			IGeneratable gen = this[c_type];
			if (gen == null)
				return "";
			return gen.Name;
		}

		public string GetMarshalReturnType(string c_type)
		{
			IGeneratable gen = this[c_type];
			if (gen == null)
				return "";
			return gen.MarshalReturnType;
		}

		public string GetToNativeReturnType(string c_type)
		{
			IGeneratable gen = this[c_type];
			if (gen == null)
				return "";
			return gen.ToNativeReturnType;
		}

		public string GetMarshalCallbackType(string c_type)
		{
			IGeneratable gen = this[c_type];
			if (gen == null)
				return "";
			return gen.MarshalCallbackType;
		}

		public string GetMarshalType(string c_type)
		{
			IGeneratable gen = this[c_type];
			if (gen == null)
				return "";
			return gen.MarshalType;
		}

		public string CallByName(string c_type, string var_name)
		{
			IGeneratable gen = this[c_type];
			if (gen == null)
				return "";
			return gen.CallByName(var_name);
		}

		public bool IsOpaque(string c_type)
		{
			if (this[c_type] is OpaqueGen)
				return true;

			return false;
		}

		public bool IsBoxed(string c_type)
		{
			if (this[c_type] is BoxedGen)
				return true;

			return false;
		}

		public bool IsStruct(string c_type)
		{
			if (this[c_type] is StructGen)
				return true;

			return false;
		}

		public bool IsEnum(string c_type)
		{
			if (this[c_type] is Enumeration)
				return true;

			return false;
		}

		public bool IsEnumFlags(string c_type)
		{
			Enumeration gen = this[c_type] as Enumeration;
			return (gen != null && gen.Elem.GetAttribute("type") == "flags");
		}

		public bool IsInterface(string c_type)
		{
			if (this[c_type] is Interface)
				return true;

			return false;
		}

		public ClassBase GetClassGen(string c_type)
		{
			return this[c_type] as ClassBase;
		}

		public bool IsObject(string c_type)
		{
			if (this[c_type] is ObjectGen)
				return true;

			return false;
		}

		public bool IsCallback(string c_type)
		{
			if (this[c_type] is CallbackGen)
				return true;

			return false;
		}

		public bool IsManuallyWrapped(string c_type)
		{
			if (this[c_type] is ManualGen)
				return true;

			return false;
		}

		public string MangleName(string name)
		{
			switch (name) {
				case "string":
					return "str1ng";
				case "event":
					return "evnt";
				case "null":
					return "is_null";
				case "object":
					return "objekt";
				case "params":
					return "parms";
				case "ref":
					return "reference";
				case "in":
					return "in_param";
				case "out":
					return "out_param";
				case "fixed":
					return "mfixed";
				case "byte":
					return "_byte";
				case "new":
					return "_new";
				case "base":
					return "_base";
				case "lock":
					return "_lock";
				case "callback":
					return "cb";
				case "readonly":
					return "read_only";
				case "interface":
					return "iface";
				case "internal":
					return "_internal";
				case "where":
					return "wh3r3";
				case "foreach":
					return "for_each";
				case "remove":
					return "_remove";
				default:
					break;
			}

			return name;
		}

		public bool IsBlittable(IGeneratable t)
		{
			if (t is Simple)
				return true;
			if (t is Enumeration)
				return true;
			if (t is ByRefGen && t.Name == "GValue")
				return true;
			if (t is IAccessor && t.MarshalType == "IntPtr")
				return true;

			if (t is StructBase) {
				foreach (StructField field in (t as StructBase).fields) {
					if (field.IsArray || field.IsNullTermArray)
						return false;

					if (field.CSType == "string")
						return false;

					// We don't care about pointers.
					if (field.IsPointer)
						continue;

					var gen = SymbolTable.Table[field.CType];
					if (!IsBlittable(gen))
						return false;
				}
				return true;
			}
			return false;
		}
	}
}
