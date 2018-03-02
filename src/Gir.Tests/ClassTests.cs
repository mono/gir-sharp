
using NUnit.Framework;

namespace Gir.Tests
{
	[TestFixture]
	public class ClassTests : GenerationTestBase
	{
		[Test]
		public void TestClassIsGenerated ()
		{
			// Test is incomplete, as record is not fully generated atm.
			var result = GenerateType (Gio2, "BufferedOutputStream");

			// Need to map pointers at symbol level.
			Assert.AreEqual (@"namespace Gio
{
	///<summary>
	/// Buffered output stream implements #GFilterOutputStream and provides
	/// for buffered writes.
	/// 
	/// By default, #GBufferedOutputStream's buffer size is set at 4 kilobytes.
	/// 
	/// To create a buffered output stream, use g_buffered_output_stream_new(),
	/// or g_buffered_output_stream_new_sized() to specify the buffer's size
	/// at construction.
	/// 
	/// To get the size of a buffer within a buffered input stream, use
	/// g_buffered_output_stream_get_buffer_size(). To change the size of a
	/// buffered output stream's buffer, use
	/// g_buffered_output_stream_set_buffer_size(). Note that the buffer's
	/// size cannot be reduced below the size of the data within the buffer.
	///</summary>
	public class BufferedOutputStream : FilterOutputStream, ISeekable
	{
		static extern OutputStream g_buffered_output_stream_new (OutputStream base_stream);

		///<summary>Creates a new buffered output stream for a base stream.</summary>
		///<returns>a #GOutputStream for the given @base_stream.</returns>
		public BufferedOutputStream (OutputStream base_stream) : base (base_stream)
		{
		}

		static extern OutputStream g_buffered_output_stream_new_sized (OutputStream base_stream, gsize size);

		///<summary>Creates a new buffered output stream with a given buffer size.</summary>
		///<returns>a #GOutputStream with an internal buffer set to @size.</returns>
		public BufferedOutputStream (OutputStream base_stream, gsize size) : base (base_stream, size)
		{
		}

		FilterOutputStream ParentInstance;

		BufferedOutputStreamPrivate Priv;

		static extern bool g_buffered_output_stream_get_auto_grow (BufferedOutputStream stream);

		///<summary>Checks if the buffer automatically grows as data is added.</summary>
		///<returns>
		/// %TRUE if the @stream's buffer automatically grows,
		/// %FALSE otherwise.
		///</returns>
		public bool GetAutoGrow ();

		static extern UIntPtr g_buffered_output_stream_get_buffer_size (BufferedOutputStream stream);

		///<summary>Gets the size of the buffer in the @stream.</summary>
		///<returns>the current size of the buffer.</returns>
		public UIntPtr GetBufferSize ();

		static extern void g_buffered_output_stream_set_auto_grow (BufferedOutputStream stream, gboolean auto_grow);

		///<summary>
		/// Sets whether or not the @stream's buffer should automatically grow.
		/// If @auto_grow is true, then each write will just make the buffer
		/// larger, and you must manually flush the buffer to actually write out
		/// the data to the underlying stream.
		///</summary>
		public void SetAutoGrow (gboolean auto_grow);

		static extern void g_buffered_output_stream_set_buffer_size (BufferedOutputStream stream, gsize size);

		///<summary>Sets the size of the internal buffer to @size.</summary>
		public void SetBufferSize (gsize size);
	}
}
", result);
		}
	}
}
