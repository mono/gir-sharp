using NUnit.Framework;

namespace Gir.Tests.Gtk2.Atk
{
	[TestFixture]
	class AtkTests : GenerationTestBase
	{
		[Test]
		public void GenerateAtkAction ()
		{
			var result = GenerateType (Gtk2Atk1, "Action", true);

			Assert.AreEqual (@"using System;
using System.Runtime.InteropServices;

namespace Atk
{
	public interface Action
	{
		bool DoAction (int i);

		string GetDescription (int i);

		string GetKeybinding (int i);

		string GetLocalizedName (int i);

		int GetNActions ();

		string GetName (int i);

		bool SetDescription (int i, string desc);
	}
}
", result);
		}

		[Test]
		public void GenerateAtkRole ()
		{
			var result = GenerateType (Gtk2Atk1, "Role", true);

			Assert.AreEqual (@"using System;
using System.Runtime.InteropServices;

namespace Atk
{
	public enum Role
	{
		Invalid = 0,
		AccelLabel = 1,
		Alert = 2,
		Animation = 3,
		Arrow = 4,
		Calendar = 5,
		Canvas = 6,
		CheckBox = 7,
		CheckMenuItem = 8,
		ColorChooser = 9,
		ColumnHeader = 10,
		ComboBox = 11,
		DateEditor = 12,
		DesktopIcon = 13,
		DesktopFrame = 14,
		Dial = 15,
		Dialog = 16,
		DirectoryPane = 17,
		DrawingArea = 18,
		FileChooser = 19,
		Filler = 20,
		FontChooser = 21,
		Frame = 22,
		GlassPane = 23,
		HtmlContainer = 24,
		Icon = 25,
		Image = 26,
		InternalFrame = 27,
		Label = 28,
		LayeredPane = 29,
		List = 30,
		ListItem = 31,
		Menu = 32,
		MenuBar = 33,
		MenuItem = 34,
		OptionPane = 35,
		PageTab = 36,
		PageTabList = 37,
		Panel = 38,
		PasswordText = 39,
		PopupMenu = 40,
		ProgressBar = 41,
		PushButton = 42,
		RadioButton = 43,
		RadioMenuItem = 44,
		RootPane = 45,
		RowHeader = 46,
		ScrollBar = 47,
		ScrollPane = 48,
		Separator = 49,
		Slider = 50,
		SplitPane = 51,
		SpinButton = 52,
		Statusbar = 53,
		Table = 54,
		TableCell = 55,
		TableColumnHeader = 56,
		TableRowHeader = 57,
		TearOffMenuItem = 58,
		Terminal = 59,
		Text = 60,
		ToggleButton = 61,
		ToolBar = 62,
		ToolTip = 63,
		Tree = 64,
		TreeTable = 65,
		Unknown = 66,
		Viewport = 67,
		Window = 68,
		Header = 69,
		Footer = 70,
		Paragraph = 71,
		Ruler = 72,
		Application = 73,
		Autocomplete = 74,
		Editbar = 75,
		Embedded = 76,
		Entry = 77,
		Chart = 78,
		Caption = 79,
		DocumentFrame = 80,
		Heading = 81,
		Page = 82,
		Section = 83,
		RedundantObject = 84,
		Form = 85,
		Link = 86,
		InputMethodWindow = 87,
		LastDefined = 88,
	}
}
", result);
		}

		[Test]
		public void GenerateAtkEventListener ()
		{
			var result = GenerateType (Gtk2Atk1, "EventListener", true);

			Assert.AreEqual(@"using System;
using System.Runtime.InteropServices;

namespace Atk
{
	[UnmanagedFunctionPointer (CallingConvention.Cdecl)]
	public delegate void EventListener (Object obj)

	[UnmanagedFunctionPointer (CallingConvention.Cdecl)]
	internal delegate void EventListenerNative (Object obj)

	internal static class EventListenerWrapper
	{
		public static void NativeCallback (Object obj)
		{
		}
	}
}
", result);
		}

		[Test]
		public void GenerateAttribute ()
		{
			var result = GenerateType (Gtk2Atk1, "Attribute", true);

			Assert.AreEqual (@"using System;
using System.Runtime.InteropServices;

namespace Atk
{
	[StructLayout (LayoutKind.Sequential)]
	public struct Attribute
	{
		string Name;
		string Value;
	}
}
", result);
		}
	}
}
