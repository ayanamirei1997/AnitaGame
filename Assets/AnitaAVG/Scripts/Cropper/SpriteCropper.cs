/*
 * sprite裁剪
 */

using UnityEngine;

namespace Anita
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class SpriteCropper : MonoBehaviour
    {
        // 边界信息
        public RectInt boundRect;  
        // 裁剪后的图片信息
        public RectInt cropRect;
        // 自动裁剪的裁剪线宽
        public int autoCropPadding = 2;
        [Range(0, 1)] public float autoCropAlpha = 0.01f;
        
        public Sprite sprite => GetComponent<SpriteRenderer>().sprite;
    }
}