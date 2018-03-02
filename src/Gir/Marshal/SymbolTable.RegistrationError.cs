
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

			public override string Message => string.Format ("Alias {0} pointing to non-registered {1}, setting to 'void'", alias.CType, alias.Type.CType);

			string DebuggerDisplay => $"{alias.CType} alias failure to {alias.Type.CType}";
		}
	}
}
