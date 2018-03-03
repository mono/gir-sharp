using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Gir
{
	public static class Utils
	{
		// Perf - maybe cache this?
		public static string ToCSharp (this string cname)
		{
			// Capitalize the first letter, and parse for underscores, capitalizing the letters after them
			var sb = new StringBuilder (cname.Length);

			bool isUpper = true;
			foreach (var c in cname) {
				if (c == '_' || c == '-') {
					isUpper = true;
					continue;
				}

				sb.Append (isUpper ? char.ToUpper (c) : c);
				isUpper = false;
			}

			return sb.ToString ();
		}

		internal static IEnumerable<T> GetAllCollectionMembers<T> (object container)
		{
			// This doesn't yield things like: <record><union/></record>
			foreach (var collection in GetCollectionsOf<T> (container)) {
				foreach (var item in collection)
					yield return (T)item;
			}
		}

		static IEnumerable<ICollection> GetCollectionsOf<T> (object obj)
		{
			var type = obj.GetType ();

			foreach (var field in type.GetFields ().Where (x => IsCollectionOf<T> (x.FieldType))) {
				yield return (ICollection)field.GetValue (obj);
			}

			foreach (var prop in type.GetProperties ().Where (x => IsCollectionOf<T> (x.PropertyType))) {
				yield return (ICollection)prop.GetValue (obj);
			}
		}

		static bool IsCollectionOf<T> (System.Type t)
		{
			foreach (var @interface in t.GetInterfaces ()) {
				if (!@interface.IsGenericType || !@interface.GetGenericTypeDefinition ().IsAssignableFrom (typeof (ICollection<>)))
					continue;

				var args = @interface.GetGenericArguments ();
				bool isOfT = typeof (T).IsAssignableFrom (args [0]);
				if (isOfT)
					return true;
			}

			return false;
		}

		internal static IEnumerable<System.Type> GetTypesImplementing<T> ()
		{
			var assembly = Assembly.GetExecutingAssembly ();

			var implementors = assembly
				.DefinedTypes
				// Filter out all the types implementing the interface
				.Where (type => typeof (T).IsAssignableFrom (type));
			return implementors;
		}
	}
}
