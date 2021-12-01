using UnityEngine;

namespace Anita
{
    /// <summary>
    /// Popup dialog on window close
    /// </summary>
    public class CloseWindowHandler : MonoBehaviour
    {
        private static bool WantsToQuit()
        {
            if (Utils.ForceQuit)
            {
                return true;
            }

            Utils.QuitWithConfirm();
            return Utils.ForceQuit;
        }

        private void Start()
        {
            Application.wantsToQuit += WantsToQuit;
        }
    }
}