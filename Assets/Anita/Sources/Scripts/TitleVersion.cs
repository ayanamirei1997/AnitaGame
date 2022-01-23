using UnityEngine;
using UnityEngine.UI;

namespace Anita
{
    [RequireComponent(typeof(Text))]
    public class TitleVersion : MonoBehaviour
    {
        private void Start()
        {
            GetComponent<Text>().text = $"v{Application.version}";
        }
    }
}