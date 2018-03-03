
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
			Assert.AreEqual (@"using System;

namespace Gio
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

		static extern OutputStream g_buffered_output_stream_new_sized (OutputStream base_stream, UIntPtr size);

		///<summary>Creates a new buffered output stream with a given buffer size.</summary>
		///<returns>a #GOutputStream with an internal buffer set to @size.</returns>
		public BufferedOutputStream (OutputStream base_stream, UIntPtr size) : base (base_stream, size)
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

		static extern void g_buffered_output_stream_set_auto_grow (BufferedOutputStream stream, bool auto_grow);

		///<summary>
		/// Sets whether or not the @stream's buffer should automatically grow.
		/// If @auto_grow is true, then each write will just make the buffer
		/// larger, and you must manually flush the buffer to actually write out
		/// the data to the underlying stream.
		///</summary>
		public void SetAutoGrow (bool auto_grow);

		static extern void g_buffered_output_stream_set_buffer_size (BufferedOutputStream stream, UIntPtr size);

		///<summary>Sets the size of the internal buffer to @size.</summary>
		public void SetBufferSize (UIntPtr size);
	}
}
", result);
		}

		[Test]
		public void GenerateGtkAboutDialog ()
		{
			var result = GenerateType(Gtk3, "AboutDialog", true);

			Assert.AreEqual (@"using System;

namespace Gtk
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

		event AboutDialog.activate-linkHandler ActivateLink;
	}
}
",
result);
		}

		[Test]
		public void GenerateGObject ()
		{
			var result = GenerateType(GObject, "Object", true);

			Assert.AreEqual (@"using System;

namespace GObject
{
	public class Object
	{
		static extern Object g_object_new_valist (UIntPtr object_type, string first_property_name, ... var_args);

		public Object (UIntPtr object_type, string first_property_name, ... var_args) : base (object_type, first_property_name, var_args)
		{
		}

		static extern IntPtr g_object_newv (UIntPtr object_type, uint n_parameters, Parameter parameters);

		public Object (UIntPtr object_type, uint n_parameters, Parameter parameters) : base (object_type, n_parameters, parameters)
		{
		}

		TypeInstance GTypeInstance;

		uint RefCount;

		Data Qdata;

		static extern void g_object_add_toggle_ref (Object object, ToggleNotify notify, IntPtr data);

		public void AddToggleRef (ToggleNotify notify, IntPtr data);

		static extern void g_object_add_weak_pointer (Object object, IntPtr weak_pointer_location);

		public void AddWeakPointer (IntPtr weak_pointer_location);

		static extern Binding g_object_bind_property (IntPtr source, string source_property, IntPtr target, string target_property, BindingFlags flags);

		public Binding BindProperty (string source_property, IntPtr target, string target_property, BindingFlags flags);

		static extern Binding g_object_bind_property_full (IntPtr source, string source_property, IntPtr target, string target_property, BindingFlags flags, BindingTransformFunc transform_to, BindingTransformFunc transform_from, IntPtr user_data, DestroyNotify notify);

		public Binding BindPropertyFull (string source_property, IntPtr target, string target_property, BindingFlags flags, BindingTransformFunc transform_to, BindingTransformFunc transform_from, IntPtr user_data, DestroyNotify notify);

		static extern Binding g_object_bind_property_with_closures (IntPtr source, string source_property, IntPtr target, string target_property, BindingFlags flags, Closure transform_to, Closure transform_from);

		public Binding BindPropertyWithClosures (string source_property, IntPtr target, string target_property, BindingFlags flags, Closure transform_to, Closure transform_from);

		static extern IntPtr g_object_dup_data (Object object, string key, DuplicateFunc dup_func, IntPtr user_data);

		public IntPtr DupData (string key, DuplicateFunc dup_func, IntPtr user_data);

		static extern IntPtr g_object_dup_qdata (Object object, uint quark, DuplicateFunc dup_func, IntPtr user_data);

		public IntPtr DupQdata (uint quark, DuplicateFunc dup_func, IntPtr user_data);

		static extern void g_object_force_floating (Object object);

		public void ForceFloating ();

		static extern void g_object_freeze_notify (Object object);

		public void FreezeNotify ();

		static extern IntPtr g_object_get_data (Object object, string key);

		public IntPtr GetData (string key);

		static extern void g_object_get_property (Object object, string property_name, Value value);

		public void GetProperty (string property_name, Value value);

		static extern IntPtr g_object_get_qdata (Object object, uint quark);

		public IntPtr GetQdata (uint quark);

		static extern void g_object_get_valist (Object object, string first_property_name, ... var_args);

		public void GetValist (string first_property_name, ... var_args);

		static extern bool g_object_is_floating (IntPtr object);

		public bool IsFloating ();

		static extern void g_object_notify (Object object, string property_name);

		public void Notify (string property_name);

		static extern void g_object_notify_by_pspec (Object object, ParamSpec pspec);

		public void NotifyByPspec (ParamSpec pspec);

		static extern IntPtr g_object_ref (IntPtr object);

		public IntPtr Ref ();

		static extern IntPtr g_object_ref_sink (IntPtr object);

		public IntPtr RefSink ();

		static extern void g_object_remove_toggle_ref (Object object, ToggleNotify notify, IntPtr data);

		public void RemoveToggleRef (ToggleNotify notify, IntPtr data);

		static extern void g_object_remove_weak_pointer (Object object, IntPtr weak_pointer_location);

		public void RemoveWeakPointer (IntPtr weak_pointer_location);

		static extern bool g_object_replace_data (Object object, string key, IntPtr oldval, IntPtr newval, DestroyNotify destroy, DestroyNotify old_destroy);

		public bool ReplaceData (string key, IntPtr oldval, IntPtr newval, DestroyNotify destroy, DestroyNotify old_destroy);

		static extern bool g_object_replace_qdata (Object object, uint quark, IntPtr oldval, IntPtr newval, DestroyNotify destroy, DestroyNotify old_destroy);

		public bool ReplaceQdata (uint quark, IntPtr oldval, IntPtr newval, DestroyNotify destroy, DestroyNotify old_destroy);

		static extern void g_object_run_dispose (Object object);

		public void RunDispose ();

		static extern void g_object_set_data (Object object, string key, IntPtr data);

		public void SetData (string key, IntPtr data);

		static extern void g_object_set_data_full (Object object, string key, IntPtr data, DestroyNotify destroy);

		public void SetDataFull (string key, IntPtr data, DestroyNotify destroy);

		static extern void g_object_set_property (Object object, string property_name, Value value);

		public void SetProperty (string property_name, Value value);

		static extern void g_object_set_qdata (Object object, uint quark, IntPtr data);

		public void SetQdata (uint quark, IntPtr data);

		static extern void g_object_set_qdata_full (Object object, uint quark, IntPtr data, DestroyNotify destroy);

		public void SetQdataFull (uint quark, IntPtr data, DestroyNotify destroy);

		static extern void g_object_set_valist (Object object, string first_property_name, ... var_args);

		public void SetValist (string first_property_name, ... var_args);

		static extern IntPtr g_object_steal_data (Object object, string key);

		public IntPtr StealData (string key);

		static extern IntPtr g_object_steal_qdata (Object object, uint quark);

		public IntPtr StealQdata (uint quark);

		static extern void g_object_thaw_notify (Object object);

		public void ThawNotify ();

		static extern void g_object_unref (IntPtr object);

		public void Unref ();

		static extern void g_object_watch_closure (Object object, Closure closure);

		public void WatchClosure (Closure closure);

		static extern void g_object_weak_ref (Object object, WeakNotify notify, IntPtr data);

		public void WeakRef (WeakNotify notify, IntPtr data);

		static extern void g_object_weak_unref (Object object, WeakNotify notify, IntPtr data);

		public void WeakUnref (WeakNotify notify, IntPtr data);

		static extern UIntPtr g_object_compat_control (UIntPtr what, IntPtr data);

		public static UIntPtr CompatControl (UIntPtr what, IntPtr data);

		static extern IntPtr g_object_connect (IntPtr object, string signal_spec, ... ...);

		public static IntPtr Connect (IntPtr object, string signal_spec, ... ...);

		static extern void g_object_disconnect (IntPtr object, string signal_spec, ... ...);

		public static void Disconnect (IntPtr object, string signal_spec, ... ...);

		static extern void g_object_get (IntPtr object, string first_property_name, ... ...);

		public static void Get (IntPtr object, string first_property_name, ... ...);

		static extern ParamSpec g_object_interface_find_property (IntPtr g_iface, string property_name);

		public static ParamSpec InterfaceFindProperty (IntPtr g_iface, string property_name);

		static extern void g_object_interface_install_property (IntPtr g_iface, ParamSpec pspec);

		public static void InterfaceInstallProperty (IntPtr g_iface, ParamSpec pspec);

		static extern ParamSpec g_object_interface_list_properties (IntPtr g_iface, uint n_properties_p);

		public static ParamSpec InterfaceListProperties (IntPtr g_iface, uint n_properties_p);

		static extern IntPtr g_object_new (UIntPtr object_type, string first_property_name, ... ...);

		public static IntPtr New (UIntPtr object_type, string first_property_name, ... ...);

		static extern void g_object_set (IntPtr object, string first_property_name, ... ...);

		public static void Set (IntPtr object, string first_property_name, ... ...);

		event System.EventHandler Notify;
	}
}
", result);
		}
	}
}
