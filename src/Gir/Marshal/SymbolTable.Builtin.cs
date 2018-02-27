using System;
namespace Gir
{
	public partial class SymbolTable
	{
		// Only call this, not the ones below.
		void RegisterBuiltIn(bool nativeWin64)
		{
			RegisterPrimitives(nativeWin64);

			//AddType(new MarshalGen("time_t", "System.DateTime", "IntPtr", "GLib.Marshaller.DateTimeTotime_t ({0})", "GLib.Marshaller.time_tToDateTime ({0})"));
			//AddType(new StringMarshalGen("gfilename", "string", "IntPtr", "GLib.Marshaller.StringToFilenamePtr({0})", "GLib.Marshaller.FilenamePtrToStringGFree({0})"));
			//AddType(new StringMarshalGen("gchar", "string", "IntPtr", "GLib.Marshaller.StringToPtrGStrdup({0})", "GLib.Marshaller.PtrToStringGFree({0})"));
			//AddType(new StringMarshalGen("char", "string", "IntPtr", "GLib.Marshaller.StringToPtrGStrdup({0})", "GLib.Marshaller.PtrToStringGFree({0})"));
		}

		void RegisterPrimitives (bool nativeWin64)
		{
			AddType(new Primitive("void", "void", string.Empty));
			AddType(new Primitive("gpointer", "IntPtr", "IntPtr.Zero"));
			AddType(new Primitive("gboolean", "bool", "false"));
			AddType(new Primitive("gint", "int", "0"));
			AddType(new Primitive("guint", "uint", "0"));
			AddType(new Primitive("int", "int", "0"));
			AddType(new Primitive("unsigned", "uint", "0"));
			AddType(new Primitive("unsigned int", "uint", "0"));
			AddType(new Primitive("gshort", "short", "0"));
			AddType(new Primitive("gushort", "ushort", "0"));
			AddType(new Primitive("short", "short", "0"));
			AddType(new Primitive("guchar", "byte", "0"));
			AddType(new Primitive("unsigned char", "byte", "0"));
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

			AddType(new Primitive("ssize_t", "IntPtr", "IntPtr.Zero"));
			AddType(new Primitive("gssize", "IntPtr", "IntPtr.Zero"));
			AddType(new Primitive("size_t", "UIntPtr", "UIntPtr.Zero"));
			AddType(new Primitive("gsize", "UIntPtr", "UIntPtr.Zero"));

			RegisterLongTypes(nativeWin64);
		}

		void RegisterLongTypes(bool nativeWin64)
		{
			if (nativeWin64) {
				AddType(new Primitive("long", "int", "0"));
				AddType(new Primitive("glong", "int", "0"));
				AddType(new Primitive("ulong", "uint", "0"));
				AddType(new Primitive("gulong", "uint", "0"));
				AddType(new Primitive("unsigned long", "uint", "0"));
			} else {
				AddType(new Primitive("long", "IntPtr", "IntPtr.Zero"));
				AddType(new Primitive("glong", "IntPtr", "IntPtr.Zero"));
				AddType(new Primitive("ulong", "UIntPtr", "UIntPtr.Zero"));
				AddType(new Primitive("gulong", "UIntPtr", "IntPtr.Zero"));
				AddType(new Primitive("unsigned long", "UIntPtr", "IntPtr.Zero"));
			}
		}
	}
}
