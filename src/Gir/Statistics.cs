using System;
using System.Collections.Generic;

namespace Gir
{
	public class Statistics
	{
		readonly Dictionary<System.Type, int> RegisteredCount = new Dictionary<System.Type, int>();

		// Bucket errors by the same kind to make for easy reviewing of error output
		readonly Dictionary<System.Type, List<Error>> RegisteredErrors = new Dictionary<System.Type, List<Error>>();

		public void ReportStatistics()
		{
			foreach (var line in GetStatistics ()) {
				Console.WriteLine(line);
			}

			foreach (var line in GetErrors ()) {
				Console.Error.WriteLine(line);
			}
		}

		public IEnumerable<string> GetStatistics ()
		{
			foreach (var kvp in RegisteredCount) {
				yield return string.Format("Registered {0} {1}s", kvp.Value.ToString(), kvp.Key);
			}
		}

		public IEnumerable<string> GetErrors ()
		{
			foreach (var kvp in RegisteredErrors) {
				yield return kvp.Key.ToString ();

				foreach (var error in kvp.Value) {
					yield return string.Format("\t{0}", error.Message);
				}
			}
		}

		public void RegisterType (ISymbol symbol)
		{
			var type = symbol.GetType();
			RegisteredCount.TryGetValue(type, out int count);
			RegisteredCount[type] = ++count;
		}

		public void RegisterError (Error error)
		{
			var type = error.GetType();
			if (!RegisteredErrors.TryGetValue(type, out var list)) {
				list = new List<Error>();
			}
			list.Add(error);
		}
	}
}
