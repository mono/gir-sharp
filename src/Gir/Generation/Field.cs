using System;
namespace Gir
{
	public partial class Field : IMemberGeneratable
	{
		public void Generate(GenerationOptions opts, IGeneratable parent, IndentWriter writer)
		{
			writer.WriteDocumentation(Doc);

			// Simple uncorrect gen for now
			var managedType = this.GetSymbol(opts);

			// We need something that will tell us the equivalent C# type
			// including the number of pointers.
			// For now, generate normal info.

			writer.WriteLine($"{managedType.Name} {Name};");
		}

		public bool NewlineAfterGeneration(GenerationOptions opts)
		{
			return true;
		}
	}
}
