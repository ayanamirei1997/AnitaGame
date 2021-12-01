/*
 * 挂在png导出的prefab上  
 * 手动配置导出的路径
 */ 

using System.IO;
using UnityEngine;

namespace Anita
{
    public class UncroppedStanding : MonoBehaviour
    {
        //Assets/AVGExample/MyDemo/Resources/MyDemo/Standings/Ergong
        public string outputDirectory;
        public string absoluteOutputDirectory => Path.Combine(Path.GetDirectoryName(Application.dataPath), outputDirectory);
    }
}