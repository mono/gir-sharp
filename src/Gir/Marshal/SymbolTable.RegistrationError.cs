using System;
namespace Gir
{
	public partial class SymbolTable
	{
		class AliasRegistrationError : Error
		{
			Alias alias;

			public AliasRegistrationError(Alias alias)
			{
				this.alias = alias;
			}

			public override string Message => string.Format("Alias {0} pointing to non-registered {1}, setting to 'void'", alias.CType, alias.Type.CType);
		}
	}
}
