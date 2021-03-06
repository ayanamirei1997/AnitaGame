//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class Anita_ColorAnimationPropertyWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(Anita.ColorAnimationProperty), typeof(Anita.LazyComputableAnimationProperty<UnityEngine.Color,UnityEngine.Color>));
		L.RegFunction("New", _CreateAnita_ColorAnimationProperty);
		L.RegFunction("__tostring", ToLua.op_ToString);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateAnita_ColorAnimationProperty(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 2 && TypeChecker.CheckTypes<Anita.CharacterColor, UnityEngine.Color>(L, 1))
			{
				Anita.CharacterColor arg0 = (Anita.CharacterColor)ToLua.ToObject(L, 1);
				UnityEngine.Color arg1 = ToLua.ToColor(L, 2);
				Anita.ColorAnimationProperty obj = new Anita.ColorAnimationProperty(arg0, arg1);
				ToLua.PushObject(L, obj);
				return 1;
			}
			else if (count == 2 && TypeChecker.CheckTypes<UnityEngine.SpriteRenderer, UnityEngine.Color>(L, 1))
			{
				UnityEngine.SpriteRenderer arg0 = (UnityEngine.SpriteRenderer)ToLua.ToObject(L, 1);
				UnityEngine.Color arg1 = ToLua.ToColor(L, 2);
				Anita.ColorAnimationProperty obj = new Anita.ColorAnimationProperty(arg0, arg1);
				ToLua.PushObject(L, obj);
				return 1;
			}
			else if (count == 2 && TypeChecker.CheckTypes<UnityEngine.UI.Image, UnityEngine.Color>(L, 1))
			{
				UnityEngine.UI.Image arg0 = (UnityEngine.UI.Image)ToLua.ToObject(L, 1);
				UnityEngine.Color arg1 = ToLua.ToColor(L, 2);
				Anita.ColorAnimationProperty obj = new Anita.ColorAnimationProperty(arg0, arg1);
				ToLua.PushObject(L, obj);
				return 1;
			}
			else if (count == 2 && TypeChecker.CheckTypes<Anita.DialogueBoxColor, UnityEngine.Color>(L, 1))
			{
				Anita.DialogueBoxColor arg0 = (Anita.DialogueBoxColor)ToLua.ToObject(L, 1);
				UnityEngine.Color arg1 = ToLua.ToColor(L, 2);
				Anita.ColorAnimationProperty obj = new Anita.ColorAnimationProperty(arg0, arg1);
				ToLua.PushObject(L, obj);
				return 1;
			}
			else if (count == 3 && TypeChecker.CheckTypes<Anita.CharacterColor, UnityEngine.Color, UnityEngine.Color>(L, 1))
			{
				Anita.CharacterColor arg0 = (Anita.CharacterColor)ToLua.ToObject(L, 1);
				UnityEngine.Color arg1 = ToLua.ToColor(L, 2);
				UnityEngine.Color arg2 = ToLua.ToColor(L, 3);
				Anita.ColorAnimationProperty obj = new Anita.ColorAnimationProperty(arg0, arg1, arg2);
				ToLua.PushObject(L, obj);
				return 1;
			}
			else if (count == 3 && TypeChecker.CheckTypes<UnityEngine.SpriteRenderer, UnityEngine.Color, UnityEngine.Color>(L, 1))
			{
				UnityEngine.SpriteRenderer arg0 = (UnityEngine.SpriteRenderer)ToLua.ToObject(L, 1);
				UnityEngine.Color arg1 = ToLua.ToColor(L, 2);
				UnityEngine.Color arg2 = ToLua.ToColor(L, 3);
				Anita.ColorAnimationProperty obj = new Anita.ColorAnimationProperty(arg0, arg1, arg2);
				ToLua.PushObject(L, obj);
				return 1;
			}
			else if (count == 3 && TypeChecker.CheckTypes<UnityEngine.UI.Image, UnityEngine.Color, UnityEngine.Color>(L, 1))
			{
				UnityEngine.UI.Image arg0 = (UnityEngine.UI.Image)ToLua.ToObject(L, 1);
				UnityEngine.Color arg1 = ToLua.ToColor(L, 2);
				UnityEngine.Color arg2 = ToLua.ToColor(L, 3);
				Anita.ColorAnimationProperty obj = new Anita.ColorAnimationProperty(arg0, arg1, arg2);
				ToLua.PushObject(L, obj);
				return 1;
			}
			else if (count == 3 && TypeChecker.CheckTypes<Anita.DialogueBoxColor, UnityEngine.Color, UnityEngine.Color>(L, 1))
			{
				Anita.DialogueBoxColor arg0 = (Anita.DialogueBoxColor)ToLua.ToObject(L, 1);
				UnityEngine.Color arg1 = ToLua.ToColor(L, 2);
				UnityEngine.Color arg2 = ToLua.ToColor(L, 3);
				Anita.ColorAnimationProperty obj = new Anita.ColorAnimationProperty(arg0, arg1, arg2);
				ToLua.PushObject(L, obj);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to ctor method: Anita.ColorAnimationProperty.New");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}
}

