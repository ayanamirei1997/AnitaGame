/*
 * 裁剪时图片的相关信息，存储在SpriteWithOffset中
 */

using System;
using UnityEngine;

namespace Anita
{
    [Serializable]
    [CreateAssetMenu(menuName = "Anita/Sprite With Offset")]
    public class SpriteWithOffset : ScriptableObject
    {
        // 裁剪的图片
        public Sprite sprite;
        // 裁剪偏移
        public Vector3 offset;
    }
}