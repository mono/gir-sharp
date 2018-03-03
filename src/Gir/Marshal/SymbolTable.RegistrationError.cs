
namespace Gir
{
	public partial class SymbolTable
	{
		[System.Diagnostics.DebuggerDisplay ("{DebuggerDisplay}")]
		class AliasRegistrationError : Error
		{
			readonly Alias alias;

			public AliasRegistrationError (Alias alias)
			{
				this.alias = alias;
			}

			public override string Message => $"Alias {alias.Name} pointing to non-registered {alias.Type.Name}, setting to 'void'";

			string DebuggerDisplay => $"{alias.Name} alias failure to {alias.Type.Name}";
		}
	}
}
