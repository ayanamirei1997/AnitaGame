using System.IO;
using UnityEditor;
using UnityEngine;

namespace Anita.Editor
{
    public static class AnitaMenu
    {
        [MenuItem("AnitaTools/清除存档测试", false, 1)]
        public static void ClearSaveData()
        {
            Debug.Log("clear data test!");
        }

        [MenuItem("AnitaTools/Debug调试", false, 1)]
        public static void DebugTest()
        {
            Debug.Log("debug test!");
        }



    }






}
