using UnityEngine.UI;

namespace Anita
{
    public class HelpViewController : ViewControllerBase
    {
        public Button returnButton;
        public Button returnButton2;

        private const string GameFirstShownKey = ConfigViewController.FirstShownKeyPrefix + "Game";

        private ConfigManager configManager;

        protected override void Awake()
        {
            base.Awake();

            returnButton.onClick.AddListener(Hide);
            returnButton2.onClick.AddListener(Hide);

            configManager = Utils.FindAnitaGameController().ConfigManager;
        }

        protected override void Start()
        {
            base.Start();

            if (configManager.GetInt(GameFirstShownKey) == 0)
            {
                configManager.SetInt(GameFirstShownKey, 1);
                Show();
            }
        }
    }
}