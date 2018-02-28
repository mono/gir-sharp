using System;
namespace Gir
{
	public partial class Field : IMemberGeneratable, IDocumented
	{
		public void Generate(IGeneratable parent, IndentWriter writer)
		{
			// Simple uncorrect gen for now
			var managedType = this.GetSymbol(writer.Options);

			// We need something that will tell us the equivalent C# type
			// including the number of pointers.
			// For now, generate normal info.

			writer.WriteLine($"{managedType.CSharpType} {Name};");
		}

		public bool NewlineAfterGeneration(GenerationOptions opts)
		{
			return true;
		}
	}
}
