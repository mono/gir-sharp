
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
			Assert.AreEqual(@"using System;

namespace Gio
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
			Assert.AreEqual(@"using System;

namespace Atk
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

		event BoundsChanged;
	}
}
", result);
		}

		[Test]
		public void GenerateAtkComponentInterfaceCompat ()
		{
			var result = GenerateType (Atk1, "Component", true);

			Assert.AreEqual (@"using System;

namespace Atk
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

		event BoundsChanged;
	}
}
", result);
		}

		[Test]
		public void GenerateAtkDriveInterfaceCompat()
		{
			var result = GenerateType(Gio2, "Drive", true);

			Assert.AreEqual(@"using System;

namespace Gio
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

		event EjectButton;

		event StopButton;
	}
}
", result);
		}

		[Test]
		public void GenerateGtkAboutDialog ()
		{
			var result = GenerateType(Gtk3, "AboutDialog", true);

			Assert.AreEqual (@"namespace Gtk
{
	public class AboutDialog : Dialog, Atk.ImplementorIface, Buildable
	{
		static extern Widget gtk_about_dialog_new ();

		public AboutDialog () : base ()
		{
		}

		Dialog ParentInstance;

		AboutDialogPrivate Priv;

		static extern void gtk_about_dialog_add_credit_section (AboutDialog about, string section_name, string people);

		public void AddCreditSection (string section_name, string people);

		static extern string gtk_about_dialog_get_artists (AboutDialog about);

		public string GetArtists ();

		static extern string gtk_about_dialog_get_authors (AboutDialog about);

		public string GetAuthors ();

		static extern string gtk_about_dialog_get_comments (AboutDialog about);

		public string GetComments ();

		static extern string gtk_about_dialog_get_copyright (AboutDialog about);

		public string GetCopyright ();

		static extern string gtk_about_dialog_get_documenters (AboutDialog about);

		public string GetDocumenters ();

		static extern string gtk_about_dialog_get_license (AboutDialog about);

		public string GetLicense ();

		static extern License gtk_about_dialog_get_license_type (AboutDialog about);

		public License GetLicenseType ();

		static extern Pixbuf gtk_about_dialog_get_logo (AboutDialog about);

		public Pixbuf GetLogo ();

		static extern string gtk_about_dialog_get_logo_icon_name (AboutDialog about);

		public string GetLogoIconName ();

		static extern string gtk_about_dialog_get_program_name (AboutDialog about);

		public string GetProgramName ();

		static extern string gtk_about_dialog_get_translator_credits (AboutDialog about);

		public string GetTranslatorCredits ();

		static extern string gtk_about_dialog_get_version (AboutDialog about);

		public string GetVersion ();

		static extern string gtk_about_dialog_get_website (AboutDialog about);

		public string GetWebsite ();

		static extern string gtk_about_dialog_get_website_label (AboutDialog about);

		public string GetWebsiteLabel ();

		static extern bool gtk_about_dialog_get_wrap_license (AboutDialog about);

		public bool GetWrapLicense ();

		static extern void gtk_about_dialog_set_artists (AboutDialog about, string artists);

		public void SetArtists (string artists);

		static extern void gtk_about_dialog_set_authors (AboutDialog about, string authors);

		public void SetAuthors (string authors);

		static extern void gtk_about_dialog_set_comments (AboutDialog about, string comments);

		public void SetComments (string comments);

		static extern void gtk_about_dialog_set_copyright (AboutDialog about, string copyright);

		public void SetCopyright (string copyright);

		static extern void gtk_about_dialog_set_documenters (AboutDialog about, string documenters);

		public void SetDocumenters (string documenters);

		static extern void gtk_about_dialog_set_license (AboutDialog about, string license);

		public void SetLicense (string license);

		static extern void gtk_about_dialog_set_license_type (AboutDialog about, License license_type);

		public void SetLicenseType (License license_type);

		static extern void gtk_about_dialog_set_logo (AboutDialog about, Pixbuf logo);

		public void SetLogo (Pixbuf logo);

		static extern void gtk_about_dialog_set_logo_icon_name (AboutDialog about, string icon_name);

		public void SetLogoIconName (string icon_name);

		static extern void gtk_about_dialog_set_program_name (AboutDialog about, string name);

		public void SetProgramName (string name);

		static extern void gtk_about_dialog_set_translator_credits (AboutDialog about, string translator_credits);

		public void SetTranslatorCredits (string translator_credits);

		static extern void gtk_about_dialog_set_version (AboutDialog about, string version);

		public void SetVersion (string version);

		static extern void gtk_about_dialog_set_website (AboutDialog about, string website);

		public void SetWebsite (string website);

		static extern void gtk_about_dialog_set_website_label (AboutDialog about, string website_label);

		public void SetWebsiteLabel (string website_label);

		static extern void gtk_about_dialog_set_wrap_license (AboutDialog about, bool wrap_license);

		public void SetWrapLicense (bool wrap_license);

		event ActivateLink;
	}
}
",
result);
		}
	}
}
