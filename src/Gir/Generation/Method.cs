using System;
namespace Gir
{
	public partial class Method : IMemberGeneratable, IDocumented
	{
		public void Generate(IGeneratable parent, IndentWriter writer)
		{
			var returnType = ReturnValue.Type.GetSymbol(writer.Options).Name;
			// generate ReturnValue then Parameters
			writer.WriteLine(string.Format("{0} {1} {2}", returnType, Name, "PARAMS"));
			writer.WriteLine("{");

			writer.WriteLine("}");
		}

		public bool NewlineAfterGeneration(GenerationOptions opts)
		{
			return true;
		}
	}
}
