using UnityEditor.Build;
using UnityEditor.Build.Reporting;

namespace Anita.Editor
{
    public class AnitaBuildHooks : IPreprocessBuildWithReport
    {
        public int callbackOrder => 0;

        public void OnPreprocessBuild(BuildReport report)
        {
            ToLuaMenu.ClearLuaWraps();
            ToLuaMenu.CopyLuaFilesToRes();
        }
    }
}