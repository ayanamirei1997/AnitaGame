﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class Anita_TimelineControllerWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(Anita.TimelineController), typeof(UnityEngine.MonoBehaviour));
		L.RegFunction("LoadTimelinePrefab", LoadTimelinePrefab);
		L.RegFunction("SetTimelinePrefab", SetTimelinePrefab);
		L.RegFunction("ClearTimelinePrefab", ClearTimelinePrefab);
		L.RegFunction("GetRestoreData", GetRestoreData);
		L.RegFunction("Restore", Restore);
		L.RegFunction("__eq", op_Equality);
		L.RegFunction("__tostring", ToLua.op_ToString);
		L.RegVar("luaName", get_luaName, set_luaName);
		L.RegVar("timelinePrefabFolder", get_timelinePrefabFolder, set_timelinePrefabFolder);
		L.RegVar("mainCamera", get_mainCamera, set_mainCamera);
		L.RegVar("cameraPP", get_cameraPP, set_cameraPP);
		L.RegVar("currentTimelinePrefabName", get_currentTimelinePrefabName, null);
		L.RegVar("playableDirector", get_playableDirector, null);
		L.RegVar("restorableObjectName", get_restorableObjectName, null);
		L.RegVar("priority", get_priority, null);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LoadTimelinePrefab(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Anita.TimelineController obj = (Anita.TimelineController)ToLua.CheckObject<Anita.TimelineController>(L, 1);
			string arg0 = ToLua.CheckString(L, 2);
			UnityEngine.GameObject o = obj.LoadTimelinePrefab(arg0);
			ToLua.PushSealed(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetTimelinePrefab(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Anita.TimelineController obj = (Anita.TimelineController)ToLua.CheckObject<Anita.TimelineController>(L, 1);
			string arg0 = ToLua.CheckString(L, 2);
			obj.SetTimelinePrefab(arg0);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ClearTimelinePrefab(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Anita.TimelineController obj = (Anita.TimelineController)ToLua.CheckObject<Anita.TimelineController>(L, 1);
			obj.ClearTimelinePrefab();
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
			Anita.TimelineController obj = (Anita.TimelineController)ToLua.CheckObject<Anita.TimelineController>(L, 1);
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
			Anita.TimelineController obj = (Anita.TimelineController)ToLua.CheckObject<Anita.TimelineController>(L, 1);
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
	static int get_luaName(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Anita.TimelineController obj = (Anita.TimelineController)o;
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
	static int get_timelinePrefabFolder(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Anita.TimelineController obj = (Anita.TimelineController)o;
			string ret = obj.timelinePrefabFolder;
			LuaDLL.lua_pushstring(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index timelinePrefabFolder on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_mainCamera(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Anita.TimelineController obj = (Anita.TimelineController)o;
			UnityEngine.Camera ret = obj.mainCamera;
			ToLua.PushSealed(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index mainCamera on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_cameraPP(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Anita.TimelineController obj = (Anita.TimelineController)o;
			Anita.PostProcessing ret = obj.cameraPP;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index cameraPP on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_currentTimelinePrefabName(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Anita.TimelineController obj = (Anita.TimelineController)o;
			string ret = obj.currentTimelinePrefabName;
			LuaDLL.lua_pushstring(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index currentTimelinePrefabName on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_playableDirector(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Anita.TimelineController obj = (Anita.TimelineController)o;
			UnityEngine.Playables.PlayableDirector ret = obj.playableDirector;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index playableDirector on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_restorableObjectName(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Anita.TimelineController obj = (Anita.TimelineController)o;
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
	static int get_priority(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Anita.TimelineController obj = (Anita.TimelineController)o;
			Anita.RestorablePriority ret = obj.priority;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index priority on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_luaName(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Anita.TimelineController obj = (Anita.TimelineController)o;
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
	static int set_timelinePrefabFolder(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Anita.TimelineController obj = (Anita.TimelineController)o;
			string arg0 = ToLua.CheckString(L, 2);
			obj.timelinePrefabFolder = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index timelinePrefabFolder on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_mainCamera(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Anita.TimelineController obj = (Anita.TimelineController)o;
			UnityEngine.Camera arg0 = (UnityEngine.Camera)ToLua.CheckObject(L, 2, typeof(UnityEngine.Camera));
			obj.mainCamera = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index mainCamera on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_cameraPP(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Anita.TimelineController obj = (Anita.TimelineController)o;
			Anita.PostProcessing arg0 = (Anita.PostProcessing)ToLua.CheckObject<Anita.PostProcessing>(L, 2);
			obj.cameraPP = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index cameraPP on a nil value");
		}
	}
}
