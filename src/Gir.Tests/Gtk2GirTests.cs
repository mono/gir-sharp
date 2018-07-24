using NUnit.Framework;

namespace Gir.Tests
{
	[TestFixture]
	public class Gtk2GirTests : GenerationTestBase
	{
		[Test]
		public void GenerateGtkWindow ()
		{
			var result = GenerateType (Gtk2, "Window", true);

			Assert.AreEqual (@"using System;

namespace Gtk
{
	public class Window : Bin, Atk.ImplementorIface, Buildable
	{
		static extern Widget gtk_window_new (WindowType type);

		public Window (WindowType type) : base (type)
		{
		}

		Bin Bin;

		string Title;

		string WmclassName;

		string WmclassClass;

		string WmRole;

		Widget FocusWidget;

		Widget DefaultWidget;

		Window TransientParent;

		WindowGeometryInfo GeometryInfo;

		Window Frame;

		WindowGroup Group;

		ushort ConfigureRequestCount;

		uint AllowShrink;

		uint AllowGrow;

		uint ConfigureNotifyReceived;

		uint NeedDefaultPosition;

		uint NeedDefaultSize;

		uint Position;

		uint Type;

		uint HasUserRefCount;

		uint HasFocus;

		uint Modal;

		uint DestroyWithParent;

		uint HasFrame;

		uint IconifyInitially;

		uint StickInitially;

		uint MaximizeInitially;

		uint Decorated;

		uint TypeHint;

		uint Gravity;

		uint IsActive;

		uint HasToplevelFocus;

		uint FrameLeft;

		uint FrameTop;

		uint FrameRight;

		uint FrameBottom;

		uint KeysChangedHandler;

		ModifierType MnemonicModifier;

		Screen Screen;

		static extern bool gtk_window_activate_default ();

		public bool ActivateDefault ();

		static extern bool gtk_window_activate_focus ();

		public bool ActivateFocus ();

		static extern bool gtk_window_activate_key (EventKey event);

		public bool ActivateKey (EventKey event);

		static extern void gtk_window_add_accel_group (AccelGroup accel_group);

		public void AddAccelGroup (AccelGroup accel_group);

		static extern void gtk_window_add_embedded_xid (uint xid);

		public void AddEmbeddedXid (uint xid);

		static extern void gtk_window_add_mnemonic (uint keyval, Widget target);

		public void AddMnemonic (uint keyval, Widget target);

		static extern void gtk_window_begin_move_drag (int button, int root_x, int root_y, uint timestamp);

		public void BeginMoveDrag (int button, int root_x, int root_y, uint timestamp);

		static extern void gtk_window_begin_resize_drag (WindowEdge edge, int button, int root_x, int root_y, uint timestamp);

		public void BeginResizeDrag (WindowEdge edge, int button, int root_x, int root_y, uint timestamp);

		static extern void gtk_window_deiconify ();

		public void Deiconify ();

		static extern void gtk_window_fullscreen ();

		public void Fullscreen ();

		static extern bool gtk_window_get_accept_focus ();

		public bool GetAcceptFocus ();

		static extern bool gtk_window_get_decorated ();

		public bool GetDecorated ();

		static extern void gtk_window_get_default_size (int width, int height);

		public void GetDefaultSize (int width, int height);

		static extern Widget gtk_window_get_default_widget ();

		public Widget GetDefaultWidget ();

		static extern bool gtk_window_get_deletable ();

		public bool GetDeletable ();

		static extern bool gtk_window_get_destroy_with_parent ();

		public bool GetDestroyWithParent ();

		static extern Widget gtk_window_get_focus ();

		public Widget GetFocus ();

		static extern bool gtk_window_get_focus_on_map ();

		public bool GetFocusOnMap ();

		static extern void gtk_window_get_frame_dimensions (int left, int top, int right, int bottom);

		[Obsolete (""This function will be removed in GTK+ 3"")]
		public void GetFrameDimensions (int left, int top, int right, int bottom);

		static extern Gravity gtk_window_get_gravity ();

		public Gravity GetGravity ();

		static extern WindowGroup gtk_window_get_group ();

		public WindowGroup GetGroup ();

		static extern bool gtk_window_get_has_frame ();

		[Obsolete (""This function will be removed in GTK+ 3"")]
		public bool GetHasFrame ();

		static extern Pixbuf gtk_window_get_icon ();

		public Pixbuf GetIcon ();

		static extern List gtk_window_get_icon_list ();

		public List GetIconList ();

		static extern string gtk_window_get_icon_name ();

		public string GetIconName ();

		static extern ModifierType gtk_window_get_mnemonic_modifier ();

		public ModifierType GetMnemonicModifier ();

		static extern bool gtk_window_get_mnemonics_visible ();

		public bool GetMnemonicsVisible ();

		static extern bool gtk_window_get_modal ();

		public bool GetModal ();

		static extern double gtk_window_get_opacity ();

		public double GetOpacity ();

		static extern void gtk_window_get_position (int root_x, int root_y);

		public void GetPosition (int root_x, int root_y);

		static extern bool gtk_window_get_resizable ();

		public bool GetResizable ();

		static extern string gtk_window_get_role ();

		public string GetRole ();

		static extern Screen gtk_window_get_screen ();

		public Screen GetScreen ();

		static extern void gtk_window_get_size (int width, int height);

		public void GetSize (int width, int height);

		static extern bool gtk_window_get_skip_pager_hint ();

		public bool GetSkipPagerHint ();

		static extern bool gtk_window_get_skip_taskbar_hint ();

		public bool GetSkipTaskbarHint ();

		static extern string gtk_window_get_title ();

		public string GetTitle ();

		static extern Window gtk_window_get_transient_for ();

		public Window GetTransientFor ();

		static extern WindowTypeHint gtk_window_get_type_hint ();

		public WindowTypeHint GetTypeHint ();

		static extern bool gtk_window_get_urgency_hint ();

		public bool GetUrgencyHint ();

		static extern WindowType gtk_window_get_window_type ();

		public WindowType GetWindowType ();

		static extern bool gtk_window_has_group ();

		public bool HasGroup ();

		static extern bool gtk_window_has_toplevel_focus ();

		public bool HasToplevelFocus ();

		static extern void gtk_window_iconify ();

		public void Iconify ();

		static extern bool gtk_window_is_active ();

		public bool IsActive ();

		static extern void gtk_window_maximize ();

		public void Maximize ();

		static extern bool gtk_window_mnemonic_activate (uint keyval, ModifierType modifier);

		public bool MnemonicActivate (uint keyval, ModifierType modifier);

		static extern void gtk_window_move (int x, int y);

		public void Move (int x, int y);

		static extern bool gtk_window_parse_geometry (string geometry);

		public bool ParseGeometry (string geometry);

		static extern void gtk_window_present ();

		public void Present ();

		static extern void gtk_window_present_with_time (uint timestamp);

		public void PresentWithTime (uint timestamp);

		static extern bool gtk_window_propagate_key_event (EventKey event);

		public bool PropagateKeyEvent (EventKey event);

		static extern void gtk_window_remove_accel_group (AccelGroup accel_group);

		public void RemoveAccelGroup (AccelGroup accel_group);

		static extern void gtk_window_remove_embedded_xid (uint xid);

		public void RemoveEmbeddedXid (uint xid);

		static extern void gtk_window_remove_mnemonic (uint keyval, Widget target);

		public void RemoveMnemonic (uint keyval, Widget target);

		static extern void gtk_window_reshow_with_initial_size ();

		public void ReshowWithInitialSize ();

		static extern void gtk_window_resize (int width, int height);

		public void Resize (int width, int height);

		static extern void gtk_window_set_accept_focus (bool setting);

		public void SetAcceptFocus (bool setting);

		static extern void gtk_window_set_decorated (bool setting);

		public void SetDecorated (bool setting);

		static extern void gtk_window_set_default (Widget default_widget);

		public void SetDefault (Widget default_widget);

		static extern void gtk_window_set_default_size (int width, int height);

		public void SetDefaultSize (int width, int height);

		static extern void gtk_window_set_deletable (bool setting);

		public void SetDeletable (bool setting);

		static extern void gtk_window_set_destroy_with_parent (bool setting);

		public void SetDestroyWithParent (bool setting);

		static extern void gtk_window_set_focus (Widget focus);

		public void SetFocus (Widget focus);

		static extern void gtk_window_set_focus_on_map (bool setting);

		public void SetFocusOnMap (bool setting);

		static extern void gtk_window_set_frame_dimensions (int left, int top, int right, int bottom);

		[Obsolete (""This function will be removed in GTK+ 3"")]
		public void SetFrameDimensions (int left, int top, int right, int bottom);

		static extern void gtk_window_set_geometry_hints (Widget geometry_widget, Geometry geometry, WindowHints geom_mask);

		public void SetGeometryHints (Widget geometry_widget, Geometry geometry, WindowHints geom_mask);

		static extern void gtk_window_set_gravity (Gravity gravity);

		public void SetGravity (Gravity gravity);

		static extern void gtk_window_set_has_frame (bool setting);

		[Obsolete (""This function will be removed in GTK+ 3"")]
		public void SetHasFrame (bool setting);

		static extern void gtk_window_set_icon (Pixbuf icon);

		public void SetIcon (Pixbuf icon);

		static extern bool gtk_window_set_icon_from_file (string filename);

		public bool SetIconFromFile (string filename);

		static extern void gtk_window_set_icon_list (List list);

		public void SetIconList (List list);

		static extern void gtk_window_set_icon_name (string name);

		public void SetIconName (string name);

		static extern void gtk_window_set_keep_above (bool setting);

		public void SetKeepAbove (bool setting);

		static extern void gtk_window_set_keep_below (bool setting);

		public void SetKeepBelow (bool setting);

		static extern void gtk_window_set_mnemonic_modifier (ModifierType modifier);

		public void SetMnemonicModifier (ModifierType modifier);

		static extern void gtk_window_set_mnemonics_visible (bool setting);

		public void SetMnemonicsVisible (bool setting);

		static extern void gtk_window_set_modal (bool modal);

		public void SetModal (bool modal);

		static extern void gtk_window_set_opacity (double opacity);

		public void SetOpacity (double opacity);

		static extern void gtk_window_set_policy (int allow_shrink, int allow_grow, int auto_shrink);

		public void SetPolicy (int allow_shrink, int allow_grow, int auto_shrink);

		static extern void gtk_window_set_position (WindowPosition position);

		public void SetPosition (WindowPosition position);

		static extern void gtk_window_set_resizable (bool resizable);

		public void SetResizable (bool resizable);

		static extern void gtk_window_set_role (string role);

		public void SetRole (string role);

		static extern void gtk_window_set_screen (Screen screen);

		public void SetScreen (Screen screen);

		static extern void gtk_window_set_skip_pager_hint (bool setting);

		public void SetSkipPagerHint (bool setting);

		static extern void gtk_window_set_skip_taskbar_hint (bool setting);

		public void SetSkipTaskbarHint (bool setting);

		static extern void gtk_window_set_startup_id (string startup_id);

		public void SetStartupId (string startup_id);

		static extern void gtk_window_set_title (string title);

		public void SetTitle (string title);

		static extern void gtk_window_set_transient_for (Window parent);

		public void SetTransientFor (Window parent);

		static extern void gtk_window_set_type_hint (WindowTypeHint hint);

		public void SetTypeHint (WindowTypeHint hint);

		static extern void gtk_window_set_urgency_hint (bool setting);

		public void SetUrgencyHint (bool setting);

		static extern void gtk_window_set_wmclass (string wmclass_name, string wmclass_class);

		public void SetWmclass (string wmclass_name, string wmclass_class);

		static extern void gtk_window_stick ();

		public void Stick ();

		static extern void gtk_window_unfullscreen ();

		public void Unfullscreen ();

		static extern void gtk_window_unmaximize ();

		public void Unmaximize ();

		static extern void gtk_window_unstick ();

		public void Unstick ();

		static extern List gtk_window_get_default_icon_list ();

		public static List GetDefaultIconList ();

		static extern string gtk_window_get_default_icon_name ();

		public static string GetDefaultIconName ();

		static extern List gtk_window_list_toplevels ();

		public static List ListToplevels ();

		static extern void gtk_window_set_auto_startup_notification (bool setting);

		public static void SetAutoStartupNotification (bool setting);

		static extern void gtk_window_set_default_icon (Pixbuf icon);

		public void SetDefaultIcon ();

		static extern bool gtk_window_set_default_icon_from_file (string filename);

		public static bool SetDefaultIconFromFile (string filename);

		static extern void gtk_window_set_default_icon_list (List list);

		public static void SetDefaultIconList (List list);

		static extern void gtk_window_set_default_icon_name (string name);

		public static void SetDefaultIconName (string name);

		event Window.activate-defaultHandler ActivateDefault;

		event Window.activate-focusHandler ActivateFocus;

		event Window.frame-eventHandler FrameEvent;

		event Window.keys-changedHandler KeysChanged;

		event Window.set-focusHandler SetFocus;
	}
}
", result);
		}
	}
}
