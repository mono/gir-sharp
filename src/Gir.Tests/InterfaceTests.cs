
using NUnit.Framework;

namespace Gir.Tests
{
	[TestFixture]
	public class InterfaceTests : GenerationTestBase
	{
		[Test]
		public void TestClassIsGenerated ()
		{
			// Test is incomplete, as record is not fully generated atm.
			var result = GenerateType (Gio2, "Seekable");

			// Need to map pointers at symbol level.
			Assert.AreEqual (@"namespace Gio
{
	///<summary>
	/// #GSeekable is implemented by streams (implementations of
	/// #GInputStream or #GOutputStream) that support seeking.
	/// 
	/// Seekable streams largely fall into two categories: resizable and
	/// fixed-size.
	/// 
	/// #GSeekable on fixed-sized streams is approximately the same as POSIX
	/// lseek() on a block device (for example: attmepting to seek past the
	/// end of the device is an error).  Fixed streams typically cannot be
	/// truncated.
	/// 
	/// #GSeekable on resizable streams is approximately the same as POSIX
	/// lseek() on a normal file.  Seeking past the end and writing data will
	/// usually cause the stream to resize by introducing zero bytes.
	///</summary>
	public interface Seekable
	{
		static extern bool g_seekable_can_seek PARAMS

		///<summary>Tests if the stream supports the #GSeekableIface.</summary>
		///<returns>%TRUE if @seekable can be seeked. %FALSE otherwise.</returns>
		bool CanSeek PARAMS

		static extern bool g_seekable_can_truncate PARAMS

		///<summary>Tests if the stream can be truncated.</summary>
		///<returns>%TRUE if the stream can be truncated, %FALSE otherwise.</returns>
		bool CanTruncate PARAMS

		static extern bool g_seekable_seek PARAMS

		///<summary>
		/// Seeks in the stream by the given @offset, modified by @type.
		/// 
		/// Attempting to seek past the end of the stream will have different
		/// results depending on if the stream is fixed-sized or resizable.  If
		/// the stream is resizable then seeking past the end and then writing
		/// will result in zeros filling the empty space.  Seeking past the end
		/// of a resizable stream and reading will result in EOF.  Seeking past
		/// the end of a fixed-sized stream will fail.
		/// 
		/// Any operation that would result in a negative offset will fail.
		/// 
		/// If @cancellable is not %NULL, then the operation can be cancelled by
		/// triggering the cancellable object from another thread. If the operation
		/// was cancelled, the error %G_IO_ERROR_CANCELLED will be returned.
		///</summary>
		///<returns>
		/// %TRUE if successful. If an error
		///     has occurred, this function will return %FALSE and set @error
		///     appropriately if present.
		///</returns>
		bool Seek PARAMS

		static extern long g_seekable_tell PARAMS

		///<summary>Tells the current position within the stream.</summary>
		///<returns>the offset from the beginning of the buffer.</returns>
		long Tell PARAMS

		static extern bool g_seekable_truncate PARAMS

		///<summary>
		/// Truncates a stream with a given #offset.
		/// 
		/// If @cancellable is not %NULL, then the operation can be cancelled by
		/// triggering the cancellable object from another thread. If the operation
		/// was cancelled, the error %G_IO_ERROR_CANCELLED will be returned. If an
		/// operation was partially finished when the operation was cancelled the
		/// partial result will be returned, without an error.
		///</summary>
		///<returns>
		/// %TRUE if successful. If an error
		///     has occurred, this function will return %FALSE and set @error
		///     appropriately if present.
		///</returns>
		bool Truncate PARAMS
	}
}
", result);
		}
	}
}
