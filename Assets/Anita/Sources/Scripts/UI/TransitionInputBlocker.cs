using UnityEngine;
using UnityEngine.EventSystems;

namespace Anita
{
    public class TransitionInputBlocker : NonDrawingGraphic, IPointerClickHandler
    {
        public void OnPointerClick(PointerEventData eventData)
        {
            AnitaAnimation.StopAll(AnimationType.UI);
        }

        private void Update()
        {
            if (Input.anyKey)
            {
                AnitaAnimation.StopAll(AnimationType.UI);
            }
        }
    }
}