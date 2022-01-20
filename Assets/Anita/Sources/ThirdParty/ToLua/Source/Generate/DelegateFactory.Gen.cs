﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using System.Collections.Generic;
using LuaInterface;

public partial class DelegateFactory
{
	static partial void Register()
	{
		dict.Clear();
		dict.Add(typeof(System.Action), factory.System_Action);
		dict.Add(typeof(System.Action<int>), factory.System_Action_int);
		dict.Add(typeof(System.Comparison<int>), factory.System_Comparison_int);
		dict.Add(typeof(System.Func<int,int>), factory.System_Func_int_int);
		dict.Add(typeof(System.Predicate<int>), factory.System_Predicate_int);
		dict.Add(typeof(UnityEngine.Events.UnityAction), factory.UnityEngine_Events_UnityAction);
		dict.Add(typeof(System.Action<UnityEngine.Playables.PlayableDirector>), factory.System_Action_UnityEngine_Playables_PlayableDirector);
		dict.Add(typeof(UnityEngine.RectTransform.ReapplyDrivenProperties), factory.UnityEngine_RectTransform_ReapplyDrivenProperties);
		dict.Add(typeof(UnityEngine.Video.VideoPlayer.EventHandler), factory.UnityEngine_Video_VideoPlayer_EventHandler);
		dict.Add(typeof(UnityEngine.Video.VideoPlayer.ErrorEventHandler), factory.UnityEngine_Video_VideoPlayer_ErrorEventHandler);
		dict.Add(typeof(UnityEngine.Video.VideoPlayer.TimeEventHandler), factory.UnityEngine_Video_VideoPlayer_TimeEventHandler);
		dict.Add(typeof(UnityEngine.Video.VideoPlayer.FrameReadyEventHandler), factory.UnityEngine_Video_VideoPlayer_FrameReadyEventHandler);
		dict.Add(typeof(Anita.AnimationEntry.EasingFunction), factory.Anita_AnimationEntry_EasingFunction);

		DelegateTraits<System.Action>.Init(factory.System_Action);
		DelegateTraits<System.Action<int>>.Init(factory.System_Action_int);
		DelegateTraits<System.Comparison<int>>.Init(factory.System_Comparison_int);
		DelegateTraits<System.Func<int,int>>.Init(factory.System_Func_int_int);
		DelegateTraits<System.Predicate<int>>.Init(factory.System_Predicate_int);
		DelegateTraits<UnityEngine.Events.UnityAction>.Init(factory.UnityEngine_Events_UnityAction);
		DelegateTraits<System.Action<UnityEngine.Playables.PlayableDirector>>.Init(factory.System_Action_UnityEngine_Playables_PlayableDirector);
		DelegateTraits<UnityEngine.RectTransform.ReapplyDrivenProperties>.Init(factory.UnityEngine_RectTransform_ReapplyDrivenProperties);
		DelegateTraits<UnityEngine.Video.VideoPlayer.EventHandler>.Init(factory.UnityEngine_Video_VideoPlayer_EventHandler);
		DelegateTraits<UnityEngine.Video.VideoPlayer.ErrorEventHandler>.Init(factory.UnityEngine_Video_VideoPlayer_ErrorEventHandler);
		DelegateTraits<UnityEngine.Video.VideoPlayer.TimeEventHandler>.Init(factory.UnityEngine_Video_VideoPlayer_TimeEventHandler);
		DelegateTraits<UnityEngine.Video.VideoPlayer.FrameReadyEventHandler>.Init(factory.UnityEngine_Video_VideoPlayer_FrameReadyEventHandler);
		DelegateTraits<Anita.AnimationEntry.EasingFunction>.Init(factory.Anita_AnimationEntry_EasingFunction);

		TypeTraits<System.Action>.Init(factory.Check_System_Action);
		TypeTraits<System.Action<int>>.Init(factory.Check_System_Action_int);
		TypeTraits<System.Comparison<int>>.Init(factory.Check_System_Comparison_int);
		TypeTraits<System.Func<int,int>>.Init(factory.Check_System_Func_int_int);
		TypeTraits<System.Predicate<int>>.Init(factory.Check_System_Predicate_int);
		TypeTraits<UnityEngine.Events.UnityAction>.Init(factory.Check_UnityEngine_Events_UnityAction);
		TypeTraits<System.Action<UnityEngine.Playables.PlayableDirector>>.Init(factory.Check_System_Action_UnityEngine_Playables_PlayableDirector);
		TypeTraits<UnityEngine.RectTransform.ReapplyDrivenProperties>.Init(factory.Check_UnityEngine_RectTransform_ReapplyDrivenProperties);
		TypeTraits<UnityEngine.Video.VideoPlayer.EventHandler>.Init(factory.Check_UnityEngine_Video_VideoPlayer_EventHandler);
		TypeTraits<UnityEngine.Video.VideoPlayer.ErrorEventHandler>.Init(factory.Check_UnityEngine_Video_VideoPlayer_ErrorEventHandler);
		TypeTraits<UnityEngine.Video.VideoPlayer.TimeEventHandler>.Init(factory.Check_UnityEngine_Video_VideoPlayer_TimeEventHandler);
		TypeTraits<UnityEngine.Video.VideoPlayer.FrameReadyEventHandler>.Init(factory.Check_UnityEngine_Video_VideoPlayer_FrameReadyEventHandler);
		TypeTraits<Anita.AnimationEntry.EasingFunction>.Init(factory.Check_Anita_AnimationEntry_EasingFunction);

		StackTraits<System.Action>.Push = factory.Push_System_Action;
		StackTraits<System.Action<int>>.Push = factory.Push_System_Action_int;
		StackTraits<System.Comparison<int>>.Push = factory.Push_System_Comparison_int;
		StackTraits<System.Func<int,int>>.Push = factory.Push_System_Func_int_int;
		StackTraits<System.Predicate<int>>.Push = factory.Push_System_Predicate_int;
		StackTraits<UnityEngine.Events.UnityAction>.Push = factory.Push_UnityEngine_Events_UnityAction;
		StackTraits<System.Action<UnityEngine.Playables.PlayableDirector>>.Push = factory.Push_System_Action_UnityEngine_Playables_PlayableDirector;
		StackTraits<UnityEngine.RectTransform.ReapplyDrivenProperties>.Push = factory.Push_UnityEngine_RectTransform_ReapplyDrivenProperties;
		StackTraits<UnityEngine.Video.VideoPlayer.EventHandler>.Push = factory.Push_UnityEngine_Video_VideoPlayer_EventHandler;
		StackTraits<UnityEngine.Video.VideoPlayer.ErrorEventHandler>.Push = factory.Push_UnityEngine_Video_VideoPlayer_ErrorEventHandler;
		StackTraits<UnityEngine.Video.VideoPlayer.TimeEventHandler>.Push = factory.Push_UnityEngine_Video_VideoPlayer_TimeEventHandler;
		StackTraits<UnityEngine.Video.VideoPlayer.FrameReadyEventHandler>.Push = factory.Push_UnityEngine_Video_VideoPlayer_FrameReadyEventHandler;
		StackTraits<Anita.AnimationEntry.EasingFunction>.Push = factory.Push_Anita_AnimationEntry_EasingFunction;
	}
	class System_Action_Event : LuaDelegate
	{
		public System_Action_Event(LuaFunction func) : base(func) { }
		public System_Action_Event(LuaFunction func, LuaTable self) : base(func, self) { }

		public void Call()
		{
			func.Call();
		}

		public void CallWithSelf()
		{
			func.BeginPCall();
			func.Push(self);
			func.PCall();
			func.EndPCall();
		}
	}

	public System.Action System_Action(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			System.Action fn = delegate() { };
			return fn;
		}

		if(!flag)
		{
			System_Action_Event target = new System_Action_Event(func);
			System.Action d = target.Call;
			target.method = d.Method;
			return d;
		}
		else
		{
			System_Action_Event target = new System_Action_Event(func, self);
			System.Action d = target.CallWithSelf;
			target.method = d.Method;
			return d;
		}
	}

	bool Check_System_Action(IntPtr L, int pos)
	{
		return TypeChecker.CheckDelegateType(typeof(System.Action), L, pos);
	}

	void Push_System_Action(IntPtr L, System.Action o)
	{
		ToLua.Push(L, o);
	}

	class System_Action_int_Event : LuaDelegate
	{
		public System_Action_int_Event(LuaFunction func) : base(func) { }
		public System_Action_int_Event(LuaFunction func, LuaTable self) : base(func, self) { }

		public void Call(int param0)
		{
			func.BeginPCall();
			func.Push(param0);
			func.PCall();
			func.EndPCall();
		}

		public void CallWithSelf(int param0)
		{
			func.BeginPCall();
			func.Push(self);
			func.Push(param0);
			func.PCall();
			func.EndPCall();
		}
	}

	public System.Action<int> System_Action_int(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			System.Action<int> fn = delegate(int param0) { };
			return fn;
		}

		if(!flag)
		{
			System_Action_int_Event target = new System_Action_int_Event(func);
			System.Action<int> d = target.Call;
			target.method = d.Method;
			return d;
		}
		else
		{
			System_Action_int_Event target = new System_Action_int_Event(func, self);
			System.Action<int> d = target.CallWithSelf;
			target.method = d.Method;
			return d;
		}
	}

	bool Check_System_Action_int(IntPtr L, int pos)
	{
		return TypeChecker.CheckDelegateType(typeof(System.Action<int>), L, pos);
	}

	void Push_System_Action_int(IntPtr L, System.Action<int> o)
	{
		ToLua.Push(L, o);
	}

	class System_Comparison_int_Event : LuaDelegate
	{
		public System_Comparison_int_Event(LuaFunction func) : base(func) { }
		public System_Comparison_int_Event(LuaFunction func, LuaTable self) : base(func, self) { }

		public int Call(int param0, int param1)
		{
			func.BeginPCall();
			func.Push(param0);
			func.Push(param1);
			func.PCall();
			int ret = (int)func.CheckNumber();
			func.EndPCall();
			return ret;
		}

		public int CallWithSelf(int param0, int param1)
		{
			func.BeginPCall();
			func.Push(self);
			func.Push(param0);
			func.Push(param1);
			func.PCall();
			int ret = (int)func.CheckNumber();
			func.EndPCall();
			return ret;
		}
	}

	public System.Comparison<int> System_Comparison_int(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			System.Comparison<int> fn = delegate(int param0, int param1) { return 0; };
			return fn;
		}

		if(!flag)
		{
			System_Comparison_int_Event target = new System_Comparison_int_Event(func);
			System.Comparison<int> d = target.Call;
			target.method = d.Method;
			return d;
		}
		else
		{
			System_Comparison_int_Event target = new System_Comparison_int_Event(func, self);
			System.Comparison<int> d = target.CallWithSelf;
			target.method = d.Method;
			return d;
		}
	}

	bool Check_System_Comparison_int(IntPtr L, int pos)
	{
		return TypeChecker.CheckDelegateType(typeof(System.Comparison<int>), L, pos);
	}

	void Push_System_Comparison_int(IntPtr L, System.Comparison<int> o)
	{
		ToLua.Push(L, o);
	}

	class System_Func_int_int_Event : LuaDelegate
	{
		public System_Func_int_int_Event(LuaFunction func) : base(func) { }
		public System_Func_int_int_Event(LuaFunction func, LuaTable self) : base(func, self) { }

		public int Call(int param0)
		{
			func.BeginPCall();
			func.Push(param0);
			func.PCall();
			int ret = (int)func.CheckNumber();
			func.EndPCall();
			return ret;
		}

		public int CallWithSelf(int param0)
		{
			func.BeginPCall();
			func.Push(self);
			func.Push(param0);
			func.PCall();
			int ret = (int)func.CheckNumber();
			func.EndPCall();
			return ret;
		}
	}

	public System.Func<int,int> System_Func_int_int(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			System.Func<int,int> fn = delegate(int param0) { return 0; };
			return fn;
		}

		if(!flag)
		{
			System_Func_int_int_Event target = new System_Func_int_int_Event(func);
			System.Func<int,int> d = target.Call;
			target.method = d.Method;
			return d;
		}
		else
		{
			System_Func_int_int_Event target = new System_Func_int_int_Event(func, self);
			System.Func<int,int> d = target.CallWithSelf;
			target.method = d.Method;
			return d;
		}
	}

	bool Check_System_Func_int_int(IntPtr L, int pos)
	{
		return TypeChecker.CheckDelegateType(typeof(System.Func<int,int>), L, pos);
	}

	void Push_System_Func_int_int(IntPtr L, System.Func<int,int> o)
	{
		ToLua.Push(L, o);
	}

	class System_Predicate_int_Event : LuaDelegate
	{
		public System_Predicate_int_Event(LuaFunction func) : base(func) { }
		public System_Predicate_int_Event(LuaFunction func, LuaTable self) : base(func, self) { }

		public bool Call(int param0)
		{
			func.BeginPCall();
			func.Push(param0);
			func.PCall();
			bool ret = func.CheckBoolean();
			func.EndPCall();
			return ret;
		}

		public bool CallWithSelf(int param0)
		{
			func.BeginPCall();
			func.Push(self);
			func.Push(param0);
			func.PCall();
			bool ret = func.CheckBoolean();
			func.EndPCall();
			return ret;
		}
	}

	public System.Predicate<int> System_Predicate_int(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			System.Predicate<int> fn = delegate(int param0) { return false; };
			return fn;
		}

		if(!flag)
		{
			System_Predicate_int_Event target = new System_Predicate_int_Event(func);
			System.Predicate<int> d = target.Call;
			target.method = d.Method;
			return d;
		}
		else
		{
			System_Predicate_int_Event target = new System_Predicate_int_Event(func, self);
			System.Predicate<int> d = target.CallWithSelf;
			target.method = d.Method;
			return d;
		}
	}

	bool Check_System_Predicate_int(IntPtr L, int pos)
	{
		return TypeChecker.CheckDelegateType(typeof(System.Predicate<int>), L, pos);
	}

	void Push_System_Predicate_int(IntPtr L, System.Predicate<int> o)
	{
		ToLua.Push(L, o);
	}

	class UnityEngine_Events_UnityAction_Event : LuaDelegate
	{
		public UnityEngine_Events_UnityAction_Event(LuaFunction func) : base(func) { }
		public UnityEngine_Events_UnityAction_Event(LuaFunction func, LuaTable self) : base(func, self) { }

		public void Call()
		{
			func.Call();
		}

		public void CallWithSelf()
		{
			func.BeginPCall();
			func.Push(self);
			func.PCall();
			func.EndPCall();
		}
	}

	public UnityEngine.Events.UnityAction UnityEngine_Events_UnityAction(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			UnityEngine.Events.UnityAction fn = delegate() { };
			return fn;
		}

		if(!flag)
		{
			UnityEngine_Events_UnityAction_Event target = new UnityEngine_Events_UnityAction_Event(func);
			UnityEngine.Events.UnityAction d = target.Call;
			target.method = d.Method;
			return d;
		}
		else
		{
			UnityEngine_Events_UnityAction_Event target = new UnityEngine_Events_UnityAction_Event(func, self);
			UnityEngine.Events.UnityAction d = target.CallWithSelf;
			target.method = d.Method;
			return d;
		}
	}

	bool Check_UnityEngine_Events_UnityAction(IntPtr L, int pos)
	{
		return TypeChecker.CheckDelegateType(typeof(UnityEngine.Events.UnityAction), L, pos);
	}

	void Push_UnityEngine_Events_UnityAction(IntPtr L, UnityEngine.Events.UnityAction o)
	{
		ToLua.Push(L, o);
	}

	class System_Action_UnityEngine_Playables_PlayableDirector_Event : LuaDelegate
	{
		public System_Action_UnityEngine_Playables_PlayableDirector_Event(LuaFunction func) : base(func) { }
		public System_Action_UnityEngine_Playables_PlayableDirector_Event(LuaFunction func, LuaTable self) : base(func, self) { }

		public void Call(UnityEngine.Playables.PlayableDirector param0)
		{
			func.BeginPCall();
			func.Push(param0);
			func.PCall();
			func.EndPCall();
		}

		public void CallWithSelf(UnityEngine.Playables.PlayableDirector param0)
		{
			func.BeginPCall();
			func.Push(self);
			func.Push(param0);
			func.PCall();
			func.EndPCall();
		}
	}

	public System.Action<UnityEngine.Playables.PlayableDirector> System_Action_UnityEngine_Playables_PlayableDirector(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			System.Action<UnityEngine.Playables.PlayableDirector> fn = delegate(UnityEngine.Playables.PlayableDirector param0) { };
			return fn;
		}

		if(!flag)
		{
			System_Action_UnityEngine_Playables_PlayableDirector_Event target = new System_Action_UnityEngine_Playables_PlayableDirector_Event(func);
			System.Action<UnityEngine.Playables.PlayableDirector> d = target.Call;
			target.method = d.Method;
			return d;
		}
		else
		{
			System_Action_UnityEngine_Playables_PlayableDirector_Event target = new System_Action_UnityEngine_Playables_PlayableDirector_Event(func, self);
			System.Action<UnityEngine.Playables.PlayableDirector> d = target.CallWithSelf;
			target.method = d.Method;
			return d;
		}
	}

	bool Check_System_Action_UnityEngine_Playables_PlayableDirector(IntPtr L, int pos)
	{
		return TypeChecker.CheckDelegateType(typeof(System.Action<UnityEngine.Playables.PlayableDirector>), L, pos);
	}

	void Push_System_Action_UnityEngine_Playables_PlayableDirector(IntPtr L, System.Action<UnityEngine.Playables.PlayableDirector> o)
	{
		ToLua.Push(L, o);
	}

	class UnityEngine_RectTransform_ReapplyDrivenProperties_Event : LuaDelegate
	{
		public UnityEngine_RectTransform_ReapplyDrivenProperties_Event(LuaFunction func) : base(func) { }
		public UnityEngine_RectTransform_ReapplyDrivenProperties_Event(LuaFunction func, LuaTable self) : base(func, self) { }

		public void Call(UnityEngine.RectTransform param0)
		{
			func.BeginPCall();
			func.PushSealed(param0);
			func.PCall();
			func.EndPCall();
		}

		public void CallWithSelf(UnityEngine.RectTransform param0)
		{
			func.BeginPCall();
			func.Push(self);
			func.PushSealed(param0);
			func.PCall();
			func.EndPCall();
		}
	}

	public UnityEngine.RectTransform.ReapplyDrivenProperties UnityEngine_RectTransform_ReapplyDrivenProperties(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			UnityEngine.RectTransform.ReapplyDrivenProperties fn = delegate(UnityEngine.RectTransform param0) { };
			return fn;
		}

		if(!flag)
		{
			UnityEngine_RectTransform_ReapplyDrivenProperties_Event target = new UnityEngine_RectTransform_ReapplyDrivenProperties_Event(func);
			UnityEngine.RectTransform.ReapplyDrivenProperties d = target.Call;
			target.method = d.Method;
			return d;
		}
		else
		{
			UnityEngine_RectTransform_ReapplyDrivenProperties_Event target = new UnityEngine_RectTransform_ReapplyDrivenProperties_Event(func, self);
			UnityEngine.RectTransform.ReapplyDrivenProperties d = target.CallWithSelf;
			target.method = d.Method;
			return d;
		}
	}

	bool Check_UnityEngine_RectTransform_ReapplyDrivenProperties(IntPtr L, int pos)
	{
		return TypeChecker.CheckDelegateType(typeof(UnityEngine.RectTransform.ReapplyDrivenProperties), L, pos);
	}

	void Push_UnityEngine_RectTransform_ReapplyDrivenProperties(IntPtr L, UnityEngine.RectTransform.ReapplyDrivenProperties o)
	{
		ToLua.Push(L, o);
	}

	class UnityEngine_Video_VideoPlayer_EventHandler_Event : LuaDelegate
	{
		public UnityEngine_Video_VideoPlayer_EventHandler_Event(LuaFunction func) : base(func) { }
		public UnityEngine_Video_VideoPlayer_EventHandler_Event(LuaFunction func, LuaTable self) : base(func, self) { }

		public void Call(UnityEngine.Video.VideoPlayer param0)
		{
			func.BeginPCall();
			func.PushSealed(param0);
			func.PCall();
			func.EndPCall();
		}

		public void CallWithSelf(UnityEngine.Video.VideoPlayer param0)
		{
			func.BeginPCall();
			func.Push(self);
			func.PushSealed(param0);
			func.PCall();
			func.EndPCall();
		}
	}

	public UnityEngine.Video.VideoPlayer.EventHandler UnityEngine_Video_VideoPlayer_EventHandler(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			UnityEngine.Video.VideoPlayer.EventHandler fn = delegate(UnityEngine.Video.VideoPlayer param0) { };
			return fn;
		}

		if(!flag)
		{
			UnityEngine_Video_VideoPlayer_EventHandler_Event target = new UnityEngine_Video_VideoPlayer_EventHandler_Event(func);
			UnityEngine.Video.VideoPlayer.EventHandler d = target.Call;
			target.method = d.Method;
			return d;
		}
		else
		{
			UnityEngine_Video_VideoPlayer_EventHandler_Event target = new UnityEngine_Video_VideoPlayer_EventHandler_Event(func, self);
			UnityEngine.Video.VideoPlayer.EventHandler d = target.CallWithSelf;
			target.method = d.Method;
			return d;
		}
	}

	bool Check_UnityEngine_Video_VideoPlayer_EventHandler(IntPtr L, int pos)
	{
		return TypeChecker.CheckDelegateType(typeof(UnityEngine.Video.VideoPlayer.EventHandler), L, pos);
	}

	void Push_UnityEngine_Video_VideoPlayer_EventHandler(IntPtr L, UnityEngine.Video.VideoPlayer.EventHandler o)
	{
		ToLua.Push(L, o);
	}

	class UnityEngine_Video_VideoPlayer_ErrorEventHandler_Event : LuaDelegate
	{
		public UnityEngine_Video_VideoPlayer_ErrorEventHandler_Event(LuaFunction func) : base(func) { }
		public UnityEngine_Video_VideoPlayer_ErrorEventHandler_Event(LuaFunction func, LuaTable self) : base(func, self) { }

		public void Call(UnityEngine.Video.VideoPlayer param0, string param1)
		{
			func.BeginPCall();
			func.PushSealed(param0);
			func.Push(param1);
			func.PCall();
			func.EndPCall();
		}

		public void CallWithSelf(UnityEngine.Video.VideoPlayer param0, string param1)
		{
			func.BeginPCall();
			func.Push(self);
			func.PushSealed(param0);
			func.Push(param1);
			func.PCall();
			func.EndPCall();
		}
	}

	public UnityEngine.Video.VideoPlayer.ErrorEventHandler UnityEngine_Video_VideoPlayer_ErrorEventHandler(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			UnityEngine.Video.VideoPlayer.ErrorEventHandler fn = delegate(UnityEngine.Video.VideoPlayer param0, string param1) { };
			return fn;
		}

		if(!flag)
		{
			UnityEngine_Video_VideoPlayer_ErrorEventHandler_Event target = new UnityEngine_Video_VideoPlayer_ErrorEventHandler_Event(func);
			UnityEngine.Video.VideoPlayer.ErrorEventHandler d = target.Call;
			target.method = d.Method;
			return d;
		}
		else
		{
			UnityEngine_Video_VideoPlayer_ErrorEventHandler_Event target = new UnityEngine_Video_VideoPlayer_ErrorEventHandler_Event(func, self);
			UnityEngine.Video.VideoPlayer.ErrorEventHandler d = target.CallWithSelf;
			target.method = d.Method;
			return d;
		}
	}

	bool Check_UnityEngine_Video_VideoPlayer_ErrorEventHandler(IntPtr L, int pos)
	{
		return TypeChecker.CheckDelegateType(typeof(UnityEngine.Video.VideoPlayer.ErrorEventHandler), L, pos);
	}

	void Push_UnityEngine_Video_VideoPlayer_ErrorEventHandler(IntPtr L, UnityEngine.Video.VideoPlayer.ErrorEventHandler o)
	{
		ToLua.Push(L, o);
	}

	class UnityEngine_Video_VideoPlayer_TimeEventHandler_Event : LuaDelegate
	{
		public UnityEngine_Video_VideoPlayer_TimeEventHandler_Event(LuaFunction func) : base(func) { }
		public UnityEngine_Video_VideoPlayer_TimeEventHandler_Event(LuaFunction func, LuaTable self) : base(func, self) { }

		public void Call(UnityEngine.Video.VideoPlayer param0, double param1)
		{
			func.BeginPCall();
			func.PushSealed(param0);
			func.Push(param1);
			func.PCall();
			func.EndPCall();
		}

		public void CallWithSelf(UnityEngine.Video.VideoPlayer param0, double param1)
		{
			func.BeginPCall();
			func.Push(self);
			func.PushSealed(param0);
			func.Push(param1);
			func.PCall();
			func.EndPCall();
		}
	}

	public UnityEngine.Video.VideoPlayer.TimeEventHandler UnityEngine_Video_VideoPlayer_TimeEventHandler(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			UnityEngine.Video.VideoPlayer.TimeEventHandler fn = delegate(UnityEngine.Video.VideoPlayer param0, double param1) { };
			return fn;
		}

		if(!flag)
		{
			UnityEngine_Video_VideoPlayer_TimeEventHandler_Event target = new UnityEngine_Video_VideoPlayer_TimeEventHandler_Event(func);
			UnityEngine.Video.VideoPlayer.TimeEventHandler d = target.Call;
			target.method = d.Method;
			return d;
		}
		else
		{
			UnityEngine_Video_VideoPlayer_TimeEventHandler_Event target = new UnityEngine_Video_VideoPlayer_TimeEventHandler_Event(func, self);
			UnityEngine.Video.VideoPlayer.TimeEventHandler d = target.CallWithSelf;
			target.method = d.Method;
			return d;
		}
	}

	bool Check_UnityEngine_Video_VideoPlayer_TimeEventHandler(IntPtr L, int pos)
	{
		return TypeChecker.CheckDelegateType(typeof(UnityEngine.Video.VideoPlayer.TimeEventHandler), L, pos);
	}

	void Push_UnityEngine_Video_VideoPlayer_TimeEventHandler(IntPtr L, UnityEngine.Video.VideoPlayer.TimeEventHandler o)
	{
		ToLua.Push(L, o);
	}

	class UnityEngine_Video_VideoPlayer_FrameReadyEventHandler_Event : LuaDelegate
	{
		public UnityEngine_Video_VideoPlayer_FrameReadyEventHandler_Event(LuaFunction func) : base(func) { }
		public UnityEngine_Video_VideoPlayer_FrameReadyEventHandler_Event(LuaFunction func, LuaTable self) : base(func, self) { }

		public void Call(UnityEngine.Video.VideoPlayer param0, long param1)
		{
			func.BeginPCall();
			func.PushSealed(param0);
			func.Push(param1);
			func.PCall();
			func.EndPCall();
		}

		public void CallWithSelf(UnityEngine.Video.VideoPlayer param0, long param1)
		{
			func.BeginPCall();
			func.Push(self);
			func.PushSealed(param0);
			func.Push(param1);
			func.PCall();
			func.EndPCall();
		}
	}

	public UnityEngine.Video.VideoPlayer.FrameReadyEventHandler UnityEngine_Video_VideoPlayer_FrameReadyEventHandler(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			UnityEngine.Video.VideoPlayer.FrameReadyEventHandler fn = delegate(UnityEngine.Video.VideoPlayer param0, long param1) { };
			return fn;
		}

		if(!flag)
		{
			UnityEngine_Video_VideoPlayer_FrameReadyEventHandler_Event target = new UnityEngine_Video_VideoPlayer_FrameReadyEventHandler_Event(func);
			UnityEngine.Video.VideoPlayer.FrameReadyEventHandler d = target.Call;
			target.method = d.Method;
			return d;
		}
		else
		{
			UnityEngine_Video_VideoPlayer_FrameReadyEventHandler_Event target = new UnityEngine_Video_VideoPlayer_FrameReadyEventHandler_Event(func, self);
			UnityEngine.Video.VideoPlayer.FrameReadyEventHandler d = target.CallWithSelf;
			target.method = d.Method;
			return d;
		}
	}

	bool Check_UnityEngine_Video_VideoPlayer_FrameReadyEventHandler(IntPtr L, int pos)
	{
		return TypeChecker.CheckDelegateType(typeof(UnityEngine.Video.VideoPlayer.FrameReadyEventHandler), L, pos);
	}

	void Push_UnityEngine_Video_VideoPlayer_FrameReadyEventHandler(IntPtr L, UnityEngine.Video.VideoPlayer.FrameReadyEventHandler o)
	{
		ToLua.Push(L, o);
	}

	class Anita_AnimationEntry_EasingFunction_Event : LuaDelegate
	{
		public Anita_AnimationEntry_EasingFunction_Event(LuaFunction func) : base(func) { }
		public Anita_AnimationEntry_EasingFunction_Event(LuaFunction func, LuaTable self) : base(func, self) { }

		public float Call(float param0)
		{
			func.BeginPCall();
			func.Push(param0);
			func.PCall();
			float ret = (float)func.CheckNumber();
			func.EndPCall();
			return ret;
		}

		public float CallWithSelf(float param0)
		{
			func.BeginPCall();
			func.Push(self);
			func.Push(param0);
			func.PCall();
			float ret = (float)func.CheckNumber();
			func.EndPCall();
			return ret;
		}
	}

	public Anita.AnimationEntry.EasingFunction Anita_AnimationEntry_EasingFunction(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			Anita.AnimationEntry.EasingFunction fn = delegate(float param0) { return 0; };
			return fn;
		}

		if(!flag)
		{
			Anita_AnimationEntry_EasingFunction_Event target = new Anita_AnimationEntry_EasingFunction_Event(func);
			Anita.AnimationEntry.EasingFunction d = target.Call;
			target.method = d.Method;
			return d;
		}
		else
		{
			Anita_AnimationEntry_EasingFunction_Event target = new Anita_AnimationEntry_EasingFunction_Event(func, self);
			Anita.AnimationEntry.EasingFunction d = target.CallWithSelf;
			target.method = d.Method;
			return d;
		}
	}

	bool Check_Anita_AnimationEntry_EasingFunction(IntPtr L, int pos)
	{
		return TypeChecker.CheckDelegateType(typeof(Anita.AnimationEntry.EasingFunction), L, pos);
	}

	void Push_Anita_AnimationEntry_EasingFunction(IntPtr L, Anita.AnimationEntry.EasingFunction o)
	{
		ToLua.Push(L, o);
	}

}
