using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace Gir
{
	public static class Parser
	{
		public static IEnumerable<Repository> Parse (string fileName, string includeDir, out Repository mainRepository)
		{
			using var fs = File.OpenRead (fileName);
			return Parse (fs, includeDir, out mainRepository);
		}

		public static IEnumerable<Repository> Parse (Stream s, string includeDir, out Repository mainRepository)
		{
			var serializer = new XmlSerializer (typeof (Repository));
			mainRepository = (Repository)serializer.Deserialize (s);

			var repositories = ParseRecursive (mainRepository, includeDir, new Dictionary<string, Repository> ()).ToList ();
			// The first repository is the main repository
			return repositories;
		}

		public static IEnumerable<Repository> ParseRecursive (Repository repository, string includeDir, Dictionary<string, Repository> resolvedRepositories)
		{
			if (!resolvedRepositories.ContainsKey (repository.GirName)) {
				resolvedRepositories [repository.GirName] = repository;

				yield return repository;

				foreach (var include in repository.Includes) {
					using var fs = File.OpenRead (Path.Combine (includeDir, include.GirName));
					var serializer = new XmlSerializer (typeof (Repository));
					var repo = (Repository)serializer.Deserialize (fs);


					foreach (var incRepo in ParseRecursive (repo, includeDir, resolvedRepositories)) {
						yield return incRepo;
					}
				}
			}
		}
	}
}
