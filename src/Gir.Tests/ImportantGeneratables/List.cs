using System;
using NUnit.Framework;

namespace Gir.Tests
{
	[TestFixture]
	public class List : GenerationTestBase
	{
		[Test]
		public void ListIsGenerated ()
		{
			var result = GenerateType(GLib, "List", true);

			Assert.AreEqual (@"using System;
using System.Runtime.InteropServices;

namespace GLib
{
	[StructLayout (LayoutKind.Sequential)]
	public struct List
	{
		IntPtr Data;

		List Next;

		List Prev;

		static extern List g_list_alloc ();

		public static List Alloc ()
		{
			return g_list_alloc ();
		}

		static extern List g_list_append (List list, IntPtr data);

		public List Append (IntPtr data)
		{
			return g_list_append (data);
		}

		static extern List g_list_concat (List list1, List list2);

		public List Concat (List list2)
		{
			return g_list_concat (list2);
		}

		static extern List g_list_copy (List list);

		public List Copy ()
		{
			return g_list_copy ();
		}

		static extern List g_list_copy_deep (List list, CopyFunc func, IntPtr user_data);

		public List CopyDeep (CopyFunc func, IntPtr user_data)
		{
			return g_list_copy_deep (func, user_data);
		}

		static extern List g_list_delete_link (List list, List link_);

		public List DeleteLink (List link_)
		{
			return g_list_delete_link (link_);
		}

		static extern List g_list_find (List list, IntPtr data);

		public List Find (IntPtr data)
		{
			return g_list_find (data);
		}

		static extern List g_list_find_custom (List list, IntPtr data, CompareFunc func);

		public List FindCustom (IntPtr data, CompareFunc func)
		{
			return g_list_find_custom (data, func);
		}

		static extern List g_list_first (List list);

		public List First ()
		{
			return g_list_first ();
		}

		static extern void g_list_foreach (List list, Func func, IntPtr user_data);

		public void Foreach (Func func, IntPtr user_data)
		{
			g_list_foreach (func, user_data);
		}

		static extern void g_list_free (List list);

		public void Free ()
		{
			g_list_free ();
		}

		static extern void g_list_free_1 (List list);

		public void Free1 ()
		{
			g_list_free_1 ();
		}

		static extern void g_list_free_full (List list, DestroyNotify free_func);

		public void FreeFull (DestroyNotify free_func)
		{
			g_list_free_full (free_func);
		}

		static extern int g_list_index (List list, IntPtr data);

		public int Index (IntPtr data)
		{
			return g_list_index (data);
		}

		static extern List g_list_insert (List list, IntPtr data, int position);

		public List Insert (IntPtr data, int position)
		{
			return g_list_insert (data, position);
		}

		static extern List g_list_insert_before (List list, List sibling, IntPtr data);

		public List InsertBefore (List sibling, IntPtr data)
		{
			return g_list_insert_before (sibling, data);
		}

		static extern List g_list_insert_sorted (List list, IntPtr data, CompareFunc func);

		public List InsertSorted (IntPtr data, CompareFunc func)
		{
			return g_list_insert_sorted (data, func);
		}

		static extern List g_list_insert_sorted_with_data (List list, IntPtr data, CompareDataFunc func, IntPtr user_data);

		public List InsertSortedWithData (IntPtr data, CompareDataFunc func, IntPtr user_data)
		{
			return g_list_insert_sorted_with_data (data, func, user_data);
		}

		static extern List g_list_last (List list);

		public List Last ()
		{
			return g_list_last ();
		}

		static extern uint g_list_length (List list);

		public uint Length ()
		{
			return g_list_length ();
		}

		static extern List g_list_nth (List list, uint n);

		public List Nth (uint n)
		{
			return g_list_nth (n);
		}

		static extern IntPtr g_list_nth_data (List list, uint n);

		public IntPtr NthData (uint n)
		{
			return g_list_nth_data (n);
		}

		static extern List g_list_nth_prev (List list, uint n);

		public List NthPrev (uint n)
		{
			return g_list_nth_prev (n);
		}

		static extern int g_list_position (List list, List llink);

		public int Position (List llink)
		{
			return g_list_position (llink);
		}

		static extern List g_list_prepend (List list, IntPtr data);

		public List Prepend (IntPtr data)
		{
			return g_list_prepend (data);
		}

		static extern List g_list_remove (List list, IntPtr data);

		public List Remove (IntPtr data)
		{
			return g_list_remove (data);
		}

		static extern List g_list_remove_all (List list, IntPtr data);

		public List RemoveAll (IntPtr data)
		{
			return g_list_remove_all (data);
		}

		static extern List g_list_remove_link (List list, List llink);

		public List RemoveLink (List llink)
		{
			return g_list_remove_link (llink);
		}

		static extern List g_list_reverse (List list);

		public List Reverse ()
		{
			return g_list_reverse ();
		}

		static extern List g_list_sort (List list, CompareFunc compare_func);

		public List Sort (CompareFunc compare_func)
		{
			return g_list_sort (compare_func);
		}

		static extern List g_list_sort_with_data (List list, CompareDataFunc compare_func, IntPtr user_data);

		public List SortWithData (CompareDataFunc compare_func, IntPtr user_data)
		{
			return g_list_sort_with_data (compare_func, user_data);
		}
	}
}
", result);
		}
	}
}
