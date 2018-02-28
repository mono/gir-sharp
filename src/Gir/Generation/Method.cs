using System;
namespace Gir
{
	public partial class Method : ICallable
	{
		public string Modifiers => string.Empty;

		public void Generate(IGeneratable parent, IndentWriter writer)
		{
			this.GenerateCallableDefinition(writer);
		}

		public bool NewlineAfterGeneration(GenerationOptions opts) => true;
	}
}
