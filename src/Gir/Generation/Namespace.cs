using System;
using System.Collections;
using System.Collections.Generic;

namespace Gir
{
	public partial class Namespace
	{
		public IEnumerable<IGeneratable> GetGeneratables()
		{
			foreach (var en in Enumerations)
				yield return en;

			// TODO: Add others
		}
	}
}
