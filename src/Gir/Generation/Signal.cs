
namespace Gir
{
	public partial class Signal : IMemberGeneratable, IDocumented
	{
		public void Generate(IGeneratable parent, IndentWriter writer)
		{
			writer.WriteLine($"event {EventHandlerQualifiedName(parent)} {Name.ToCSharp()};");
		}

		bool IsEventHandler {
			get {
				return ReturnValue.Type.CType == "void" && Parameters.Count == 0;// && (Parameters[0] is Object || Parameters[0] is Interface);
			}
		}

		string EventHandlerQualifiedName (IGeneratable parent)
		{
			if (IsEventHandler)
				return "System.EventHandler";

			return parent.Name + "." + EventHandlerName;
		}

		public bool NewlineAfterGeneration (GenerationOptions opts) => true;

		string EventHandlerName {
			get {
				if (IsEventHandler)
					return "EventHandler";

				//if (SymbolTable.Table[container_type.NS + Name + "Handler"] != null)
					//return Name + "EventHandler";

				return Name + "Handler";
			}
		}
	}
}
