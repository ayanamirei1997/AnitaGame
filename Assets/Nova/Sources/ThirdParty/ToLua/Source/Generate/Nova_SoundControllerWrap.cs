﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class Nova_SoundControllerWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(Nova.SoundController), typeof(UnityEngine.MonoBehaviour));
		L.RegFunction("PlayClipAtPoint", PlayClipAtPoint);
		L.RegFunction("PlayClipNo3D", PlayClipNo3D);
		L.RegFunction("__eq", op_Equality);
		L.RegFunction("__tostring", ToLua.op_ToString);
		L.RegVar("luaName", get_luaName, set_luaName);
		L.RegVar("audioFolder", get_audioFolder, set_audioFolder);
		L.RegVar("configVolume", get_configVolume, set_configVolume);
		L.RegVar("suppressSound", get_suppressSound, set_suppressSound);
		L.RegVar("Current", get_Current, null);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int PlayClipAtPoint(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 4 && TypeChecker.CheckTypes<UnityEngine.AudioClip, UnityEngine.Vector3, float>(L, 2))
			{
				Nova.SoundController obj = (Nova.SoundController)ToLua.CheckObject<Nova.SoundController>(L, 1);
				UnityEngine.AudioClip arg0 = (UnityEngine.AudioClip)ToLua.ToObject(L, 2);
				UnityEngine.Vector3 arg1 = ToLua.ToVector3(L, 3);
				float arg2 = (float)LuaDLL.lua_tonumber(L, 4);
				obj.PlayClipAtPoint(arg0, arg1, arg2);
				return 0;
			}
			else if (count == 4 && TypeChecker.CheckTypes<string, UnityEngine.Vector3, float>(L, 2))
			{
				Nova.SoundController obj = (Nova.SoundController)ToLua.CheckObject<Nova.SoundController>(L, 1);
				string arg0 = ToLua.ToString(L, 2);
				UnityEngine.Vector3 arg1 = ToLua.ToVector3(L, 3);
				float arg2 = (float)LuaDLL.lua_tonumber(L, 4);
				obj.PlayClipAtPoint(arg0, arg1, arg2);
				return 0;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: Nova.SoundController.PlayClipAtPoint");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int PlayClipNo3D(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 4 && TypeChecker.CheckTypes<UnityEngine.AudioClip, UnityEngine.Vector3, float>(L, 2))
			{
				Nova.SoundController obj = (Nova.SoundController)ToLua.CheckObject<Nova.SoundController>(L, 1);
				UnityEngine.AudioClip arg0 = (UnityEngine.AudioClip)ToLua.ToObject(L, 2);
				UnityEngine.Vector3 arg1 = ToLua.ToVector3(L, 3);
				float arg2 = (float)LuaDLL.lua_tonumber(L, 4);
				obj.PlayClipNo3D(arg0, arg1, arg2);
				return 0;
			}
			else if (count == 4 && TypeChecker.CheckTypes<string, UnityEngine.Vector3, float>(L, 2))
			{
				Nova.SoundController obj = (Nova.SoundController)ToLua.CheckObject<Nova.SoundController>(L, 1);
				string arg0 = ToLua.ToString(L, 2);
				UnityEngine.Vector3 arg1 = ToLua.ToVector3(L, 3);
				float arg2 = (float)LuaDLL.lua_tonumber(L, 4);
				obj.PlayClipNo3D(arg0, arg1, arg2);
				return 0;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: Nova.SoundController.PlayClipNo3D");
			}
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
	static int get_luaName(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Nova.SoundController obj = (Nova.SoundController)o;
			string ret = obj.luaName;
			LuaDLL.lua_pushstring(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index luaName on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_audioFolder(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Nova.SoundController obj = (Nova.SoundController)o;
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
	static int get_configVolume(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Nova.SoundController obj = (Nova.SoundController)o;
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
	static int get_suppressSound(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Nova.SoundController obj = (Nova.SoundController)o;
			bool ret = obj.suppressSound;
			LuaDLL.lua_pushboolean(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index suppressSound on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Current(IntPtr L)
	{
		try
		{
			ToLua.Push(L, Nova.SoundController.Current);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_luaName(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Nova.SoundController obj = (Nova.SoundController)o;
			string arg0 = ToLua.CheckString(L, 2);
			obj.luaName = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index luaName on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_audioFolder(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Nova.SoundController obj = (Nova.SoundController)o;
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
	static int set_configVolume(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Nova.SoundController obj = (Nova.SoundController)o;
			float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);
			obj.configVolume = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index configVolume on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_suppressSound(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Nova.SoundController obj = (Nova.SoundController)o;
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			obj.suppressSound = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index suppressSound on a nil value");
		}
	}
}

