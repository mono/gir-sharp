using System.Collections.Generic;

namespace Gir
{
	public partial class Namespace
	{
		public IEnumerable<IGeneratable> GetGeneratables()
		{
			return Utils.GetAllCollectionMembers<IGeneratable>(this);
		}
	}
}
