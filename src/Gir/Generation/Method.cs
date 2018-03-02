
namespace Gir
{
	public partial class Method : ICallable
	{
		public string Modifiers { get; set; }

		public void Generate (IGeneratable parent, IndentWriter writer)
		{
			if (parent is Interface)
				Modifiers = "public";

			this.GenerateCallableDefinition(writer);
		}

		public bool NewlineAfterGeneration (GenerationOptions opts) => true;
	}
}
