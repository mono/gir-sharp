
namespace Gir
{
	public partial class Signal : IMemberGeneratable, IDocumented
	{
		public void Generate(IGeneratable parent, IndentWriter writer)
		{
			// FIXME, Signal isn't being populated correctly
			//writer.WriteLine($"event {EventHandlerQualifiedName(parent)} {Name.ToCSharp()};");
			writer.WriteLine ($"event {Name.ToCSharp ()};");
		}

		bool IsEventHandler {
			get {
				return ReturnValue.Type.Name == "void" && Parameters.Count == 1;// && (Parameters[0] is Object || Parameters[0] is Interface);
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
