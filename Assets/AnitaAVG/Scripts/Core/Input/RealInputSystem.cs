using UnityEngine;
using UnityEngine.EventSystems;

namespace Anita
{
    public class RealInputSystem : BaseInput
    {
        public BaseInput originalInput;

        public override Vector2 mousePosition
        {
            get
            {
                // todo: 手机下防止点击后鼠标保持高亮
                if (Application.isMobilePlatform && touchCount == 0)
                {
                    return Vector3.zero;
                }

                return originalInput.mousePosition - RealScreen.offset;
            }
        }
        
        public override int touchCount => originalInput.touchCount > 0 ? 1 : 0;

        // 可以获取一个Touch对象，touchIndex是你手指触摸的顺序
        public override Touch GetTouch(int index)
        {
            var touch = base.GetTouch(index);
            touch.position -= RealScreen.offset;
            return touch;
        }
    }
    
    public static class RealInput
    {
        public static Vector3 mousePosition => Input.mousePosition - (Vector3)RealScreen.offset;
    }
}