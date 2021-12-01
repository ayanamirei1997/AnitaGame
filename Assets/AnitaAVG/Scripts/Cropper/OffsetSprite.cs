/*
 * 带有offset的sprite
 * 继承自SpcriptableObject，以便将数据存储在.asset文件中
 */

using System;
using UnityEngine;

namespace Anita
{
    [Serializable]
    [CreateAssetMenu(menuName = "Anita/Sprite偏移")]
    public class OffsetSprite : ScriptableObject
    {
        public Sprite sprite;
        public Vector3 offset;
    }
}