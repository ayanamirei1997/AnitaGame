using UnityEngine;

namespace Anita
{
    public class ToggleFullScreen : MonoBehaviour
    {
        private InputMapper inputMapper;

        private void Awake()
        {
            inputMapper = Utils.FindAnitaGameController().InputMapper;
        }

        private void Update()
        {
            if (inputMapper.GetKeyUp(AbstractKey.ToggleFullScreen))
            {
                GameRenderManager.SwitchFullScreen();
            }
        }
    }
}