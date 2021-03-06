//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class Anita_AudioControllerWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(Anita.AudioController), typeof(UnityEngine.MonoBehaviour));
		L.RegFunction("Play", Play);
		L.RegFunction("Stop", Stop);
		L.RegFunction("Pause", Pause);
		L.RegFunction("UnPause", UnPause);
		L.RegFunction("Preload", Preload);
		L.RegFunction("Unpreload", Unpreload);
		L.RegFunction("GetRestoreData", GetRestoreData);
		L.RegFunction("Restore", Restore);
		L.RegFunction("__eq", op_Equality);
		L.RegFunction("__tostring", ToLua.op_ToString);
		L.RegVar("slider", get_slider, set_slider);
		L.RegVar("text", get_text, set_text);
		L.RegVar("luaGlobalName", get_luaGlobalName, set_luaGlobalName);
		L.RegVar("audioFolder", get_audioFolder, set_audioFolder);
		L.RegVar("musicEntryList", get_musicEntryList, set_musicEntryList);
		L.RegVar("currentAudioName", get_currentAudioName, null);
		L.RegVar("isPlaying", get_isPlaying, null);
		L.RegVar("scriptVolume", get_scriptVolume, set_scriptVolume);
		L.RegVar("configVolume", get_configVolume, set_configVolume);
		L.RegVar("restorableObjectName", get_restorableObjectName, null);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Play(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Anita.AudioController obj = (Anita.AudioController)ToLua.CheckObject<Anita.AudioController>(L, 1);
			string arg0 = ToLua.CheckString(L, 2);
			obj.Play(arg0);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Stop(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Anita.AudioController obj = (Anita.AudioController)ToLua.CheckObject<Anita.AudioController>(L, 1);
			obj.Stop();
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Pause(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Anita.AudioController obj = (Anita.AudioController)ToLua.CheckObject<Anita.AudioController>(L, 1);
			obj.Pause();
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int UnPause(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Anita.AudioController obj = (Anita.AudioController)ToLua.CheckObject<Anita.AudioController>(L, 1);
			obj.UnPause();
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Preload(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Anita.AudioController obj = (Anita.AudioController)ToLua.CheckObject<Anita.AudioController>(L, 1);
			string arg0 = ToLua.CheckString(L, 2);
			obj.Preload(arg0);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Unpreload(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Anita.AudioController obj = (Anita.AudioController)ToLua.CheckObject<Anita.AudioController>(L, 1);
			string arg0 = ToLua.CheckString(L, 2);
			obj.Unpreload(arg0);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetRestoreData(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Anita.AudioController obj = (Anita.AudioController)ToLua.CheckObject<Anita.AudioController>(L, 1);
			Anita.IRestoreData o = obj.GetRestoreData();
			ToLua.PushObject(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Restore(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Anita.AudioController obj = (Anita.AudioController)ToLua.CheckObject<Anita.AudioController>(L, 1);
			Anita.IRestoreData arg0 = (Anita.IRestoreData)ToLua.CheckObject<Anita.IRestoreData>(L, 2);
			obj.Restore(arg0);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int op_Equality(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.Object arg0 = (UnityEngine.Object)ToLua.ToObject(L, 1);
			UnityEngine.Object arg1 = (UnityEngine.Object)ToLua.ToObject(L, 2);
			bool o = arg0 == arg1;
			LuaDLL.lua_pushboolean(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_slider(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Anita.AudioController obj = (Anita.AudioController)o;
			UnityEngine.UI.Slider ret = obj.slider;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index slider on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_text(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Anita.AudioController obj = (Anita.AudioController)o;
			UnityEngine.UI.Text ret = obj.text;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index text on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_luaGlobalName(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Anita.AudioController obj = (Anita.AudioController)o;
			string ret = obj.luaGlobalName;
			LuaDLL.lua_pushstring(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index luaGlobalName on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_audioFolder(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Anita.AudioController obj = (Anita.AudioController)o;
			string ret = obj.audioFolder;
			LuaDLL.lua_pushstring(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index audioFolder on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_musicEntryList(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Anita.AudioController obj = (Anita.AudioController)o;
			Anita.MusicEntryList ret = obj.musicEntryList;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index musicEntryList on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_currentAudioName(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Anita.AudioController obj = (Anita.AudioController)o;
			string ret = obj.currentAudioName;
			LuaDLL.lua_pushstring(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index currentAudioName on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isPlaying(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Anita.AudioController obj = (Anita.AudioController)o;
			bool ret = obj.isPlaying;
			LuaDLL.lua_pushboolean(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index isPlaying on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_scriptVolume(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Anita.AudioController obj = (Anita.AudioController)o;
			float ret = obj.scriptVolume;
			LuaDLL.lua_pushnumber(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index scriptVolume on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_configVolume(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Anita.AudioController obj = (Anita.AudioController)o;
			float ret = obj.configVolume;
			LuaDLL.lua_pushnumber(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index configVolume on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_restorableObjectName(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Anita.AudioController obj = (Anita.AudioController)o;
			string ret = obj.restorableObjectName;
			LuaDLL.lua_pushstring(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index restorableObjectName on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_slider(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Anita.AudioController obj = (Anita.AudioController)o;
			UnityEngine.UI.Slider arg0 = (UnityEngine.UI.Slider)ToLua.CheckObject<UnityEngine.UI.Slider>(L, 2);
			obj.slider = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index slider on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_text(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Anita.AudioController obj = (Anita.AudioController)o;
			UnityEngine.UI.Text arg0 = (UnityEngine.UI.Text)ToLua.CheckObject<UnityEngine.UI.Text>(L, 2);
			obj.text = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index text on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_luaGlobalName(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Anita.AudioController obj = (Anita.AudioController)o;
			string arg0 = ToLua.CheckString(L, 2);
			obj.luaGlobalName = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index luaGlobalName on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_audioFolder(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Anita.AudioController obj = (Anita.AudioController)o;
			string arg0 = ToLua.CheckString(L, 2);
			obj.audioFolder = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index audioFolder on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_musicEntryList(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Anita.AudioController obj = (Anita.AudioController)o;
			Anita.MusicEntryList arg0 = (Anita.MusicEntryList)ToLua.CheckObject<Anita.MusicEntryList>(L, 2);
			obj.musicEntryList = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index musicEntryList on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_scriptVolume(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Anita.AudioController obj = (Anita.AudioController)o;
			float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);
			obj.scriptVolume = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index scriptVolume on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_configVolume(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Anita.AudioController obj = (Anita.AudioController)o;
			float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);
			obj.configVolume = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index configVolume on a nil value");
		}
	}
}

