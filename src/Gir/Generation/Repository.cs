using System.Collections.Generic;

namespace Gir
{
	public partial class Repository
	{
		public IEnumerable<IGeneratable> GetGeneratables () => Namespace.GetGeneratables ();
	}
}
