﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class Nova_CharacterControllerWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(Nova.CharacterController), typeof(Nova.CompositeSpriteControllerBase));
		L.RegFunction("Say", Say);
		L.RegFunction("StopVoice", StopVoice);
		L.RegFunction("GetRestoreData", GetRestoreData);
		L.RegFunction("Restore", Restore);
		L.RegFunction("ReplayVoice", ReplayVoice);
		L.RegFunction("StopVoiceAll", StopVoiceAll);
		L.RegFunction("__eq", op_Equality);
		L.RegFunction("__tostring", ToLua.op_ToString);
		L.RegVar("luaGlobalName", get_luaGlobalName, set_luaGlobalName);
		L.RegVar("voiceFolder", get_voiceFolder, set_voiceFolder);
		L.RegVar("stopVoiceWhenDialogueWillChange", get_stopVoiceWhenDialogueWillChange, set_stopVoiceWhenDialogueWillChange);
		L.RegVar("suppressSound", get_suppressSound, set_suppressSound);
		L.RegVar("layer", get_layer, set_layer);
		L.RegVar("color", get_color, set_color);
		L.RegVar("environmentColor", get_environmentColor, set_environmentColor);
		L.RegVar("restorableObjectName", get_restorableObjectName, null);
		L.RegVar("MaxVoiceDurationOfNextDialogue", get_MaxVoiceDurationOfNextDialogue, null);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Say(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 3);
			Nova.CharacterController obj = (Nova.CharacterController)ToLua.CheckObject<Nova.CharacterController>(L, 1);
			string arg0 = ToLua.CheckString(L, 2);
			float arg1 = (float)LuaDLL.luaL_checknumber(L, 3);
			obj.Say(arg0, arg1);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int StopVoice(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Nova.CharacterController obj = (Nova.CharacterController)ToLua.CheckObject<Nova.CharacterController>(L, 1);
			obj.StopVoice();
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
			Nova.CharacterController obj = (Nova.CharacterController)ToLua.CheckObject<Nova.CharacterController>(L, 1);
			Nova.IRestoreData o = obj.GetRestoreData();
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
			Nova.CharacterController obj = (Nova.CharacterController)ToLua.CheckObject<Nova.CharacterController>(L, 1);
			Nova.IRestoreData arg0 = (Nova.IRestoreData)ToLua.CheckObject<Nova.IRestoreData>(L, 2);
			obj.Restore(arg0);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ReplayVoice(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 1)
			{
				System.Collections.Generic.IReadOnlyDictionary<string,Nova.VoiceEntry> arg0 = (System.Collections.Generic.IReadOnlyDictionary<string,Nova.VoiceEntry>)ToLua.CheckObject<System.Collections.Generic.IReadOnlyDictionary<string,Nova.VoiceEntry>>(L, 1);
				Nova.CharacterController.ReplayVoice(arg0);
				return 0;
			}
			else if (count == 2)
			{
				System.Collections.Generic.IReadOnlyDictionary<string,Nova.VoiceEntry> arg0 = (System.Collections.Generic.IReadOnlyDictionary<string,Nova.VoiceEntry>)ToLua.CheckObject<System.Collections.Generic.IReadOnlyDictionary<string,Nova.VoiceEntry>>(L, 1);
				bool arg1 = LuaDLL.luaL_checkboolean(L, 2);
				Nova.CharacterController.ReplayVoice(arg0, arg1);
				return 0;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: Nova.CharacterController.ReplayVoice");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int StopVoiceAll(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 0);
			Nova.CharacterController.StopVoiceAll();
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
	static int get_luaGlobalName(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Nova.CharacterController obj = (Nova.CharacterController)o;
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
	static int get_voiceFolder(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Nova.CharacterController obj = (Nova.CharacterController)o;
			string ret = obj.voiceFolder;
			LuaDLL.lua_pushstring(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index voiceFolder on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_stopVoiceWhenDialogueWillChange(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Nova.CharacterController obj = (Nova.CharacterController)o;
			bool ret = obj.stopVoiceWhenDialogueWillChange;
			LuaDLL.lua_pushboolean(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index stopVoiceWhenDialogueWillChange on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_suppressSound(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Nova.CharacterController obj = (Nova.CharacterController)o;
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
	static int get_layer(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Nova.CharacterController obj = (Nova.CharacterController)o;
			int ret = obj.layer;
			LuaDLL.lua_pushinteger(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index layer on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_color(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Nova.CharacterController obj = (Nova.CharacterController)o;
			UnityEngine.Color ret = obj.color;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index color on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_environmentColor(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Nova.CharacterController obj = (Nova.CharacterController)o;
			UnityEngine.Color ret = obj.environmentColor;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index environmentColor on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_restorableObjectName(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Nova.CharacterController obj = (Nova.CharacterController)o;
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
	static int get_MaxVoiceDurationOfNextDialogue(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushnumber(L, Nova.CharacterController.MaxVoiceDurationOfNextDialogue);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_luaGlobalName(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Nova.CharacterController obj = (Nova.CharacterController)o;
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
	static int set_voiceFolder(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Nova.CharacterController obj = (Nova.CharacterController)o;
			string arg0 = ToLua.CheckString(L, 2);
			obj.voiceFolder = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index voiceFolder on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_stopVoiceWhenDialogueWillChange(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Nova.CharacterController obj = (Nova.CharacterController)o;
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			obj.stopVoiceWhenDialogueWillChange = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index stopVoiceWhenDialogueWillChange on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_suppressSound(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Nova.CharacterController obj = (Nova.CharacterController)o;
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			obj.suppressSound = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index suppressSound on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_layer(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Nova.CharacterController obj = (Nova.CharacterController)o;
			int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
			obj.layer = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index layer on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_color(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Nova.CharacterController obj = (Nova.CharacterController)o;
			UnityEngine.Color arg0 = ToLua.ToColor(L, 2);
			obj.color = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index color on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_environmentColor(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Nova.CharacterController obj = (Nova.CharacterController)o;
			UnityEngine.Color arg0 = ToLua.ToColor(L, 2);
			obj.environmentColor = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index environmentColor on a nil value");
		}
	}
}

