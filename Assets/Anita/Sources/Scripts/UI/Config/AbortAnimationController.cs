using UnityEngine;

namespace Anita
{
    /// <summary>
    /// Toggle ability to abort animation based on the value in ConfigManager
    /// </summary>
    [RequireComponent(typeof(DialogueBoxController))]
    public class AbortAnimationController : MonoBehaviour
    {
        public string configKeyName;

        private ConfigManager configManager;
        private DialogueBoxController controller;

        private void Awake()
        {
            configManager = Utils.FindAnitaGameController().ConfigManager;
            controller = GetComponent<DialogueBoxController>();
        }

        private void OnEnable()
        {
            configManager.AddValueChangeListener(configKeyName, UpdateValue);
            UpdateValue();
        }

        private void OnDisable()
        {
            configManager.RemoveValueChangeListener(configKeyName, UpdateValue);
        }

        private void UpdateValue()
        {
            controller.canAbortAnimation = configManager.GetInt(configKeyName) > 0;
        }
    }
}