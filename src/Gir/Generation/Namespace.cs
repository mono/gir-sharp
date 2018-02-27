using System.Collections.Generic;

namespace Gir
{
	public partial class Namespace
	{
		public IEnumerable<IGeneratable> GetGeneratables() => Utils.GetAllCollectionMembers<IGeneratable>(this);
	}
}
