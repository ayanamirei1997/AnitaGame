﻿/*
 * 存储 rectTransform 的 anchor 与 offset
 */

using System;
using UnityEngine;

namespace Anita
{
    [Serializable]
    public class RectTransformRestoreData : IRestoreData
    {
        public readonly Vector4Data anchor;
        public readonly Vector4Data offset;

        public RectTransformRestoreData(RectTransform rect)
        {
            anchor = new Vector4Data(rect.anchorMin, rect.anchorMax);
            offset = new Vector4Data(rect.offsetMin, rect.offsetMax);
        }

        public void Restore(RectTransform rect)
        {
            anchor.Split(out var min, out var max);
            rect.anchorMin = min;
            rect.anchorMax = max;
            offset.Split(out min, out max);
            rect.offsetMin = min;
            rect.offsetMax = max;
        }
    }
}