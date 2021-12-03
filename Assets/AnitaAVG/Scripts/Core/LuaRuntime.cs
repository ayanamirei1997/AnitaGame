/*
 * Lua运行的Runtime
 */
using LuaInterface;
using UnityEngine;

namespace Anita
{
    
    // 单例 
    public class LuaRuntime : MonoBehaviour
    {
        private LuaState lua;
        private LuaFunction luaLoadString;
        private bool inited;

        // 应该在最开始启动
        private void Init()
        {
            if (inited)
            {
                return;
            }

            new LuaResLoader();
            DelegateFactory.Init();
            lua = new LuaState();
            lua.Start();
            LuaBinder.Bind(lua);
            lua.AddSearchPath(Application.dataPath + "/Anita/Lua");

            InitRequires();

            // 获取luaload函数
            luaLoadString = lua.GetFunction("loadstring");
            if (luaLoadString == null)
            {
                // Lua 5.2后弃用loadstring
                luaLoadString = lua.GetFunction("load");
            }

            inited = true;
        }

        public void InitRequires()
        {
            lua.DoString("require 'requires'");
        }

        private void CheckInit()
        {
            this.RuntimeAssert(inited, "LuaRuntime methods should be called after Init().");
        }
        
        // 使对象在 lua 中可见
        // 该对象将被分配为全局变量 __Anita 
        // 可以通过 __Anita[name] 从 lua 脚本访问
        public void BindObject(string name, object obj, string tableName = "__Anita")
        {
            CheckInit();
            var table = lua.GetTable(tableName);
            table[name] = obj;
            table.Dispose();
        }
        
        public LuaFunction WrapClosure(string code)
        {
            CheckInit();
            return luaLoadString.Invoke<string, LuaFunction>(code);
        }

        public void DoFile(string name)
        {
            CheckInit();
            lua.DoFile(name);
        }

        public void DoString(string chunk)
        {
            CheckInit();
            lua.DoString(chunk);
        }

        public T DoString<T>(string chunk)
        {
            CheckInit();
            return lua.DoString<T>(chunk);
        }

        private void Dispose()
        {
            CheckInit();
            luaLoadString.Dispose();
            lua.Dispose();
        }

        #region Singleton pattern

        static LuaRuntime() { }

        private LuaRuntime() { }

        // Codes from http://wiki.unity3d.com/index.php/Singleton
        private static LuaRuntime _instance;

        private static readonly object Lock = new object();

        public static LuaRuntime Instance
        {
            get
            {
                if (ApplicationIsQuitting)
                {
                    Debug.LogWarningFormat("Anita: [Singleton] Instance {0} " +
                                           "already destroyed on application quit. " +
                                           "Won't create again, return null.",
                        typeof(LuaRuntime));
                    return null;
                }

                lock (Lock)
                {
                    if (_instance == null)
                    {
                        _instance = (LuaRuntime)FindObjectOfType(typeof(LuaRuntime));

                        if (FindObjectsOfType(typeof(LuaRuntime)).Length > 1)
                        {
                            Debug.LogError("Anita: [Singleton] Something went really wrong --- " +
                                           "there should never be more than 1 singleton! " +
                                           "Reopening the scene might fix it.");
                            return _instance;
                        }

                        if (_instance == null)
                        {
                            var singleton = new GameObject();
                            _instance = singleton.AddComponent<LuaRuntime>();
                            _instance.Init();
                            singleton.name = "(singleton) " + typeof(LuaRuntime);

                            DontDestroyOnLoad(singleton);

                            // Debug.LogFormat("Antia: [Singleton] An instance of {0} " +
                            //                 "is needed in the scene, so {1} " +
                            //                 "was created with DontDestroyOnLoad.",
                            //     typeof(LuaRuntime), singleton);
                        }
                        else
                        {
                            // Debug.LogFormat("Antia: [Singleton] Using instance already created: {0}",
                            //     _instance.gameObject.name);
                        }
                    }

                    return _instance;
                }
            }
        }

        private static bool ApplicationIsQuitting = false;

        // 当 Unity 退出时，它会以随机顺序销毁对象。
        // 原则上，单例只有在应用程序退出时才会被销毁。
        // 如果任何脚本在销毁后调用 Instance，
        // 它将创建一个有问题的ghost object，即使在停止播放应用程序之后, 该对象将保留在编辑器场景中
        // 特别糟糕！
        // 所以，这是为了确保我们不会创建那个有问题的ghost object。
        private void OnDestroy()
        {
            ApplicationIsQuitting = true;
            Dispose();
        }

        #endregion
    }
}