﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class Anita_VolumeAnimationPropertyWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(Anita.VolumeAnimationProperty), typeof(Anita.FloatBaseAnimationProperty));
		L.RegFunction("New", _CreateAnita_VolumeAnimationProperty);
		L.RegFunction("__tostring", ToLua.op_ToString);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateAnita_VolumeAnimationProperty(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 2 && TypeChecker.CheckTypes<Anita.UnifiedAudioSource, float>(L, 1))
			{
				Anita.UnifiedAudioSource arg0 = (Anita.UnifiedAudioSource)ToLua.ToObject(L, 1);
				float arg1 = (float)LuaDLL.lua_tonumber(L, 2);
				Anita.VolumeAnimationProperty obj = new Anita.VolumeAnimationProperty(arg0, arg1);
				ToLua.PushObject(L, obj);
				return 1;
			}
			else if (count == 2 && TypeChecker.CheckTypes<Anita.AudioController, float>(L, 1))
			{
				Anita.AudioController arg0 = (Anita.AudioController)ToLua.ToObject(L, 1);
				float arg1 = (float)LuaDLL.lua_tonumber(L, 2);
				Anita.VolumeAnimationProperty obj = new Anita.VolumeAnimationProperty(arg0, arg1);
				ToLua.PushObject(L, obj);
				return 1;
			}
			else if (count == 3 && TypeChecker.CheckTypes<Anita.UnifiedAudioSource, float, float>(L, 1))
			{
				Anita.UnifiedAudioSource arg0 = (Anita.UnifiedAudioSource)ToLua.ToObject(L, 1);
				float arg1 = (float)LuaDLL.lua_tonumber(L, 2);
				float arg2 = (float)LuaDLL.lua_tonumber(L, 3);
				Anita.VolumeAnimationProperty obj = new Anita.VolumeAnimationProperty(arg0, arg1, arg2);
				ToLua.PushObject(L, obj);
				return 1;
			}
			else if (count == 3 && TypeChecker.CheckTypes<Anita.UnifiedAudioSource, float, Anita.UseRelativeValue>(L, 1))
			{
				Anita.UnifiedAudioSource arg0 = (Anita.UnifiedAudioSource)ToLua.ToObject(L, 1);
				float arg1 = (float)LuaDLL.lua_tonumber(L, 2);
				Anita.UseRelativeValue arg2 = (Anita.UseRelativeValue)ToLua.ToObject(L, 3);
				Anita.VolumeAnimationProperty obj = new Anita.VolumeAnimationProperty(arg0, arg1, arg2);
				ToLua.PushObject(L, obj);
				return 1;
			}
			else if (count == 3 && TypeChecker.CheckTypes<Anita.AudioController, float, float>(L, 1))
			{
				Anita.AudioController arg0 = (Anita.AudioController)ToLua.ToObject(L, 1);
				float arg1 = (float)LuaDLL.lua_tonumber(L, 2);
				float arg2 = (float)LuaDLL.lua_tonumber(L, 3);
				Anita.VolumeAnimationProperty obj = new Anita.VolumeAnimationProperty(arg0, arg1, arg2);
				ToLua.PushObject(L, obj);
				return 1;
			}
			else if (count == 3 && TypeChecker.CheckTypes<Anita.AudioController, float, Anita.UseRelativeValue>(L, 1))
			{
				Anita.AudioController arg0 = (Anita.AudioController)ToLua.ToObject(L, 1);
				float arg1 = (float)LuaDLL.lua_tonumber(L, 2);
				Anita.UseRelativeValue arg2 = (Anita.UseRelativeValue)ToLua.ToObject(L, 3);
				Anita.VolumeAnimationProperty obj = new Anita.VolumeAnimationProperty(arg0, arg1, arg2);
				ToLua.PushObject(L, obj);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to ctor method: Anita.VolumeAnimationProperty.New");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}
}
