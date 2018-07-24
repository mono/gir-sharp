
using NUnit.Framework;

namespace Gir.Tests
{
	[TestFixture]
	public class RecordTests : GenerationTestBase
	{
		[Test]
		public void TestRecordIsGenerated ()
		{
			// Test is incomplete, as record is not fully generated atm.
			var result = GenerateType (GLib, "ByteArray");

			// Need to map pointers at symbol level.
			Assert.AreEqual (@"using System;

namespace GLib
{
	///<summary>Contains the public fields of a GByteArray.</summary>
	public struct ByteArray
	{
		///<summary>
		/// a pointer to the element data. The data may be moved as
		///     elements are added to the #GByteArray
		///</summary>
		byte Data;

		///<summary>the number of elements in the #GByteArray</summary>
		uint Len;

		static extern ByteArray g_byte_array_append (ByteArray array, byte data, uint len);

		///<summary>
		/// Adds the given bytes to the end of the #GByteArray.
		/// The array will grow in size automatically if necessary.
		///</summary>
		///<returns>the #GByteArray</returns>
		public ByteArray Append (byte data, uint len);

		static extern byte g_byte_array_free (ByteArray array, bool free_segment);

		///<summary>
		/// Frees the memory allocated by the #GByteArray. If @free_segment is
		/// %TRUE it frees the actual byte data. If the reference count of
		/// @array is greater than one, the #GByteArray wrapper is preserved but
		/// the size of @array will be set to zero.
		///</summary>
		///<returns>
		/// the element data if @free_segment is %FALSE, otherwise
		///          %NULL.  The element data should be freed using g_free().
		///</returns>
		public byte Free (bool free_segment);

		static extern Bytes g_byte_array_free_to_bytes (ByteArray array);

		///<summary>
		/// Transfers the data from the #GByteArray into a new immutable #GBytes.
		/// 
		/// The #GByteArray is freed unless the reference count of @array is greater
		/// than one, the #GByteArray wrapper is preserved but the size of @array
		/// will be set to zero.
		/// 
		/// This is identical to using g_bytes_new_take() and g_byte_array_free()
		/// together.
		///</summary>
		///<returns>
		/// a new immutable #GBytes representing same
		///     byte data that was in the array
		///</returns>
		public Bytes FreeToBytes ();

		static extern ByteArray g_byte_array_new ();

		///<summary>Creates a new #GByteArray with a reference count of 1.</summary>
		///<returns>the new #GByteArray</returns>
		public static ByteArray New ();

		static extern ByteArray g_byte_array_new_take (byte data, UIntPtr len);

		///<summary>
		/// Create byte array containing the data. The data will be owned by the array
		/// and will be freed with g_free(), i.e. it could be allocated using g_strdup().
		///</summary>
		///<returns>a new #GByteArray</returns>
		public static ByteArray NewTake (byte[] data, UIntPtr len);

		static extern ByteArray g_byte_array_prepend (ByteArray array, byte data, uint len);

		///<summary>
		/// Adds the given data to the start of the #GByteArray.
		/// The array will grow in size automatically if necessary.
		///</summary>
		///<returns>the #GByteArray</returns>
		public ByteArray Prepend (byte data, uint len);

		static extern ByteArray g_byte_array_ref (ByteArray array);

		///<summary>
		/// Atomically increments the reference count of @array by one.
		/// This function is thread-safe and may be called from any thread.
		///</summary>
		///<returns>The passed in #GByteArray</returns>
		public ByteArray Ref ();

		static extern ByteArray g_byte_array_remove_index (ByteArray array, uint index_);

		///<summary>
		/// Removes the byte at the given index from a #GByteArray.
		/// The following bytes are moved down one place.
		///</summary>
		///<returns>the #GByteArray</returns>
		public ByteArray RemoveIndex (uint index_);

		static extern ByteArray g_byte_array_remove_index_fast (ByteArray array, uint index_);

		///<summary>
		/// Removes the byte at the given index from a #GByteArray. The last
		/// element in the array is used to fill in the space, so this function
		/// does not preserve the order of the #GByteArray. But it is faster
		/// than g_byte_array_remove_index().
		///</summary>
		///<returns>the #GByteArray</returns>
		public ByteArray RemoveIndexFast (uint index_);

		static extern ByteArray g_byte_array_remove_range (ByteArray array, uint index_, uint length);

		///<summary>
		/// Removes the given number of bytes starting at the given index from a
		/// #GByteArray.  The following elements are moved to close the gap.
		///</summary>
		///<returns>the #GByteArray</returns>
		public ByteArray RemoveRange (uint index_, uint length);

		static extern ByteArray g_byte_array_set_size (ByteArray array, uint length);

		///<summary>Sets the size of the #GByteArray, expanding it if necessary.</summary>
		///<returns>the #GByteArray</returns>
		public ByteArray SetSize (uint length);

		static extern ByteArray g_byte_array_sized_new (uint reserved_size);

		///<summary>
		/// Creates a new #GByteArray with @reserved_size bytes preallocated.
		/// This avoids frequent reallocation, if you are going to add many
		/// bytes to the array. Note however that the size of the array is still
		/// 0.
		///</summary>
		///<returns>the new #GByteArray</returns>
		public static ByteArray SizedNew (uint reserved_size);

		static extern void g_byte_array_sort (ByteArray array, CompareFunc compare_func);

		///<summary>
		/// Sorts a byte array, using @compare_func which should be a
		/// qsort()-style comparison function (returns less than zero for first
		/// arg is less than second arg, zero for equal, greater than zero if
		/// first arg is greater than second arg).
		/// 
		/// If two array elements compare equal, their order in the sorted array
		/// is undefined. If you want equal elements to keep their order (i.e.
		/// you want a stable sort) you can write a comparison function that,
		/// if two elements would otherwise compare equal, compares them by
		/// their addresses.
		///</summary>
		public void Sort (CompareFunc compare_func);

		static extern void g_byte_array_sort_with_data (ByteArray array, CompareDataFunc compare_func, IntPtr user_data);

		///<summary>
		/// Like g_byte_array_sort(), but the comparison function takes an extra
		/// user data argument.
		///</summary>
		public void SortWithData (CompareDataFunc compare_func, IntPtr user_data);

		static extern void g_byte_array_unref (ByteArray array);

		///<summary>
		/// Atomically decrements the reference count of @array by one. If the
		/// reference count drops to 0, all memory allocated by the array is
		/// released. This function is thread-safe and may be called from any
		/// thread.
		///</summary>
		public void Unref ();
	}
}
", result);
		}

//		[Test]
//		[Ignore ("This currently fails. NRE w/ do_action field")]
//		public void CanGenerateActionIfaceRecord ()
//		{
//			// Test is incomplete, as record is not fully generated atm.
//			var result = GenerateType(Atk1, "ActionIface");


//			// Need to map pointers at symbol level.
//			Assert.AreEqual(@"namespace Atk
//{
//}", result);
//}
	}
}
