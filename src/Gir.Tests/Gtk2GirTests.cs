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

		public bool ActivateDefault ()
		{
			return gtk_window_activate_default ();
		}

		static extern bool gtk_window_activate_focus ();

		public bool ActivateFocus ()
		{
			return gtk_window_activate_focus ();
		}

		static extern bool gtk_window_activate_key (EventKey event);

		public bool ActivateKey (EventKey event)
		{
			return gtk_window_activate_key (event);
		}

		static extern void gtk_window_add_accel_group (AccelGroup accel_group);

		public void AddAccelGroup (AccelGroup accel_group)
		{
			gtk_window_add_accel_group (accel_group);
		}

		static extern void gtk_window_add_embedded_xid (uint xid);

		public void AddEmbeddedXid (uint xid)
		{
			gtk_window_add_embedded_xid (xid);
		}

		static extern void gtk_window_add_mnemonic (uint keyval, Widget target);

		public void AddMnemonic (uint keyval, Widget target)
		{
			gtk_window_add_mnemonic (keyval, target);
		}

		static extern void gtk_window_begin_move_drag (int button, int root_x, int root_y, uint timestamp);

		public void BeginMoveDrag (int button, int root_x, int root_y, uint timestamp)
		{
			gtk_window_begin_move_drag (button, root_x, root_y, timestamp);
		}

		static extern void gtk_window_begin_resize_drag (WindowEdge edge, int button, int root_x, int root_y, uint timestamp);

		public void BeginResizeDrag (WindowEdge edge, int button, int root_x, int root_y, uint timestamp)
		{
			gtk_window_begin_resize_drag (edge, button, root_x, root_y, timestamp);
		}

		static extern void gtk_window_deiconify ();

		public void Deiconify ()
		{
			gtk_window_deiconify ();
		}

		static extern void gtk_window_fullscreen ();

		public void Fullscreen ()
		{
			gtk_window_fullscreen ();
		}

		static extern bool gtk_window_get_accept_focus ();

		public bool GetAcceptFocus ()
		{
			return gtk_window_get_accept_focus ();
		}

		static extern bool gtk_window_get_decorated ();

		public bool GetDecorated ()
		{
			return gtk_window_get_decorated ();
		}

		static extern void gtk_window_get_default_size (int width, int height);

		public void GetDefaultSize (int width, int height)
		{
			gtk_window_get_default_size (width, height);
		}

		static extern Widget gtk_window_get_default_widget ();

		public Widget GetDefaultWidget ()
		{
			return gtk_window_get_default_widget ();
		}

		static extern bool gtk_window_get_deletable ();

		public bool GetDeletable ()
		{
			return gtk_window_get_deletable ();
		}

		static extern bool gtk_window_get_destroy_with_parent ();

		public bool GetDestroyWithParent ()
		{
			return gtk_window_get_destroy_with_parent ();
		}

		static extern Widget gtk_window_get_focus ();

		public Widget GetFocus ()
		{
			return gtk_window_get_focus ();
		}

		static extern bool gtk_window_get_focus_on_map ();

		public bool GetFocusOnMap ()
		{
			return gtk_window_get_focus_on_map ();
		}

		static extern void gtk_window_get_frame_dimensions (int left, int top, int right, int bottom);

		[Obsolete (""This function will be removed in GTK+ 3"")]
		public void GetFrameDimensions (int left, int top, int right, int bottom)
		{
			gtk_window_get_frame_dimensions (left, top, right, bottom);
		}

		static extern Gravity gtk_window_get_gravity ();

		public Gravity GetGravity ()
		{
			return gtk_window_get_gravity ();
		}

		static extern WindowGroup gtk_window_get_group ();

		public WindowGroup GetGroup ()
		{
			return gtk_window_get_group ();
		}

		static extern bool gtk_window_get_has_frame ();

		[Obsolete (""This function will be removed in GTK+ 3"")]
		public bool GetHasFrame ()
		{
			return gtk_window_get_has_frame ();
		}

		static extern Pixbuf gtk_window_get_icon ();

		public Pixbuf GetIcon ()
		{
			return gtk_window_get_icon ();
		}

		static extern List gtk_window_get_icon_list ();

		public List GetIconList ()
		{
			return gtk_window_get_icon_list ();
		}

		static extern string gtk_window_get_icon_name ();

		public string GetIconName ()
		{
			return gtk_window_get_icon_name ();
		}

		static extern ModifierType gtk_window_get_mnemonic_modifier ();

		public ModifierType GetMnemonicModifier ()
		{
			return gtk_window_get_mnemonic_modifier ();
		}

		static extern bool gtk_window_get_mnemonics_visible ();

		public bool GetMnemonicsVisible ()
		{
			return gtk_window_get_mnemonics_visible ();
		}

		static extern bool gtk_window_get_modal ();

		public bool GetModal ()
		{
			return gtk_window_get_modal ();
		}

		static extern double gtk_window_get_opacity ();

		public double GetOpacity ()
		{
			return gtk_window_get_opacity ();
		}

		static extern void gtk_window_get_position (int root_x, int root_y);

		public void GetPosition (int root_x, int root_y)
		{
			gtk_window_get_position (root_x, root_y);
		}

		static extern bool gtk_window_get_resizable ();

		public bool GetResizable ()
		{
			return gtk_window_get_resizable ();
		}

		static extern string gtk_window_get_role ();

		public string GetRole ()
		{
			return gtk_window_get_role ();
		}

		static extern Screen gtk_window_get_screen ();

		public Screen GetScreen ()
		{
			return gtk_window_get_screen ();
		}

		static extern void gtk_window_get_size (int width, int height);

		public void GetSize (int width, int height)
		{
			gtk_window_get_size (width, height);
		}

		static extern bool gtk_window_get_skip_pager_hint ();

		public bool GetSkipPagerHint ()
		{
			return gtk_window_get_skip_pager_hint ();
		}

		static extern bool gtk_window_get_skip_taskbar_hint ();

		public bool GetSkipTaskbarHint ()
		{
			return gtk_window_get_skip_taskbar_hint ();
		}

		static extern string gtk_window_get_title ();

		public string GetTitle ()
		{
			return gtk_window_get_title ();
		}

		static extern Window gtk_window_get_transient_for ();

		public Window GetTransientFor ()
		{
			return gtk_window_get_transient_for ();
		}

		static extern WindowTypeHint gtk_window_get_type_hint ();

		public WindowTypeHint GetTypeHint ()
		{
			return gtk_window_get_type_hint ();
		}

		static extern bool gtk_window_get_urgency_hint ();

		public bool GetUrgencyHint ()
		{
			return gtk_window_get_urgency_hint ();
		}

		static extern WindowType gtk_window_get_window_type ();

		public WindowType GetWindowType ()
		{
			return gtk_window_get_window_type ();
		}

		static extern bool gtk_window_has_group ();

		public bool HasGroup ()
		{
			return gtk_window_has_group ();
		}

		static extern bool gtk_window_has_toplevel_focus ();

		public bool HasToplevelFocus ()
		{
			return gtk_window_has_toplevel_focus ();
		}

		static extern void gtk_window_iconify ();

		public void Iconify ()
		{
			gtk_window_iconify ();
		}

		static extern bool gtk_window_is_active ();

		public bool IsActive ()
		{
			return gtk_window_is_active ();
		}

		static extern void gtk_window_maximize ();

		public void Maximize ()
		{
			gtk_window_maximize ();
		}

		static extern bool gtk_window_mnemonic_activate (uint keyval, ModifierType modifier);

		public bool MnemonicActivate (uint keyval, ModifierType modifier)
		{
			return gtk_window_mnemonic_activate (keyval, modifier);
		}

		static extern void gtk_window_move (int x, int y);

		public void Move (int x, int y)
		{
			gtk_window_move (x, y);
		}

		static extern bool gtk_window_parse_geometry (string geometry);

		public bool ParseGeometry (string geometry)
		{
			return gtk_window_parse_geometry (geometry);
		}

		static extern void gtk_window_present ();

		public void Present ()
		{
			gtk_window_present ();
		}

		static extern void gtk_window_present_with_time (uint timestamp);

		public void PresentWithTime (uint timestamp)
		{
			gtk_window_present_with_time (timestamp);
		}

		static extern bool gtk_window_propagate_key_event (EventKey event);

		public bool PropagateKeyEvent (EventKey event)
		{
			return gtk_window_propagate_key_event (event);
		}

		static extern void gtk_window_remove_accel_group (AccelGroup accel_group);

		public void RemoveAccelGroup (AccelGroup accel_group)
		{
			gtk_window_remove_accel_group (accel_group);
		}

		static extern void gtk_window_remove_embedded_xid (uint xid);

		public void RemoveEmbeddedXid (uint xid)
		{
			gtk_window_remove_embedded_xid (xid);
		}

		static extern void gtk_window_remove_mnemonic (uint keyval, Widget target);

		public void RemoveMnemonic (uint keyval, Widget target)
		{
			gtk_window_remove_mnemonic (keyval, target);
		}

		static extern void gtk_window_reshow_with_initial_size ();

		public void ReshowWithInitialSize ()
		{
			gtk_window_reshow_with_initial_size ();
		}

		static extern void gtk_window_resize (int width, int height);

		public void Resize (int width, int height)
		{
			gtk_window_resize (width, height);
		}

		static extern void gtk_window_set_accept_focus (bool setting);

		public void SetAcceptFocus (bool setting)
		{
			gtk_window_set_accept_focus (setting);
		}

		static extern void gtk_window_set_decorated (bool setting);

		public void SetDecorated (bool setting)
		{
			gtk_window_set_decorated (setting);
		}

		static extern void gtk_window_set_default (Widget default_widget);

		public void SetDefault (Widget default_widget)
		{
			gtk_window_set_default (default_widget);
		}

		static extern void gtk_window_set_default_size (int width, int height);

		public void SetDefaultSize (int width, int height)
		{
			gtk_window_set_default_size (width, height);
		}

		static extern void gtk_window_set_deletable (bool setting);

		public void SetDeletable (bool setting)
		{
			gtk_window_set_deletable (setting);
		}

		static extern void gtk_window_set_destroy_with_parent (bool setting);

		public void SetDestroyWithParent (bool setting)
		{
			gtk_window_set_destroy_with_parent (setting);
		}

		static extern void gtk_window_set_focus (Widget focus);

		public void SetFocus (Widget focus)
		{
			gtk_window_set_focus (focus);
		}

		static extern void gtk_window_set_focus_on_map (bool setting);

		public void SetFocusOnMap (bool setting)
		{
			gtk_window_set_focus_on_map (setting);
		}

		static extern void gtk_window_set_frame_dimensions (int left, int top, int right, int bottom);

		[Obsolete (""This function will be removed in GTK+ 3"")]
		public void SetFrameDimensions (int left, int top, int right, int bottom)
		{
			gtk_window_set_frame_dimensions (left, top, right, bottom);
		}

		static extern void gtk_window_set_geometry_hints (Widget geometry_widget, Geometry geometry, WindowHints geom_mask);

		public void SetGeometryHints (Widget geometry_widget, Geometry geometry, WindowHints geom_mask)
		{
			gtk_window_set_geometry_hints (geometry_widget, geometry, geom_mask);
		}

		static extern void gtk_window_set_gravity (Gravity gravity);

		public void SetGravity (Gravity gravity)
		{
			gtk_window_set_gravity (gravity);
		}

		static extern void gtk_window_set_has_frame (bool setting);

		[Obsolete (""This function will be removed in GTK+ 3"")]
		public void SetHasFrame (bool setting)
		{
			gtk_window_set_has_frame (setting);
		}

		static extern void gtk_window_set_icon (Pixbuf icon);

		public void SetIcon (Pixbuf icon)
		{
			gtk_window_set_icon (icon);
		}

		static extern bool gtk_window_set_icon_from_file (string filename);

		public bool SetIconFromFile (string filename)
		{
			return gtk_window_set_icon_from_file (filename);
		}

		static extern void gtk_window_set_icon_list (List list);

		public void SetIconList (List list)
		{
			gtk_window_set_icon_list (list);
		}

		static extern void gtk_window_set_icon_name (string name);

		public void SetIconName (string name)
		{
			gtk_window_set_icon_name (name);
		}

		static extern void gtk_window_set_keep_above (bool setting);

		public void SetKeepAbove (bool setting)
		{
			gtk_window_set_keep_above (setting);
		}

		static extern void gtk_window_set_keep_below (bool setting);

		public void SetKeepBelow (bool setting)
		{
			gtk_window_set_keep_below (setting);
		}

		static extern void gtk_window_set_mnemonic_modifier (ModifierType modifier);

		public void SetMnemonicModifier (ModifierType modifier)
		{
			gtk_window_set_mnemonic_modifier (modifier);
		}

		static extern void gtk_window_set_mnemonics_visible (bool setting);

		public void SetMnemonicsVisible (bool setting)
		{
			gtk_window_set_mnemonics_visible (setting);
		}

		static extern void gtk_window_set_modal (bool modal);

		public void SetModal (bool modal)
		{
			gtk_window_set_modal (modal);
		}

		static extern void gtk_window_set_opacity (double opacity);

		public void SetOpacity (double opacity)
		{
			gtk_window_set_opacity (opacity);
		}

		static extern void gtk_window_set_policy (int allow_shrink, int allow_grow, int auto_shrink);

		public void SetPolicy (int allow_shrink, int allow_grow, int auto_shrink)
		{
			gtk_window_set_policy (allow_shrink, allow_grow, auto_shrink);
		}

		static extern void gtk_window_set_position (WindowPosition position);

		public void SetPosition (WindowPosition position)
		{
			gtk_window_set_position (position);
		}

		static extern void gtk_window_set_resizable (bool resizable);

		public void SetResizable (bool resizable)
		{
			gtk_window_set_resizable (resizable);
		}

		static extern void gtk_window_set_role (string role);

		public void SetRole (string role)
		{
			gtk_window_set_role (role);
		}

		static extern void gtk_window_set_screen (Screen screen);

		public void SetScreen (Screen screen)
		{
			gtk_window_set_screen (screen);
		}

		static extern void gtk_window_set_skip_pager_hint (bool setting);

		public void SetSkipPagerHint (bool setting)
		{
			gtk_window_set_skip_pager_hint (setting);
		}

		static extern void gtk_window_set_skip_taskbar_hint (bool setting);

		public void SetSkipTaskbarHint (bool setting)
		{
			gtk_window_set_skip_taskbar_hint (setting);
		}

		static extern void gtk_window_set_startup_id (string startup_id);

		public void SetStartupId (string startup_id)
		{
			gtk_window_set_startup_id (startup_id);
		}

		static extern void gtk_window_set_title (string title);

		public void SetTitle (string title)
		{
			gtk_window_set_title (title);
		}

		static extern void gtk_window_set_transient_for (Window parent);

		public void SetTransientFor (Window parent)
		{
			gtk_window_set_transient_for (parent);
		}

		static extern void gtk_window_set_type_hint (WindowTypeHint hint);

		public void SetTypeHint (WindowTypeHint hint)
		{
			gtk_window_set_type_hint (hint);
		}

		static extern void gtk_window_set_urgency_hint (bool setting);

		public void SetUrgencyHint (bool setting)
		{
			gtk_window_set_urgency_hint (setting);
		}

		static extern void gtk_window_set_wmclass (string wmclass_name, string wmclass_class);

		public void SetWmclass (string wmclass_name, string wmclass_class)
		{
			gtk_window_set_wmclass (wmclass_name, wmclass_class);
		}

		static extern void gtk_window_stick ();

		public void Stick ()
		{
			gtk_window_stick ();
		}

		static extern void gtk_window_unfullscreen ();

		public void Unfullscreen ()
		{
			gtk_window_unfullscreen ();
		}

		static extern void gtk_window_unmaximize ();

		public void Unmaximize ()
		{
			gtk_window_unmaximize ();
		}

		static extern void gtk_window_unstick ();

		public void Unstick ()
		{
			gtk_window_unstick ();
		}

		static extern List gtk_window_get_default_icon_list ();

		public static List GetDefaultIconList ()
		{
			return gtk_window_get_default_icon_list ();
		}

		static extern string gtk_window_get_default_icon_name ();

		public static string GetDefaultIconName ()
		{
			return gtk_window_get_default_icon_name ();
		}

		static extern List gtk_window_list_toplevels ();

		public static List ListToplevels ()
		{
			return gtk_window_list_toplevels ();
		}

		static extern void gtk_window_set_auto_startup_notification (bool setting);

		public static void SetAutoStartupNotification (bool setting)
		{
			gtk_window_set_auto_startup_notification (setting);
		}

		static extern void gtk_window_set_default_icon (Pixbuf icon);

		public void SetDefaultIcon ()
		{
			gtk_window_set_default_icon ();
		}

		static extern bool gtk_window_set_default_icon_from_file (string filename);

		public static bool SetDefaultIconFromFile (string filename)
		{
			return gtk_window_set_default_icon_from_file (filename);
		}

		static extern void gtk_window_set_default_icon_list (List list);

		public static void SetDefaultIconList (List list)
		{
			gtk_window_set_default_icon_list (list);
		}

		static extern void gtk_window_set_default_icon_name (string name);

		public static void SetDefaultIconName (string name)
		{
			gtk_window_set_default_icon_name (name);
		}

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
