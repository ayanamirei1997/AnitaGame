﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class Nova_ScriptLoaderWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(Nova.ScriptLoader), typeof(System.Object));
		L.RegFunction("Init", Init);
		L.RegFunction("ForceInit", ForceInit);
		L.RegFunction("GetFlowChartTree", GetFlowChartTree);
		L.RegFunction("RegisterNewNode", RegisterNewNode);
		L.RegFunction("BeginAddLocaleForNode", BeginAddLocaleForNode);
		L.RegFunction("RegisterJump", RegisterJump);
		L.RegFunction("RegisterBranch", RegisterBranch);
		L.RegFunction("EndRegisterBranch", EndRegisterBranch);
		L.RegFunction("SetCurrentAsStart", SetCurrentAsStart);
		L.RegFunction("SetCurrentAsUnlockedStart", SetCurrentAsUnlockedStart);
		L.RegFunction("SetCurrentAsDefaultStart", SetCurrentAsDefaultStart);
		L.RegFunction("SetCurrentAsEnd", SetCurrentAsEnd);
		L.RegFunction("New", _CreateNova_ScriptLoader);
		L.RegFunction("__tostring", ToLua.op_ToString);
		L.RegVar("stateLocale", get_stateLocale, set_stateLocale);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateNova_ScriptLoader(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 0)
			{
				Nova.ScriptLoader obj = new Nova.ScriptLoader();
				ToLua.PushObject(L, obj);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to ctor method: Nova.ScriptLoader.New");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Init(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Nova.ScriptLoader obj = (Nova.ScriptLoader)ToLua.CheckObject<Nova.ScriptLoader>(L, 1);
			string arg0 = ToLua.CheckString(L, 2);
			obj.Init(arg0);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ForceInit(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Nova.ScriptLoader obj = (Nova.ScriptLoader)ToLua.CheckObject<Nova.ScriptLoader>(L, 1);
			string arg0 = ToLua.CheckString(L, 2);
			obj.ForceInit(arg0);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetFlowChartTree(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Nova.ScriptLoader obj = (Nova.ScriptLoader)ToLua.CheckObject<Nova.ScriptLoader>(L, 1);
			Nova.FlowChartTree o = obj.GetFlowChartTree();
			ToLua.PushObject(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RegisterNewNode(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Nova.ScriptLoader obj = (Nova.ScriptLoader)ToLua.CheckObject<Nova.ScriptLoader>(L, 1);
			string arg0 = ToLua.CheckString(L, 2);
			obj.RegisterNewNode(arg0);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int BeginAddLocaleForNode(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Nova.ScriptLoader obj = (Nova.ScriptLoader)ToLua.CheckObject<Nova.ScriptLoader>(L, 1);
			string arg0 = ToLua.CheckString(L, 2);
			obj.BeginAddLocaleForNode(arg0);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RegisterJump(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Nova.ScriptLoader obj = (Nova.ScriptLoader)ToLua.CheckObject<Nova.ScriptLoader>(L, 1);
			string arg0 = ToLua.CheckString(L, 2);
			obj.RegisterJump(arg0);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RegisterBranch(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 7);
			Nova.ScriptLoader obj = (Nova.ScriptLoader)ToLua.CheckObject<Nova.ScriptLoader>(L, 1);
			string arg0 = ToLua.CheckString(L, 2);
			string arg1 = ToLua.CheckString(L, 3);
			string arg2 = ToLua.CheckString(L, 4);
			Nova.BranchImageInformation arg3 = (Nova.BranchImageInformation)ToLua.CheckObject<Nova.BranchImageInformation>(L, 5);
			Nova.BranchMode arg4 = (Nova.BranchMode)ToLua.CheckObject(L, 6, typeof(Nova.BranchMode));
			LuaFunction arg5 = ToLua.CheckLuaFunction(L, 7);
			obj.RegisterBranch(arg0, arg1, arg2, arg3, arg4, arg5);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int EndRegisterBranch(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Nova.ScriptLoader obj = (Nova.ScriptLoader)ToLua.CheckObject<Nova.ScriptLoader>(L, 1);
			obj.EndRegisterBranch();
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetCurrentAsStart(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Nova.ScriptLoader obj = (Nova.ScriptLoader)ToLua.CheckObject<Nova.ScriptLoader>(L, 1);
			string arg0 = ToLua.CheckString(L, 2);
			obj.SetCurrentAsStart(arg0);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetCurrentAsUnlockedStart(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Nova.ScriptLoader obj = (Nova.ScriptLoader)ToLua.CheckObject<Nova.ScriptLoader>(L, 1);
			string arg0 = ToLua.CheckString(L, 2);
			obj.SetCurrentAsUnlockedStart(arg0);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetCurrentAsDefaultStart(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Nova.ScriptLoader obj = (Nova.ScriptLoader)ToLua.CheckObject<Nova.ScriptLoader>(L, 1);
			string arg0 = ToLua.CheckString(L, 2);
			obj.SetCurrentAsDefaultStart(arg0);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetCurrentAsEnd(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Nova.ScriptLoader obj = (Nova.ScriptLoader)ToLua.CheckObject<Nova.ScriptLoader>(L, 1);
			string arg0 = ToLua.CheckString(L, 2);
			obj.SetCurrentAsEnd(arg0);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_stateLocale(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Nova.ScriptLoader obj = (Nova.ScriptLoader)o;
			UnityEngine.SystemLanguage ret = obj.stateLocale;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index stateLocale on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_stateLocale(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Nova.ScriptLoader obj = (Nova.ScriptLoader)o;
			UnityEngine.SystemLanguage arg0 = (UnityEngine.SystemLanguage)ToLua.CheckObject(L, 2, typeof(UnityEngine.SystemLanguage));
			obj.stateLocale = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index stateLocale on a nil value");
		}
	}
}

