// 处理鼠标的manager
// 主要处理：1、屏幕点击与移动端点击后隐藏鼠标  2、点击后一段时间自动隐藏鼠标

using System;
using UnityEngine;

namespace Anita
{
    public class CursorManager : MonoBehaviour
    {
        public Texture2D cursorTexture;
        public Vector2 hotspot = Vector2.zero;
        public bool autoHideAfterDuration;
        public float hideAfterSeconds = 10.0f;

        private Vector3 lastCursorPosition;
        private float idleTime;

        
        private void OnEnable()
        {
            if (cursorTexture != null)
            {
                Cursor.SetCursor(cursorTexture, hotspot, CursorMode.Auto);
            }

            lastCursorPosition = RealInput.mousePosition;
        }
        
        private void OnDisable()
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }

        private void Update()
        {
            if (!autoHideAfterDuration) return;

            Vector3 currentCursorPosition = RealInput.mousePosition;
            // 鼠标有移动 重置idleTime
            if (currentCursorPosition != lastCursorPosition)
            {
                Cursor.visible = true;
                lastCursorPosition = currentCursorPosition;
                idleTime = 0.0f;
                return;
            }

            if (Cursor.visible)
            {
                idleTime += Time.deltaTime;
                if (idleTime > hideAfterSeconds)
                {
                    Cursor.visible = false;
                    idleTime = 0.0f;
                }
            }
        }
    }
}