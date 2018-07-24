
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

		public void AddCreditSection (string section_name, string[] people);

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

		public void SetArtists (string[] artists);

		static extern void gtk_about_dialog_set_authors (AboutDialog about, string authors);

		public void SetAuthors (string[] authors);

		static extern void gtk_about_dialog_set_comments (AboutDialog about, string comments);

		public void SetComments (string comments);

		static extern void gtk_about_dialog_set_copyright (AboutDialog about, string copyright);

		public void SetCopyright (string copyright);

		static extern void gtk_about_dialog_set_documenters (AboutDialog about, string documenters);

		public void SetDocumenters (string[] documenters);

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
	}
}
