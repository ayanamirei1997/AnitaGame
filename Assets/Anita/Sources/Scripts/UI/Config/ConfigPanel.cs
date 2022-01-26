using UnityEngine;

namespace Anita
{
    public class ConfigPanel : MonoBehaviour
    {
        public ConfigTextPreviewController textPreview;
        public AnitaAnimation textPreviewAnimation;

        private void Awake()
        {
            textPreview.textPreviewAnimation = textPreviewAnimation;
        }
    }
}