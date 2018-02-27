using System;
namespace Gir
{
	public partial class Field : IMemberGeneratable
	{
		public void Generate(IGeneratable parent, IndentWriter writer)
		{
			writer.WriteDocumentation(Doc);
			// Simple uncorrect gen for now
			writer.WriteLine($"{Type.Name} {Name};");
		}
	}
}
