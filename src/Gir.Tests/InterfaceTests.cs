﻿
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
		///<summary>Tests if the stream supports the #GSeekableIface.</summary>
		///<returns>%TRUE if @seekable can be seeked. %FALSE otherwise.</returns>
		bool CanSeek (Seekable seekable);

		///<summary>Tests if the stream can be truncated.</summary>
		///<returns>%TRUE if the stream can be truncated, %FALSE otherwise.</returns>
		bool CanTruncate (Seekable seekable);

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
		bool Seek (Seekable seekable, long offset, GLib.SeekType type, Cancellable cancellable);

		///<summary>Tells the current position within the stream.</summary>
		///<returns>the offset from the beginning of the buffer.</returns>
		long Tell (Seekable seekable);

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
		bool Truncate (Seekable seekable, long offset, Cancellable cancellable);
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
		bool CanSeek ();

		bool CanTruncate ();

		bool Seek (long offset, SeekType type, Cancellable cancellable);

		long Tell ();

		bool Truncate (long offset, Cancellable cancellable);
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
		///<summary>
		/// Add the specified handler to the set of functions to be called
		/// when this object receives focus events (in or out). If the handler is
		/// already added it is not added again
		///</summary>
		[Obsolete (""(Version: 2.9.4) If you need to track when an object gains or
lose the focus, use the #AtkObject::state-change ""focused"" notification instead."")]
		///<returns>
		/// a handler id which can be used in atk_component_remove_focus_handler()
		/// or zero if the handler was already added.
		///</returns>
		uint AddFocusHandler (FocusHandler handler);

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
		bool Contains (int x, int y, CoordType coord_type);

		///<summary>
		/// Returns the alpha value (i.e. the opacity) for this
		/// @component, on a scale from 0 (fully transparent) to 1.0
		/// (fully opaque).
		///</summary>
		///<returns>An alpha value from 0 to 1.0, inclusive.</returns>
		double GetAlpha ();

		///<summary>Gets the rectangle which gives the extent of the @component.</summary>
		void GetExtents (int x, int y, int width, int height, CoordType coord_type);

		///<summary>Gets the layer of the component.</summary>
		///<returns>an #AtkLayer which is the layer of the component</returns>
		Layer GetLayer ();

		///<summary>
		/// Gets the zorder of the component. The value G_MININT will be returned
		/// if the layer of the component is not ATK_LAYER_MDI or ATK_LAYER_WINDOW.
		///</summary>
		///<returns>
		/// a gint which is the zorder of the component, i.e. the depth at
		/// which the component is shown in relation to other components in the same
		/// container.
		///</returns>
		int GetMdiZorder ();

		///<summary>
		/// Gets the position of @component in the form of
		/// a point specifying @component's top-left corner.
		///</summary>
		[Obsolete (""(Version: ) Since 2.12. Use atk_component_get_extents() instead."")]
		void GetPosition (int x, int y, CoordType coord_type);

		///<summary>Gets the size of the @component in terms of width and height.</summary>
		[Obsolete (""(Version: ) Since 2.12. Use atk_component_get_extents() instead."")]
		void GetSize (int width, int height);

		///<summary>Grabs focus for this @component.</summary>
		///<returns>%TRUE if successful, %FALSE otherwise.</returns>
		bool GrabFocus ();

		///<summary>
		/// Gets a reference to the accessible child, if one exists, at the
		/// coordinate point specified by @x and @y.
		///</summary>
		///<returns>
		/// a reference to the accessible
		/// child, if one exists
		///</returns>
		Object RefAccessibleAtPoint (int x, int y, CoordType coord_type);

		///<summary>
		/// Remove the handler specified by @handler_id from the list of
		/// functions to be executed when this object receives focus events
		/// (in or out).
		///</summary>
		[Obsolete (""(Version: 2.9.4) If you need to track when an object gains or
lose the focus, use the #AtkObject::state-change ""focused"" notification instead."")]
		void RemoveFocusHandler (uint handler_id);

		///<summary>Sets the extents of @component.</summary>
		///<returns>%TRUE or %FALSE whether the extents were set or not</returns>
		bool SetExtents (int x, int y, int width, int height, CoordType coord_type);

		///<summary>Sets the postition of @component.</summary>
		///<returns>%TRUE or %FALSE whether or not the position was set or not</returns>
		bool SetPosition (int x, int y, CoordType coord_type);

		///<summary>Set the size of the @component in terms of width and height.</summary>
		///<returns>%TRUE or %FALSE whether the size was set or not</returns>
		bool SetSize (int width, int height);

		event Bounds-changed;
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
		[Obsolete (""(Version: 2.9.4) If you need to track when an object gains or
lose the focus, use the #AtkObject::state-change ""focused"" notification instead."")]
		uint AddFocusHandler (FocusHandler handler);

		bool Contains (int x, int y, CoordType coord_type);

		double GetAlpha ();

		void GetExtents (int x, int y, int width, int height, CoordType coord_type);

		Layer GetLayer ();

		int GetMdiZorder ();

		[Obsolete (""(Version: ) Since 2.12. Use atk_component_get_extents() instead."")]
		void GetPosition (int x, int y, CoordType coord_type);

		[Obsolete (""(Version: ) Since 2.12. Use atk_component_get_extents() instead."")]
		void GetSize (int width, int height);

		bool GrabFocus ();

		Object RefAccessibleAtPoint (int x, int y, CoordType coord_type);

		[Obsolete (""(Version: 2.9.4) If you need to track when an object gains or
lose the focus, use the #AtkObject::state-change ""focused"" notification instead."")]
		void RemoveFocusHandler (uint handler_id);

		bool SetExtents (int x, int y, int width, int height, CoordType coord_type);

		bool SetPosition (int x, int y, CoordType coord_type);

		bool SetSize (int width, int height);

		event Bounds-changed;
	}
}
", result);
		}

		[Test]
		public void GenerateAtkDriveInterfaceCompat()
		{
			var result = GenerateType(Gio2, "Drive", true);

			Assert.AreEqual(@"namespace Gio
{
	public interface Drive
	{
		bool CanEject ();

		bool CanPollForMedia ();

		bool CanStart ();

		bool CanStartDegraded ();

		bool CanStop ();

		[Obsolete (""(Version: 2.22) Use g_drive_eject_with_operation() instead."")]
		void Eject (MountUnmountFlags flags, Cancellable cancellable, AsyncReadyCallback callback, IntPtr user_data);

		[Obsolete (""(Version: 2.22) Use g_drive_eject_with_operation_finish() instead."")]
		bool EjectFinish (IAsyncResult result);

		void EjectWithOperation (MountUnmountFlags flags, MountOperation mount_operation, Cancellable cancellable, AsyncReadyCallback callback, IntPtr user_data);

		bool EjectWithOperationFinish (IAsyncResult result);

		string EnumerateIdentifiers ();

		IIcon GetIcon ();

		string GetIdentifier (string kind);

		string GetName ();

		string GetSortKey ();

		DriveStartStopType GetStartStopType ();

		IIcon GetSymbolicIcon ();

		List GetVolumes ();

		bool HasMedia ();

		bool HasVolumes ();

		bool IsMediaCheckAutomatic ();

		bool IsMediaRemovable ();

		void PollForMedia (Cancellable cancellable, AsyncReadyCallback callback, IntPtr user_data);

		bool PollForMediaFinish (IAsyncResult result);

		void Start (DriveStartFlags flags, MountOperation mount_operation, Cancellable cancellable, AsyncReadyCallback callback, IntPtr user_data);

		bool StartFinish (IAsyncResult result);

		void Stop (MountUnmountFlags flags, MountOperation mount_operation, Cancellable cancellable, AsyncReadyCallback callback, IntPtr user_data);

		bool StopFinish (IAsyncResult result);

		event Changed;

		event Disconnected;

		event Eject-button;

		event Stop-button;
	}
}
", result);
		}
	}
}
