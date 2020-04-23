
namespace Gir
{
	public partial class Member : IMemberGeneratable, IDocumented
	{
		public bool NewlineAfterGeneration (GenerationOptions opts) => opts.GenerateDocumentation;

		public void Generate (IGeneratable parent, IndentWriter writer)
		{
			var value = Value;
			if (parent is IEnumFormatter formatter)
				value = formatter.FormatValue (value);

			writer.WriteLine (Name.ToCSharp () + " = " + value + ",");
		}
	}

	public interface IEnumFormatter
	{
		string FormatValue (string value);
	}
}
