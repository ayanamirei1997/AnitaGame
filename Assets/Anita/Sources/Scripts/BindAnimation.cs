using UnityEngine;

namespace Anita
{
    [RequireComponent(typeof(AnitaAnimation))]
    public class BindAnimation : MonoBehaviour
    {
        public string luaGlobalName;

        private void Awake()
        {
            var luaHiddenName = "_" + luaGlobalName;
            LuaRuntime.Instance.BindObject(luaHiddenName, GetComponent<AnitaAnimation>());
            LuaRuntime.Instance.DoString($"{luaGlobalName} = WrapAnim:new {{ anim = __Anita['{luaHiddenName}'] }}");
        }
    }
}