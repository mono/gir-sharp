using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Gir
{
	public static class Parser
	{
		private static readonly Dictionary<string, Repository> ResolvedRepositories = new Dictionary<string, Repository> ();
		
		public static IEnumerable<Repository> Parse(string fileName, string includeDir, out Repository mainRepository)
		{
			using (var fs = File.OpenRead (fileName)) {
				return Parse (fs, includeDir, out mainRepository);
			}
		}

		public static IEnumerable<Repository> Parse(Stream s, string includeDir, out Repository mainRepository)
		{
			var serializer = new System.Xml.Serialization.XmlSerializer(typeof(Repository));
			mainRepository = (Repository)serializer.Deserialize(s);

			var repositories = ParseRecursive (mainRepository, includeDir).ToList ();
			repositories.Add(mainRepository);
			return repositories;
		}

		public static IEnumerable<Repository> ParseRecursive (Repository repository, string includeDir)
		{
			if (!ResolvedRepositories.ContainsKey(repository.GirName)) {
				ResolvedRepositories[repository.GirName] = repository;
				
				yield return repository;

				foreach (var include in repository.Includes) {
					using (var fs = File.OpenRead (Path.Combine(includeDir, include.GirName))) {
						var serializer = new System.Xml.Serialization.XmlSerializer(typeof(Repository));
						var repo = (Repository)serializer.Deserialize(fs);

						
						foreach (var incRepo in ParseRecursive(repo, includeDir)) {
							yield return incRepo;
						}
					}
				}
			}
		}
	}
}
