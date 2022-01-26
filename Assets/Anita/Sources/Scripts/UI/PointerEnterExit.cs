using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Anita
{
    public class PointerEnterExit : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public UnityEvent onPointerEnter;
        public UnityEvent onPointerExit;

        public void OnPointerEnter(PointerEventData pointerEventData)
        {
            onPointerEnter.Invoke();
        }

        public void OnPointerExit(PointerEventData pointerEventData)
        {
            onPointerExit.Invoke();
        }
    }
}