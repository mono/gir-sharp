using System;
using System.Collections;
using System.Collections.Generic;

namespace Gir
{
	public partial class Repository
	{
		// Stub for xml serializers
		public void Add(System.Object obj) { }

		public IEnumerable<IGeneratable> GetGeneratables ()
		{
			return Namespace.GetGeneratables();
		}
	}
}
