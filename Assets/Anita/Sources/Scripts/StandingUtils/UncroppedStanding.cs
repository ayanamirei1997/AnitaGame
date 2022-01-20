using System.IO;
using UnityEngine;

namespace Anita
{
    public class UncroppedStanding : MonoBehaviour
    {
        // e.g： "Assets/path/to/image"
        public string outputDirectory;

        public string absoluteOutputDirectory => Path.Combine(Path.GetDirectoryName(Application.dataPath), outputDirectory);
    }
}