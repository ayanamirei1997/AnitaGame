﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class Anita_I18nHelperWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(Anita.I18nHelper), typeof(System.Object));
		L.RegFunction("Get", Get);
		L.RegFunction("Set", Set);
		L.RegFunction("New", _CreateAnita_I18nHelper);
		L.RegFunction("__tostring", ToLua.op_ToString);
		L.RegVar("NodeNames", get_NodeNames, null);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateAnita_I18nHelper(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 0)
			{
				Anita.I18nHelper obj = new Anita.I18nHelper();
				ToLua.PushObject(L, obj);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to ctor method: Anita.I18nHelper.New");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Get(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Anita.I18nHelper obj = (Anita.I18nHelper)ToLua.CheckObject<Anita.I18nHelper>(L, 1);
			string arg0 = ToLua.CheckString(L, 2);
			string o = obj.Get(arg0);
			LuaDLL.lua_pushstring(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Set(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 4);
			Anita.I18nHelper obj = (Anita.I18nHelper)ToLua.CheckObject<Anita.I18nHelper>(L, 1);
			string arg0 = ToLua.CheckString(L, 2);
			UnityEngine.SystemLanguage arg1 = (UnityEngine.SystemLanguage)ToLua.CheckObject(L, 3, typeof(UnityEngine.SystemLanguage));
			string arg2 = ToLua.CheckString(L, 4);
			obj.Set(arg0, arg1, arg2);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_NodeNames(IntPtr L)
	{
		try
		{
			ToLua.PushObject(L, Anita.I18nHelper.NodeNames);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}
}

