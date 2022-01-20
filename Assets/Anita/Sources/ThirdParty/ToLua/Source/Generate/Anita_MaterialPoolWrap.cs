﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class Anita_MaterialPoolWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(Anita.MaterialPool), typeof(UnityEngine.MonoBehaviour));
		L.RegFunction("Get", Get);
		L.RegFunction("GetRestorableMaterial", GetRestorableMaterial);
		L.RegFunction("Ensure", Ensure);
		L.RegFunction("__eq", op_Equality);
		L.RegFunction("__tostring", ToLua.op_ToString);
		L.RegVar("defaultMaterial", get_defaultMaterial, set_defaultMaterial);
		L.RegVar("factory", get_factory, null);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Get(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Anita.MaterialPool obj = (Anita.MaterialPool)ToLua.CheckObject<Anita.MaterialPool>(L, 1);
			string arg0 = ToLua.CheckString(L, 2);
			UnityEngine.Material o = obj.Get(arg0);
			ToLua.Push(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetRestorableMaterial(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Anita.MaterialPool obj = (Anita.MaterialPool)ToLua.CheckObject<Anita.MaterialPool>(L, 1);
			string arg0 = ToLua.CheckString(L, 2);
			Anita.RestorableMaterial o = obj.GetRestorableMaterial(arg0);
			ToLua.Push(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Ensure(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UnityEngine.GameObject arg0 = (UnityEngine.GameObject)ToLua.CheckObject(L, 1, typeof(UnityEngine.GameObject));
			Anita.MaterialPool o = Anita.MaterialPool.Ensure(arg0);
			ToLua.Push(L, o);
			return 1;
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
	static int get_defaultMaterial(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Anita.MaterialPool obj = (Anita.MaterialPool)o;
			UnityEngine.Material ret = obj.defaultMaterial;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index defaultMaterial on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_factory(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Anita.MaterialPool obj = (Anita.MaterialPool)o;
			Anita.MaterialFactory ret = obj.factory;
			ToLua.PushSealed(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index factory on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_defaultMaterial(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Anita.MaterialPool obj = (Anita.MaterialPool)o;
			UnityEngine.Material arg0 = (UnityEngine.Material)ToLua.CheckObject<UnityEngine.Material>(L, 2);
			obj.defaultMaterial = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index defaultMaterial on a nil value");
		}
	}
}
