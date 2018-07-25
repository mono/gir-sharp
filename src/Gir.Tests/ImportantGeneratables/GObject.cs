using System;
using NUnit.Framework;

namespace Gir.Tests
{
	[TestFixture]
	public class GObject : GenerationTestBase
	{
		[Test]
		public void GenerateGObject ()
		{
			var result = GenerateType (GObject, "Object", true);

			Assert.AreEqual (@"using System;
using System.Runtime.InteropServices;

namespace GObject
{
	public class Object
	{
		static extern Object g_object_new_valist (UIntPtr object_type, string first_property_name, ... var_args);

		public Object (UIntPtr object_type, string first_property_name, ... var_args) : base (object_type, first_property_name, var_args)
		{
		}

		static extern Object g_object_newv (UIntPtr object_type, uint n_parameters, Parameter parameters);

		public Object (UIntPtr object_type, uint n_parameters, Parameter[] parameters) : base (object_type, n_parameters, parameters)
		{
		}

		TypeInstance GTypeInstance;

		uint RefCount;

		Data Qdata;

		static extern void g_object_add_toggle_ref (Object object, ToggleNotify notify, IntPtr data);

		public void AddToggleRef (ToggleNotify notify, IntPtr data)
		{
			g_object_add_toggle_ref (notify, data);
		}

		static extern void g_object_add_weak_pointer (Object object, IntPtr weak_pointer_location);

		public void AddWeakPointer (IntPtr weak_pointer_location)
		{
			g_object_add_weak_pointer (weak_pointer_location);
		}

		static extern Binding g_object_bind_property (Object source, string source_property, Object target, string target_property, BindingFlags flags);

		public Binding BindProperty (string source_property, Object target, string target_property, BindingFlags flags)
		{
			return g_object_bind_property (source_property, target, target_property, flags);
		}

		static extern Binding g_object_bind_property_full (Object source, string source_property, Object target, string target_property, BindingFlags flags, BindingTransformFunc transform_to, BindingTransformFunc transform_from, IntPtr user_data, DestroyNotify notify);

		public Binding BindPropertyFull (string source_property, Object target, string target_property, BindingFlags flags, BindingTransformFunc transform_to, BindingTransformFunc transform_from, IntPtr user_data, DestroyNotify notify)
		{
			return g_object_bind_property_full (source_property, target, target_property, flags, transform_to, transform_from, user_data, notify);
		}

		static extern Binding g_object_bind_property_with_closures (Object source, string source_property, Object target, string target_property, BindingFlags flags, Closure transform_to, Closure transform_from);

		public Binding BindPropertyWithClosures (string source_property, Object target, string target_property, BindingFlags flags, Closure transform_to, Closure transform_from)
		{
			return g_object_bind_property_with_closures (source_property, target, target_property, flags, transform_to, transform_from);
		}

		static extern IntPtr g_object_dup_data (Object object, string key, DuplicateFunc dup_func, IntPtr user_data);

		public IntPtr DupData (string key, DuplicateFunc dup_func, IntPtr user_data)
		{
			return g_object_dup_data (key, dup_func, user_data);
		}

		static extern IntPtr g_object_dup_qdata (Object object, uint quark, DuplicateFunc dup_func, IntPtr user_data);

		public IntPtr DupQdata (uint quark, DuplicateFunc dup_func, IntPtr user_data)
		{
			return g_object_dup_qdata (quark, dup_func, user_data);
		}

		static extern void g_object_force_floating (Object object);

		public void ForceFloating ()
		{
			g_object_force_floating ();
		}

		static extern void g_object_freeze_notify (Object object);

		public void FreezeNotify ()
		{
			g_object_freeze_notify ();
		}

		static extern IntPtr g_object_get_data (Object object, string key);

		public IntPtr GetData (string key)
		{
			return g_object_get_data (key);
		}

		static extern void g_object_get_property (Object object, string property_name, Value value);

		public void GetProperty (string property_name, Value value)
		{
			g_object_get_property (property_name, value);
		}

		static extern IntPtr g_object_get_qdata (Object object, uint quark);

		public IntPtr GetQdata (uint quark)
		{
			return g_object_get_qdata (quark);
		}

		static extern void g_object_get_valist (Object object, string first_property_name, ... var_args);

		public void GetValist (string first_property_name, ... var_args)
		{
			g_object_get_valist (first_property_name, var_args);
		}

		static extern bool g_object_is_floating (Object object);

		public bool IsFloating ()
		{
			return g_object_is_floating ();
		}

		static extern void g_object_notify (Object object, string property_name);

		public void Notify (string property_name)
		{
			g_object_notify (property_name);
		}

		static extern void g_object_notify_by_pspec (Object object, ParamSpec pspec);

		public void NotifyByPspec (ParamSpec pspec)
		{
			g_object_notify_by_pspec (pspec);
		}

		static extern Object g_object_ref (Object object);

		public Object Ref ()
		{
			return g_object_ref ();
		}

		static extern Object g_object_ref_sink (Object object);

		public Object RefSink ()
		{
			return g_object_ref_sink ();
		}

		static extern void g_object_remove_toggle_ref (Object object, ToggleNotify notify, IntPtr data);

		public void RemoveToggleRef (ToggleNotify notify, IntPtr data)
		{
			g_object_remove_toggle_ref (notify, data);
		}

		static extern void g_object_remove_weak_pointer (Object object, IntPtr weak_pointer_location);

		public void RemoveWeakPointer (IntPtr weak_pointer_location)
		{
			g_object_remove_weak_pointer (weak_pointer_location);
		}

		static extern bool g_object_replace_data (Object object, string key, IntPtr oldval, IntPtr newval, DestroyNotify destroy, DestroyNotify old_destroy);

		public bool ReplaceData (string key, IntPtr oldval, IntPtr newval, DestroyNotify destroy, DestroyNotify old_destroy)
		{
			return g_object_replace_data (key, oldval, newval, destroy, old_destroy);
		}

		static extern bool g_object_replace_qdata (Object object, uint quark, IntPtr oldval, IntPtr newval, DestroyNotify destroy, DestroyNotify old_destroy);

		public bool ReplaceQdata (uint quark, IntPtr oldval, IntPtr newval, DestroyNotify destroy, DestroyNotify old_destroy)
		{
			return g_object_replace_qdata (quark, oldval, newval, destroy, old_destroy);
		}

		static extern void g_object_run_dispose (Object object);

		public void RunDispose ()
		{
			g_object_run_dispose ();
		}

		static extern void g_object_set_data (Object object, string key, IntPtr data);

		public void SetData (string key, IntPtr data)
		{
			g_object_set_data (key, data);
		}

		static extern void g_object_set_data_full (Object object, string key, IntPtr data, DestroyNotify destroy);

		public void SetDataFull (string key, IntPtr data, DestroyNotify destroy)
		{
			g_object_set_data_full (key, data, destroy);
		}

		static extern void g_object_set_property (Object object, string property_name, Value value);

		public void SetProperty (string property_name, Value value)
		{
			g_object_set_property (property_name, value);
		}

		static extern void g_object_set_qdata (Object object, uint quark, IntPtr data);

		public void SetQdata (uint quark, IntPtr data)
		{
			g_object_set_qdata (quark, data);
		}

		static extern void g_object_set_qdata_full (Object object, uint quark, IntPtr data, DestroyNotify destroy);

		public void SetQdataFull (uint quark, IntPtr data, DestroyNotify destroy)
		{
			g_object_set_qdata_full (quark, data, destroy);
		}

		static extern void g_object_set_valist (Object object, string first_property_name, ... var_args);

		public void SetValist (string first_property_name, ... var_args)
		{
			g_object_set_valist (first_property_name, var_args);
		}

		static extern IntPtr g_object_steal_data (Object object, string key);

		public IntPtr StealData (string key)
		{
			return g_object_steal_data (key);
		}

		static extern IntPtr g_object_steal_qdata (Object object, uint quark);

		public IntPtr StealQdata (uint quark)
		{
			return g_object_steal_qdata (quark);
		}

		static extern void g_object_thaw_notify (Object object);

		public void ThawNotify ()
		{
			g_object_thaw_notify ();
		}

		static extern void g_object_unref (Object object);

		public void Unref ()
		{
			g_object_unref ();
		}

		static extern void g_object_watch_closure (Object object, Closure closure);

		public void WatchClosure (Closure closure)
		{
			g_object_watch_closure (closure);
		}

		static extern void g_object_weak_ref (Object object, WeakNotify notify, IntPtr data);

		public void WeakRef (WeakNotify notify, IntPtr data)
		{
			g_object_weak_ref (notify, data);
		}

		static extern void g_object_weak_unref (Object object, WeakNotify notify, IntPtr data);

		public void WeakUnref (WeakNotify notify, IntPtr data)
		{
			g_object_weak_unref (notify, data);
		}

		static extern UIntPtr g_object_compat_control (UIntPtr what, IntPtr data);

		public static UIntPtr CompatControl (UIntPtr what, IntPtr data)
		{
			return g_object_compat_control (what, data);
		}

		static extern IntPtr g_object_connect (IntPtr object, string signal_spec, ... ...);

		public static IntPtr Connect (IntPtr object, string signal_spec, ... ...)
		{
			return g_object_connect (object, signal_spec, ...);
		}

		static extern void g_object_disconnect (IntPtr object, string signal_spec, ... ...);

		public static void Disconnect (IntPtr object, string signal_spec, ... ...)
		{
			g_object_disconnect (object, signal_spec, ...);
		}

		static extern void g_object_get (IntPtr object, string first_property_name, ... ...);

		public static void Get (IntPtr object, string first_property_name, ... ...)
		{
			g_object_get (object, first_property_name, ...);
		}

		static extern ParamSpec g_object_interface_find_property (IntPtr g_iface, string property_name);

		public static ParamSpec InterfaceFindProperty (IntPtr g_iface, string property_name)
		{
			return g_object_interface_find_property (g_iface, property_name);
		}

		static extern void g_object_interface_install_property (IntPtr g_iface, ParamSpec pspec);

		public static void InterfaceInstallProperty (IntPtr g_iface, ParamSpec pspec)
		{
			g_object_interface_install_property (g_iface, pspec);
		}

		static extern ParamSpec g_object_interface_list_properties (IntPtr g_iface, uint n_properties_p);

		public static ParamSpec InterfaceListProperties (IntPtr g_iface, uint n_properties_p)
		{
			return g_object_interface_list_properties (g_iface, n_properties_p);
		}

		static extern IntPtr g_object_new (UIntPtr object_type, string first_property_name, ... ...);

		public static IntPtr New (UIntPtr object_type, string first_property_name, ... ...)
		{
			return g_object_new (object_type, first_property_name, ...);
		}

		static extern void g_object_set (IntPtr object, string first_property_name, ... ...);

		public static void Set (IntPtr object, string first_property_name, ... ...)
		{
			g_object_set (object, first_property_name, ...);
		}

		event System.EventHandler Notify;
	}
}
", result);
		}

		[Test]
		public void GTypeStructsAreInternal ()
		{
			var result = GenerateType (GObject, "ObjectClass", true);

			Assert.AreEqual (@"using System;
using System.Runtime.InteropServices;

namespace GObject
{
	[StructLayout(LayoutKind.Sequential)]
	internal struct ObjectClass
	{
		TypeClass GTypeClass;

		SList ConstructProperties;

		constructor Constructor;

		set_property SetProperty;

		get_property GetProperty;

		dispose Dispose;

		finalize Finalize;

		dispatch_properties_changed DispatchPropertiesChanged;

		notify Notify;

		constructed Constructed;

		UIntPtr Flags;

		IntPtr Pdummy;

		static extern ParamSpec g_object_class_find_property (ObjectClass oclass, string property_name);

		public ParamSpec FindProperty (string property_name)
		{
			return g_object_class_find_property (property_name);
		}

		static extern void g_object_class_install_properties (ObjectClass oclass, uint n_pspecs, ParamSpec pspecs);

		public void InstallProperties (uint n_pspecs, ParamSpec[] pspecs)
		{
			g_object_class_install_properties (n_pspecs, pspecs);
		}

		static extern void g_object_class_install_property (ObjectClass oclass, uint property_id, ParamSpec pspec);

		public void InstallProperty (uint property_id, ParamSpec pspec)
		{
			g_object_class_install_property (property_id, pspec);
		}

		static extern ParamSpec g_object_class_list_properties (ObjectClass oclass, uint n_properties);

		public ParamSpec ListProperties (uint n_properties)
		{
			return g_object_class_list_properties (n_properties);
		}

		static extern void g_object_class_override_property (ObjectClass oclass, uint property_id, string name);

		public void OverrideProperty (uint property_id, string name)
		{
			g_object_class_override_property (property_id, name);
		}
	}
}
", result);
		}
	}
}
