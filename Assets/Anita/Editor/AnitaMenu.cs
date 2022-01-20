/*
 * 自定义的部分操作
 */

using System.IO;
using UnityEditor;
using UnityEngine;

namespace Anita.Editor
{
    public static class AnitaMenu
    {
        [MenuItem("Anita/Clear Save Data", false, 1)]
        public static void ClearSaveData()
        {
            var saveDir = new DirectoryInfo(Application.persistentDataPath + "/Save/");
            foreach (var file in saveDir.GetFiles())
            {
                file.Delete();
            }
        }

        [MenuItem("Anita/Clear Config Data", false, 1)]
        public static void ClearConfigData()
        {
            PlayerPrefs.DeleteAll();
        }

        [MenuItem("Anita/Reset Input Mapping", false, 1)]
        public static void ResetInputMapping()
        {
            if (Directory.Exists(InputMapper.InputFilesDirectory))
            {
                Directory.Delete(InputMapper.InputFilesDirectory, true);
            }
        }
    }
}