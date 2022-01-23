using UnityEngine;

namespace Anita
{
    /// <summary>
    /// Create and init AnitaGameController prefab
    /// </summary>
    public class AnitaCreator : MonoBehaviour
    {
        public GameObject novaGameControllerPrefab;

        private void Awake()
        {
            var controllerCount = GameObject.FindGameObjectsWithTag("AnitaGameController").Length;
            if (controllerCount > 1)
            {
                Debug.LogWarning("Anita: Multiple AnitaGameController found in the scene.");
            }

            if (controllerCount >= 1)
            {
                return;
            }

            var controller = Instantiate(novaGameControllerPrefab);
            controller.tag = "AnitaGameController";
            DontDestroyOnLoad(controller);
        }
    }
}