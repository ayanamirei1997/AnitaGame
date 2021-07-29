using UnityEngine;

namespace AnitaAVG
{
    /// <summary>
    /// Create and init AnitaAVGGameController prefab
    /// </summary>
    public class AnitaAVGCreator : MonoBehaviour
    {
        public GameObject anitaAVGGameControllerPrefab;

        private void Awake()
        {
            var controllerCount = GameObject.FindGameObjectsWithTag("AnitaAVGGameController").Length;
            if (controllerCount > 1)
            {
                Debug.LogWarning("Nova: Multiple AnitaAVGGameController found in the scene.");
            }

            if (controllerCount >= 1)
            {
                return;
            }

            var controller = Instantiate(anitaAVGGameControllerPrefab);
            controller.tag = "AnitaAVGGameController";
            DontDestroyOnLoad(controller);
        }
    }
}