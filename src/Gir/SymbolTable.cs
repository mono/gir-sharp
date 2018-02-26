﻿using System;
using System.Collections.Generic;

namespace Gir.Symbols
{
	public class SymbolTable
	{
		static SymbolTable table = new SymbolTable();

		Dictionary<string, IGeneratable> types = new Dictionary<string, IGeneratable>();

		public static SymbolTable Table => table;

		public SymbolTable()
		{
			// Simple easily mapped types
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

			// platform specific integer types.
#if WIN64LONGS
			AddType (new Primitive ("long", "int", "0"));
			AddType (new Primitive ("glong", "int", "0"));
			AddType (new Primitive ("ulong", "uint", "0"));
			AddType (new Primitive ("gulong", "uint", "0"));
			AddType (new Primitive ("unsigned long", "uint", "0"));
#else
			AddType(new IntPtrGen("long"));
			AddType(new IntPtrGen("glong"));
			AddType(new UIntPtrGen("ulong"));
			AddType(new UIntPtrGen("gulong"));
			AddType(new UIntPtrGen("unsigned long"));
#endif

			AddType(new IntPtrGen("ssize_t"));
			AddType(new IntPtrGen("gssize"));
			AddType(new UIntPtrGen("size_t"));
			AddType(new UIntPtrGen("gsize"));

#if OFF_T_8
			AddType (new AliasGen ("off_t", "long"));
#else
			AddType(new IntPtrGen("off_t"));
#endif

			// string types
			//AddType(new ConstStringGen("const-gchar"));
			//AddType(new ConstStringGen("const-xmlChar"));
			//AddType(new ConstStringGen("const-char"));
			//AddType(new ConstFilenameGen("const-gfilename"));
			//AddType(new StringMarshalGen("gfilename", "string", "IntPtr", "GLib.Marshaller.StringToFilenamePtr({0})", "GLib.Marshaller.FilenamePtrToStringGFree({0})"));
			//AddType(new StringMarshalGen("gchar", "string", "IntPtr", "GLib.Marshaller.StringToPtrGStrdup({0})", "GLib.Marshaller.PtrToStringGFree({0})"));
			//AddType(new StringMarshalGen("char", "string", "IntPtr", "GLib.Marshaller.StringToPtrGStrdup({0})", "GLib.Marshaller.PtrToStringGFree({0})"));
			AddType(new Primitive("GStrv", "string[]", "null"));

			// manually wrapped types requiring more complex marshaling
			//AddType(new ManualGen("GInitiallyUnowned", "GLib.InitiallyUnowned", "GLib.Object.GetObject ({0})"));
			//AddType(new ManualGen("GObject", "GLib.Object", "GLib.Object.GetObject ({0})"));
			//AddType(new ManualGen("GList", "GLib.List"));
			//AddType(new ManualGen("GPtrArray", "GLib.PtrArray"));
			//AddType(new ManualGen("GSList", "GLib.SList"));
			//AddType(new MarshalGen("gunichar", "char", "uint", "GLib.Marshaller.CharToGUnichar ({0})", "GLib.Marshaller.GUnicharToChar ({0})"));
			//AddType(new MarshalGen("time_t", "System.DateTime", "IntPtr", "GLib.Marshaller.DateTimeTotime_t ({0})", "GLib.Marshaller.time_tToDateTime ({0})"));
			//AddType(new MarshalGen("GString", "string", "IntPtr", "new GLib.GString ({0}).Handle", "GLib.GString.PtrToString ({0})"));
			//AddType(new MarshalGen("GType", "GLib.GType", "IntPtr", "{0}.Val", "new GLib.GType({0})", freeAfterUse: false));
			//AddType(new ByRefGen("GValue", "GLib.Value"));
			AddType(new Primitive("GDestroyNotify", "GLib.DestroyNotify", "null"));

			// FIXME: These ought to be handled properly.
			AddType(new Primitive("GC", "IntPtr", "IntPtr.Zero"));
			AddType(new Primitive("GError", "IntPtr", "IntPtr.Zero"));
			AddType(new Primitive("GMemChunk", "IntPtr", "IntPtr.Zero"));
			AddType(new Primitive("GTimeVal", "IntPtr", "IntPtr.Zero"));
			AddType(new Primitive("GClosure", "IntPtr", "IntPtr.Zero"));
			AddType(new Primitive("GArray", "IntPtr", "IntPtr.Zero"));
			AddType(new Primitive("GByteArray", "IntPtr", "IntPtr.Zero"));
			AddType(new Primitive("GData", "IntPtr", "IntPtr.Zero"));
			AddType(new Primitive("GIOChannel", "IntPtr", "IntPtr.Zero"));
			AddType(new Primitive("GTypeModule", "GLib.Object", "null"));
			AddType(new Primitive("GHashTable", "System.IntPtr", "IntPtr.Zero"));
			AddType(new Primitive("va_list", "IntPtr", "IntPtr.Zero"));
			AddType(new Primitive("GParamSpec", "IntPtr", "IntPtr.Zero"));
			AddType(new Primitive("gconstpointer", "IntPtr", "IntPtr.Zero"));
		}

		public void AddType (IGeneratable gen)
		{
			types[gen.Name] = gen;
		}

		public void AddType (IEnumerable<IGeneratable> gens)
		{
			foreach (IGeneratable gen in gens)
				types[gen.Name] = gen;
		}

		public int Count => types.Count;

		public IEnumerable<IGeneratable> Generatables => types.Values;

		public IGeneratable this[string ctype] {
			get {
				return DeAlias(ctype);
			}
		}

		bool IsConstString(string type)
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

		string Trim(string type)
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

		IGeneratable DeAlias(string type)
		{
			type = Trim(type);
			IGeneratable gen;
			while (types.TryGetValue(type, out gen) && gen is Alias) {
				IGeneratable igen = gen as Alias;
				if (types.TryGetValue(igen.Name, out IGeneratable temp))
					types[type] = temp;
				type = igen.Name;
			}

			types.TryGetValue(type, out gen);
			return gen;
		}

		//public string FromNativeReturn(string c_type, string val)
		//{
		//	IGeneratable gen = this[c_type];
		//	if (gen == null)
		//		return "";
		//	return gen.FromNativeReturn(val);
		//}

		//public string ToNativeReturn(string c_type, string val)
		//{
		//	IGeneratable gen = this[c_type];
		//	if (gen == null)
		//		return "";
		//	return gen.ToNativeReturn(val);
		//}

		//public string FromNative(string c_type, string val)
		//{
		//	IGeneratable gen = this[c_type];
		//	if (gen == null)
		//		return "";
		//	return gen.FromNative(val);
		//}

		//public string GetCSType(string c_type)
		//{
		//	IGeneratable gen = this[c_type];
		//	if (gen == null)
		//		return "";
		//	return gen.QualifiedName;
		//}

		//public string GetName(string c_type)
		//{
		//	IGeneratable gen = this[c_type];
		//	if (gen == null)
		//		return "";
		//	return gen.Name;
		//}

		//public string GetMarshalReturnType(string c_type)
		//{
		//	IGeneratable gen = this[c_type];
		//	if (gen == null)
		//		return "";
		//	return gen.MarshalReturnType;
		//}

		//public string GetToNativeReturnType(string c_type)
		//{
		//	IGeneratable gen = this[c_type];
		//	if (gen == null)
		//		return "";
		//	return gen.ToNativeReturnType;
		//}

		//public string GetMarshalCallbackType(string c_type)
		//{
		//	IGeneratable gen = this[c_type];
		//	if (gen == null)
		//		return "";
		//	return gen.MarshalCallbackType;
		//}

		//public string GetMarshalType(string c_type)
		//{
		//	IGeneratable gen = this[c_type];
		//	if (gen == null)
		//		return "";
		//	return gen.MarshalType;
		//}

		//public string CallByName(string c_type, string var_name)
		//{
		//	IGeneratable gen = this[c_type];
		//	if (gen == null)
		//		return "";
		//	return gen.CallByName(var_name);
		//}

		//public bool IsOpaque(string c_type)
		//{
		//	return this[c_type] is OpaqueGen;
		//}

		//public bool IsBoxed(string c_type)
		//{
		//	return this[c_type] is BoxedGen;
		//}

		public bool IsStruct(string c_type)
		{
			return this[c_type] is Record;
		}

		public bool IsEnum(string c_type)
		{
			return this[c_type] is Enumeration;
		}

		public bool IsEnumFlags(string c_type)
		{
			return this[c_type] is Bitfield;
		}

		public bool IsInterface(string c_type)
		{
			return this[c_type] is Interface;
		}

		//public ClassBase GetClassGen(string c_type)
		//{
		//	return this[c_type] as ClassBase;
		//}

		//public bool IsObject(string c_type)
		//{
		//	return this[c_type] is ObjectGen;
		//}

		public bool IsCallback(string c_type)
		{
			return this[c_type] is Callback;
		}

		//public bool IsManuallyWrapped(string c_type)
		//{
		//	return this[c_type] is ManualGen;
		//}
	}
}
