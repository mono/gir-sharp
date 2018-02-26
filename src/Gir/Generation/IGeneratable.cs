using System;
using System.Text;

namespace Gir
{
	public interface IGeneratable
	{
		string Name { get; }
		//void Process();
		void Generate(GenerationOptions opts);
	}

	public interface IType
	{
		string CType { get; set; }
	}

	public static class ITypeExtensions
	{
		// Perf - maybe cache this?
		public static string ToCSharp (this string cname)
		{
			// Capitalize the first letter, and parse for underscores, capitalizing the letters after them
			var sb = new StringBuilder(cname.Length);

			bool isUpper = true;
			foreach (var c in cname)
			{
				if (c == '_')
				{
					isUpper = true;
					continue;
				}

				sb.Append(isUpper ? char.ToUpper(c) : c);
				isUpper = false;
			}

			return sb.ToString();
		}
	}
}
