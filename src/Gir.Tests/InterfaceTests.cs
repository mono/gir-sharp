
using NUnit.Framework;

namespace Gir.Tests
{
	[TestFixture]
	public class InterfaceTests : GenerationTestBase
	{
		public void TestSeekableInterfaceIsGenerated()
		{
			var result = GenerateType(Gio2, "Seekable");
			Assert.AreEqual(@"namespace Gio
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
	public interface ISeekable
	{
		static extern bool g_seekable_can_seek (Seekable seekable);

		///<summary>Tests if the stream supports the #GSeekableIface.</summary>
		///<returns>%TRUE if @seekable can be seeked. %FALSE otherwise.</returns>
		public bool CanSeek (Seekable seekable);

		static extern bool g_seekable_can_truncate (Seekable seekable);

		///<summary>Tests if the stream can be truncated.</summary>
		///<returns>%TRUE if the stream can be truncated, %FALSE otherwise.</returns>
		public bool CanTruncate (Seekable seekable);

		static extern bool g_seekable_seek (Seekable seekable, gint64 offset, GLib.SeekType type, Cancellable cancellable);

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
		public bool Seek (Seekable seekable, gint64 offset, GLib.SeekType type, Cancellable cancellable);

		static extern long g_seekable_tell (Seekable seekable);

		///<summary>Tells the current position within the stream.</summary>
		///<returns>the offset from the beginning of the buffer.</returns>
		public long Tell (Seekable seekable);

		static extern bool g_seekable_truncate (Seekable seekable, gint64 offset, Cancellable cancellable);

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
		public bool Truncate (Seekable seekable, gint64 offset, Cancellable cancellable);
	}
}
", result);
		}

		[Test]
		public void TestSeekableInterfaceIsGeneratedCompatEnabled()
		{
			var result = GenerateType(Gio2, "Seekable", true);
			Assert.AreEqual(@"namespace Gio
{
	public interface Seekable
	{
		static extern bool g_seekable_can_seek (Seekable seekable);

		public bool CanSeek (Seekable seekable);

		static extern bool g_seekable_can_truncate (Seekable seekable);

		public bool CanTruncate (Seekable seekable);

		static extern bool g_seekable_seek (Seekable seekable, gint64 offset, GLib.SeekType type, Cancellable cancellable);

		public bool Seek (Seekable seekable, gint64 offset, GLib.SeekType type, Cancellable cancellable);

		static extern long g_seekable_tell (Seekable seekable);

		public long Tell (Seekable seekable);

		static extern bool g_seekable_truncate (Seekable seekable, gint64 offset, Cancellable cancellable);

		public bool Truncate (Seekable seekable, gint64 offset, Cancellable cancellable);
	}
}
", result);
		}

		[Test]
		public void GenerateAtkComponentInterface ()
		{
			var result = GenerateType(Atk1, "Component");
			Assert.AreEqual(@"namespace Atk
{
	///<summary>
	/// #AtkComponent should be implemented by most if not all UI elements
	/// with an actual on-screen presence, i.e. components which can be
	/// said to have a screen-coordinate bounding box.  Virtually all
	/// widgets will need to have #AtkComponent implementations provided
	/// for their corresponding #AtkObject class.  In short, only UI
	/// elements which are *not* GUI elements will omit this ATK interface.
	/// 
	/// A possible exception might be textual information with a
	/// transparent background, in which case text glyph bounding box
	/// information is provided by #AtkText.
	///</summary>
	public interface IComponent
	{
		static extern uint atk_component_add_focus_handler (Component component, FocusHandler handler);

		///<summary>
		/// Add the specified handler to the set of functions to be called
		/// when this object receives focus events (in or out). If the handler is
		/// already added it is not added again
		///</summary>
		///<returns>
		/// a handler id which can be used in atk_component_remove_focus_handler()
		/// or zero if the handler was already added.
		///</returns>
		public uint AddFocusHandler (Component component, FocusHandler handler);

		static extern bool atk_component_contains (Component component, gint x, gint y, CoordType coord_type);

		///<summary>
		/// Checks whether the specified point is within the extent of the @component.
		/// 
		/// Toolkit implementor note: ATK provides a default implementation for
		/// this virtual method. In general there are little reason to
		/// re-implement it.
		///</summary>
		///<returns>
		/// %TRUE or %FALSE indicating whether the specified point is within
		/// the extent of the @component or not
		///</returns>
		public bool Contains (Component component, gint x, gint y, CoordType coord_type);

		static extern double atk_component_get_alpha (Component component);

		///<summary>
		/// Returns the alpha value (i.e. the opacity) for this
		/// @component, on a scale from 0 (fully transparent) to 1.0
		/// (fully opaque).
		///</summary>
		///<returns>An alpha value from 0 to 1.0, inclusive.</returns>
		public double GetAlpha (Component component);

		static extern void atk_component_get_extents (Component component, gint x, gint y, gint width, gint height, CoordType coord_type);

		///<summary>Gets the rectangle which gives the extent of the @component.</summary>
		public void GetExtents (Component component, gint x, gint y, gint width, gint height, CoordType coord_type);

		static extern Layer atk_component_get_layer (Component component);

		///<summary>Gets the layer of the component.</summary>
		///<returns>an #AtkLayer which is the layer of the component</returns>
		public Layer GetLayer (Component component);

		static extern int atk_component_get_mdi_zorder (Component component);

		///<summary>
		/// Gets the zorder of the component. The value G_MININT will be returned
		/// if the layer of the component is not ATK_LAYER_MDI or ATK_LAYER_WINDOW.
		///</summary>
		///<returns>
		/// a gint which is the zorder of the component, i.e. the depth at
		/// which the component is shown in relation to other components in the same
		/// container.
		///</returns>
		public int GetMdiZorder (Component component);

		static extern void atk_component_get_position (Component component, gint x, gint y, CoordType coord_type);

		///<summary>
		/// Gets the position of @component in the form of
		/// a point specifying @component's top-left corner.
		///</summary>
		public void GetPosition (Component component, gint x, gint y, CoordType coord_type);

		static extern void atk_component_get_size (Component component, gint width, gint height);

		///<summary>Gets the size of the @component in terms of width and height.</summary>
		public void GetSize (Component component, gint width, gint height);

		static extern bool atk_component_grab_focus (Component component);

		///<summary>Grabs focus for this @component.</summary>
		///<returns>%TRUE if successful, %FALSE otherwise.</returns>
		public bool GrabFocus (Component component);

		static extern Object atk_component_ref_accessible_at_point (Component component, gint x, gint y, CoordType coord_type);

		///<summary>
		/// Gets a reference to the accessible child, if one exists, at the
		/// coordinate point specified by @x and @y.
		///</summary>
		///<returns>
		/// a reference to the accessible
		/// child, if one exists
		///</returns>
		public Object RefAccessibleAtPoint (Component component, gint x, gint y, CoordType coord_type);

		static extern void atk_component_remove_focus_handler (Component component, guint handler_id);

		///<summary>
		/// Remove the handler specified by @handler_id from the list of
		/// functions to be executed when this object receives focus events
		/// (in or out).
		///</summary>
		public void RemoveFocusHandler (Component component, guint handler_id);

		static extern bool atk_component_set_extents (Component component, gint x, gint y, gint width, gint height, CoordType coord_type);

		///<summary>Sets the extents of @component.</summary>
		///<returns>%TRUE or %FALSE whether the extents were set or not</returns>
		public bool SetExtents (Component component, gint x, gint y, gint width, gint height, CoordType coord_type);

		static extern bool atk_component_set_position (Component component, gint x, gint y, CoordType coord_type);

		///<summary>Sets the postition of @component.</summary>
		///<returns>%TRUE or %FALSE whether or not the position was set or not</returns>
		public bool SetPosition (Component component, gint x, gint y, CoordType coord_type);

		static extern bool atk_component_set_size (Component component, gint width, gint height);

		///<summary>Set the size of the @component in terms of width and height.</summary>
		///<returns>%TRUE or %FALSE whether the size was set or not</returns>
		public bool SetSize (Component component, gint width, gint height);
	}
}
", result);
		}

		[Test]
		public void GenerateAtkComponentInterfaceCompat ()
		{
			var result = GenerateType (Atk1, "Component", true);

			Assert.AreEqual (@"namespace Atk
{
	public interface Component
	{
		static extern uint atk_component_add_focus_handler (Component component, FocusHandler handler);

		public uint AddFocusHandler (Component component, FocusHandler handler);

		static extern bool atk_component_contains (Component component, gint x, gint y, CoordType coord_type);

		public bool Contains (Component component, gint x, gint y, CoordType coord_type);

		static extern double atk_component_get_alpha (Component component);

		public double GetAlpha (Component component);

		static extern void atk_component_get_extents (Component component, gint x, gint y, gint width, gint height, CoordType coord_type);

		public void GetExtents (Component component, gint x, gint y, gint width, gint height, CoordType coord_type);

		static extern Layer atk_component_get_layer (Component component);

		public Layer GetLayer (Component component);

		static extern int atk_component_get_mdi_zorder (Component component);

		public int GetMdiZorder (Component component);

		static extern void atk_component_get_position (Component component, gint x, gint y, CoordType coord_type);

		public void GetPosition (Component component, gint x, gint y, CoordType coord_type);

		static extern void atk_component_get_size (Component component, gint width, gint height);

		public void GetSize (Component component, gint width, gint height);

		static extern bool atk_component_grab_focus (Component component);

		public bool GrabFocus (Component component);

		static extern Object atk_component_ref_accessible_at_point (Component component, gint x, gint y, CoordType coord_type);

		public Object RefAccessibleAtPoint (Component component, gint x, gint y, CoordType coord_type);

		static extern void atk_component_remove_focus_handler (Component component, guint handler_id);

		public void RemoveFocusHandler (Component component, guint handler_id);

		static extern bool atk_component_set_extents (Component component, gint x, gint y, gint width, gint height, CoordType coord_type);

		public bool SetExtents (Component component, gint x, gint y, gint width, gint height, CoordType coord_type);

		static extern bool atk_component_set_position (Component component, gint x, gint y, CoordType coord_type);

		public bool SetPosition (Component component, gint x, gint y, CoordType coord_type);

		static extern bool atk_component_set_size (Component component, gint width, gint height);

		public bool SetSize (Component component, gint width, gint height);
	}
}
", result);
		}
	}
}
