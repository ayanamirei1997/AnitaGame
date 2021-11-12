// 根据屏幕纵横比处理

using UnityEngine;

namespace Anita
{
    public class RealScreen
    {
        // 纵横比
        // todo： 某些时候可以根据纵横比的值来决定pc/手机/平板显示
        public static float aspectRatio = (float) Screen.width / Screen.height;
        public static int height = Screen.height;
        public static int width = Screen.width;
        public static Vector2 uiSize = new Vector2(Screen.height, Screen.width);
        public static float fHeight = Screen.height;
        public static float fWidth = Screen.width;
    
        // 距离中心的偏移
        public static Vector2 offset =>
            new Vector2((fWidth - width) / 2, (fHeight - height) / 2);

    }
}