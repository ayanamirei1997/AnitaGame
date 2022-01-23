using UnityEngine;

namespace Anita
{
    [ExportCustomType]
    public class InputHelper : MonoBehaviour
    {
        private GameController gameController;

        private void Awake()
        {
            gameController = Utils.FindAnitaGameController();
            LuaRuntime.Instance.BindObject("inputHelper", this);
        }

        public void DisableInput()
        {
            gameController.DisableInput();
        }

        public void EnableInput()
        {
            gameController.EnableInput();
        }
    }
}