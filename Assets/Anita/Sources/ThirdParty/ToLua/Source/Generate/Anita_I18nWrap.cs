﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class Anita_I18nWrap
{
	public static void Register(LuaState L)
	{
		L.BeginStaticLibs("I18n");
		L.RegFunction("__", __);
		L.RegVar("LocalePath", get_LocalePath, null);
		L.RegVar("SupportedLocales", get_SupportedLocales, null);
		L.RegVar("LocaleChanged", get_LocaleChanged, null);
		L.RegVar("DefaultLocale", get_DefaultLocale, null);
		L.RegVar("CurrentLocale", get_CurrentLocale, set_CurrentLocale);
		L.EndStaticLibs();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int __(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 1 && TypeChecker.CheckTypes<System.Collections.Generic.Dictionary<UnityEngine.SystemLanguage,string>>(L, 1))
			{
				System.Collections.Generic.Dictionary<UnityEngine.SystemLanguage,string> arg0 = (System.Collections.Generic.Dictionary<UnityEngine.SystemLanguage,string>)ToLua.ToObject(L, 1);
				string o = Anita.I18n.__(arg0);
				LuaDLL.lua_pushstring(L, o);
				return 1;
			}
			else if (TypeChecker.CheckTypes<UnityEngine.SystemLanguage, string>(L, 1) && TypeChecker.CheckParamsType<object>(L, 3, count - 2))
			{
				UnityEngine.SystemLanguage arg0 = (UnityEngine.SystemLanguage)ToLua.ToObject(L, 1);
				string arg1 = ToLua.ToString(L, 2);
				object[] arg2 = ToLua.ToParamsObject(L, 3, count - 2);
				string o = Anita.I18n.__(arg0, arg1, arg2);
				LuaDLL.lua_pushstring(L, o);
				return 1;
			}
			else if (TypeChecker.CheckTypes<string>(L, 1) && TypeChecker.CheckParamsType<object>(L, 2, count - 1))
			{
				string arg0 = ToLua.ToString(L, 1);
				object[] arg1 = ToLua.ToParamsObject(L, 2, count - 1);
				string o = Anita.I18n.__(arg0, arg1);
				LuaDLL.lua_pushstring(L, o);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: Anita.I18n.__");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_LocalePath(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushstring(L, Anita.I18n.LocalePath);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_SupportedLocales(IntPtr L)
	{
		try
		{
			ToLua.Push(L, Anita.I18n.SupportedLocales);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_LocaleChanged(IntPtr L)
	{
		try
		{
			ToLua.PushObject(L, Anita.I18n.LocaleChanged);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_DefaultLocale(IntPtr L)
	{
		try
		{
			ToLua.Push(L, Anita.I18n.DefaultLocale);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_CurrentLocale(IntPtr L)
	{
		try
		{
			ToLua.Push(L, Anita.I18n.CurrentLocale);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_CurrentLocale(IntPtr L)
	{
		try
		{
			UnityEngine.SystemLanguage arg0 = (UnityEngine.SystemLanguage)ToLua.CheckObject(L, 2, typeof(UnityEngine.SystemLanguage));
			Anita.I18n.CurrentLocale = arg0;
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}
}

