using Unity;
using UnityEngine;

namespace Anita
{
    
    /// <summary>
    /// 创建一个运行的prefab
    /// </summary>
    public class AnitaAVGCreator : MonoBehaviour
    {
        public GameObject anitaAVGGameControllerPrefab;

        // 运行时直接创建
        private void Awake()
        {
            var controllerCount = GameObject.FindGameObjectsWithTag("AnitaAVGGameController").Length;
            if (controllerCount >= 1)
            {
                Debug.LogWarning("Anita: GameController 已经初始化");
                return;
            }

            var controller = Instantiate(anitaAVGGameControllerPrefab);
            controller.tag = "AnitaAVGGameController";
            DontDestroyOnLoad(controller);
            //Debug.Log("tag 为 AnitaAVGGameController 的 prefab 为"+controllerCount);
        }
    }
}