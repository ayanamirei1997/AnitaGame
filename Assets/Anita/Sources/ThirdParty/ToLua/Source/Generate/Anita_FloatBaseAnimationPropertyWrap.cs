//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class Anita_FloatBaseAnimationPropertyWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(Anita.FloatBaseAnimationProperty), typeof(Anita.LazyComputableAnimationProperty<float,float>));
		L.RegFunction("__tostring", ToLua.op_ToString);
		L.EndClass();
	}
}

