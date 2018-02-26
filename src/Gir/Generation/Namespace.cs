﻿using System.Collections.Generic;

namespace Gir
{
	public partial class Namespace
	{
		public IEnumerable<IGeneratable> GetGeneratables()
		{
			foreach (var en in Enumerations)
				yield return en;

			foreach (var bitfield in Bitfields)
				yield return bitfield;

			foreach (var alias in Aliases)
				yield return alias;

			// TODO: Add others
		}
	}
}
