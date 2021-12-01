// 字体的描边处理
// 这里用来处理CloseButton的X

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Anita
{
    public class AnitaTextOutline : Shadow
    {
        private readonly List<UIVertex> uiVerticesList = new List<UIVertex>();

        private static readonly Vector2[] Directions =
        {
            new Vector2(0, 1),
            new Vector2(0, -1),
            new Vector2(1, 0),
            new Vector2(-1, 0),
            new Vector2(1, 1),
            new Vector2(1, -1),
            new Vector2(-1, 1),
            new Vector2(-1, -1)
        };

        public override void ModifyMesh(VertexHelper vh)
        {
            // sqrMagnitude节省cpu的粗略距离
            // 浮点数可以与零相差的最小值
            // 无需处理最小颗粒以内的部分
            if (!IsActive() || effectDistance.sqrMagnitude < float.Epsilon)
                return;
            vh.GetUIVertexStream(uiVerticesList);
            var num = uiVerticesList.Count * 9;
            if (uiVerticesList.Capacity < num)
                uiVerticesList.Capacity = num;
            var count = 0;
            foreach (var dir in Directions)
            {
                var start = count;
                count = uiVerticesList.Count;
                var _effectDistance = effectDistance;
                var dx = _effectDistance.x * dir.x;
                var dy = _effectDistance.y * dir.y;
                ApplyShadowZeroAlloc(uiVerticesList, effectColor, start, count, dx, dy);
                Debug.Log(" start "+ start + " count " + count + "  " + dx + "  " + dy);
            }

            vh.Clear();
            vh.AddUIVertexTriangleStream(uiVerticesList);
        }
    }
}