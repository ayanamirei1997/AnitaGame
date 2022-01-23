using UnityEngine;

namespace Anita
{
    public class HideOnMobile : MonoBehaviour
    {
        private void Awake()
        {
            gameObject.SetActive(!Application.isMobilePlatform);
        }
    }
}