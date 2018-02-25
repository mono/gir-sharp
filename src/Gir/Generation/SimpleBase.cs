using System;

namespace Gir
{
	public abstract class SimpleBase : IGeneratable
	{
		string type;
		string ctype;
		string ns = String.Empty;
		string default_value = String.Empty;

		public SimpleBase(string ctype, string type, string default_value)
		{
			string[] toks = type.Split('.');
			this.ctype = ctype;
			this.type = toks[toks.Length - 1];
			if (toks.Length > 2)
				ns = String.Join(".", toks, 0, toks.Length - 1);
			else if (toks.Length == 2)
				ns = toks[0];
			this.default_value = default_value;
		}

		public string CName => ctype;

		public string Name => type;

		public string QualifiedName {
			get {
				return ns == String.Empty ? type : ns + "." + type;
			}
		}

		public virtual string MarshalType {
			get {
				return QualifiedName;
			}
		}

		public virtual string MarshalReturnType {
			get {
				return MarshalType;
			}
		}

		public virtual string MarshalCallbackType {
			get {
				return MarshalType;
			}
		}

		public virtual string DefaultValue {
			get {
				return default_value;
			}
		}

		public virtual string ToNativeReturnType {
			get {
				return MarshalType;
			}
		}

		public virtual string CallByName(string var)
		{
			return var;
		}

		public virtual string FromNative(string var)
		{
			return var;
		}

		public virtual string FromNativeReturn(string var)
		{
			return FromNative(var);
		}

		public virtual string ToNativeReturn(string var)
		{
			return CallByName(var);
		}

		public bool Validate()
		{
			return true;
		}

		public void Generate()
		{
		}

		void Generate(GenerationOptions opts)
		{
			// FIXME, actually generate stuff, or not?
		}
	}
}
