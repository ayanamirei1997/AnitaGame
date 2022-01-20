/*
 * 裁剪Sprite
 */
using UnityEngine;

namespace Anita
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class SpriteCropper : MonoBehaviour
    {
        // 边界Rect
        public RectInt boundRect;
        // 裁剪Rect
        public RectInt cropRect;
        public int autoCropPadding = 2;
        [Range(0, 1)] public float autoCropAlpha = 0.01f;
        
        // 裁剪效果图
        public Sprite sprite => GetComponent<SpriteRenderer>().sprite;
    }
}