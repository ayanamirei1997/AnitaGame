using UnityEngine;

namespace Anita
{
    public class HideOnNonMobile : MonoBehaviour
    {
        private void Awake()
        {
            gameObject.SetActive(Application.isMobilePlatform);
        }
    }
}