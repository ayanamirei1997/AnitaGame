﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class Nova_VariablesWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(Nova.Variables), typeof(System.Object));
		L.RegFunction("Get", Get);
		L.RegFunction("Set", Set);
		L.RegFunction("CopyFrom", CopyFrom);
		L.RegFunction("Reset", Reset);
		L.RegFunction("ToString", ToString);
		L.RegFunction("New", _CreateNova_Variables);
		L.RegFunction("__tostring", ToLua.op_ToString);
		L.RegVar("hash", get_hash, null);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateNova_Variables(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 0)
			{
				Nova.Variables obj = new Nova.Variables();
				ToLua.PushObject(L, obj);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to ctor method: Nova.Variables.New");
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
			Nova.Variables obj = (Nova.Variables)ToLua.CheckObject<Nova.Variables>(L, 1);
			string arg0 = ToLua.CheckString(L, 2);
			Nova.VariableEntry o = obj.Get(arg0);
			ToLua.PushObject(L, o);
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
			Nova.Variables obj = (Nova.Variables)ToLua.CheckObject<Nova.Variables>(L, 1);
			string arg0 = ToLua.CheckString(L, 2);
			Nova.VariableType arg1 = (Nova.VariableType)ToLua.CheckObject(L, 3, typeof(Nova.VariableType));
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
	static int CopyFrom(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Nova.Variables obj = (Nova.Variables)ToLua.CheckObject<Nova.Variables>(L, 1);
			Nova.Variables arg0 = (Nova.Variables)ToLua.CheckObject<Nova.Variables>(L, 2);
			obj.CopyFrom(arg0);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Reset(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Nova.Variables obj = (Nova.Variables)ToLua.CheckObject<Nova.Variables>(L, 1);
			obj.Reset();
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ToString(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Nova.Variables obj = (Nova.Variables)ToLua.CheckObject<Nova.Variables>(L, 1);
			string o = obj.ToString();
			LuaDLL.lua_pushstring(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_hash(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Nova.Variables obj = (Nova.Variables)o;
			ulong ret = obj.hash;
			LuaDLL.tolua_pushuint64(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index hash on a nil value");
		}
	}
}

